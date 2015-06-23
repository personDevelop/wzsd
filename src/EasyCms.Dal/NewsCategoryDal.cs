using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Dal
{
    public class NewsCategoryDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }
            int state = (int)Dal.From<NewsCategory>().Select(NewsCategory._.State).ToScalar();
            if (state == (int)CategoryState.审核通过)
            {
                return "当前新闻分类已审核通过,不能删除";
            }
            //判断是否已被新闻引用过
            bool Eixt = Dal.Exists<NewsInfo>(NewsInfo._.ClassID == id);
            if (Eixt)
            {
                return "当前新闻分类已被使用,不能删除";
            }
            Eixt = Dal.Exists<NewsCategory>(NewsCategory._.ParentID == id);
            if (Eixt)
            {
                return "当前新闻分类下含有子分类 ,不能删除";
            }
            int i = Dal.Delete<NewsCategory>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除分类";
            }
        }

        public int Save(NewsCategory item)
        {
            //分级码 级数     顺序
            /*如果是新增的   
             有上级  则更新上级为 是否明细  =false , 分级码重新计算分级码 
             */
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {

                CustomSqlSection csql = null;

                string sql = string.Empty;
                NewsCategory parent = null;
                if (string.IsNullOrEmpty(item.ParentID))
                {
                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        item.FJM = item.ID;
                        item.JS = 1;
                        item.OrderNo = Dal.Count<NewsCategory>(NewsCategory._.ParentID.IsNullOrEmpty(), NewsCategory._.ID, false);
                    }
                    else
                    {
                        if (item.ID != item.FJM)
                        {
                            //说明是从非根级调整到根级节点 
                            int oldJS = item.JS;
                            item.JS = 1;
                            int seriesChaZhi = oldJS - item.JS;//级数调整前后的差值

                            item.OrderNo = Dal.Count<NewsCategory>(NewsCategory._.ParentID.IsNullOrEmpty(), NewsCategory._.ID, false);

                            string oldParentFJM = item.FJM.Substring(0, item.FJM.IndexOf(item.ID) + 1);

                            sql = "update NewsCategory set FJM=Replace(FJM,@classcode,''),JS=JS-@JS where FJM like '@oldFJM%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentFJM)
                                 .AddInputParameter("JS", seriesChaZhi)
                                 .AddInputParameter("oldFJM", item.FJM)
                                  ;
                        }
                    }
                }
                else
                {

                    parent = Dal.Find<NewsCategory>(item.ParentID);

                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {

                        item.FJM = parent.FJM + ";" + item.ID;
                        item.JS = item.FJM.Count(p => p == ';') + 1;
                        item.OrderNo = Dal.Count<NewsCategory>(NewsCategory._.ParentID == item.ParentID, NewsCategory._.ID, false);
                    }
                    else
                    {
                        if (!item.FJM.EndsWith(item.ParentID + ";" + item.ID))
                        {
                            //调整父编码了
                            item.OrderNo = Dal.Count<NewsCategory>(NewsCategory._.ParentID == item.ParentID, NewsCategory._.ID, false);
                            string oldFJM = item.FJM;
                            int oldJS = item.JS;
                            item.FJM = parent.FJM + ";" + item.ID;
                            item.JS = item.FJM.Count(p => p == ';') + 1;
                            int seriesChaZhi = item.JS - oldJS;//级数调整前后的差值
                            string oldParentFJM = item.FJM.Substring(0, item.FJM.IndexOf(item.ID) + 1);
                            //更新子级的 级数 和分级编号 

                            sql = "update NewsCategory set FJM=Replace(FJM,@classcode,'@newParentClassCOde'),JS=JS+@JS where FJM like '@oldFJM%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentFJM)
                                .AddInputParameter("newParentClassCOde", parent.FJM)
                                .AddInputParameter("JS", seriesChaZhi)
                                .AddInputParameter("oldFJM", oldFJM)
                                 ;
                        }
                    }
                }
                if (dal == null)
                {
                    tr = Dal.BeginTransaction(out dal);
                }
                dal.SubmitNew(ref dal, item);
                if (csql != null)
                {
                    csql.ExecuteNonQuery();
                }
                dal.CommitTransaction(tr);
                return 1;

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<NewsCategory>().Select(NewsCategory._.ID, NewsCategory._.ParentID, NewsCategory._.Code, NewsCategory._.Name, NewsCategory._.AllowSubclass).OrderBy(NewsCategory._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<NewsCategory>().OrderBy(NewsCategory._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = NewsCategory._.Code == val;
            }
            else
            {
                where = NewsCategory._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && NewsCategory._.ID != ID;

            }
            return !Dal.Exists<NewsCategory>(where);
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ParentID == parentId).OrderBy(NewsCategory._.OrderNo).ToDataTable();

        }
        public NewsCategory GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<NewsCategory>("a").Join<NewsCategory>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<NewsCategory>();
        }


        public System.Data.DataTable GetListByFJM(string classCode)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ID != classCode && NewsCategory._.FJM.StartsWith(classCode)).OrderBy(NewsCategory._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ParentID == parentId).OrderBy(NewsCategory._.OrderNo).Select(NewsCategory._.Name).ToSinglePropertyArray();
        }


    }

    public enum CategoryState
    {
        草稿,
        等待审核,
        审核通过
    }
}

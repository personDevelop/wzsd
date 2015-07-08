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
    public class ShopCategoryDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            return "";
            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    return "要删除的参数值不能为空";
            //}
            //int state = (int)Dal.From<ShopCategory>().Select(ShopCategory._.State).ToScalar();
            //if (state == (int)CategoryState.审核通过)
            //{
            //    return "当前新闻分类已审核通过,不能删除";
            //}
            ////判断是否已被新闻引用过
            //bool Eixt = Dal.Exists<NewsInfo>(NewsInfo._.ClassID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类已被使用,不能删除";
            //}
            //Eixt = Dal.Exists<ShopCategory>(ShopCategory._.ParentID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类下含有子分类 ,不能删除";
            //}
            //int i = Dal.Delete<ShopCategory>(id);
            //if (i == 0)
            //{
            //    return "删除失败";
            //}
            //else
            //{
            //    return "成功删除分类";
            //}
        }

        public int Save(ShopCategory item)
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
                ShopCategory parent = null;
                if (string.IsNullOrEmpty(item.ParentID))
                {
                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        item.ClassCode = item.ID;
                        item.Depth = 1;
                        item.OrderNo = Dal.Count<ShopCategory>(ShopCategory._.ParentID.IsNullOrEmpty(), ShopCategory._.ID, false);
                    }
                    else
                    {
                        if (item.ID != item.ClassCode)
                        {
                            //说明是从非根级调整到根级节点 
                            int oldDepth = item.Depth;
                            item.Depth = 1;
                            int seriesChaZhi = oldDepth - item.Depth;//级数调整前后的差值

                            item.OrderNo = Dal.Count<ShopCategory>(ShopCategory._.ParentID.IsNullOrEmpty(), ShopCategory._.ID, false);

                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);

                            sql = "update ShopCategory set ClassCode=Replace(ClassCode,@classcode,''),Depth=Depth-@Depth where ClassCode like '@oldClassCode%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentClassCode)
                                 .AddInputParameter("Depth", seriesChaZhi)
                                 .AddInputParameter("oldClassCode", item.ClassCode)
                                  ;
                        }
                    }
                }
                else
                {

                    parent = Dal.Find<ShopCategory>(item.ParentID);

                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {

                        item.ClassCode = parent.ClassCode + ";" + item.ID;
                        item.Depth = item.ClassCode.Count(p => p == ';') + 1;
                        item.OrderNo = Dal.Count<ShopCategory>(ShopCategory._.ParentID == item.ParentID, ShopCategory._.ID, false);
                    }
                    else
                    {
                        if (!item.ClassCode.EndsWith(item.ParentID + ";" + item.ID))
                        {
                            //调整父编码了
                            item.OrderNo = Dal.Count<ShopCategory>(ShopCategory._.ParentID == item.ParentID, ShopCategory._.ID, false);
                            string oldClassCode = item.ClassCode;
                            int oldDepth = item.Depth;
                            item.ClassCode = parent.ClassCode + ";" + item.ID;
                            item.Depth = item.ClassCode.Count(p => p == ';') + 1;
                            int seriesChaZhi = item.Depth - oldDepth;//级数调整前后的差值
                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);
                            //更新子级的 级数 和分级编号 

                            sql = "update ShopCategory set ClassCode=Replace(ClassCode,@classcode,'@newParentClassCOde'),Depth=Depth+@Depth where ClassCode like '@oldClassCode%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentClassCode)
                                .AddInputParameter("newParentClassCOde", parent.ClassCode)
                                .AddInputParameter("Depth", seriesChaZhi)
                                .AddInputParameter("oldClassCode", oldClassCode)
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
                return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.ParentID, ShopCategory._.Code, ShopCategory._.Name).OrderBy(ShopCategory._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ShopCategory>().OrderBy(ShopCategory._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopCategory._.Code == val;
            }
            else
            {
                where = ShopCategory._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopCategory._.ID != ID;

            }
            return !Dal.Exists<ShopCategory>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.Name).OrderBy(ShopCategory._.OrderNo).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopCategory>().OrderBy(ShopCategory._.OrderNo)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ParentID == parentId).OrderBy(ShopCategory._.OrderNo).ToDataTable();

        }
        public ShopCategory GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<ShopCategory>("a").Join<ShopCategory>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<ShopCategory>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ID != classCode && ShopCategory._.ClassCode.StartsWith(classCode)).OrderBy(ShopCategory._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ParentID == parentId).OrderBy(ShopCategory._.OrderNo).Select(ShopCategory._.Name).ToSinglePropertyArray();
        }



        public DataTable GetAppEntity(string id)
        {
            WhereClip where = new WhereClip();
            if (string.IsNullOrWhiteSpace(id))
            {
                where = ShopCategory._.ParentID.IsNullOrEmpty();
            }
            else
            {
                where = ShopCategory._.ParentID == id;
            }
            DataTable dt = Dal.From<ShopCategory>().Where(where).Select(ShopCategory._.ID, ShopCategory._.Code, ShopCategory._.Name, ShopCategory._.ClassCode, ShopCategory._.SmallLogo)
                .ToDataTable();
            return dt;
        }
    }


}

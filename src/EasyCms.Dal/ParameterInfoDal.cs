using EasyCms.Model;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Dal
{
    public class ParameterInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }
            ParameterInfo p = GetEntity(id);
            if (p.IsSystem)
            {
                return "系统参数不能删除";
            }
            else if (!p.IsDelete)
            {
                return "当前参数不允许删除";
            }
            int i = Dal.Delete<ParameterInfo>(ParameterInfo._.ClassCode.StartsWith(p.ClassCode));
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除" + i + "个参数";
            }
        }

        public int Save(ParameterInfo item)
        {
            //分级码 级数  是否明细   顺序
            /*如果是新增的   
             有上级  则更新上级为 是否明细  =false , 分级码重新计算分级码 
             */
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {

                CustomSqlSection csql = null;
                List<ParameterInfo> list = new List<ParameterInfo>();
                list.Add(item);
                string sql = string.Empty;
                ParameterInfo parent = null;
                if (string.IsNullOrEmpty(item.ParentID))
                {
                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        item.ClassCode = item.ID;
                        item.Series = 1;
                        item.OrderNo = Dal.Count<ParameterInfo>(ParameterInfo._.ParentID.IsNullOrEmpty(), ParameterInfo._.ID, false);
                    }
                    else
                    {
                        if (item.ID != item.ClassCode)
                        {
                            int oldSeries = item.Series;

                            item.Series = 1;
                            int seriesChaZhi = oldSeries - item.Series;//级数调整前后的差值

                            item.OrderNo = Dal.Count<ParameterInfo>(ParameterInfo._.ParentID.IsNullOrEmpty(), ParameterInfo._.ID, false);

                            int count = Dal.Count<ParameterInfo>(ParameterInfo._.ClassCode.StartsWith(item.ClassCode.Replace(item.ID, "")), ParameterInfo._.ID, false);
                            if (count == 0)
                            {
                                parent = new ParameterInfo();
                                parent.Where = ParameterInfo._.ClassCode == item.ClassCode.Replace(item.ID + ";", "");
                                parent.RecordStatus = Sharp.Common.StatusType.update;
                                parent.IsDetails = true;
                                list.Add(parent);

                            }
                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);
                            //说明是从非根级调整到根级节点 
                            sql = "update ParameterInfo set ClassCode=Replace(ClassCode,@classcode,''),Series=Series-@Series where ClassCode like '@oldClassCode%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentClassCode)
                                 .AddInputParameter("Series", seriesChaZhi)
                                 .AddInputParameter("oldClassCode", item.ClassCode)
                                  ;
                        }
                    }
                }
                else
                {

                    parent = Dal.Find<ParameterInfo>(item.ParentID);
                    parent.IsDetails = false;
                    list.Add(parent);
                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {

                        item.ClassCode = parent.ClassCode + ";" + item.ID;
                        item.Series = item.ClassCode.Count(p => p == ';') + 1;
                        item.OrderNo = Dal.Count<ParameterInfo>(ParameterInfo._.ParentID == item.ParentID, ParameterInfo._.ID, false);
                    }
                    else
                    {
                        if (!item.ClassCode.EndsWith(item.ParentID + ";" + item.ID))
                        {
                            //调整父编码了
                            item.OrderNo = Dal.Count<ParameterInfo>(ParameterInfo._.ParentID == item.ParentID, ParameterInfo._.ID, false);
                            string oldClassCode = item.ClassCode;
                            int oldSeries = item.Series;
                            item.ClassCode = parent.ClassCode + ";" + item.ID;
                            item.Series = item.ClassCode.Count(p => p == ';') + 1;
                            int seriesChaZhi = item.Series - oldSeries;//级数调整前后的差值
                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);
                            //更新子级的 级数 和分级编号 

                            sql = "update ParameterInfo set ClassCode=Replace(ClassCode,@classcode,'@newParentClassCOde'),Series=Series+@Series where ClassCode like '@oldClassCode%'";
                            tr = Dal.BeginTransaction(out dal);
                            csql = dal.FromCustomSql(sql, tr).AddInputParameter("classcode", oldParentClassCode)
                                .AddInputParameter("newParentClassCOde", parent.ClassCode)
                                .AddInputParameter("Series", seriesChaZhi)
                                .AddInputParameter("oldClassCode", oldClassCode)
                                 ;
                        }
                    }
                }
                if (dal == null)
                {
                    tr = Dal.BeginTransaction(out dal);
                }
                dal.SubmitNew(list, ref dal);
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
                return Dal.From<ParameterInfo>().Select(ParameterInfo._.ID, ParameterInfo._.ParentID, ParameterInfo._.Code, ParameterInfo._.Name, ParameterInfo._.IsCanHasLeaf).OrderBy(ParameterInfo._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ParameterInfo>().OrderBy(ParameterInfo._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = ParameterInfo._.ParentID == parentID;

            if (IsCode)
            {
                where = where && ParameterInfo._.Code == val;
            }
            else
            {
                where = where && ParameterInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ParameterInfo._.ID != ID;

            }
            return !Dal.Exists<ParameterInfo>(where);
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ParentID == parentId).OrderBy(ParameterInfo._.OrderNo).ToDataTable();

        }
        public ParameterInfo GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<ParameterInfo>("a").Join<ParameterInfo>("b", new WhereClip("a.parentId=b.id"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<ParameterInfo>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ID != classCode && ParameterInfo._.ClassCode.StartsWith(classCode)).OrderBy(ParameterInfo._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ParentID == parentId).OrderBy(ParameterInfo._.OrderNo).Select(ParameterInfo._.Name).ToSinglePropertyArray();
        }



        public string GetRegistAgreement()
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ID == StaticValue.RegistAgreementID).Select(ParameterInfo._.Value5).ToScalar() as string;
        }
    }
}

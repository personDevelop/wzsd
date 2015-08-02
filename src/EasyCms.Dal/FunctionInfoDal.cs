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
    public class FunctionInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            return "删除失败";

        }

        public int Save(FunctionInfo item)
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
                FunctionInfo parent = null;
                if (string.IsNullOrEmpty(item.ParentID))
                {
                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        item.ClassCode = item.ID;
                        item.Js = 1;
                        item.OrderNo = Dal.Count<FunctionInfo>(FunctionInfo._.ParentID.IsNullOrEmpty(), FunctionInfo._.ID, false);
                    }
                    else
                    {
                        if (item.ID != item.ClassCode)
                        {
                            //说明是从非根级调整到根级节点 

                            int oldSeries = item.Js;

                            item.Js = 1;
                            int seriesChaZhi = oldSeries - item.Js;//级数调整前后的差值

                            item.OrderNo = Dal.Count<FunctionInfo>(FunctionInfo._.ParentID.IsNullOrEmpty(), FunctionInfo._.ID, false);

                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);

                            sql = "update FunctionInfo set ClassCode=Replace(ClassCode,@classcode,''),js=js-@Series   where ClassCode like '@oldClassCode%'";
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

                    parent = Dal.Find<FunctionInfo>(item.ParentID);

                    if (item.RecordStatus == Sharp.Common.StatusType.add)
                    {

                        item.ClassCode = parent.ClassCode + ";" + item.ID;
                        item.Js = item.ClassCode.Count(p => p == ';') + 1;
                        item.OrderNo = Dal.Count<FunctionInfo>(FunctionInfo._.ParentID == item.ParentID, FunctionInfo._.ID, false);
                    }
                    else
                    {
                        if (!item.ClassCode.EndsWith(item.ParentID + ";" + item.ID))
                        {
                            //调整父编码了
                            item.OrderNo = Dal.Count<FunctionInfo>(FunctionInfo._.ParentID == item.ParentID, FunctionInfo._.ID, false);
                            string oldClassCode = item.ClassCode;
                            int oldSeries = item.Js;
                            item.ClassCode = parent.ClassCode + ";" + item.ID;
                            item.Js = item.ClassCode.Count(p => p == ';') + 1;
                            int seriesChaZhi = item.Js - oldSeries;//级数调整前后的差值
                            string oldParentClassCode = item.ClassCode.Substring(0, item.ClassCode.IndexOf(item.ID) + 1);
                            //更新子级的 级数 和分级编号 

                            sql = "update FunctionInfo set ClassCode=Replace(ClassCode,@classcode,'@newParentClassCOde'),js=js+@Series  where ClassCode like '@oldClassCode%'";
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


        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = FunctionInfo._.ParentID == parentID;

            if (IsCode)
            {
                where = where && FunctionInfo._.Code == val;
            }
            else
            {
                where = where && FunctionInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && FunctionInfo._.ID != ID;

            }
            return !Dal.Exists<FunctionInfo>(where);
        }
        public DataTable GetList(bool IsForSelected = false)
        {

            if (IsForSelected)
            {
                return Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.ShowText, FunctionInfo._.Name, FunctionInfo._.ParentID).
                    OrderBy(FunctionInfo._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<FunctionInfo>().
                   OrderBy(FunctionInfo._.OrderNo).ToDataTable();
        }
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ParentID == parentId).OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }
        public FunctionInfo GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<FunctionInfo>("a").Join<FunctionInfo>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<FunctionInfo>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ID != classCode && FunctionInfo._.ClassCode.StartsWith(classCode)).OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ParentID == parentId).OrderBy(FunctionInfo._.OrderNo).Select(FunctionInfo._.Name).ToSinglePropertyArray();
        }



        public DataTable GetParentMoudle()
        {
            int pageCount = 0;
            return Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.ShowText, FunctionInfo._.Name, FunctionInfo._.ParentID, FunctionInfo._.AccessType).
                    Where(FunctionInfo._.Enable == true && FunctionInfo._.AccessType < 2).
                    OrderBy(FunctionInfo._.OrderNo).ToDataTable();
        }

        public List<FunctionInfo> GetListWithUrl(int funcType)
        {
            List<FunctionInfo> list=
             Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.ShowText, FunctionInfo._.ClassCode, FunctionInfo._.AccessType, FunctionInfo._.ParentID, FunctionInfo._.URL, FunctionInfo._.CallArea, FunctionInfo._.CallControler, FunctionInfo._.CallAction, FunctionInfo._.Description, FunctionInfo._.Js).
                    Where(FunctionInfo._.Enable == true && FunctionInfo._.FuncType == funcType)
                    .OrderBy(FunctionInfo._.Js,FunctionInfo._.OrderNo).
                     List<FunctionInfo>(); 
            return list ;
        }
    }

}

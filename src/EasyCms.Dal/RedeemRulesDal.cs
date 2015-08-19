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
    public class RedeemRulesDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }


            int i = Dal.Delete<RedeemRules>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除分类";
            }
        }

        public int Save(RedeemRules item)
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
                return Dal.From<RedeemRules>().Join<ParameterInfo>(ParameterInfo._.ID == RedeemRules._.RuleType).Select(RedeemRules._.ID, RedeemRules._.Name , ParameterInfo._.Name.Alias("RuleTypeName")).ToDataTable();
            }
            else
                return Dal.From<RedeemRules>().Join<ParameterInfo>(ParameterInfo._.ID == RedeemRules._.RuleType).Select(RedeemRules._.ID.All, ParameterInfo._.Name.Alias("RuleTypeName")). ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = RedeemRules._.Name == val;
            }
            else
            {
                where = RedeemRules._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && RedeemRules._.ID != ID;

            }
            return !Dal.Exists<RedeemRules>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<RedeemRules>().Join<ParameterInfo>(ParameterInfo._.ID == RedeemRules._.RuleType).Select(RedeemRules._.ID, RedeemRules._.Name, ParameterInfo._.Name.Alias("RuleTypeName")).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<RedeemRules>().Join<ParameterInfo>(ParameterInfo._.ID == RedeemRules._.RuleType).Select(RedeemRules._.ID.All, ParameterInfo._.Name.Alias("RuleTypeName")).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public RedeemRules GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<RedeemRules>("a").
                Select(new ExpressionClip("a.*"))
                .Where(where)
                .ToFirst<RedeemRules>();
        }







    }

}

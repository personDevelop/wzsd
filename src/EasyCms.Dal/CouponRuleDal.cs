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
    public class CouponRuleDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            int i = Dal.Delete<CouponRule>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除优惠券";
            }
        }

        public int Save(CouponRule item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc).ToDataTable();
            }
            else
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc)

                    .ToDataTable();
        }
        public bool Exit(string ID, string RecordStatus, string name)
        {
            WhereClip where = CouponRule._.Name == name;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && CouponRule._.ID != ID;

            }
            return !Dal.Exists<CouponRule>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public CouponRule GetEntity(string id)
        {

            return Dal.Find<CouponRule>(id);
        }




        public DataTable GetCoupon(string host, bool isAll = false)
        {
            WhereClip where = new WhereClip();
            if (isAll)
            {
                where = CouponRule._.IsEnable == true;
            }
            return Dal.From<CouponRule>().Join<AttachFile>(CouponRule._.ImageUrl == AttachFile._.RefID, JoinType.leftJoin)
                .Join<ParameterInfo>(CouponRule._.ClassId == ParameterInfo._.ID, JoinType.leftJoin)
                .Select(CouponRule._.ID, CouponRule._.Name, CouponRule._.JE,
                new ExpressionClip("case when QxLx=0 then '时间范围'  else   '固定天数' end ").Alias("QxLx")
                , CouponRule._.StartDate, CouponRule._.EndDate, CouponRule._.QXTS,
                new ExpressionClip("case when CouponType=0 then '普通优惠券' when CouponType=1 then '兑换优惠券' else '赠送优惠券' end ").Alias("CouponTypeName"),
                CouponRule._.CouponType, CouponRule._.ClassId, ParameterInfo._.Name.Alias("ClassName"), AttachFile.GetFilePath(host))
                .Where(where)
                .ToDataTable();


        }
    }


}

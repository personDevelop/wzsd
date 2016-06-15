using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Business
{
    public class CouponRuleBll
    {
        CouponRuleDal Dal = new CouponRuleDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(CouponRule item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(string name, int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(  name, pagenum, pagesize, ref   recordCount, IsForSelected);
        }
        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);

        }


        public CouponRule GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }




        public DataTable GetCoupon(string host)
        {
            return Dal.GetCoupon(host);
        }

        public DataTable GetSendRecordList(int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetSendRecordList(pagenum, pagesize, ref   recordCount);
        }

        public SendCoupon GetSendReordeEntity(string id)
        {
            return Dal.GetSendReordeEntity(id);
        }

        public string DeleteSendRecord(string id)
        {
            return Dal.DeleteSendRecord(id);
        }

        public int SaveSendRecord(SendCoupon p)
        {
            return Dal.SaveSendRecord(p);
        }
 

        public bool Send(string id, out string err)
        {
            return Dal.Send(id, out   err);
        }

        

        public DataTable GetMyCoupon(string host, string status, int pageIndex, string accountID)
        {
            return Dal.GetMyCoupon(host, status, pageIndex, accountID);
        }
        public DataTable GetMyCanEnableCoupon( string accountID)
        {
            return Dal.GetMyCanEnableCoupon( accountID);
        }

        public string GetCouponName(string couponID)
        {
            return Dal.GetCouponName(couponID);
        }
    }
}

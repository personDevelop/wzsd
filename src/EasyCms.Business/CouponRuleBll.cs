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
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
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
    }
}

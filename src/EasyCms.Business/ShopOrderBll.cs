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
    public class ShopOrderBll
    {
        ShopOrderDal Dal = new ShopOrderDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopOrder item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(int pagenum, int pagesize,WhereClip where, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, where, ref   recordCount, IsForSelected);
        }

        public ShopOrder GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }




        public ShopOrderModel CreateOrder(ShopOrderModel order, string host, string accuontID, out string err)
        {
            return Dal.CreateOrder(order, host, accuontID, out err);
        }

        public string Submit(ShopOrderModel order, ManagerUserInfo accuont, out string err)
        {
            return Dal.Submit(order, accuont, out err);
        }

        public List<ShopOrder> GetMyOrder(ManagerUserInfo user, int queryPage, int queryStatus, string other, out string err)
        {
            return Dal.GetMyOrder(user, queryPage, queryStatus, other, out err);
        }

        public ShopOrder GetOrder(string id, string userid, out string err)
        {
            return Dal.GetOrder(id, userid, out   err);
        }

        public Dictionary<string, string> ExeAction(ActionEnum actionID, string wlgs, List<string> orderIDs, out string err)
        {
            return Dal.ExeAction(  actionID,wlgs, orderIDs, out   err);
        }

        public DataTable GetList(WhereClip where)
        {
            return Dal.GetList(where);
        }

        public DataTable GetOrderStatus(string id, string accountID, out string err)
        {
            return Dal.GetOrderStatus(  id,   accountID, out   err);
        }
    }
}

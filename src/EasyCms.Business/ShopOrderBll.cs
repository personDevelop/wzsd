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

        public int Save(ShopOrder item, string userID, string username)
        {
            return Dal.Save(item, userID, username);
        }

        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount, bool IsForSelected = false)
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

        public string Submit(ShopOrderModel order, ManagerUserInfo accuont, out bool mustGenerSign, out string err)
        {
            return Dal.Submit(order, accuont, out   mustGenerSign, out err);
        }

        public List<ShopOrder> GetMyOrder(string host, ManagerUserInfo user, int queryPage, string queryStatus, string other, out string err)
        {
            return Dal.GetMyOrder(host, user, queryPage, queryStatus, other, out err);
        }

        public ShopOrder GetOrder(string host, string id, string userid, out string err)
        {
            return Dal.GetOrder(host, id, userid, out   err);
        }

        public Dictionary<string, string> ExeAction(ActionEnum actionID, string wlgs, List<string> orderIDs, string userID, string username, out string err)
        {
            return Dal.ExeAction(actionID, wlgs, orderIDs, userID, username, out   err);
        }

        public DataTable GetList(WhereClip where)
        {
            return Dal.GetList(where);
        }

        public DataTable GetOrderStatus(string id, string accountID, out string err)
        {
            return Dal.GetOrderStatus(id, accountID, out   err);
        }

        public void PaySuccess(string orderID, string payJe)
        {
            Dal.PaySuccess(orderID, payJe);
        }

        public int CancleOrder(string accountid, string orderid, out string error)
        {
            return Dal.CancleOrder(accountid, orderid, out error);
        }

        public bool PaySuccess(string orderID, out string err)
        {
            return Dal.PaySuccess(orderID, out err);
        }

        public DataTable GetOrderDetail(string id)
        {
            return Dal.GetOrderDetail(id);
        }

        public DataTable getDataTable(WhereClip where)
        {
            return Dal.getDataTable(where);
        }

        public DataTable GetCanReturnDetail(string host, string orderID  )
        {
            return Dal.GetCanReturnDetail(host, orderID );
        }
    }
}

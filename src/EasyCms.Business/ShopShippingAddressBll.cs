﻿using EasyCms.Dal;
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
    public class ShopShippingAddressBll
    {
        ShopShippingAddressDal Dal = new ShopShippingAddressDal();
        public bool Delete(string id)
        {

            return Dal.Delete(id);
        }

        public string Save(ShopShippingAddress item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(string userID, bool IsDefault)
        {
            return Dal.GetList(userID, IsDefault);
        }
        public DataTable GetWebList(string userID)
        {
            return Dal.GetWebList(userID);
        }
        public ShopShippingAddress GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public string SetDefault(string id)
        {
            return Dal.SetDefault(id);
        }

        public ShopShippingAddress GetDefaultShopAddressForShow(string userID)
        {
            return Dal.GetShopAddressForShow(userID, true).ToFirst<ShopShippingAddress>();
        }

        public bool UserDelete(string accountid, string id, out string err)
        {
            return Dal.UserDelete(accountid, id, out   err);
        }

     
    }
}

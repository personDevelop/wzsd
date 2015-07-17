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
    public class ShopShoppingCartsBll
    {
        ShopShoppingCartsDal Dal = new ShopShoppingCartsDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopShoppingCarts item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(string userID)
        {
            return Dal.GetList(userID);
        }
       
 
        public ShopShoppingCarts GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 


    }
}
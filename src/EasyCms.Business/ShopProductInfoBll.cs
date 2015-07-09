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
    public class ShopProductInfoBll
    {
        ShopProductInfoDal Dal = new ShopProductInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spa, List<ShopProductSKU> listSku, List<ShopProductSKUInfo> listSkuInfo)
        {
            return Dal.Save(item, list, spa, listSku, listSkuInfo);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }

        public ShopProductInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);

        }

        public DataTable GetAttrWithProdcutVal(string ptypeid, string productID)
        {
            return Dal.GetAttrWithProdcutVal(ptypeid, productID);

        }



        public DataSet GetGgWithProdcutVal(string ptypeid, string productID)
        {
            return Dal.GetGgWithProdcutVal(ptypeid, productID);
        }



        public ShopProductInfo GetSaleEntity(string id)
        {
            return Dal.GetSaleEntity(id);
        }

        public DataTable GetProductsByCategory(string categoryID, int pageindex, ref int pageCount, ref int recordCount)
        {
            return Dal.GetProductsByCategory(categoryID, pageindex, ref   pageCount, ref   recordCount);
        }
    }
}
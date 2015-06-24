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
    public class ShopBrandInfoBll
    {
        ShopBrandInfoDal Dal = new ShopBrandInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopBrandInfo item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }


        public bool Exit(string ID,   string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID,  RecordStatus, val, IsCode);

        }

        public ShopBrandInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }




    }
}

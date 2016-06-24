using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EasyCms.Business
{
    public class APPVersionBll
    {
        APPVersionDal Dal = new APPVersionDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(APPVersion  item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(string name, int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(name, pagenum, pagesize, ref recordCount );
        }

        public APPVersion GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public string Exit(string iD, string recordStatus, string val, int checkCode)
        {
            return Dal.Exit(iD, recordStatus, val, checkCode).ToString().ToLower();
        }

        public DataTable GetAppVersion()
        {
            return Dal.GetAppVersion();
        }
    }
}

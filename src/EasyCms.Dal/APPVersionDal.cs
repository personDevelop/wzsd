using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EasyCms.Dal
{
    public class APPVersionDal : Sharp.Data.BaseManager
    {

        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("APPVersion", "ID", id, out error);
            return error;
        }

        public int Save(APPVersion item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(string name, int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
           
                return Dal.From<APPVersion>().OrderBy(APPVersion._.Code)
                   
                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public APPVersion GetEntity(string id)
        {
            return Dal.Find<APPVersion>(id);
        }

        public bool Exit(string iD, string recordStatus, string val, int checkCode)
        {
            WhereClip where = null;  
            switch (checkCode)
            {
                case 2:
                    where =  APPVersion._.Name == val;
                    break;
                case 3:
                    where = APPVersion._.PlatForm == int.Parse(val);
                    break;
                default:
                    where = APPVersion._.Code == val;
                    break;
            }
            if (recordStatus == StatusType.update.ToString())
            {
                where = where && APPVersion._.ID != iD;

            }
            return !Dal.Exists<APPVersion>(where) ;
        }

        public DataTable GetAppVersion()
        {
            return Dal.From<APPVersion>().Select(APPVersion._.Version, APPVersion._.SoftPath, APPVersion._.VersionName, APPVersion._.VersionNote).ToDataTable(1);
        }
    }
}

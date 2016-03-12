using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Dal
{
    public class SystemBrandInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SystemBrandInfo", "ID", id, out error);
            return error;
        }

        public int Save(SystemBrandInfo item)
        {
            return Dal.Submit(item);

        }
         
     
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<SystemBrandInfo>().ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);

        }
        public SystemBrandInfo GetEntity(string id)
        {
            return Dal.Find<SystemBrandInfo>(id);

        }




        public List<SystemBrandInfo> GetList(WhereClip where)
        {
            return Dal.From<SystemBrandInfo>().Where(where).OrderBy(SystemBrandInfo._.CreateTime.Desc).List<SystemBrandInfo>();
        }

        public DataTable GetBrandList(int brandType, int pageSize, string host)
        {
            return Dal.From<SystemBrandInfo>().Where(SystemBrandInfo._.BrandType==brandType)
                .Join<AttachFile>(AttachFile._.RefID==SystemBrandInfo._.ID)
                .Select(SystemBrandInfo._.Name,SystemBrandInfo._.AppHandleTag, SystemBrandInfo._.ActionValue,AttachFile.GetFilePath(host))
                .OrderBy(SystemBrandInfo._.CreateTime.Desc).ToDataTable(pageSize);
        }
    }


}

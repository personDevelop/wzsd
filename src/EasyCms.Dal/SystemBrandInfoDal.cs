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
            return Dal.From<SystemBrandInfo>().Where(SystemBrandInfo._.IsVideo == false && SystemBrandInfo._.IsTop == true && SystemBrandInfo._.BrandType==brandType)
                .Join<AttachFile>(AttachFile._.RefID==SystemBrandInfo._.ID)
                .Select(SystemBrandInfo._.Name,SystemBrandInfo._.AppHandleTag, SystemBrandInfo._.ActionValue,AttachFile.GetThumbnaifilePath(host))
                .OrderBy(SystemBrandInfo._.TopTime.Desc).ToDataTable(pageSize);
        }

        public DataTable GetTopVideoList(int brandType, int pageSize, string host)
        {
            return Dal.From<SystemBrandInfo>().Where(SystemBrandInfo._.IsVideo==true&& SystemBrandInfo._.IsTop==true&& SystemBrandInfo._.BrandType == brandType)
                .Join<AttachFile>(AttachFile._.RefID == SystemBrandInfo._.ID)
                .Select(SystemBrandInfo._.Name, SystemBrandInfo._.VideoUrl, SystemBrandInfo._.AppHandleTag, SystemBrandInfo._.ActionValue, AttachFile.GetCompressionfilePath(host))
                .OrderBy(SystemBrandInfo._.TopTime.Desc).ToDataTable(pageSize);
        }

        public DataTable GetVideoList(int brandType, int pageIndex, int pagesize, string host)
        {
            int pageCount = 0,recourdCount=0;
            return Dal.From<SystemBrandInfo>().Where(SystemBrandInfo._.IsVideo == true   && SystemBrandInfo._.BrandType == brandType)
                .Join<AttachFile>(AttachFile._.RefID == SystemBrandInfo._.ID)
                .Select(SystemBrandInfo._.Name, SystemBrandInfo._.VideoUrl, SystemBrandInfo._.AppHandleTag, SystemBrandInfo._.ActionValue, AttachFile.GetCompressionfilePath(host))
                .OrderBy(SystemBrandInfo._.TopTime.Desc).ToDataTable(pagesize, pageIndex,ref pageCount,ref recourdCount);
        }
    }


}

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
    public class SystemBrandInfoBll
    {
        SystemBrandInfoDal Dal = new SystemBrandInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SystemBrandInfo item)
        {
            return Dal.Save(item);
        }

        
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount );
        }
         
        public SystemBrandInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public List<SystemBrandInfo> GetList(WhereClip where)
        {
            return Dal.GetList(where);
        }

        public DataTable GetBrandList(int brandType, int pageSize, string host)
        {
            return Dal.GetBrandList(brandType,   pageSize,   host);
        }
    }
}

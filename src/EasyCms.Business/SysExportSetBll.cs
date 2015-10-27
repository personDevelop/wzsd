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
    public class SysExportSetBll
    {
        SysExportSetDal Dal = new SysExportSetDal();
        public string Delete(string id)
        {
            return Dal.Delete(id);
        }

        public int Save(SysExportSet item, List<SysExportMx> mxLixt)
        {
            return Dal.Save(item, mxLixt);

        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount);
        }
        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.GetListByParentId(parentId);

        }
        public SysExportSet GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public DataTable AddMx(  string table )
        {
            return Dal.AddMx(table);
        }



        public DataTable GetMxList(string id)
        {
            return Dal.GetMxList(id );
        }
    }
}

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

       
        public SysExportSet GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }
        public SysExportSet GetEntityByCode(string code)
        {
            return Dal.GetEntityByCode(code);
        }
        public DataTable AddMx(  string table )
        {
            return Dal.AddMx(table);
        }



        public DataTable GetMxDataTable(string id)
        {
            return Dal.GetMxDataTable(id );
        }
        public DataTable GetExportMxDataTable(string id)
        {
            return Dal.GetExportMxDataTable(id);
        }
        public DataTable GetResult(string sql, Dictionary<string, object> paras)
        {
            return Dal.GetResult(sql,paras);
        }
    }
}

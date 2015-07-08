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
    public class AdministrativeRegionsBll
    {
        AdministrativeRegionsDal Dal = new AdministrativeRegionsDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(AdministrativeRegions item)
        {
            return Dal.Save(item);
        }
 
        public DataTable GetList(int ParentID, bool IsForSelected = false)
        {
            return Dal.GetList(ParentID, IsForSelected);
        }
        public bool Exit(int ID, int ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }

        
        public AdministrativeRegions GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.GetListByFullPath (classCode);

        }

        public string[] GetNameByParentId(int parentId)
        {
            return Dal.GetNameByParentId(parentId);
        }


    }
}

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

        public decimal GetFreightWithRegion(int id, out string error)
        {
            return Dal.GetFreightWithRegion(id, out   error);
            
        }

        public string[] GetNameByParentId(int parentId)
        {
            return Dal.GetNameByParentId(parentId);
        }



        public DataTable GetOne(int id)
        {
            return Dal.GetOne(id);
        }

        public decimal GetFreightWithAddress(string id, out string error)
        {
            return Dal.GetFreightWithAddress(id, out error);
            
        }

        public DataTable GetPathByFullPath(string fullPath)
        {
            return Dal.GetPathByFullPath(fullPath);
        }

        public string GetPathByDefault(int defaultval)
        {
            return Dal.GetPathByDefault(defaultval);
        }

        public DataTable GetByJs(int p)
        {
            throw new NotImplementedException();
        }


        public List<AdministrativeRegions> GetRegionPathWithNotRoot(int regeonID)
        {
            return Dal.GetRegionPathWithNotRoot(regeonID);
        }
        public int[] GetParentIDByChildID(int regeonID)
        {
            return Dal.GetParentIDByChildID(regeonID);
        }

        public string GetPathByID(int regionId)
        {
            return Dal.GetPathByID(regionId);
        }
    }
}

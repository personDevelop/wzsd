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
    public class HelpTypeBll
    {
        HelpTypeDal Dal = new HelpTypeDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(HelpType item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
      
        public bool Exit(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.GetListByParentId(parentId);

        }
        public HelpType GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 

    }
}

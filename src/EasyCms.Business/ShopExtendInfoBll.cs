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
    public class ShopExtendInfoBll
    {
        ShopExtendInfoDal Dal = new ShopExtendInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }
        
        public int Save(ShopExtendInfo item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount, IsForSelected);
        }

        public DataTable GetValList(string host, string attriID)
        {
            return Dal.GetValList(host, attriID);
        }

        public bool Exit(string ID, string categoryID, string RecordStatus, string val )
        {
            return Dal.Exit(ID, categoryID, RecordStatus, val );

        }
        public bool ExitExtendInfoValue(string ID, string AttributeId, string RecordStatus, string val)
        {
            return Dal.ExitExtendInfoValue (ID, AttributeId, RecordStatus, val);
        }
        public ShopExtendInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public int Save(List<ShopExtendInfoValue> list)
        {
            return Dal.Save(list);
        }

        

        public int SaveAttrVal(ShopExtendInfoValue p)
        {
            return Dal.SaveAttrVal(p);
        }

        public ShopExtendInfoValue GetAttrEntity(string valueID)
        {
            return Dal.GetAttrVal(valueID);
        }

        public int DeleteAttrVal(string id, out string eroor)
        {
            return Dal.DeleteAttrVal(id, out eroor);
        }

        public DataTable GetList(string categoryID, string name, string fullName, string pTypeID, UsageMode usageMode, int pagenum, int pagesize, 
            ref int recordCount )
        {
            return Dal.GetList(categoryID, name, fullName,
               pTypeID, usageMode, pagenum, pagesize, ref recordCount );
        }
    }
}

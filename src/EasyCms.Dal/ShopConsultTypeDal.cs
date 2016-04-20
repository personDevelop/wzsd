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
    public class ShopConsultTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopConsultType", "ID", id, out error);
            return error;
        }

        public int Save(ShopConsultType item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList( )
        {
           
                return Dal.From<ShopConsultType>(). OrderBy(ShopConsultType._.Code).ToDataTable();
        }
        public bool Exit(string ID,   string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopConsultType._.Code == val;
            }
            else
            {
                where = ShopConsultType._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopConsultType._.ID != ID;

            }
            return !Dal.Exists<ShopConsultType>(where);
        }
       
       
        public ShopConsultType GetEntity(string id)
        {
            

            return Dal.Find<ShopConsultType>(id);
        }

 


    }

    
}

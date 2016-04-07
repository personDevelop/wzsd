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
    public class AttributeTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("AttributeType", "ID", id, out error);
            return error;
        }

        public int Save(AttributeType item)
        { 
                return Dal.Submit(item); 
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<AttributeType>().Select(AttributeType._.ID,  AttributeType._.Code, AttributeType._.Name  ).OrderBy(AttributeType._.Code).ToDataTable();
            }
            else
                return Dal.From<AttributeType>().OrderBy(AttributeType._.Code).ToDataTable();
        }
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = AttributeType._.Code == val;
            }
            else
            {
                where = AttributeType._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && AttributeType._.ID != ID;

            }
            return !Dal.Exists<AttributeType>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<AttributeType>() .Select(AttributeType._.ID, AttributeType._.Code, AttributeType._.Name).OrderBy(AttributeType._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<AttributeType>().   OrderBy(AttributeType._.Code)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
 
        public AttributeType GetEntity(string id)
        {
            
            return Dal.Find<AttributeType>(id);
        } 
    }

    
}

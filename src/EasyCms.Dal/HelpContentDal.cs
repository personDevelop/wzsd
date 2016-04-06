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
    public class HelpContentDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("HelpContent", "ID", id, out error);
            return error;
        }

        public int Save(HelpContent item)
        {
            return Dal.Submit (  item); 
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID==HelpType._.ID)
                .Select(HelpContent._.ID, HelpContent._.Code, HelpContent._.Name,


                    HelpType._.Name.Alias("CategoryName") ).OrderBy(HelpContent._.Code).ToDataTable();
            }
            else
                return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                 .Select(HelpContent._.ID.All, HelpType._.Name.Alias("CategoryName")).OrderBy(HelpContent._.Code).ToDataTable();
        }
       
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;

            if (IsForSelected)
            {
                return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                .Select(HelpContent._.ID, HelpContent._.Code, HelpContent._.Name,


                    HelpType._.Name.Alias("CategoryName")).OrderBy(HelpContent._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                 .Select(HelpContent._.ID.All, HelpType._.Name.Alias("CategoryName")).OrderBy(HelpContent._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
           
        }
      
        public HelpContent GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);
            return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                 .Select(HelpContent._.ID.All, HelpType._.Name.Alias("CategoryName")).Where(where).OrderBy(HelpContent._.Code).ToFirst<HelpContent>();
        }


       

    }

    
}

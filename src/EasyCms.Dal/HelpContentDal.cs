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
            if (item.RecordStatus== StatusType.add)
                item.OrderNo = Dal.Count<HelpContent>(HelpContent._.CategoryID==item.CategoryID,HelpContent._.ID, false)+1;
            return Dal.Submit (  item); 
        }

        public DataTable GetList( )
        {
            DataTable dt= Dal.From<HelpType>().Select(HelpType._.ID, HelpType._.Code, HelpType._.Name,
                HelpType._.IsShowButtom, HelpType._.IsShowNavi, HelpType._.OrderNo, HelpType._.ParentID
                ,new ExpressionClip("CONVERT(bit,0)").Alias("IsContent")
                )   .ToDataTable();
                
            DataTable dt1=Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID==HelpType._.ID)
                .Select(HelpContent._.ID, HelpContent._.Code, HelpContent._.Name, HelpType._.IsShowButtom, HelpType._.IsShowNavi,
                HelpContent._.OrderNo, HelpType._.ID.Alias("ParentID"), new ExpressionClip("CONVERT(bit,1)").Alias("IsContent")
                ).ToDataTable();
            if (dt1.Rows.Count>0)
                dt.Merge(dt1);
            return dt ;
            
        }
       
    
      
        public HelpContent GetEntity(string id)
        {
           
            return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                .Select(HelpContent._.ID.All, HelpType._.Name.Alias("CategoryName")  ).Where(HelpContent._.ID==id).ToFirst<HelpContent>();
        }


       

    }

    
}

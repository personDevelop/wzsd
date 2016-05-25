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

        public HelpContent GetFirst()
        {
            return Dal.From<HelpContent>().ToDataTable(1).ToFirst<HelpContent>();
        }

        public DataTable GetTreeList(WhereClip wherepara = null)
        {
            WhereClip where = new WhereClip();
            if (WhereClip.IsNullOrEmpty(wherepara))
            {
                where = wherepara;
            }
           
            DataTable dt= Dal.From<HelpType>().Select(HelpType._.ID, HelpType._.Code, HelpType._.Name,
                HelpType._.IsShowButtom, HelpType._.IsShowNavi, HelpType._.OrderNo, HelpType._.ParentID
                ,new ExpressionClip("CONVERT(bit,0)").Alias("IsContent")
                )  .Where(wherepara).ToDataTable();
                
            DataTable dt1=Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID==HelpType._.ID)
                .Select(HelpContent._.ID, HelpContent._.Code, HelpContent._.Name, HelpType._.IsShowButtom, HelpType._.IsShowNavi,
                HelpContent._.OrderNo, HelpType._.ID.Alias("ParentID"), new ExpressionClip("CONVERT(bit,1)").Alias("IsContent")
                ).ToDataTable();
            if (dt1.Rows.Count>0)
                dt.Merge(dt1);
            return dt ;
            
        }

        public string GetContentID(string id)
        {
            return Dal.From<HelpContent>().Where(HelpContent._.ID==id).Select(HelpContent._.ContentHtml).ToScalar() as string;
        }

        public List<HelpContent> GetFootList()
        {
            return Dal.From<HelpContent>().Join<HelpType>(HelpType._.ID == HelpContent._.CategoryID && HelpType._.IsShowButtom == true)
               .Select(HelpContent._.ID, HelpContent._.Name, HelpContent._.CategoryID, HelpContent._.OrderNo).OrderBy(HelpContent._.OrderNo).List<HelpContent>();
        }

        public HelpContent GetEntity(string id)
        {
           
            return Dal.From<HelpContent>().Join<HelpType>(HelpContent._.CategoryID == HelpType._.ID)
                .Select(HelpContent._.ID.All, HelpType._.Name.Alias("CategoryName")  ).Where(HelpContent._.ID==id).ToFirst<HelpContent>();
        }


       

    }

    
}

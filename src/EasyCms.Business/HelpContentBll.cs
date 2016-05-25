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
    public class HelpContentBll
    {
        HelpContentDal Dal = new HelpContentDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(HelpContent item)
        {
            return Dal.Save(item);
        }

        public HelpContent GetFirst()
        {
            return Dal.GetFirst( );
        }

        public DataTable GetList(WhereClip where=null )
        {
            return Dal.GetTreeList(where);
        }
       
       
        public HelpContent GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public List<HelpContent> GetFootList()
        {
            return Dal.GetFootList();
        }

        public string GetContentByParaID(string payTypeDescripbe)
        {
         string id=   new ParameterInfoBll().GetValue(payTypeDescripbe);
            return Dal.GetContentID(id);
        }
    }
}

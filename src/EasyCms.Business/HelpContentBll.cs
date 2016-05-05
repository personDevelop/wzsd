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

        public DataTable GetList( )
        {
            return Dal.GetTreeList( );
        }
       
       
        public HelpContent GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public List<HelpContent> GetFootList()
        {
            return Dal.GetFootList();
        }
        

    }
}

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
    public class WebSiteSetBll
    {
        WebSiteSetDal Dal = new WebSiteSetDal();
       
        public int Save(WebSiteSet item)
        {
            return Dal.Save(item);
        }
         
 
        public WebSiteSet GetEntity( )
        {
            return Dal.GetEntity( );
        }

  

    }
}

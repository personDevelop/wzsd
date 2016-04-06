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
    public class WebSiteParaSetBll
    {
        WebSiteParaSetDal Dal = new WebSiteParaSetDal();
        

        public int Save(WebSiteParaSet item)
        {
            return Dal.Save(item);
        }
         
        public WebSiteParaSet GetEntity( )
        {
            return Dal.GetEntity( );
        }

 


    }
}

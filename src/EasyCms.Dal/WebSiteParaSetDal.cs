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
    public class WebSiteParaSetDal : Sharp.Data.BaseManager
    {
        public int Save(WebSiteParaSet item)
        {

            return Dal.Submit(item);
        }

        public WebSiteParaSet GetEntity( )
        {
            WebSiteParaSet asp = Dal.From<WebSiteParaSet>()
               .ToFirst<WebSiteParaSet>();
            if (asp == null)
            {
                asp = new WebSiteParaSet() { ID = Guid.NewGuid().ToString() };
            }
            return asp;
        }


         

    }

   
}

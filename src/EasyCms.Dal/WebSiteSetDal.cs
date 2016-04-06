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
    public class WebSiteSetDal : Sharp.Data.BaseManager
    {
      

        public int Save(WebSiteSet item)
        {
             
            return Dal.Submit(item);

        }





        public WebSiteSet GetEntity()
        {

            WebSiteSet asp = Dal.From<WebSiteSet>()
              .ToFirst<WebSiteSet>();
            if (asp == null)
            {
                asp = new WebSiteSet() { ID = Guid.NewGuid().ToString() };
            }
            return asp;

        }




    }


}

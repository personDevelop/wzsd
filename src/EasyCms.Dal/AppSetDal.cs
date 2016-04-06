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
    public class AppSetDal : Sharp.Data.BaseManager
    {

        public int Save(AppSet item)
        {

            return Dal.Submit(item); 
        }


        public AppSet GetEntity()
        {

            AppSet asp = Dal.From<AppSet>()
                .ToFirst<AppSet>();
            if (asp==null)
            {
                asp = new AppSet() {  ID=Guid.NewGuid().ToString()};
            }
            return asp;
        }




    }

}

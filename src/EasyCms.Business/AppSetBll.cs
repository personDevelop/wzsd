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
    public class AppSetBll
    {
        AppSetDal Dal = new AppSetDal();
        

        public int Save(AppSet item)
        {
            return Dal.Save(item);
        } 
        
         
        public AppSet GetEntity( )
        {
            return Dal.GetEntity( );
        }

 


    }
}

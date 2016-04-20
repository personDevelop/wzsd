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
    public class ShopConsultTypeBll
    {
        ShopConsultTypeDal Dal = new ShopConsultTypeDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopConsultType item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList( )
        {
            return Dal.GetList( );
        }
       
        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID,   RecordStatus, val, IsCode);

        }

        
        public ShopConsultType GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 


    }
}

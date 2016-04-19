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
    public class OnLineUserDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("OnLineUser", "ID", id, out error);
            return error;
        }

        public int Save(OnLineUser item)
        {
            return Dal.Submit(item);


        }

        public DataTable GetList(bool IsForSelected = false)
        {

            return Dal.From<OnLineUser>().ToDataTable();
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;

            return Dal.From<OnLineUser>().ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public OnLineUser GetEntity(string id)
        {

            return Dal.Find<OnLineUser>(id);
        }

    }

    }

  

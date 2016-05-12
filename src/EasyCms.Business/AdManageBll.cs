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
    public class AdManageBll
    {
        AdManageDal Dal = new AdManageDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(AdManage item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount );
        }
        public bool Exit(string ID,   string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID,   RecordStatus, val, IsCode);

        }

       
        public AdManage GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public List<AdManage> GetAdByPositon(string posiontCode,int count, ref AdPositon posionEntity)
        {

            return Dal.GetAdByPositon(posiontCode, count, ref   posionEntity);
        }
        public AdManage GetOnAdByPosition(string posiontCode)
        {
            return Dal.GetOnAdByPosition(posiontCode );
        }

    }
}

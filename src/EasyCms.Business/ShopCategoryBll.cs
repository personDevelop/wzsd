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
    public class ShopCategoryBll
    {
        ShopCategoryDal Dal = new ShopCategoryDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopCategory item)
        {
            return Dal.Save(item);
        }
        public List<ShopCategory> GetShowIndex(string host)
        {
            return Dal.GetShowIndex(host );
        }
        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public List<ShopCategory> GetListWithNavi(string parentID, int maxLayer = 3)
        {
            return Dal.GetListWithNavi(  parentID,   maxLayer);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }
        public bool Exit(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }
        
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.GetListByParentId(parentId);

        }
        public ShopCategory GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.GetListByClassCode(classCode);

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.GetNameByParentId(parentId);
        }



        public DataTable GetAppEntityList(string id, string host)
        {
            return Dal.GetAppEntityList(id, host);

        }

        public string[] GetClassCode(string categoryID)
        {
            return Dal.GetClassCode(categoryID);
        }

        public DataTable GetAppEntity(string id, string host)
        {
            return Dal.GetAppEntity(id, host);
        }
    }
}

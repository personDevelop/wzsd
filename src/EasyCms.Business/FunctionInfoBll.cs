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
    public class FunctionInfoBll
    {
        FunctionInfoDal Dal = new FunctionInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(FunctionInfo item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }

        public bool Exit(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.GetListByParentId(parentId);

        }
        public FunctionInfo GetEntity(string id)
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



        public DataTable GetParentMoudle()
        {
            return Dal.GetParentMoudle();
        }

        public List<FunctionInfo> GetListWithUrl(int functype)
        {
            return Dal.GetListWithUrl(functype);
        }
    }
}

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
    public class FunctionRightBll
    {
        FunctionRightDal Dal = new FunctionRightDal();


        public DataTable GetRoleOrMemberOrderList(int id)
        {
            return Dal.GetRoleOrMemberOrderList(id);
        }

        public DataTable GetRightList(string roleID, bool isAll, int sqtype)
        {
            return Dal.GetRightList(roleID, isAll, sqtype);
        }

        public string SaveRight(Model.ViewModel.SaveModel saveModel)
        {
            return Dal.SaveRight(saveModel);
        }

        internal static List<FunctionRight> GetAllRight()
        {
            return new FunctionRightDal().GetAllRight();
        }
    }
}

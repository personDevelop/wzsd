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
        private static List<FunctionInfo> GetAllFucntion()
        {
            return new FunctionInfoDal().GetAllFunction();
        }
        public static List<FunctionInfo> GetEnableFucntion()
        {
            if (!CacheContainer.Contains(StaticValue.FunctionCachKey))
            {
                CacheContainer.AddCache(StaticValue.FunctionCachKey, FunctionInfoBll.GetAllFucntion());
            }

            return CacheContainer.GetCache(StaticValue.FunctionCachKey) as List<FunctionInfo>;

        }


        public static List<FunctionRight> GetRightList()
        {
            if (!CacheContainer.Contains(StaticValue.FunctionRightCachKey))
            {
                CacheContainer.AddCache(StaticValue.FunctionRightCachKey, FunctionRightBll.GetAllRight());
            }

            return CacheContainer.GetCache(StaticValue.FunctionRightCachKey) as List<FunctionRight>;

        }



      

        public static void WriteLog(string userid, string area, string controler, string action)
        {
           
            string error = string.Empty;
            FunctionInfo func = FindFunc(area, controler, action, out error);
            if (func != null)
            {
                if (func.IsRecord)
                {
                    error = "操作功能【" + func.Name + "】";

                }
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                string funcid = null;
                if (func != null)
                {
                    funcid = func.ID;
                }
                new LogBll().WriteOperLog(error, userid, funcid);

            }

        }

        public static FunctionInfo FindFunc(string area, string controler, string action, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(controler))
            {
                controler = "index";
            }
            if (string.IsNullOrWhiteSpace(action))
            {
                action = "index";
            }
            area = area.ToLower();
            controler = controler.ToLower(); action = action.ToLower();
            List<FunctionInfo> list = GetEnableFucntion();

            if (list == null || list.Count == 0)
            {
                error = "还没有定义所有功能";
                return null;
            }
            else
                if (list.Exists(p => p.CallArea.ToLower() == area && p.CallControler.ToLower() == controler
                    && (p.CallAction.ToLower() == action || (action == "index" &&
                    string.IsNullOrWhiteSpace(p.CallAction)))))
                {
                    FunctionInfo func = list.Find(p => p.CallArea.ToLower() == area && p.CallControler.ToLower() == controler && (p.CallAction.ToLower() == action
                    || (action == "index" &&
                    string.IsNullOrWhiteSpace(p.CallAction))));
                    return func;
                }
                else
                {

                    if (new ParameterInfoBll().GetValue(StaticValue.IsRecordNotFundFunc) == "1")
                    {
                        error = string.Format("没找到对应的功能【{0}】【{1}】【{2}】 ", area, controler, action);
                    }
                    return null;
                }
        }
    }
}

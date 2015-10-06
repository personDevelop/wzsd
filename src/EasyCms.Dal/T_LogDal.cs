using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EasyCms.Dal
{
    public class T_LogDal : Sharp.Data.BaseManager
    {


        public System.Data.DataTable GetList(int pagenum, int pagesize, Sharp.Common.WhereClip where, ref int recordCount)
        {
            int pageCount = 0;

            DataTable dt = Dal.From<T_Log>().Join<ManagerUserInfo>(T_Log._.Createor == ManagerUserInfo._.ID, JoinType.leftJoin)
                .Join<FunctionInfo>(FunctionInfo._.ID == T_Log._.FunNameSource, JoinType.leftJoin)
                .Select(T_Log._.ID, T_Log._.Info, T_Log._.CrateDate, T_Log._.Createor, T_Log._.msgOrder,
                 T_Log._.ModleNameSource, T_Log._.ContextInfo,
                ManagerUserInfo._.Name.Alias("CreateorName"), FunctionInfo._.Name.Alias("FunName"))


                .Where(where).OrderBy(T_Log._.CrateDate.Desc)

                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            dt.Columns.Add("OrderName");
            foreach (DataRow item in dt.Rows)
            {
                int order = (int)item["msgOrder"];
                if (order > 0)
                {
                    item["OrderName"] = "异常信息";
                }
                else
                { item["OrderName"] = "操作日志"; }
            }
            return dt;
        }

        public string Delete(string id)
        {
          int count=  Dal.Delete<T_Log>( T_Log._.ID.In(id.Split(',')));
          return "成功删除"+count+"条日志";
        }
    }
}

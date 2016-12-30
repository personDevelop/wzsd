using EasyCms.Dal;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasyCms.Business
{

    public class LogBll:ILog
    {

        LogDal CurrentClient = new LogDal();
        static LogBll()
        {

            new LogDal().RegisterErrorSqlLogger();
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex"></param>
        public void WriteException(Exception ex, string accountid = null, string funcID = null, string extinfo = null)
        {
            Write(ex.GetExceptionMsg(), LogOrder.严重错误, accountid, funcID, extinfo);


        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex"></param>
         public int Write(string msg, LogOrder msgOrder = LogOrder.严重错误, string funName = "", string className = "", string modleName = "", string context = "")
        {
           

            T_Log log = new T_Log();
            log.ID = Guid.NewGuid().ToString();
            log.Info = msg;
            log.msgOrder = (int)msgOrder;
            log.CrateDate = DateTime.Now;
            log.Createor = modleName;
            log.FunNameSource = funName;
            log.ContextInfo = context;
            return CurrentClient.Write(log);
          

        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        public void WriteOperLog(string info, string accountid, string funcID)
        {

            T_Log log = new T_Log();
            log.ID = Guid.NewGuid().ToString();
            log.Info = info;
            log.msgOrder = (int)LogOrder.操作日志;
            log.CrateDate = DateTime.Now;
            log.Createor = accountid;
            log.FunNameSource = funcID;
            CurrentClient.Write(log);
        }

        public int Delete(string id)
        {
            new T_LogDal().Delete(id);
            return  0;
        }
        public int DeleteByIds(List<string> idlist)
        {
            return CurrentClient.DeleteByIds(idlist);
        }

        public int DeleteAll()
        {
            return CurrentClient.DeleteAll();
        }

        public void WriteToFile(string context)
        {
            string path = Path.Combine(@"e:\CMSLog");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {

                    //开始写入
                    sw.Write(context + System.Environment.NewLine);
                }
            }
        }


        public System.Data.DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            return new T_LogDal().GetList(pagenum, pagesize, where, ref   recordCount);
        }

        public void WriteException(Model.ViewModel.AppException exception, string userID)
        {
            T_Log log = new T_Log();
            log.ID = Guid.NewGuid().ToString();
            log.Info = exception.Info;
            log.msgOrder = (int)LogOrder.严重错误;
            log.CrateDate = DateTime.Now;
            log.ModleNameSource = "APP";
            log.ClassNameSource = exception.Token;
            log.Createor = userID; 
            log.ContextInfo = exception.ExtInfo;
            CurrentClient.Write(log);

        }

        public int Write(T_Log msg)
        {
            throw new NotImplementedException();
        }

       

        public void RegisterErrorSqlLogger()
        {
            throw new NotImplementedException();
        }

        public void WriteSqlError(string msg)
        {
            throw new NotImplementedException();
        }

        public void Write(Exception ex)
        {
            WriteException(ex);
        }

        public void Write(Exception ex, string context)
        {
            WriteException(ex, context);
        }

        
    }
}

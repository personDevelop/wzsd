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
    public class NoticeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("Notice", "ID", id, out error);
            return error;
        }

        public int Save(Notice item)
        { 
                return Dal.Submit(item); 
        }

       
      
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<Notice>().Select(Notice._.ID, Notice._.NoticeTitle, Notice._.CreateDate,Notice._.DjStatus, Notice._.PublishTime   ).OrderBy(Notice._.CreateDate.Desc)
                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<Notice>() .OrderBy(Notice._.CreateDate.Desc)
                     .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public string Publish(string  ids, int stat)
        {
            string err = string.Empty;

            try
            {
                Notice p = new Notice();
                p.RecordStatus = StatusType.update;
                p.Where = Notice._.ID.In(ids.Split(';')) && Notice._.DjStatus != stat;
                p.DjStatus = (DjStatus)stat;
                p.PublishTime = DateTime.Now;
                Dal.Submit(p);
                err = "操作成功";
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return err;
        }

        public Notice GetEntity(string id)
        {
           
            return Dal.Find<Notice>(id);
        }


       
     
      

    } 
}

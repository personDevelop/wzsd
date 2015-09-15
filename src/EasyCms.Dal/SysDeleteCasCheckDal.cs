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
    public class SysDeleteCasCheckDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }

            int i = Dal.Delete<SysDeleteCasCheck>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除";
            }
        }

        public int Save(SysDeleteCasCheck item)
        {
            return Dal.Submit(item);

        }

        public List<SysDeleteCasCheck> GetList(string talbeName)
        {
            return Dal.From<SysDeleteCasCheck>().Where(SysDeleteCasCheck._.CheckTableName == talbeName).List<SysDeleteCasCheck>();
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;


            return Dal.From<SysDeleteCasCheck>().OrderBy(SysDeleteCasCheck._.CheckTableName)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public SysDeleteCasCheck GetEntity(string id)
        { 
            return Dal.Find<SysDeleteCasCheck>(id);
        }

  


    }


}

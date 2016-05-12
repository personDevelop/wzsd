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
    public class SearchKeyWordDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SearchKeyWord", "ID", id, out error);
            return error;
        }

        public int Save(SearchKeyWord item)
        {
            return Dal.Submit(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<SearchKeyWord>().Select(SearchKeyWord._.ID, SearchKeyWord._.SKey).OrderBy(SearchKeyWord._.OrderNo).
                    ToDataTable();
            }
            else
                return Dal.From<SearchKeyWord>().OrderBy(SearchKeyWord._.OrderNo).ToDataTable();
        }
        public bool Exit(string val)
        {
            WhereClip where = SearchKeyWord._.SKey == val;

            return !Dal.Exists<SearchKeyWord>(where);
        }

        public  string[] GetKeyList(bool isHot=true)
        {
            WhereClip where = SearchKeyWord._.IsHot == isHot;

            return  Dal.From<SearchKeyWord>().Where(where).OrderBy(SearchKeyWord._.OrderNo,SearchKeyWord._.SearchCount)
                .Select(SearchKeyWord._.SKey).ToSinglePropertyArray();
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<SearchKeyWord>().Select(SearchKeyWord._.ID, SearchKeyWord._.SKey).OrderBy(SearchKeyWord._.OrderNo).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<SearchKeyWord>() .OrderBy(SearchKeyWord._.SearchCount.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
    
        public SearchKeyWord GetEntity(string id)
        {
           

            return Dal.Find<SearchKeyWord>(id);
        }

 

    }


}

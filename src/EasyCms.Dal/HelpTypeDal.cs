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
    public class HelpTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("HelpType", "ID", id, out error);
            return error;
        }

        public int Save(HelpType item)
        {
            return CommonDal.UpdatePath<HelpType>(Dal, item, HelpType._.ID, HelpType._.ParentID, HelpType._.ClassCode, HelpType._.OrderNo, HelpType._.Series, HelpType._.IsDetails);


        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<HelpType>().Select(HelpType._.ID, HelpType._.ParentID, HelpType._.Code, HelpType._.Name).OrderBy(HelpType._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<HelpType>().OrderBy(HelpType._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = HelpType._.ParentID == parentID;

            if (IsCode)
            {
                where = where && HelpType._.Code == val;
            }
            else
            {
                where = where && HelpType._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && HelpType._.ID != ID;

            }
            return !Dal.Exists<HelpType>(where);
        }

        public List<HelpType> GetFootList()
        {
            return Dal.From<HelpType>().Where(HelpType._.IsShowButtom == true && HelpType._.ParentID.IsNullOrEmpty())
                 .Select(HelpType._.ID, HelpType._.Name).List<HelpType>();
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<HelpType>().Where(HelpType._.ParentID == parentId).OrderBy(HelpType._.OrderNo).ToDataTable();

        }
        public HelpType GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<HelpType>("a").Join<HelpType>("b", new WhereClip("a.parentId=b.id"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<HelpType>();
        }


    }


}

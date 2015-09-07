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
    public class FunctionInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            return "删除失败";

        }

        public int Save(FunctionInfo item)
        {
            return CommonDal.UpdatePath<FunctionInfo>(Dal, item, FunctionInfo._.ID, FunctionInfo._.ParentID, FunctionInfo._.ClassCode, FunctionInfo._.OrderNo, FunctionInfo._.Js,null);
            

        }


        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = FunctionInfo._.ParentID == parentID;

            if (IsCode)
            {
                where = where && FunctionInfo._.Code == val;
            }
            else
            {
                where = where && FunctionInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && FunctionInfo._.ID != ID;

            }
            return !Dal.Exists<FunctionInfo>(where);
        }
        public DataTable GetList(bool IsForSelected = false)
        {

            if (IsForSelected)
            {
                return Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.ShowText, FunctionInfo._.Name, FunctionInfo._.ParentID).
                    OrderBy(FunctionInfo._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<FunctionInfo>().
                   OrderBy(FunctionInfo._.OrderNo).ToDataTable();
        }
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ParentID == parentId).OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }
        public FunctionInfo GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<FunctionInfo>("a").Join<FunctionInfo>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<FunctionInfo>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ID != classCode && FunctionInfo._.ClassCode.StartsWith(classCode)).OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.ParentID == parentId).OrderBy(FunctionInfo._.OrderNo).Select(FunctionInfo._.Name).ToSinglePropertyArray();
        }



        public DataTable GetParentMoudle()
        {
            int pageCount = 0;
            return Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.ShowText, FunctionInfo._.Name, FunctionInfo._.ParentID, FunctionInfo._.AccessType).
                    Where(FunctionInfo._.Enable == true && FunctionInfo._.AccessType < 2).
                    OrderBy(FunctionInfo._.OrderNo).ToDataTable();
        }

        public List<FunctionInfo> GetListWithUrl(int funcType)
        {
            List<FunctionInfo> list=
             Dal.From<FunctionInfo>().
                    Select(FunctionInfo._.ID, FunctionInfo._.ShowText, FunctionInfo._.ClassCode, FunctionInfo._.AccessType, FunctionInfo._.ParentID, FunctionInfo._.URL, FunctionInfo._.CallArea, FunctionInfo._.CallControler, FunctionInfo._.CallAction, FunctionInfo._.Description, FunctionInfo._.Js).
                    Where(FunctionInfo._.Enable == true && FunctionInfo._.FuncType == funcType)
                    .OrderBy(FunctionInfo._.Js,FunctionInfo._.OrderNo).
                     List<FunctionInfo>(); 
            return list ;
        }
    }

}

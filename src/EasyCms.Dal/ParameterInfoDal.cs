using EasyCms.Model;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Dal
{
    public class ParameterInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }
            ParameterInfo p = GetEntity(id);
            if (p.IsSystem)
            {
                return "系统参数不能删除";
            }
            else if (!p.IsDelete)
            {
                return "当前参数不允许删除";
            }
            int i = Dal.Delete<ParameterInfo>(ParameterInfo._.ClassCode.StartsWith(p.ClassCode));
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除" + i + "个参数";
            }
        }

        public int Save(ParameterInfo item)
        {
            return CommonDal.UpdatePath<ParameterInfo>(Dal, item, ParameterInfo._.ID, ParameterInfo._.ParentID, ParameterInfo._.ClassCode, ParameterInfo._.OrderNo, ParameterInfo._.Series, ParameterInfo._.IsDetails);
            

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ParameterInfo>().Select(ParameterInfo._.ID, ParameterInfo._.ParentID, ParameterInfo._.Code, ParameterInfo._.Name, ParameterInfo._.IsCanHasLeaf).OrderBy(ParameterInfo._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ParameterInfo>().OrderBy(ParameterInfo._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = ParameterInfo._.ParentID == parentID;

            if (IsCode)
            {
                where = where && ParameterInfo._.Code == val;
            }
            else
            {
                where = where && ParameterInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ParameterInfo._.ID != ID;

            }
            return !Dal.Exists<ParameterInfo>(where);
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ParentID == parentId).OrderBy(ParameterInfo._.OrderNo).ToDataTable();

        }
        public ParameterInfo GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<ParameterInfo>("a").Join<ParameterInfo>("b", new WhereClip("a.parentId=b.id"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<ParameterInfo>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ID != classCode && ParameterInfo._.ClassCode.StartsWith(classCode)).OrderBy(ParameterInfo._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ParentID == parentId).OrderBy(ParameterInfo._.OrderNo).Select(ParameterInfo._.Name).ToSinglePropertyArray();
        }



        public string GetRegistAgreement()
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ID == StaticValue.RegistAgreementID).Select(ParameterInfo._.Value5).ToScalar() as string;
        }

        public DataTable GetIdAndNameByParentId(string parentID)
        {
            return Dal.From<ParameterInfo>().Where(ParameterInfo._.ParentID == parentID && ParameterInfo._.IsEnable == true)
                .Select(ParameterInfo._.ID, ParameterInfo._.Name).ToDataTable();

        }
    }
}

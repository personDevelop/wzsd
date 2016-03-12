using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Sharp.Common;

namespace EasyCms.Business
{
    public class ParameterInfoBll
    {
        ParameterInfoDal Dal = new ParameterInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ParameterInfo item)
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
        public List<ParameterInfo> GetListEntityByParentId(string parentId)
        {
            return GetListByParentId(parentId).ToList<ParameterInfo>();

        }
        public ParameterInfo GetEntity(string id)
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


        public string GetValue(string id, int valOrderNo = 1)
        {
            ParameterInfo p = GetEntity(id);
            switch (valOrderNo)
            {
                case 2:
                    return p.Value2;

                case 3:
                    return p.Value3;
                case 4:
                    return p.Value4;
                case 5:
                    return p.Value5;
                case 0:
                case 1:
                default:
                    return p.Value;
            }
        }
        public string[] GetTwoValue(string id)
        {

            string[] vlas = new string[2];

            ParameterInfo p = GetEntity(id);
            vlas[0] = p.Value;
            vlas[1] = p.Value2;
            return vlas;
        }



        #region 常量参数
        /// <summary>
        /// 日志记录等级
        /// </summary>
        public const string LogWriterOrder = "56bf6b05-339d-4aeb-90cd-c869e95d4e44";
        #endregion


        public string GetParaValue5(string paraID)
        {
            return Dal.GetParaValue5(paraID);
        }


        public DataTable GetIdAndNameByParentId(string parentID)
        {
            return Dal.GetIdAndNameByParentId(parentID);
        }
    }
}

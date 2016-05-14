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
    public class AdministrativeRegionsDal : Sharp.Data.BaseManager
    {
        public string Delete(string strid)
        {
            int id = -9999;
            if (int.TryParse(strid, out id))
            {
                AdministrativeRegions ad = Dal.Find<AdministrativeRegions>(id);
                if (ad == null)
                {
                    return "删除失败，行政区域ID不合法";

                }
                else
                {
                    AdministrativeRegions updatead = new AdministrativeRegions();
                    updatead.Where = AdministrativeRegions._.FullPath.StartsWith(ad.FullPath + "|") || AdministrativeRegions._.ID == id;
                    updatead.IsStop = true;
                    Dal.Submit(updatead);
                    return "成功删除行政区域";
                }
            }
            else
            {
                return "删除失败，行政区域ID不合法";
            }


        }

        public int Save(AdministrativeRegions item)
        {
            //分级码 级数     顺序
            /*如果是新增的   
             有上级  则更新上级为 是否明细  =false , 分级码重新计算分级码 
             */


            try
            {
                AdministrativeRegions parent = null;
                if (item.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (item.ParentID == 0)
                    {
                        item.FullPath = item.ID.ToString();
                        item.Path = item.Name;
                        item.Jb = 1;
                    }
                    else
                    {
                        parent = GetEntity(item.ParentID.ToString());
                        item.FullPath = parent.FullPath + "|" + item.ID;
                        item.Path = parent.Path + "|" + item.Name;
                        item.Jb = parent.Jb + 1;
                    }
                }
                Dal.Submit(item);
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<AdministrativeRegions> GetRegionPathWithNotRoot(int regeonID)
        {
            AdministrativeRegions curent= Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID == regeonID).Select(AdministrativeRegions._.FullPath, AdministrativeRegions._.Jb).ToFirst<AdministrativeRegions>();
            string fullpath = curent.FullPath;
           fullpath=fullpath.Substring( fullpath.IndexOf('|', 2));
            List<AdministrativeRegions> list= Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.FullPath.StartsWith(fullpath)&& AdministrativeRegions._.Jb<=curent.Jb)
            .Select  (AdministrativeRegions._.ID, AdministrativeRegions._.Code, AdministrativeRegions._.Name, AdministrativeRegions._.ParentID, AdministrativeRegions._.Path, AdministrativeRegions._.FullPath)
                    
                    .OrderBy(AdministrativeRegions._.Code).List<AdministrativeRegions>();
            return list;


        }

        public bool Exit(int ID, int parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = AdministrativeRegions._.Code == val;
            }
            else
            {
                where = where && AdministrativeRegions._.ParentID == parentID;
                where = AdministrativeRegions._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && AdministrativeRegions._.ID != ID;

            }
            return !Dal.Exists<AdministrativeRegions>(where);
        }
        public DataTable GetList(int parentID, bool IsForSelected = false)
        {

            if (IsForSelected)
            {
                return Dal.From<AdministrativeRegions>().
                    Select(AdministrativeRegions._.ID, AdministrativeRegions._.Code, AdministrativeRegions._.Name, AdministrativeRegions._.ParentID, AdministrativeRegions._.Path, AdministrativeRegions._.FullPath)
                    .Where(AdministrativeRegions._.ParentID == parentID)
                    .OrderBy(AdministrativeRegions._.Code).ToDataTable();
            }
            else
                return Dal.From<AdministrativeRegions>()
                    .Where(AdministrativeRegions._.ParentID == parentID)
                    .OrderBy(AdministrativeRegions._.Code).ToDataTable();
        }

        public AdministrativeRegions GetEntity(string strid)
        {
            int id = -999;
            if (int.TryParse(strid, out id))
            {
                WhereClip where = new WhereClip("a.id=@id");
                where.Parameters.Add("id", id);

                return Dal.From<AdministrativeRegions>("a").Join<AdministrativeRegions>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                    .Select(new ExpressionClip("a.*,b.Name ParentName"))
                    .Where(where)
                    .ToFirst<AdministrativeRegions>();
            }
            else
            { return null; }

        }


        public System.Data.DataTable GetListByFullPath(string classCode)
        {
            return Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID != classCode && AdministrativeRegions._.FullPath.StartsWith(classCode)).OrderBy(AdministrativeRegions._.Code).ToDataTable();

        }

        public string[] GetNameByParentId(int parentId)
        {
            return Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ParentID == parentId).OrderBy(AdministrativeRegions._.Code).Select(AdministrativeRegions._.Name).ToSinglePropertyArray();
        }



        public DataTable GetOne(int id)
        {
            return Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID == id).ToDataTable();

        }

        public DataTable GetPathByFullPath(string fullPath)
        {
            return Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID.In(fullPath.Split('|')))
                .OrderBy(AdministrativeRegions._.Jb).ToDataTable();

        }

        public string GetPathByDefault(int id)
        {
            if (id > 0)
            {
                string result = Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID == id)
                    .Select(AdministrativeRegions._.FullPath).ToScalar().ToString();
                int index = result.IndexOf("|");
                if (index > -1)
                {
                    result = result.Substring(index + 1);
                }
                return result;
            }
            return string.Empty;
        }
    }


}

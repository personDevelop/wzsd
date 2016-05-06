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
    public class AdManageDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("AdManage", "ID", id, out error);
            return error;
        }

        public int Save(AdManage item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<AdManage>().Select(AdManage._.ID, AdManage._.Name, AdManage._.AdType).OrderBy(AdManage._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<AdManage>().OrderBy(AdManage._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = AdManage._.Code == val;
            }
            else
            {
                where = AdManage._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && AdManage._.ID != ID;

            }
            return !Dal.Exists<AdManage>(where);
        }

        public AdManage GetOnAdByPosition(string posiontCode)
        {
            AdPositon posionEntity = Dal.From<AdPositon>().Where(AdPositon._.Code == posiontCode).ToFirst<AdPositon>();

            return Dal.From<AdManage>().Join<AttachFile>(AdManage._.ImgageID == AttachFile._.RefID,JoinType.leftJoin)
                  .Select(AdManage._.Note, AdManage._.LinkUrl, AdManage._.Name, AttachFile.GetFilePath("", "AdImgUrl"))
                  .Where(AdManage._.PositionID == posionEntity.ID).OrderBy(AdManage._.OrderNo).ToFirst<AdManage>();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posiontCode"></param>
        /// <param name="count">0 不限制</param>
        /// <returns></returns>
        public List<AdManage> GetAdByPositon(string posiontCode, int count, ref AdPositon posionEntity)
        {
            posionEntity = Dal.From<AdPositon>().Where(AdPositon._.Code == posiontCode).ToFirst<AdPositon>();

            QuerySection qry = Dal.From<AdManage>().Join<AttachFile>(AdManage._.ImgageID == AttachFile._.RefID, JoinType.leftJoin
)
              .Select(AdManage._.Note, AdManage._.LinkUrl, AdManage._.Name, AttachFile.GetFilePath("", "AdImgUrl"))
              .Where(AdManage._.PositionID == posionEntity.ID).OrderBy(AdManage._.OrderNo);
            if (count > 0)
            {
                return qry.ToDataTable(count).ToList<AdManage>();
            }
            else

                return qry.List<AdManage>();
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<AdManage>().Join<AdPositon>(AdManage._.PositionID == AdPositon._.ID, JoinType.leftJoin)
             .Select(AdManage._.ID.All, AdPositon._.Name.Alias("PositionName"))
            .OrderBy(AdManage._.PositionID, AdManage._.OrderNo)

                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public AdManage GetEntity(string id)
        {
            WhereClip where = AdManage._.ID == id;
            return Dal.From<AdManage>().Join<AdPositon>(AdManage._.PositionID == AdPositon._.ID, JoinType.leftJoin)
                .Select(AdManage._.ID.All, AdPositon._.Name.Alias("PositionName"))
                .Where(where)
                .ToFirst<AdManage>();
        }



    }


}

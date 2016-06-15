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
    public class ShopActivityDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopGroupBuy", "ID", id, out error);
            return error;
        }

        public int Save(ShopGroupBuy item)
        {
            return Dal.Submit(item);
        }



        public DataTable GetList(string name, int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
            WhereClip where = ShopGroupBuy._.ActivityName.Contains(name) || ShopGroupBuy._.ActivityTitle.Contains(name);
            return Dal.From<ShopGroupBuy>().Select(ShopGroupBuy._.ID, ShopGroupBuy._.ActivityName, ShopGroupBuy._.ActivityTitle,
                   ShopGroupBuy._.StartDate, ShopGroupBuy._.EndDate
                   , ShopGroupBuy._.FinePrice, ShopGroupBuy._.GroupCount, ShopGroupBuy._.LimitQty
                   , ShopGroupBuy._.MaxCount, ShopGroupBuy._.BuyCount, ShopGroupBuy._.Sequence
                   , ShopGroupBuy._.Status).Where(where).OrderBy(ShopGroupBuy._.CreateDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public string RemoveIDTime(string rlationTimeIDs)
        {
            string[] ids = rlationTimeIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dal.Delete<ShopCountDownTime>(ShopCountDownTime._.ID.In(ids));
            return string.Empty;
        }

        public DataTable GetShopCountDownList(string name, int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
            WhereClip where = ShopCountDown._.ActivityName.Contains(name) || ShopCountDown._.ActivityTitle.Contains(name);
            return Dal.From<ShopCountDown>().Select(ShopCountDown._.ID, ShopCountDown._.ActivityName, ShopCountDown._.ActivityTitle,
                   ShopCountDown._.LoopType, ShopCountDown._.IsLimit
                 , ShopCountDown._.SendJf, ShopCountDown._.ActivityType
                   , ShopCountDown._.MaxCount, ShopCountDown._.BuyCount
                   , ShopCountDown._.ActivityStatus).Where(where).OrderBy(ShopCountDown._.CreateDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);

        }

        public ShopCountDown GetShopCountDownEntity(string activityID)
        {
            return Dal.Find<ShopCountDown>(activityID);
        }

        public DataTable GetSubList(string activityID)
        {
            DataTable dt = Dal.From<ShopCountProducnt>().Where(ShopCountProducnt._.ActivityID == activityID && ShopCountProducnt._.SKUID.IsNullOrEmpty())
               .Join<ShopProductInfo>(ShopCountProducnt._.ProductId == ShopProductInfo._.ID).Select(ShopCountProducnt._.ID,
               ShopCountProducnt._.OldPrice, ShopCountProducnt._.Price, ShopProductInfo._.Name.Alias("ProductName"), new ExpressionClip("''").Alias("SKUName"))
               .ToDataTable();
            DataTable dt1 = Dal.From<ShopCountProducnt>().Where(ShopCountProducnt._.ActivityID == activityID)
               .Join<View_ProductInfoBySkuid>(ShopCountProducnt._.SKUID == View_ProductInfoBySkuid._.SKUID).Select(ShopCountProducnt._.ID,
               ShopCountProducnt._.OldPrice, ShopCountProducnt._.Price, View_ProductInfoBySkuid._.Name.Alias("ProductName"), View_ProductInfoBySkuid._.SKUName)
               .ToDataTable();
            int maxCount = Math.Max(dt.Rows.Count, dt1.Rows.Count);
            if (maxCount == 0)
            {
                return dt;
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        dt.Merge(dt1);
                    }
                }
                else
                {

                    return dt1;
                }
            }
            return dt;
        }

        public ShopCountDownTime GetShopCountTime(string id)
        {
            return Dal.Find<ShopCountDownTime>(id);
        }

        public string SaveShopCountDownTime(ShopCountDownTime p)
        {
            string msg = "";
            ///检测天数是否为0
            if (p.EndDate <= p.StartDate)
            {
                msg = "截止时间必须大于开始时间";
            }
            else
            {
                switch (p.LoopType)
                {
                    case LoopType.固定日期:
                        if (!p.StaticDate.HasValue || p.StaticDate.Value < DateTime.Now)
                        {
                            msg = "日期不能为空，且必须大于当前时间";
                        }
                        break;
                    case LoopType.天:
                        if (p.WeekOrDay <= 0 || p.WeekOrDay > 28)
                        {
                            msg = "每月天数范围为1-28号";
                        }
                        break;
                    case LoopType.周:
                        if (p.WeekOrDay <= 0 || p.WeekOrDay > 7)
                        {
                            msg = "每周只有七天，请填写正确的星期数";
                        }
                        break;
                    default:
                        break;
                }
                
            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                //检测是否有交叉的情况
                DataTable dt = Dal.FromCustomSql(@" select 1 from ShopCountDownTime  where   ActivityID=@ActivityID and  ID!@ID and 
 ( @StartDate BETWEEN  StartDate and  EndDate or @EndDate BETWEEN StartDate and  EndDate  )
  and  isnull( StaticDate,' ') =isnull(@StaticDate,' ') and  WeekOrDay=@WeekOrDay and looptype=@LoopType ")
    .AddInputParameter("ActivityID", p.ActivityID).AddInputParameter("ID", p.ID).AddInputParameter("StartDate", p.StartDate)
    .AddInputParameter("EndDate", p.EndDate).AddInputParameter("StaticDate", p.StaticDate).AddInputParameter("WeekOrDay", p.WeekOrDay).AddInputParameter("LoopType", p.LoopType)
    .ToDataTable();
                if (dt.Rows.Count > 0)
                {
                    msg = "时间范围有交叉，请修改后重新保存";
                }
            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                Dal.Submit(p);
            }
            return "";
        }

        public string RemoveIDTimeByActivityID(string activityID)
        {
            Dal.Delete<ShopCountDownTime>(ShopCountDownTime._.ActivityID == activityID);
            return "删除成功";
        }

        public DataTable GetSubTimeList(string activityID)
        {
            return Dal.From<ShopCountDownTime>().Where(ShopCountDownTime._.ActivityID == activityID)

                .ToDataTable();
        }

        public string SaveShopCountDown(ShopCountDown p)
        {
            Dal.Submit(p);
            return string.Empty;
        }

        public string DeleteShopCountDown(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopCountDown", "ID", id, out error);
            return error;
        }

        public string IsQyOrStopCuoutDown(string activityID, int opcode)
        {
            string result = "操作成功";
            ShopCountDown entity = Dal.Find<ShopCountDown>(activityID);
            if (opcode == 1)//启动
            {
                //且当前状态是停止状态

                if (entity.ActivityStatus == AcitivyStatus.制单 || entity.ActivityStatus == AcitivyStatus.停用)
                {
                    //先判断当前活动下有没有商品，}
                    bool isexst = Dal.Exists<ShopCountProducnt>(ShopCountProducnt._.ActivityID == activityID);
                    if (!isexst)
                    {
                        result = "当前活动还没有添加商品，启动失败";
                    }
                    else
                    {
                        isexst = Dal.Exists<ShopCountDownTime>(ShopCountDownTime._.ActivityID == activityID);
                        if (!isexst)
                        {
                            result = "当前活动还没有设置活动时间，启动失败";
                        }
                        else
                        {
                            if (entity.LoopType == LoopType.固定日期)
                            {
                                //查询其最后日期是否小于当前日期
                                DateTime dt =Convert.ToDateTime( Dal.Max<ShopCountDownTime>(ShopCountDownTime._.ActivityID == activityID, ShopCountDownTime._.StaticDate));
                                if (dt < DateTime.Now)
                                {
                                    result = "当前活动已经过了结束时间，不能启动";
                                }

                            }

                        }
                    }

                    if (string.IsNullOrWhiteSpace(result))
                    {
                        entity.ActivityStatus = AcitivyStatus.进行中;
                    }
                }
                else
                {
                    result = string.Format("当前活动状态【{0}】启动失败", entity.ActivityStatus);
                }
            }
            else if (opcode == 0)//停止
            {
                //当前状态是不是启动状态
                //且当前状态是停止状态

                if (entity.ActivityStatus == AcitivyStatus.进行中)
                {

                    //然后判断当前活动有没有结束

                    entity.ActivityStatus = AcitivyStatus.停用;

                }
                else
                {
                    result = string.Format("当前活动状态【{0}】停止失败", entity.ActivityStatus);
                }
            }
            if (string.IsNullOrWhiteSpace(result) || result.Equals("操作成功"))
            {
                Dal.Submit(entity);
            }
            return result;
        }

        public string IsQyOrStop(string id, int opcode)
        {
            string result = "操作成功";
            ShopGroupBuy entity = Dal.Find<ShopGroupBuy>(id);
            if (opcode == 1)//启动
            {
                //且当前状态是停止状态

                if (entity.Status == AcitivyStatus.制单 || entity.Status == AcitivyStatus.停用)
                {

                    //然后判断当前活动有没有结束
                    if (entity.EndDate < DateTime.Now)
                    {
                        result = "当前活动已经过了结束时间，不能启动";
                    }
                    else
                    {  //先判断当前活动下有没有商品，}
                        bool isexst = Dal.Exists<ShopCountProducnt>(ShopCountProducnt._.ActivityID == id);
                        if (isexst)
                        {
                            entity.Status = AcitivyStatus.进行中;
                        }
                        else
                        {
                            result = "当前活动还没有添加商品，启动失败";
                        }
                    }
                }
                else
                {
                    result = string.Format("当前活动状态【{0}】启动失败", entity.Status);
                }
            }
            else if (opcode == 0)//停止
            {
                //当前状态是不是启动状态
                //且当前状态是停止状态

                if (entity.Status == AcitivyStatus.进行中)
                {

                    //然后判断当前活动有没有结束

                    entity.Status = AcitivyStatus.停用;

                }
                else
                {
                    result = string.Format("当前活动状态【{0}】停止失败", entity.Status);
                }
            }
            if (string.IsNullOrWhiteSpace(result) || result.Equals("操作成功"))
            {
                Dal.Submit(entity);
            }
            return result;
        }

        public ShopCountProducnt GetShopCountProducnt(string id)
        {
            ShopCountProducnt P = Dal.From<ShopCountProducnt>().Join<ShopProductInfo>(ShopProductInfo._.ID == ShopCountProducnt._.ProductId)
                .Select(ShopCountProducnt._.ID.All, ShopProductInfo._.Name.Alias("ProductName")).Where(ShopCountProducnt._.ID == id).ToFirst<ShopCountProducnt>();
            if (!string.IsNullOrWhiteSpace(P.SKUID))
            {
                P.SKUCode = Dal.From<View_ProductInfoBySkuid>().Where(View_ProductInfoBySkuid._.SKUID == P.SKUID).Select(View_ProductInfoBySkuid._.SKUName).ToScalar() as string;
            }

            return P;
        }

        public string SaveShopCountProducnt(ShopCountProducnt p)
        {
            if (Dal.Exists<ShopCountProducnt>(ShopCountProducnt._.ActivityID == p.ActivityID && ShopCountProducnt._.ProductId == p.ProductId && ShopCountProducnt._.ID != p.ID))
            {
                return "当前活动已存在该商品，不能添加";
            }
            Dal.Submit(p);
            return string.Empty;
        }

        public ShopGroupBuy GetEntity(string id)
        {
            return Dal.Find<ShopGroupBuy>(id);
        }




        public string RemoveIDProduct(string RlationProductIDs)
        {
            string[] ids = RlationProductIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dal.Delete<ShopCountProducnt>(ShopCountProducnt._.ID.In(ids));
            return string.Empty;

        }

    }


}

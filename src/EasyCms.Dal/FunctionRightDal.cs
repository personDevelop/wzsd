using EasyCms.Model;
using EasyCms.Model.ViewModel;
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
    public class FunctionRightDal : Sharp.Data.BaseManager
    {




        public DataTable GetRoleOrMemberOrderList(int id)
        {
            if (id == 0)
            {
                return Dal.From<SysRoleInfo>().Where(SysRoleInfo._.Enable == true)
                    .OrderBy(SysRoleInfo._.Code)
                    .Select(SysRoleInfo._.ID, SysRoleInfo._.Code, SysRoleInfo._.Name).ToDataTable();

            }
            else
            {
                return Dal.From<RangeDict>().Where(RangeDict._.IsEnable == true).OrderBy(RangeDict._.RankLevel)
                    .Select(RangeDict._.ID, RangeDict._.RankLevel.Alias("Code"), RangeDict._.Name).ToDataTable();

            }
        }

        public DataTable GetRightList(string roleID, bool isAll, int sqtype)
        {
            WhereClip where = FunctionInfo._.IsMustNot == false ;
            if (sqtype == 0)
            {
                where =where&& FunctionInfo._.FuncType.In(new int[] { 0, 1 });
            }
            else
            {
                where =where&& FunctionInfo._.FuncType == 2;
            }
            DataTable dt = null;
            if (isAll)
            {
                dt = Dal.From<FunctionInfo>()
                     .Where(where)
                    .Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.Name, FunctionInfo._.FuncType, FunctionInfo._.ParentID,
                    FunctionInfo._.Js,
                    FunctionInfo._.ClassCode
                        ).OrderBy(FunctionInfo._.OrderNo)
                        .ToDataTable();
                dt.Columns.Add("IsVisble", typeof(bool));
                dt.Columns.Add("IsEnable", typeof(bool));
            }
            else
            {

                dt = Dal.From<FunctionInfo>().Join<FunctionRight>(FunctionInfo._.ID == FunctionRight._.FunID
                  && FunctionRight._.RoleID == roleID
                  , JoinType.leftJoin).OrderBy(FunctionInfo._.OrderNo)
                   .Where(where)
                  .Select(FunctionInfo._.ID, FunctionInfo._.Code, FunctionInfo._.Name, FunctionInfo._.FuncType, FunctionInfo._.ParentID,
                  FunctionInfo._.Js, FunctionInfo._.ClassCode, FunctionRight._.IsEnable, FunctionRight._.IsVisble
                      ).ToDataTable();




            }
            return dt;
        }

        public string SaveRight(SaveModel saveModel)
        {
            string typename = "角色";
            if (saveModel.Sqtype == 1)
            {
                typename = "会员等级";
            }
            string result = "";
            if (saveModel.RightData == null || saveModel.RightData.Count == 0)
            {
                result = "请先勾选要授权的功能,否则不能授权";
            }
            else
            {
                List<FunctionRight> list = new List<FunctionRight>();
                if (saveModel.IsAll)
                {
                    //统一授权，只增，不删
                    string[] roleList = null;
                    if (saveModel.Sqtype == 0)
                    {
                        //角色，先查出所有角色
                        roleList = Dal.From<SysRoleInfo>().Where(SysRoleInfo._.Enable == true).Select(SysRoleInfo._.ID).ToSinglePropertyArray();

                    }
                    else
                    {
                        //会员等级，先查出所有会员等级

                        roleList = Dal.From<RangeDict>().Where(RangeDict._.IsEnable == true).Select(RangeDict._.ID).ToSinglePropertyArray();
                    }
                    if (roleList != null && roleList.Length > 0)
                    {

                        //先按照功能，将权限表中删掉
                        FunctionRight deleteFr = new FunctionRight()
                        {
                            RecordStatus = StatusType.delete,
                            Where = FunctionRight._.FunID.In(saveModel.RightData.Select(p => p.ID).ToArray())
                        };
                        list.Add(deleteFr);
                        foreach (string roleid in roleList)
                        {
                            foreach (RightData item in saveModel.RightData)
                            {
                                FunctionRight fr = new FunctionRight()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    RoleID = roleid,
                                    FunID = item.ID,
                                    IsEnable = item.IsEnable,
                                    IsVisble = item.IsVisble,
                                    RoleType = saveModel.Sqtype
                                };
                                list.Add(fr);
                            }
                        }


                    }
                    else
                    {
                        result = "当前系统没有" + typename + ",不能授权";
                    }
                }
                else
                {
                    //按照角色授权
                    if (string.IsNullOrWhiteSpace(saveModel.RoleID))
                    {
                        result = "请选择要授权的" + typename;
                    }
                    else
                    {
                        //先将当前角色的权限删掉，然后重新增加
                        FunctionRight deleteFr = new FunctionRight()
                        {
                            RecordStatus = StatusType.delete,
                            Where = FunctionRight._.RoleID == saveModel.RoleID
                        };
                        list.Add(deleteFr);
                        foreach (RightData item in saveModel.RightData)
                        {
                            FunctionRight fr = new FunctionRight()
                            {
                                ID = Guid.NewGuid().ToString(),
                                RoleID = saveModel.RoleID,
                                FunID = item.ID,
                                IsEnable = item.IsEnable,
                                IsVisble = item.IsVisble,
                                RoleType = saveModel.Sqtype
                            };
                            list.Add(fr);
                        }
                    }

                }
                if (list.Count > 0)
                {
                    SessionFactory dal;
                    IDbTransaction tr = Dal.BeginTransaction(out dal);
                    try
                    {
                        dal.SubmitNew(tr, ref dal, list);
                        dal.CommitTransaction(tr);
                        //清空缓存
                        CacheContainer.RemoveCache(StaticValue.FunctionRightCachKey);
                    }
                    catch (Exception)
                    {
                        dal.RollbackTransaction(tr);
                        throw;
                    }
                }
            }
            return result;
        }

        public List<FunctionRight> GetAllRight()
        {
            return Dal.From<FunctionRight>()

              .Select(FunctionRight._.RoleID, FunctionRight._.FunID, FunctionRight._.IsEnable, FunctionRight._.IsVisble
                  ).List<FunctionRight>();
        }
    }


}

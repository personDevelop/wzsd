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
    public static class CommonDal
    {
        public static int UpdatePath<T>(this SessionFactory Dal, T entity, PropertyItem IdName, PropertyItem parentIdName, PropertyItem classCodeName, PropertyItem OrderNumName,
            PropertyItem depthName, PropertyItem isMxName) where T : BaseEntity, new()
        {
            //分级码 级数     顺序
            /*如果是新增的   
             有上级  则更新上级为 是否明细  =false , 分级码重新计算分级码 
             */
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {
                T updateChild = null;
                T whereOrderEntity = null;
                T parent = null;
                string id = entity.GetPropertyValue(IdName) as string;
                string parentID = entity.GetPropertyValue(parentIdName) as string;
                string classCode = entity.GetPropertyValue(classCodeName) as string;//原来的分级码 
                string newclassCode = null;
                int seriesChaZhi = 0;
                int depth = 1;
                if (!WhereClip.IsNullOrEmpty(depthName))
                {
                    depth = (int)entity.GetPropertyValue(depthName);
                }
                int OrderNum = -1;
                if (!WhereClip.IsNullOrEmpty(OrderNumName))
                {
                    OrderNum = (int)entity.GetPropertyValue(OrderNumName);
                }
                bool ChangeParent = false;
                if (string.IsNullOrEmpty(parentID))
                {
                    if (entity.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        //这种情况 直接赋值
                        newclassCode = id;
                        depth = 1;
                        seriesChaZhi = depth;
                        if (!WhereClip.IsNullOrEmpty(OrderNumName))
                        {
                            OrderNum = Dal.Count<T>(parentIdName.IsNullOrEmpty(), IdName, false) + 1;
                        }
                    }
                    else
                    {
                        if (id != classCode)
                        {
                            //说明是从非根级调整到根级节点 ,这种情况需要批量调整下级节点
                            ChangeParent = true;
                            newclassCode = id;
                            int oldDepth = depth;
                            depth = 1;
                            seriesChaZhi = depth - oldDepth;//级数调整前后的差值
                            if (!WhereClip.IsNullOrEmpty(OrderNumName))
                            {
                                OrderNum = Dal.Count<T>(parentIdName.IsNullOrEmpty(), IdName, false) + 1;
                            }

                        }
                    }
                }
                else
                {


                    if (entity.RecordStatus == Sharp.Common.StatusType.add)
                    {
                        parent = Dal.Find<T>(parentID);
                        string parentClassCode = parent.GetPropertyValue(classCodeName) as string;
                        newclassCode = parentClassCode + ";" + id;
                        depth = newclassCode.Count(p => p == ';') + 1;
                        seriesChaZhi = depth;
                        if (!WhereClip.IsNullOrEmpty(OrderNumName))
                        {
                            OrderNum = Dal.Count<T>(parentIdName == parentID, IdName, false) + 1;
                        }
                    }
                    else
                    {
                        if (!classCode.EndsWith(parentID + ";" + id))
                        {

                            parent = Dal.Find<T>(parentID);
                            string parentClassCode = parent.GetPropertyValue(classCodeName) as string;
                            //调整父编码了 ,这种情况需要批量调整下级节点
                            ChangeParent = true;
                            newclassCode = parentClassCode + ";" + id;
                            int oldDepth = depth;
                            depth = newclassCode.Count(p => p == ';') + 1;
                            seriesChaZhi = depth - oldDepth;//级数调整前后的差值
                            if (!WhereClip.IsNullOrEmpty(OrderNumName))
                            {
                                OrderNum = Dal.Count<T>(parentIdName == parentID, IdName, false) + 1;
                            }
                        }
                    }
                }

                if (!WhereClip.IsNullOrEmpty(classCodeName) && newclassCode != null)
                {
                    entity.SetModifiedProperty(classCodeName, newclassCode);
                }
                if (!WhereClip.IsNullOrEmpty(depthName) && seriesChaZhi != 0)
                {
                    entity.SetModifiedProperty(depthName, depth);
                }
                if (!WhereClip.IsNullOrEmpty(OrderNumName) && OrderNum > -1)
                {

                    entity.SetModifiedProperty(OrderNumName, OrderNum);
                }
                if (ChangeParent)
                {
                    updateChild = new T();
                    updateChild.RecordStatus = StatusType.update;
                    ExpressionClip classCodeExpress = new ExpressionClip("Replace(ClassCode,@classcode,@newParentClassCOde)");
                    classCodeExpress.Parameters.Add("classcode", classCode);
                    classCodeExpress.Parameters.Add("newParentClassCOde", newclassCode);
                    updateChild.SetModifiedProperty(classCodeName, classCodeExpress);
                    updateChild.Where = classCodeName.StartsWith(classCode + ";");
                    updateChild.SetModifiedProperty(classCodeName, classCodeExpress);
                    if (!WhereClip.IsNullOrEmpty(depthName) && seriesChaZhi != 0)
                    {
                        ExpressionClip DepthExpress = new ExpressionClip("Depth+@Depth");
                        DepthExpress.Parameters.Add("Depth", seriesChaZhi);
                        updateChild.SetModifiedProperty(depthName, DepthExpress);
                    }




                }
                else
                    if (entity.ChangedProperties != null && entity.ChangedProperties.ContainsKey(OrderNumName.ColumnName))
                    {
                        //说明调整过顺序，那就完蛋了，需要重新调整顺序了啊啊啊
                        int oldOrder = (int)entity.ChangedProperties[OrderNumName.ColumnName].OldValue;
                        WhereClip whereOrder = new WhereClip();
                        ExpressionClip orderNumExpress = null;
                        if (oldOrder > OrderNum)
                        {
                            //说明向上调整了  比如原来是8 现在是5  则 把原来>=5 且<8 的各加1
                            whereOrder = OrderNumName >= OrderNum && OrderNumName < oldOrder;
                            orderNumExpress = new ExpressionClip(" OrderNo+1");
                        }
                        else if (oldOrder < OrderNum)
                        {
                            //向下调整了   比如原来是5 现在是8  则 把原来>=5 且<8 的各-1
                            whereOrder = OrderNumName > oldOrder && OrderNumName <= OrderNum;
                            orderNumExpress = new ExpressionClip(" OrderNo-1");
                        }
                        whereOrder = whereOrder && parentIdName == parentID;
                        whereOrderEntity = new T();
                        whereOrderEntity.RecordStatus = StatusType.update;
                        whereOrderEntity.SetModifiedProperty(OrderNumName, orderNumExpress);
                        whereOrderEntity.Where = whereOrder;
                    }



                tr = Dal.BeginTransaction(out dal);

                if (whereOrderEntity != null)
                {
                    dal.SubmitNew(ref dal, whereOrderEntity);
                }
                dal.SubmitNew(ref dal, entity);
                if (updateChild != null)
                {
                    dal.SubmitNew(ref dal, updateChild);
                }





                dal.CommitTransaction(tr);
                if (!WhereClip.IsNullOrEmpty(isMxName))
                {
                    //批量更新 是否是明细
                    T IsMxEntity = new T();
                    IsMxEntity.RecordStatus = StatusType.update;
                    IsMxEntity.SetModifiedProperty(isMxName, true);

                    IsMxEntity.Where = new WhereClip(string.Format(" not exists( select  1 from {0} b where {0}.{1}=b.{2})", IsMxEntity.TableName, IdName.ColumnName, parentIdName.ColumnName));
                    Dal.Submit(IsMxEntity);
                    IsMxEntity.SetModifiedProperty(isMxName, false);

                    IsMxEntity.Where = new WhereClip(string.Format("   exists( select  1 from {0} b where {0}.{1}=b.{2})", IsMxEntity.TableName, IdName.ColumnName, parentIdName.ColumnName));
                    Dal.Submit(IsMxEntity);
                }
                return 1;

            }
            catch (Exception)
            {
                if (tr != null)
                {
                    dal.RollbackTransaction(tr);
                }

                throw;
            }

        }

        public static int Delete(this SessionFactory Dal, string taleName, string keyField, string id, out string err, StringBuilder sb = null)
        {
            err = string.Empty;

            List<SysDeleteCasCheck> list = Dal.From<SysDeleteCasCheck>().Where(SysDeleteCasCheck._.CheckTableName == taleName && SysDeleteCasCheck._.IsEnable == true).List<SysDeleteCasCheck>();

            #region 检测是否存在，禁止删除
            if (list.Exists(p => p.IsCascadeDelete == false))
            {
                List<SysDeleteCasCheck> HasEistlist = list.Where(p => p.IsCascadeDelete == false).ToList();
                foreach (SysDeleteCasCheck item in HasEistlist)
                {
                    if (!string.IsNullOrWhiteSpace(item.CheckExistSql))
                    {
                        string sql = string.Format(item.CheckExistSql, id);
                        List<string> reftableidList = Dal.FromCustomSql(sql).ToStringList();
                        if (reftableidList.Count > 0)
                        {
                            err = item.ErrorMsg;
                            return 0;
                        }
                    }
                }
            }
            #endregion

            #region 允许删除，检测级联删除
            if (sb == null)
            {
                sb = new StringBuilder();
            }
            if (list.Exists(p => p.IsCascadeDelete == true))
            {
                List<SysDeleteCasCheck> HasEistlist = list.Where(p => p.IsCascadeDelete == true).ToList();
                foreach (SysDeleteCasCheck item in HasEistlist)
                {
                    if (!string.IsNullOrWhiteSpace(item.CheckExistSql) && !string.IsNullOrWhiteSpace(item.CascadeDeleteSql))
                    {
                        string sql = string.Format(item.CheckExistSql, id);
                        List<string> reftableidList = Dal.FromCustomSql(sql).ToStringList();
                        foreach (string reftableid in reftableidList)
                        {
                            if (item.CascadeTableName == taleName && item.CascadeTableRefKey == keyField && reftableid == id)
                            {

                            }
                            else
                            {
                                Dal.Delete(item.CascadeTableName, item.CascadeTableRefKey, reftableid, out err, sb);
                                if (!string.IsNullOrWhiteSpace(err))
                                {
                                    sb.Clear();
                                    return 0;
                                }
                            }

                        }
                        if (item.ISTree)
                        {
                            sql = string.Format("select {0} from {1} where {2}='{3}'", item.TreeFjmField, item.CheckTableName, keyField, id);
                            string fjm = Dal.FromCustomSql(sql).ToScalar() as string;
                            if (!string.IsNullOrWhiteSpace(fjm))
                            {
                                sb.Append(string.Format(item.CascadeDeleteSql, fjm) + ";");
                            }
                        }
                        else
                        {
                            sb.Append(string.Format(item.CascadeDeleteSql, id) + ";");
                        } 

                    }
                }
            }
            #endregion
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            int i = 0;
            try
            {
                if (sb.Length > 0)
                {
                    i += dal.FromCustomSql(sb.ToString(), tr).ExecuteNonQuery();

                }
                if (!string.IsNullOrWhiteSpace(keyField))
                {
                    i += dal.FromCustomSql(string.Format("delete from {0} where {1}='{2}'", taleName, keyField, id), tr).ExecuteNonQuery();
                }

                dal.CommitTransaction(tr);
                err = "删除成功" + i + "条数据";
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }
            return 0;
        }



       

    }
}

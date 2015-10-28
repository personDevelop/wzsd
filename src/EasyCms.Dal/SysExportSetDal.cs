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
    public class SysExportSetDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SysExportSet", "ID", id, out error);
            return error;
        }

        public int Save(SysExportSet item, List<SysExportMx> mxLixt)
        {
            //分级码 级数     顺序
            /*如果是新增的   
             有上级  则更新上级为 是否明细  =false , 分级码重新计算分级码 
             */
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {
                item.RecordStatus = StatusType.add;
                foreach (var mx in mxLixt)
                {
                    mx.RecordStatus = StatusType.add;
                    mx.MID = item.ID;
                    if (string.IsNullOrWhiteSpace(mx.ID))
                    {
                        mx.ID = Guid.NewGuid().ToString();
                    }
                }
                mxLixt = mxLixt.OrderBy(p => p.OrderNo).ToList();
                for (int i = 0; i < mxLixt.Count; i++)
                {
                    mxLixt[i].OrderNo = i;

                }
                SysExportSet delMain = new SysExportSet();
                delMain.Where = SysExportSet._.ID == item.ID;
                delMain.RecordStatus = StatusType.delete;
                SysExportMx del = new SysExportMx();
                del.Where = SysExportMx._.MID == item.ID;
                del.RecordStatus = StatusType.delete;
                tr = Dal.BeginTransaction(out dal);
                dal.SubmitNew(tr, ref dal, delMain, del, item);
                dal.SubmitNew(tr, ref dal, mxLixt);
                dal.CommitTransaction(tr);

                return 1;

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }

        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
            return Dal.From<SysExportSet>().Select(SysExportSet._.ID, SysExportSet._.Code, SysExportSet._.Name, SysExportSet._.SqlStr).OrderBy(SysExportSet._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
        public bool Exit(string ID, string RecordStatus, string val)
        {
            WhereClip where = SysExportSet._.Code == val;
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && SysExportSet._.ID != ID;

            }
            return !Dal.Exists<SysExportSet>(where);
        }


        public SysExportSet GetEntity(string id)
        {
            return Dal.Find<SysExportSet>(id);
        }

        public DataTable AddMx(string table)
        {
            List<SysExportMx> mxList = new List<SysExportMx>();
            bool isSql = false;
            if (table.ToLower().StartsWith("select"))
            {
                isSql = true;
            }
            if (isSql)
            {
                if (table.Contains("where"))
                {
                    table += " and 1=2";
                }
                else
                {
                    table += " where 1=2";
                }
                DataTable dt = Dal.FromCustomSql(table).ToDataTable();
                int i = 0;
                foreach (DataColumn item in dt.Columns)
                {
                    SysExportMx mx = new SysExportMx()
                    {
                        ID = Guid.NewGuid().ToString(),
                        Code = item.ColumnName,
                        SourcTable = dt.TableName,
                        OrderNo = i++,

                    };
                    if (item.DataType == typeof(DateTime))
                    {
                        mx.ShowType = ShowType.日期;
                        mx.FormatType = "yyyy-MM-dd";
                        mx.AlignType = AlignType.居中;
                    }
                    else if (item.DataType == typeof(int))
                    {
                        mx.ShowType = ShowType.数值;
                        mx.AlignType = AlignType.居右;
                    }
                    else if (item.DataType == typeof(decimal))
                    {
                        mx.ShowType = ShowType.数值;
                        mx.FormatType = "n2";
                        mx.AlignType = AlignType.居右;
                    }
                    else
                    {
                        mx.ShowType = ShowType.文本;
                    }
                    mxList.Add(mx);
                }
            }
            else
            {
                string[] sourceTalbeName = table.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (sourceTalbeName.Length > 0)
                {
                    foreach (var oneTalbe in sourceTalbeName)
                    {
                        if (!string.IsNullOrWhiteSpace(oneTalbe))
                        {
                            DataTable dt = Dal.FromCustomSql("select * from " + oneTalbe + " where 1=2").ToDataTable();
                            int i = 0;
                            foreach (DataColumn item in dt.Columns)
                            {
                                SysExportMx mx = new SysExportMx()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    Code = item.ColumnName,
                                    SourcTable = oneTalbe,
                                    OrderNo = i++,
                                };
                                if (item.DataType == typeof(DateTime))
                                {
                                    mx.ShowType = ShowType.日期;
                                    mx.FormatType = "yyyy-MM-dd";
                                    mx.AlignType = AlignType.居中;
                                }
                                else if (item.DataType == typeof(int))
                                {
                                    mx.ShowType = ShowType.数值;
                                    mx.AlignType = AlignType.居右;
                                }
                                else if (item.DataType == typeof(decimal))
                                {
                                    mx.ShowType = ShowType.数值;
                                    mx.FormatType = "n2";
                                    mx.AlignType = AlignType.居右;
                                }
                                else
                                {
                                    mx.ShowType = ShowType.文本;
                                }
                                mxList.Add(mx);
                            }
                        }
                    }
                }
            }

            DataTable dtresult = Dal.FromCustomSql("select * from SysExportMx where 1=2").ToDataTable();
            dtresult.Columns.Add("ShowTypeName");
            dtresult.Columns.Add("AlignTypeName");
            foreach (var item in mxList)
            {
                DataRow dr = dtresult.AddRow(item);
                switch (item.ShowType)
                {
                    case ShowType.无:
                    case ShowType.文本:
                    default:
                        dr["ShowTypeName"] = ShowType.文本.ToString();
                        break;
                    case ShowType.数值:
                        dr["ShowTypeName"] = ShowType.数值.ToString();
                        break;
                    case ShowType.日期:
                        dr["ShowTypeName"] = ShowType.日期.ToString();
                        break;
                }
                switch (item.AlignType)
                {
                    case AlignType.无:
                    case AlignType.居左:
                    default:
                        dr["ShowTypeName"] = AlignType.居左.ToString();
                        break;
                    case AlignType.居中:
                        dr["ShowTypeName"] = AlignType.居中.ToString();
                        break;
                    case AlignType.居右:
                        dr["ShowTypeName"] = AlignType.居右.ToString();
                        break;
                }


            }


            return dtresult;
        }



        public DataTable GetMxDataTable(string id)
        {
            return Dal.From<SysExportMx>().Where(SysExportMx._.MID == id).OrderBy(SysExportMx._.OrderNo).ToDataTable();

        }
        public DataTable GetExportMxDataTable(string id)
        {
            return Dal.From<SysExportMx>().Where(SysExportMx._.MID == id && SysExportMx._.NotExport == false).OrderBy(SysExportMx._.OrderNo).ToDataTable();

        }
        public DataTable GetResult(string sql, Dictionary<string, object> paras)
        {
            CustomSqlSection cs = Dal.FromCustomSql(sql);
            if (paras != null)
            {
                foreach (var item in paras.Keys)
                {
                    cs.AddInputParameter(item, paras[item]);
                }
            }
            return cs.ToDataTable();
        }

        public SysExportSet GetEntityByCode(string code)
        {
            return Dal.From<SysExportSet>().Where(SysExportSet._.Code == code).ToFirst<SysExportSet>();
        }
    }


}

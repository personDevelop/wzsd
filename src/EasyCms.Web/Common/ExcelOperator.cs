using EasyCms.Business;
using EasyCms.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Sharp.Common;
using NPOI.SS.Util;
using System.Text.RegularExpressions;

namespace EasyCms.Web.Common
{
    /// <summary>
    /// 两种方式  
    /// 1.完全根据导出设置来
    /// 2.自己提供数据源，展示格式根据设置来
    /// 3.自己提供数据源，直接导出excle
    /// </summary>
    public class ExcelOperator
    {
        static SysExportSetBll bll = new SysExportSetBll();
        public static bool ExportExcle(string exportSetCode, string path, out string err, WhereClip where = null, string orderBy = null)
        {
            err = string.Empty;
            SysExportSet set = bll.GetEntityByCode(exportSetCode);
            List<SysExportMx> mxList = bll.GetMxDataTable(set.ID).ToList<SysExportMx>();
            string sql = set.SqlStr.Trim();
            #region 获取取数sql
            if (!sql.StartsWith("select"))
            {
                sql = "select * from " + sql;
            }
            if (!WhereClip.IsNullOrEmpty(where))
            {

                if (sql.Contains("$where$"))
                {
                    sql = sql.Replace("$where$", "  " + where.SqlBuilder.ToString() + "  ");
                }
                else
                {

                    sql = sql + "  where  " + where.SqlBuilder.ToString();
                }
            }
            else
            {
                if (sql.Contains("$where$"))
                {
                    sql = sql.Replace("$where$", " ");
                }
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {

                if (sql.Contains("$orderby$"))
                {
                    sql = sql.Replace("$orderby$", "  " + orderBy + "  ");
                }
                else
                {
                    sql = sql + "  order by  " + orderBy;
                }
            }
            else
            {
                if (sql.Contains("$orderby$"))
                {
                    sql = sql.Replace("$orderby$", " ");
                }
            }
            #endregion
            Dictionary<string, object> s = null;
            if (!WhereClip.IsNullOrEmpty(where))
            {
                s = where.Parameters;
            }
            DataTable dtsource = bll.GetResult(sql, s);
            return ExportExcle(exportSetCode, path, dtsource, out err);


        }




        #region - 由数字转换为Excel中的列字母 -

        public static int ToIndex(string columnName)
        {
            if (!Regex.IsMatch(columnName.ToUpper(), @"[A-Z]+")) { throw new Exception("invalid parameter"); }
            int index = 0;
            char[] chars = columnName.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index - 1;
        }

        public static string ToName(int index)
        {
            if (index < 0) { throw new Exception("invalid parameter"); }
            List<string> chars = new List<string>();
            do
            {
                if (chars.Count > 0) index--;
                chars.Insert(0, ((char)(index % 26 + (int)'A')).ToString());
                index = (int)((index - index % 26) / 26);
            } while (index > 0);
            return String.Join(string.Empty, chars.ToArray());
        }
        #endregion

        public static bool ExportExcle(string exportSetCode, string path, DataTable dtsource, out string err)
        {
            err = string.Empty;
            bool result = false;
            SysExportSet set = bll.GetEntityByCode(exportSetCode);
            List<SysExportMx> mxList = bll.GetExportMxDataTable(set.ID).ToList<SysExportMx>();
            int newOrderNo = 0;
            foreach (var item in mxList)
            {
                item.OrderNo = newOrderNo++;
            }
            Dictionary<string, int> columIndex = new Dictionary<string, int>();
            Dictionary<int, SysExportMx> columSet = new Dictionary<int, SysExportMx>();
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(set.Name);
            int RowIndex = 0;
            if (set.ShowTableCaption)
            {
                IRow rowCaption = sheet.CreateRow(RowIndex++);
                ICell cellCaption = rowCaption.CreateCell(0);
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, mxList.Count));
                cellCaption.SetCellValue(set.Name);
                ICellStyle style = workbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                IFont font = workbook.CreateFont();
                font.FontHeight = 20 * 20;
                font.IsBold = true;
                style.SetFont(font);
                cellCaption.CellStyle = style;
            }
            #region 创建标题
            if (mxList.Exists(p => !string.IsNullOrWhiteSpace(p.GroupCode)))
            {
                //有多级标题
                int startRowIndex = RowIndex;
                List<string> mxGroupList = mxList.Where(p => !string.IsNullOrWhiteSpace(p.GroupCode)).Select(p => p.GroupCode).Distinct().ToList();
                IRow rowtitle1 = sheet.CreateRow(RowIndex++);
                IRow rowtitle2 = sheet.CreateRow(RowIndex++);
                int colIndex = 0;
                foreach (var item in mxList)
                {
                    if (mxGroupList.Contains(item.GroupCode))
                    {
                        //分组列
                        ICell icGroup = rowtitle1.CreateCell(item.OrderNo);
                        icGroup.SetCellValue(item.GroupName);
                        //获取开始列
                        int start = mxList.Where(p => p.GroupCode == item.GroupCode).Min(p => p.OrderNo);
                        //获取结束列
                        int end = mxList.Where(p => p.GroupCode == item.GroupCode).Max(p => p.OrderNo);
                        //起始行，结束行，起始列，结束列
                        sheet.AddMergedRegion(new CellRangeAddress(startRowIndex, startRowIndex, start, end));
                        ICellStyle style = workbook.CreateCellStyle();
                        style.Alignment = HorizontalAlignment.Center;
                        icGroup.CellStyle = style;
                        mxGroupList.Remove(item.GroupCode);
                    }
                    //普通列
                    ICell ic = rowtitle2.CreateCell(item.OrderNo);
                    ic.SetCellValue(item.Name);
                    columIndex.Add(item.Code, colIndex);
                    columSet.Add(colIndex, item);
                    colIndex++;
                }

            }
            else
            {
                //一级标题
                IRow rowtitle1 = sheet.CreateRow(RowIndex++);

                int colIndex = 0;
                foreach (var item in mxList)
                {

                    //普通列
                    ICell ic = rowtitle1.CreateCell(item.OrderNo);
                    ic.SetCellValue(item.Name);
                    columIndex.Add(item.Code, colIndex);
                    columSet.Add(colIndex, item);
                    colIndex++;
                }
            }
            #endregion
            int DataRowIndex = RowIndex;
            List<CellRangeAddress> listCellRange = new List<CellRangeAddress>();
            //获取其主键字段
            List<string> listKey = mxList.Where(p => p.IsKey).Select(p => p.Code).ToList();
            #region 创建单元格
            int dtrowIndex = 0;
            foreach (DataRow item in dtsource.Rows)
            {
                IRow rowdata = sheet.CreateRow(RowIndex++);

                foreach (var columName in columIndex.Keys)
                {
                    int cellIndex = columIndex[columName];
                    SysExportMx cellSet = columSet[cellIndex];
                    ICell cell = rowdata.CreateCell(cellIndex);
                    #region 设置单元格样式
                    ICellStyle style = null;
                    switch (cellSet.AlignType)
                    {
                        case AlignType.无:
                            break;
                        case AlignType.居左:
                            break;
                        case AlignType.居中:
                            //设置单元格的样式：水平对齐居中
                            style = workbook.CreateCellStyle();
                            style.Alignment = HorizontalAlignment.Center;
                            cell.CellStyle = style;
                            break;
                        case AlignType.居右:
                            //设置单元格的样式：水平对齐居中
                            style = workbook.CreateCellStyle();
                            style.Alignment = HorizontalAlignment.Right;
                            cell.CellStyle = style;
                            break;
                        default:
                            break;
                    }
                    #endregion
                    #region 设置合并单元格
                    if (cellSet.IsMergeRow)
                    {
                        if (dtrowIndex > 0)
                        {
                            //看看他和上一行相同单元格值是否相等
                            DataRow uprow = dtsource.Rows[dtrowIndex - 1];
                            if (uprow[columName] as string == item[columName] as string)
                            {
                                bool isSame = true;
                                foreach (var keyCode in listKey)
                                {
                                    if (uprow[keyCode] != item[keyCode])
                                    {
                                        isSame = false;
                                        break;
                                    }

                                }
                                if (isSame)
                                {
                                    CellRangeAddress x = new CellRangeAddress(DataRowIndex + dtrowIndex - 1, DataRowIndex + dtrowIndex, cellIndex, cellIndex);
                                    listCellRange.Add(x);
                                }

                            }
                        }
                    }
                    #endregion
                    #region 给单元格赋值
                    switch (cellSet.ShowType)
                    {
                        case ShowType.无:
                        case ShowType.文本:
                        default:
                            cell.SetCellValue(item[columName] as string);
                            break;
                        case ShowType.数值:
                            if (item[columName] != null && item[columName] != DBNull.Value)
                            {
                                try
                                {
                                    double d = Convert.ToDouble(item[columName]);
                                    if (!string.IsNullOrWhiteSpace(cellSet.FormatType))
                                    {
                                        string format = cellSet.FormatType.Trim();
                                        format = format.Substring(format.Length - 1);
                                        int jd = 0;
                                        if (int.TryParse(format, out jd))
                                        {
                                            if (jd > 0)
                                            {
                                                string s = "1".PadRight(jd, '0');
                                                int jdb = int.Parse(s);
                                                int d1 = (int)(d * jdb);
                                                if (d1 > 0)
                                                {
                                                    int third = ((int)d * jd * 0) % 10;//进位
                                                    if (third >= 5) d1++;
                                                }
                                                d = (double)d1 / 100;
                                            }
                                        }
                                    }
                                    cell.SetCellValue(d);
                                }
                                catch (Exception)
                                {
                                    cell.SetCellValue(item[columName] as string);
                                }
                            }

                            break;
                        case ShowType.日期:
                            if (item[columName] != null && item[columName] != DBNull.Value)
                            {
                                try
                                {
                                    DateTime d = Convert.ToDateTime(item[columName]);

                                    if (!string.IsNullOrWhiteSpace(cellSet.FormatType))
                                    {
                                        string val = d.ToString(cellSet.FormatType);
                                        cell.SetCellValue(val);
                                    }
                                    else
                                    {
                                        cell.SetCellValue(d);
                                    }

                                }
                                catch (Exception)
                                {
                                    cell.SetCellValue(item[columName] as string);
                                }
                            }
                            break;

                    }
                    #endregion


                }
                dtrowIndex++;
            }
            #endregion

            #region 设置聚合公式
            if (mxList.Exists(p => p.AggregateType != AggregateType.无))
            {

                IRow rowAggregate = sheet.CreateRow(RowIndex++);
                List<SysExportMx> mxAggregate = mxList.Where(p => p.AggregateType != AggregateType.无).ToList();
                for (int i = 0; i < columIndex.Count; i++)
                {
                    ICell cell2 = rowAggregate.CreateCell(i);

                    if (mxAggregate.Exists(p => p.OrderNo == i))
                    {
                        SysExportMx mx = mxAggregate.Find(p => p.OrderNo == i);
                        string colName = ToName(i);
                        string fw = string.Format("({0}{1}:{2}{3})", colName, DataRowIndex+1 , colName, RowIndex -1);
                        switch (mx.AggregateType)
                        {
                            case AggregateType.无:
                                break;
                            case AggregateType.求和:
                                fw = "SUM" + fw;

                                break;
                            case AggregateType.平均:
                                fw = "AVG" + fw;
                                break;
                            case AggregateType.最大:
                                fw = "MAX" + fw;
                                break;
                            case AggregateType.最小:
                                fw = "MIN" + fw;
                                break;
                            default:
                                break;
                        }
                        cell2.CellFormula = fw;
                    }
                }


            }
            #endregion

            foreach (CellRangeAddress item in listCellRange)
            {
                sheet.AddMergedRegion(item);
            }

            delOldFile(path);
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
            return result;
        }
        public static void delOldFile(string path)
        {
            FileInfo f = new FileInfo(path);


            string dict = f.DirectoryName;

            if (Directory.Exists(dict))
            {
                string[] fs = Directory.GetFileSystemEntries(dict);
                foreach (string item in fs)
                {
                    try
                    { 
                        File.Delete(item);
                    }
                    catch { }
                }
            }
            else
            {
                Directory.CreateDirectory(dict);
            }




        }

    }
}
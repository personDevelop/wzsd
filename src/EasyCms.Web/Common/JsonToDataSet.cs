using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EasyCms.Web 
{
    public class JsonToDataSet
    {
        public const string DataSetCaption = "DataSet";
        public const string TableCaption = "Table";
        public const string RowsCaption = "Rows";
        public const string ColumnsCaption = "Columns";



        /// <summary>
        /// 获取dataset对象
        /// </summary>
        /// <param name="strJson">dataset 结构、数据字符串</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strJson)
        {
            DataSet ds = new DataSet();
            strJson = strJson.Replace("{\"" + TableCaption + "\":[", "").TrimEnd('}').TrimEnd(']');//去除多余字符
            string[] groupdata = Regex.Split(strJson, ",{\"" + ColumnsCaption + "\"", RegexOptions.IgnoreCase);  // 对表分组
            /// 生成数据表
            for (int i = 0; i < groupdata.Length; i++)
            {
                string dtstr = groupdata[i];
                if (':' == dtstr[0])
                    dtstr = "{\"" + ColumnsCaption + "\"" + dtstr;
                GetTableInfo(ds, dtstr);
            }
            return ds;
        }
        /// <summary>
        /// 获取datatable 对象
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strJson)
        {
            return GetTableInfo(strJson);
        }


        /// <summary>
        /// 获取datatable对象
        /// </summary>
        /// <param name="ds">dataset 对象</param>
        /// <param name="strjson">ds结构、数据字符串</param>
        protected static void GetTableInfo(DataSet ds, string strjson)
        {
            ds.Tables.Add(GetTableInfo(strjson));
        }
        /// <summary>
        /// 获取datatable 对象
        /// </summary>
        /// <param name="strjson"></param>
        /// <returns></returns>
        protected static DataTable GetTableInfo(string strjson)
        {
            DataTable dt = new DataTable();
            //{"Columns":
            Match mcolumns = Regex.Match(strjson, "{\"" + ColumnsCaption + "\":"); // Columns
            //,"Rows":
            Match mrow = Regex.Match(strjson, ",\"" + RowsCaption + "\":");  // rows 
            if (strjson == null && strjson == "" && strjson.Length > 0)
            {
                return dt;
            }
            ///创建表结构
            //5  {"Columns":{  去掉Columns 所占字符数  6 是前面5个字符 在加上} 字符占用的字符数 
            CreateDataColumn(dt,
                strjson.Substring(mcolumns.Index + ColumnsCaption.Length + 5, (mrow.Index - mcolumns.Index) - ColumnsCaption.Length - 6)); // 导入Column数据 ColumnsCaption.Length + (3-1) 是 'Columns':  占有的字符数 的序号
            /// 填充数据内容
            if ((strjson.Length - mrow.Index - RowsCaption.Length - 5) > 0)
                //4 ,"": 所占的字符数,已截取到[符号    
                CreateDataRow(dt, strjson.Substring(mrow.Index + RowsCaption.Length + 4,
                     strjson.Length - (mrow.Index + RowsCaption.Length + 4 + 1))); // 导入row数据  RowsCaption.Length + (3-1) 是 'Rows':  占有的字符数 的序号

            return dt;
        }

        /// <summary>
        /// 创建列对象
        /// </summary>
        /// <param name="dt">datatable对象</param>
        /// <param name="strjson">列对象字符串</param>
        protected static void CreateDataColumn(DataTable dt, string strjson)
        {
            string[] columndata = strjson.Split(',');
            foreach (string type in columndata)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = type.Substring(0, type.IndexOf(':')).Replace(":", "").Replace("\"", "");
                GetcolumnType(type.Substring(type.IndexOf(':')).Replace(":", "").Replace("\"", ""), column);
                dt.Columns.Add(column);
            }
        }

        /// <summary>
        /// 增加行内容
        /// </summary>
        /// <param name="dt">datatable对象</param>
        /// <param name="strjson">行对象字符串</param>
        protected static void CreateDataRow(DataTable dt, string strjson)
        {
            strjson = strjson.TrimStart('[').TrimEnd(']');
            if (string.IsNullOrEmpty(strjson.Trim())) return;
            string[] rowsdata = Regex.Split(strjson, "},{", RegexOptions.IgnoreCase);
            for (int j = 0; j < rowsdata.Length; j++)
            {
                string rowstr = rowsdata[j].TrimStart('{').TrimEnd('}');
                DataRow row = dt.NewRow();
                rowstr = rowstr.Replace(",\",\"", "`\",\"");
                string[] colsdata = Regex.Split(rowstr, ",\"", RegexOptions.IgnoreCase);
                for (int i = 0; i < colsdata.Length; i++)  // 判断共有行数
                {
                    colsdata[i] = colsdata[i].Replace("`", "^");
                    string colname = colsdata[i].Substring(0, colsdata[i].IndexOf(':')).Trim('\"');
                    if (!dt.Columns.Contains(colname)) throw new Exception("数据表中没有字段：" + colname);
                    SetRows(row, colname
                       , dt.Columns[colname].DataType.ToString(),
                       colsdata[i].Substring(colsdata[i].IndexOf(':') + 1));

                }
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 获取column数据类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="column">datacolumn对象</param>
        protected static void GetcolumnType(string type, DataColumn column)
        {
            switch (type)
            {
                case "Int32":
                    column.DataType = typeof(int);
                    break;
                case "DateTime":
                    column.DataType = typeof(DateTime);
                    break;
                case "Single":
                    column.DataType = typeof(float);
                    break;
                case "Double":
                    column.DataType = typeof(double);
                    break;
                case "Decimal":
                    column.DataType = typeof(decimal);
                    break;
                default:
                    column.DataType = typeof(string);
                    break;
            }
        }

        /// <summary>
        /// 设置datarow内容
        /// </summary>
        /// <param name="dr">datarow 对象</param>
        /// <param name="count">数量</param>
        /// <param name="type">类型</param>
        /// <param name="data">数据值</param>
        protected static void SetRows(DataRow dr, string fieldname, string type, string data)
        {
            //data=data.Substring(1,data.Length-2);
            if (data.IndexOf("\"") == 0)
            {
                data = data.Substring(1);
                if (data.LastIndexOf("\"") == (data.Length - 1)) data = data.Substring(0, data.Length - 1);
                data = data.Replace("\\\"", "\"");
            }
            decimal vsdec;
            DateTime vsdate;
            try
            {
                switch (type.Remove(0, 7))
                {
                    case "Int32":
                        if (Decimal.TryParse(data, out vsdec))
                        {
                            dr[fieldname] = Convert.ToInt32(data);
                        }
                        else
                        {
                            dr[fieldname] = DBNull.Value;
                        }
                        break;
                    case "DateTime":
                        if (DateTime.TryParse(data, out vsdate))
                        {
                            dr[fieldname] = vsdate;
                        }
                        else
                        {
                            dr[fieldname] = DBNull.Value;
                        }
                        break;
                    case "Single":
                        if (Decimal.TryParse(data, out vsdec))
                        {
                            dr[fieldname] = Convert.ToSingle(data);
                        }
                        else
                        {
                            dr[fieldname] = DBNull.Value;
                        }
                        break;
                    case "Double":
                        if (Decimal.TryParse(data, out vsdec))
                        {
                            dr[fieldname] = Convert.ToDecimal(data);
                        }
                        else
                        {
                            dr[fieldname] = DBNull.Value;
                        }

                        break;
                    case "Decimal":
                        if (Decimal.TryParse(data, out vsdec))
                        {
                            dr[fieldname] = Convert.ToDecimal(data);
                        }
                        else
                        {
                            dr[fieldname] = DBNull.Value;
                        }
                        break;
                    default:
                        dr[fieldname] = Convert.ToString(data.Replace("\\\\", "\\"));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(fieldname + "数据格式不正确。" + ex.Message);
            }
        }


    }
}
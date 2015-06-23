using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EasyCms.Web 
{
    public static class JsonConvert
    {





        public static string Convert2Json(object o)
        {
            StringBuilder sb = new StringBuilder();
            WriteValue(sb, o);
            return sb.ToString();
        }

        public static void WriteValue(StringBuilder sb, object val)
        {
            if (val == null || val == System.DBNull.Value)
            {
                sb.Append("\"\"");
            }
            else if (val is string || val is Guid)
            {
                WriteString(sb, val.ToString());
            }
            else if (val is bool)
            {
                sb.Append(val.ToString().ToLower());
            }
            else if (val is double ||
                val is float ||
                val is long ||
                val is int ||
                val is short ||
                val is byte ||
                val is decimal)
            {
                sb.AppendFormat("{0}", val);
            }
            else if (val.GetType().IsEnum)
            {
                sb.Append((int)val);
            }
            else if (val is DateTime)
            {
                sb.Append("\"");
                sb.Append(((DateTime)val).ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("\"");
            }
            else if (val is DataSet)
            {
                WriteDataSet(sb, val as DataSet);
            }
            else if (val is DataTable)
            {
                WriteDataTable(sb, val as DataTable);
            }
            else if (val is DataRowCollection)
            {
                WriteDataRows(sb, val as DataRowCollection);
            }
            else if (val is DataRow)
            {
                WriteDataRow(sb, val as DataRow);
            }
            else if (val is Hashtable)
            {
                WriteHashtable(sb, val as Hashtable);
            }
            else if (val is Dictionary<string, object>)
            {
                WirteDictionary(sb, val as Dictionary<string, object>);

            }
            else if (val is IEnumerable)
            {
                WriteEnumerable(sb, val as IEnumerable);
            }
        }
        private static void WriteEnumerable(StringBuilder sb, IEnumerable e)
        {
            bool hasItems = false;
            sb.Append("[");
            foreach (object val in e)
            {
                WriteValue(sb, val);
                sb.Append(",");
                hasItems = true;
            }
            // Remove the trailing comma.
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("]");
        }
        private static void WirteDictionary(StringBuilder sb, Dictionary<string, object> e)
        {
            bool hasItems = false;
            sb.Append("{");
            foreach (string key in e.Keys)
            {
                sb.AppendFormat("\"{0}\":", key.ToUpper());
                WriteValue(sb, e[key]);
                sb.AppendFormat(",");
                hasItems = true;
            }
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("}");
        }
        private static void WriteHashtable(StringBuilder sb, Hashtable e)
        {
            bool hasItems = false;
            sb.Append("{");
            foreach (string key in e.Keys)
            {
                sb.AppendFormat("\"{0}\":", key.ToUpper());
                WriteValue(sb, e[key]);
                sb.Append(",");
                hasItems = true;
            }
            // Remove the trailing comma.
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("}");
        }

        private static void WriteDataSet(StringBuilder sb, DataSet ds)
        {
            sb.Append("{\"" + JsonToDataSet.TableCaption + "\":[");// sb.Append("{\"" + ds.DataSetName +"\":{");
            foreach (DataTable table in ds.Tables)
            {
                WriteDataTable(sb, table);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (ds.Tables.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("]}");
        }

        private static void WriteDataTable(StringBuilder sb, DataTable table)
        {
            //sb.Append("{\"" + JsonToDataSet.ColumnsCaption + "\":{");

            //foreach (DataColumn col in table.Columns)
            //{
            //    WriteDataColumn(sb, col);
            //    sb.Append(",");
            //}

            //if (table.Columns.Count > 0)
            //    --sb.Length;
            //sb.Append("},");
            
            WriteTableRows(sb, table.Rows);
     
            //sb.Append("}");
        }
        private static void WriteTableRows(StringBuilder sb, DataRowCollection rows)
        {
            //sb.Append("\"" + JsonToDataSet.RowsCaption + "\":[");
            sb.Append("[");
            foreach (DataRow row in rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (rows.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("]");
        }
        private static void WriteDataRows(StringBuilder sb, DataRowCollection rows)
        {
            sb.Append("{");
            WriteTableRows(sb, rows);
            sb.Append("}");
        }
        private static void WriteDataColumn(StringBuilder sb, DataColumn column)
        {
            //sb.Append("{");
            sb.AppendFormat("\"{0}\":", column.ColumnName.ToUpper());
            sb.AppendFormat("\"{0}\"", column.DataType.ToString().Remove(0, 7));
            //  sb.Append("}");
        }
        private static void WriteDataRow(StringBuilder sb, DataRow row)
        {
            sb.Append("{");
            foreach (DataColumn column in row.Table.Columns)
            {
                sb.AppendFormat("\"{0}\":", column.ColumnName);
                WriteValue(sb, row[column]);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (row.Table.Columns.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("}");
        }



        private static void WriteString(StringBuilder sb, string s)
        {
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            sb.Append("\"");
        }


    }
}
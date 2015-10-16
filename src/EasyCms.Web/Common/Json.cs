using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Sharp.Common;
using Newtonsoft.Json.Converters;


namespace EasyCms.Web.Common
{
    public class JsonWithDataTable
    {

        public static string Serialize(object value, bool conatin = false, params string[] props)
        {
            Type type = value.GetType();

            JsonSerializer json = new JsonSerializer();
            json.NullValueHandling = NullValueHandling.Include;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            List<string> otherProp = new List<string>();
            if (props != null && props.Length > 0)
            {
                foreach (var item in props)
                {
                    otherProp.Add(item);
                }
            }
            json.ContractResolver = new LimitPropsContractResolver(otherProp, conatin);
            if (type == typeof(DataRow))
                json.Converters.Add(new DataRowConverter());
            else if (type == typeof(DataTable))
                json.Converters.Add(new DataTableConverter());
            else if (type == typeof(DataSet))
                json.Converters.Add(new DataSetConverter());

            json.Converters.Add(new DateTimeConverter());
            json.Converters.Add(new DBNullCreationConverter());
            string output = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.QuoteChar = '"';
                    if (value == null)
                    {
                        value = string.Empty;
                    }
                    json.Serialize(writer, value);
                    output = sw.ToString();
                }
            }
            return output;
        }

        public static object Deserialize(string jsonText, Type valueType)
        {
            JsonSerializer json = new JsonSerializer();
            json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            object result = null;
            using (StringReader sr = new StringReader(jsonText))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    result = json.Deserialize(reader, valueType);
                }
            }
            ;


            return result;
        }
    }

    /// <summary>
    /// 对DBNull的转换处理，此处只写了转换成JSON字符串的处理，JSON字符串转对象的未处理
    /// </summary>
    public class DBNullCreationConverter : JsonConverter
    {
        /// <summary>
        /// 是否允许转换
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            bool canConvert = false;
            switch (objectType.FullName)
            {
                case "System.DBNull":
                    canConvert = true;
                    break;
                case "System.String":
                    canConvert = true;
                    break;

            }
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || value == DBNull.Value)
            {
                writer.WriteValue(string.Empty);
            }
            else
            {
                writer.WriteValue(value);
            }
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 是否允许转换JSON字符串时调用
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
    }
    /// <summary>
    /// Converts a <see cref="DataRow"/> object to and from JSON.
    /// </summary>
    public class DataRowConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataRow, JsonSerializer serializer)
        {
            DataRow row = dataRow as DataRow;

            // *** HACK: need to use root serializer to write the column value
            //     should be fixed in next ver of JSON.NET with writer.Serialize(object)
            JsonSerializer ser = new JsonSerializer();

            writer.WriteStartObject();
            foreach (DataColumn column in row.Table.Columns)
            {
                writer.WritePropertyName(column.ColumnName);
                ser.Serialize(writer, row[column]);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataRow).IsAssignableFrom(valueType);
        }



        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

    public class DateTimeConverter : DateTimeConverterBase
    {
        private static IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm" };
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }
    /// <summary>
    /// Converts a DataTable to JSON. Note no support for deserialization
    /// </summary>
    public class DataTableConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataTable, JsonSerializer serializer)
        {
            DataTable table = dataTable as DataTable;
            DataRowConverter converter = new DataRowConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Rows");
            writer.WriteStartArray();

            foreach (DataRow row in table.Rows)
            {
                converter.WriteJson(writer, row, serializer);
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataTable).IsAssignableFrom(valueType);
        }






        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converts a <see cref="DataSet"/> object to JSON. No support for reading.
    /// </summary>
    public class DataSetConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        public override void WriteJson(JsonWriter writer, object dataset, JsonSerializer serializer)
        {
            DataSet dataSet = dataset as DataSet;

            DataTableConverter converter = new DataTableConverter();

            writer.WriteStartObject();

            writer.WritePropertyName("Tables");
            writer.WriteStartArray();

            foreach (DataTable table in dataSet.Tables)
            {
                converter.WriteJson(writer, table, serializer);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified value type.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified value type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type valueType)
        {
            return typeof(DataSet).IsAssignableFrom(valueType);
        }



        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }



    public class LimitPropsContractResolver : DefaultContractResolver
    {
        static Type BaseType = typeof(BaseEntity);
        static List<string> BaseReturnOprops = new List<string>(new string[] { "IsSuccess", "Msg", "data", "PageIndex", "RecordCount", "TotalPageCount" ,
        "TotalRecourdCount","Data" });

        List<string> props = null;

        bool retain;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="props">传入的属性数组</param>
        /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
        public LimitPropsContractResolver(List<string> props, bool retain = false)
        {
            //指定要序列化属性的清单
            this.props = props;

            this.retain = retain;
        }

        protected override IList<JsonProperty> CreateProperties(Type type,

        MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =
            base.CreateProperties(type, memberSerialization);
            //只保留清单有列出的属性
            return list.Where(p =>
            {
                if (p.DeclaringType == BaseType)
                {
                    return false;
                }

                else
                    if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                    {
                        return true;
                    }
                    else
                        if (BaseReturnOprops.Contains(p.PropertyName))
                        {
                            return true;

                        }
                        else
                        {
                            if (retain)
                            {
                                return props.Contains(p.DeclaringType.Name + "." + p.PropertyName);

                            }
                            else
                            {
                                return !props.Contains(p.DeclaringType.Name + "." + p.PropertyName);
                            }
                        }
            }).ToList();
        }
    }

    //public class WebExtensionsJavaScriptSerializer : JSONSerializerBase, IJSONSerializer
    //{
    //    public WebExtensionsJavaScriptSerializer(JSONSerializer serializer)
    //        : base(serializer)
    //    { }

    //    public string Serialize(object value)
    //{
    //    JavaScriptSerializer ser = new JavaScriptSerializer();

    //    List<JavaScriptConverter> converters = new List<JavaScriptConverter>();

    //    if (value != null)
    //    {
    //        Type type = value.GetType();
    //        if (type == typeof(DataTable) || type == typeof(DataRow) || type == typeof(DataSet))
    //        {
    //            converters.Add(new WebExtensionsDataRowConverter());
    //            converters.Add(new WebExtensionsDataTableConverter());
    //            converters.Add(new WebExtensionsDataSetConverter());
    //        }

    //        if (converters.Count > 0)
    //            ser.RegisterConverters(converters);
    //    }

    //    return = ser.Serialize(value);
    //}
    //    public object Deserialize(string jsonText, Type valueType)
    //    {
    //        // *** Have to use Reflection with a 'dynamic' non constant type instance
    //        JavaScriptSerializer ser = new JavaScriptSerializer();


    //        object result = ser.GetType()
    //                           .GetMethod("Deserialize")
    //                           .MakeGenericMethod(valueType)
    //                          .Invoke(ser, new object[1] { jsonText });
    //        return result;
    //    }
    //}



    //internal class WebExtensionsDataTableConverter : JavaScriptConverter
    //{
    //    public override IEnumerable<Type> SupportedTypes
    //    {
    //        get { return new Type[] { typeof(DataTable) }; }
    //    }

    //    public override object Deserialize(IDictionary<string, object> dictionary, Type type,
    //                                       JavaScriptSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    //    {
    //        DataTable table = obj as DataTable;

    //        // *** result 'object'
    //        Dictionary<string, object> result = new Dictionary<string, object>();

    //        if (table != null)
    //        {
    //            // *** We'll represent rows as an array/listType
    //            List<object> rows = new List<object>();

    //            foreach (DataRow row in table.Rows)
    //            {
    //                rows.Add(row);  // Rely on DataRowConverter to handle
    //            }
    //            result["Rows"] = rows;

    //            return result;
    //        }

    //        return new Dictionary<string, object>();
    //    }
    //}

    //internal class WebExtensionsDataRowConverter : JavaScriptConverter
    //{
    //    public override IEnumerable<Type> SupportedTypes
    //    {
    //        get { return new Type[] { typeof(DataRow) }; }
    //    }

    //    public override object Deserialize(IDictionary<string, object> dictionary, Type type,
    //                                       JavaScriptSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    //    {
    //        DataRow dataRow = obj as DataRow;
    //        Dictionary<string, object> propValues = new Dictionary<string, object>();

    //        if (dataRow != null)
    //        {
    //            foreach (DataColumn dc in dataRow.Table.Columns)
    //            {
    //                propValues.Add(dc.ColumnName, dataRow[dc]);
    //            }
    //        }

    //        return propValues;
    //    }
    //}

    //internal class WebExtensionsDataSetConverter : JavaScriptConverter
    //{
    //    public override IEnumerable<Type> SupportedTypes
    //    {
    //        get { return new Type[] { typeof(DataSet) }; }
    //    }

    //    public override object Deserialize(IDictionary<string, object> dictionary, Type type,
    //                                       JavaScriptSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    //    {
    //        DataSet dataSet = obj as DataSet;
    //        Dictionary<string, object> tables = new Dictionary<string, object>();

    //        if (dataSet != null)
    //        {
    //            foreach (DataTable dt in dataSet.Tables)
    //            {
    //                tables.Add(dt.TableName, dt);
    //            }
    //        }

    //        return tables;
    //    }
    //}
}
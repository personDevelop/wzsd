using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Common
{
    public static class FormatResponse
    {
        public static HttpResponseMessage Format(this string str, bool isSuccess)
        {
            if (isSuccess)
            {
                return str.FormatSuccess();
            }
            else
            {
                return str.FormatError();
            }
        }
        public static HttpResponseMessage Format(this Exception ex)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = false, Msg = ex.Message });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        public static HttpResponseMessage FormatError(this string error)
        {
            if (error.Contains("成功"))
                return error.FormatSuccess();
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = false, Msg = error });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }
        public static HttpResponseMessage FormatSuccess(this string resultStr)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = true, Msg = "操作成功", data = resultStr });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        public static HttpResponseMessage Format(this DataTable dt)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = true, Msg = "操作成功", data = dt });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

        public static HttpResponseMessage FormatObjProp(this object obj, bool conatin = false, params PropertyItem[] props)
        {
            List<string> otherProp = new List<string>();
            if (props != null && props.Length > 0)
            {
                foreach (var item in props)
                {
                    otherProp.Add(item.TableName + "." + item.ColumnName);
                }
            }
            return FormatObj(obj, conatin, otherProp.ToArray());

        }

        public static HttpResponseMessage FormatObj(this object obj, bool conatin = false, params string[] props)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = true, Msg = "操作成功", data = obj }, conatin, props);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }


        public static JsonResult FormatErrorJsonResult(this string error)
        {

            return new JsonResult() { Data = new { IsSuccess = false, Msg = error }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public static JsonResult FormatJsonResult(this object obj)
        {

            return new JsonResult() { Data = new { IsSuccess = true, Msg = "操作成功", data = obj }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public static JsonResult FormatExceptionJsonResult(this Exception ex)
        {

            return new JsonResult() { Data = new { IsSuccess = false, Msg = ex.GetExceptionMsg() }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}
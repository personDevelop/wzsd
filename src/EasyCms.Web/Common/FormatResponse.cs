using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace EasyCms.Web.Common
{
    public static class FormatResponse
    {
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
    }
}
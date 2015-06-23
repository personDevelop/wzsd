using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
namespace MVCExtention
{
    public static class ExtendHtmlInput
    {
        public static System.Web.Mvc.HtmlHelper MvcHelper
        {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html; }
        }

        public static System.Web.Mvc.UrlHelper MvcUrl
        {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Url; }
        }

        public static MvcHtmlString Img(this HtmlHelper helper, string imgName, string altMsg="", string title = "", string style = "")
        {
            return MvcHtmlString.Create(string.Format(" <img src=\"~/Content/Images/{0}\"  alt=\"{1}\"  title=\"{2}\" style=\"{3}\" />",imgName,altMsg,title,style));
        }
    }




}

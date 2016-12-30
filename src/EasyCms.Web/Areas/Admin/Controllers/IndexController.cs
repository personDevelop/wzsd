using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using EasyCms.Session;
using System.Web.Security;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {
    
        //
        // GET: /Admin/Index/
        public ActionResult Index()
        {

            try
            {
               
                List<FunctionInfo> list = new FunctionInfoBll().GetListWithUrl(CmsSession.GetRoleID(), 0);
                StringBuilder sb = new StringBuilder();
                foreach (var item in list.Where(p => p.Js == 1))
                {
                    if (list.Exists(p => p.ParentID == item.ID))
                    {
                        FunctionInfo first = list.Find(p => p.ParentID == item.ID);
                        sb.AppendFormat(@" <div class='list-group'>
                    <h1 title='{0}'><img src='{1}' /></h1>
                    <div class='list-wrap'>
                        <h2>{2}<i></i></h2>", item.ShowText, item.Image, first.ShowText);

                        GetChildList(list, first.ID, sb);
                        sb.AppendFormat("</div></div>");

                    }


                }
                this.ViewData["funcInfo"] = sb.ToString();
                return View();
            }
            catch (Exception ex)
            {
                new LogBll().WriteException(ex);
                throw;
            }
        }

        private void GetChildList(List<FunctionInfo> list, string parentID, StringBuilder sb)
        {
            if (list.Exists(p => p.ParentID == parentID))
            {


                sb.Append(" <ul>");
                foreach (var item in list.Where(p => p.ParentID == parentID))
                {
                    string url = "#";
                    switch (item.AccessType)
                    {
                        case AccessType.层级模块:
                            break;
                        case AccessType.普通模块:
                            break;
                        case AccessType.MVC功能:
                            url = Url.Action(item.CallAction, item.CallControler, new { area = item.CallArea });
                            break;
                        case AccessType.API功能:
                            break;
                        case AccessType.URL功能:
                            url = item.URL;
                            break;
                        case AccessType.其它:
                            break;
                        default:
                            break;
                    }
                     
                    sb.AppendFormat(@"  <li> <a href='{1}' navid='{2}' target='mainframe' > <span>{0}</span>  </a>",
                        item.ShowText, url,item.ID);

                    GetChildList(list, item.ID, sb);
                    sb.Append(" </li>");
                }
                sb.Append(" </ul>");
            }
        }


        public ActionResult LogOut()
        {

            CmsSession.LogOut();
           
            FormsAuthentication.SignOut();
            return RedirectToAction("", "Login");
        }

        public string GetSessionInfo()
        {
           
            string resulttemp = @"SessionID：{0};Session中的数据个数：{1};IsCookieless:{2};IsNewSession:{3};
                     IsReadOnly;{4};Mode:{5}; Timeout:{6}";
         string    result1 = string.Format(resulttemp, Session.SessionID,Session.Count,Session.IsCookieless
                , Session.IsNewSession,Session.IsReadOnly,Session.Mode, Session.Timeout );

            string result2 = string.Format(resulttemp, CmsSession.  Session.SessionID, CmsSession.Session.Count, CmsSession.Session.IsCookieless
                           , CmsSession.Session.IsNewSession, CmsSession.Session.IsReadOnly, CmsSession.Session.Mode, CmsSession.Session.Timeout);


            return result1+"；session框架："+result2;
           

        }
    }
}
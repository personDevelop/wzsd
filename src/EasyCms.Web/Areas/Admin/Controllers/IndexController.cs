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

        private void GetChildList(List<FunctionInfo> list, string parentID, StringBuilder sb)
        {
            if (list.Exists(p => p.ParentID == parentID))
            {


                sb.Append(" <ul>");
                foreach (var item in list.Where(p => p.ParentID == parentID))
                {
                    string url = "#";
                    if (item.AccessType > 1)
                    {
                        switch (item.AccessType)
                        {
                            case 0:
                            case 1:
                            case 4:
                            default:
                                break;
                            case 2:
                                url = Url.Action(item.CallAction, item.CallControler, new { area = item.CallArea });
                                break;
                            case 3:
                                url = item.URL;
                                break;
                        }
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

    }
}
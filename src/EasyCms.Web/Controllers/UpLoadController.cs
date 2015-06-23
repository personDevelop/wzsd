using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class UpLoadController : Controller
    {
        //
        // GET: /UpLoad/
        public ActionResult UpLoadProcess(string uid, string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file)
        {
            try
            {
                string filePathName = string.Empty;
                string[] types = type.Split('/');
                string fileid = Guid.NewGuid().ToString();
                string extend = name.Substring(name.LastIndexOf('.') + 1);
                string filePath = "~/Upload/" + types[0] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/" + fileid + "." + extend;
                AttachFile af = new AttachFile()
                {
                    ID = fileid,
                    RefID = uid,
                    FileName = fileid + "." + extend,
                    FileSize = size,
                    FileExtName = extend,
                    UploadTime = DateTime.Now,
                    BigClass = types[0],
                    FilePath = filePath,
                    RealFileName = name,

                };
                int i = new AttachFileBll().Save(af);
                if (i > 0)
                {
                    string savePath = Server.MapPath(filePath);
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                    }
                    file.SaveAs(savePath);
                    return Json(new
                    {
                        jsonrpc = "2.0",
                        id = id,
                        uid = fileid
                    });
                }
                else
                {
                    return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = id });
                }
            }
            catch (Exception ex)
            {

                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败", ExceptionMsg = ex.Message.Replace("\\", "/") }, id = id });
            }

        }

        public void deleteFile(string id)
        {
            new AttachFileBll().deleteFile(id);
        }
       
        public ActionResult GetFiles(string refid)
        {
            List<SimpalFile> list = new AttachFileBll().GetFiles(refid);
          
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
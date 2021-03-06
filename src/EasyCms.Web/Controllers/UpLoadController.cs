﻿using EasyCms.Business;
using EasyCms.Model;
using Sharp.Common;
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
        string host
        {
            get
            {
                
                string url = Request.Url.Authority + Request.ApplicationPath;
                if (!url.StartsWith("http://")) url = "http://" + url;
                return url;
            }
        }
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
                string ThumbnaifilePath = "~/Upload/" + types[0] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/" + fileid + "Thumbnai.jpg";
                string compressionfilePath = "~/Upload/" + types[0] + "/" + DateTime.Now.ToString("yyyyMMdd") + "/" + fileid + "compression.jpg";

                if (string.IsNullOrWhiteSpace(uid))
                {
                    uid = fileid;
                }
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
                     ThumbnaifilePath=ThumbnaifilePath,
                     CompressionfilePath=compressionfilePath

                };
                int i = new AttachFileBll().Save(af);
                if (i > 0)
                {
                    string savePath = Server.MapPath(filePath);
                    if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                    }
                    //保存原图
                    file.SaveAs(savePath);
                    //保存缩略图
                   int with=0,  height = 0;
                    ImgThumbnailType ThumbnailType = ImgThumbnailType.无;
                    ImgThumbnail.ThumbnailRecommend(file.InputStream, file.ContentLength, ref with, ref height, ref ThumbnailType);
                      ThumbnaifilePath = Server.MapPath(ThumbnaifilePath);
                    ImgThumbnail.Thumbnail(file.InputStream, ThumbnaifilePath, with, height, 100, ThumbnailType);

                    //保存压缩图 
                    ImgThumbnail.ThumbnailRecommend(file.InputStream, file.ContentLength,  ref with, ref height, ref ThumbnailType, true);
                    compressionfilePath = Server.MapPath(compressionfilePath);
                    ImgThumbnail.Thumbnail(file.InputStream, compressionfilePath, with, height, 100, ThumbnailType);
                    return Json(new
                    {
                        jsonrpc = "2.0",
                        id = id,
                        uid = fileid,
                        RefID = uid
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
            List<SimpalFile> list = new AttachFileBll().GetFiles(refid, host);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
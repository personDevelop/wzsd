using ImportData.OldEntity;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportData
{
    public partial class frmGetDetailImgPath : Form
    {
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");

        public frmGetDetailImgPath()
        {
            InitializeComponent();
        }
        StringBuilder sb = new StringBuilder();
        private void button1_Click(object sender, EventArgs e)
        {
              sb = new StringBuilder();
            string[] lsit = oldDb.From<h7_goods>().Select(h7_goods._.content).ToSinglePropertyArray();
            foreach (var item in lsit)
            {
                DownLoadImg(item);
            }
            textBox1.Text = sb.ToString();
        }

        private string DownLoadImg(string details)
        {
            string result = details; 
            try
            {
                string key = "src=\\\""; string endKey = "\\\"";
                int index = -1; int endIndex = -1;

                while (details.Contains(key))
                {
                    index = details.IndexOf(key); endIndex = details.IndexOf(endKey, index + key.Length);
                    string code = details.Substring(index + key.Length, endIndex - index - key.Length);
                    string path = string.Empty;
                    details = details.Substring(endIndex);
                    sb.AppendLine(code); 
                }

            }

            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            finally
            {

            }

            return result;
        }

        //private void  DownLoadImg(string imgUrl, int order, string refID, ref string newPath)
        //{
            
        //    newPath = string.Empty;
        //    string temPath = string.Empty;
           
        //    DateTime dtime = DateTime.Now;
        //    string imgExtend = ".jpg";
        //    string ImgName = string.Empty;
        //    if (imgUrl.StartsWith("http://"))
        //    {
        //        int index = imgUrl.LastIndexOf(".");
        //        imgExtend = imgUrl.Substring(index + 1);
        //        index = imgUrl.LastIndexOf("/");
        //        ImgName = imgUrl.Substring(index + 1);
        //    }
        //    else
        //    {
        //        af = new AttachFile() { ID = Guid.NewGuid().ToString(), RefID = refID, OrderNo = order };

        //        if (!imgUrl.StartsWith("/"))
        //        {
        //            imgUrl = "/" + imgUrl;
        //        }

        //        int index = imgUrl.LastIndexOf(".");
        //        imgExtend = imgUrl.Substring(index + 1);
        //        index = imgUrl.LastIndexOf("/");
        //        ImgName = imgUrl.Substring(index + 1);
        //        temPath = imgUrl.Substring(0, index);

        //        //解析存储路径 /upload/2015/05/25/20150525022430736.jpg 和 /upload/image/20140924/20140924173349_82108.jpg
        //        if (imgUrl.StartsWith("/upload/image/"))
        //        {
        //            // /upload/image/20140924/20140924173349_82108.jpg 
        //            // 对应 /Upload/image/20160302/6359255402554279341476917.jpg


        //            string date = temPath.Replace(" /upload/image/", "");
        //            System.IFormatProvider format = new System.Globalization.CultureInfo("zh-cn", true);

        //            dtime = DateTime.ParseExact(date, "yyyyMMdd", format);
        //            af.UploadTime = dtime;
        //        }
        //        else
        //        {
        //            // /upload/2015/05/25/20150525022430736.jpg  
        //            //对应~/Upload/image/20160228/0001840b-07b4-445a-80a8-b05738e21482.jpg
        //            string date = temPath.Replace("/upload/", "").Replace("/", "-");
        //            try
        //            {
        //                dtime = DateTime.Parse(date);
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //            af.UploadTime = dtime;
        //            temPath = "/Upload/image/" + dtime.ToString("yyyyMMdd");

        //        }

        //        af.FileExtName = imgExtend;
        //        af.FileName = af.RealFileName = ImgName;
        //        af.FilePath = "~" + temPath + "/" + ImgName;
        //        af.BigClass = "image";
        //    }
        //    temPath = "\\Upload\\image\\" + dtime.ToString("yyyyMMdd");
        //    if (temPath.StartsWith("\\"))
        //    {
        //        temPath = temPath.Substring(1);
        //    }
        //    path = Path.Combine(path, temPath);
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    path = Path.Combine(path, ImgName);
        //    if (!File.Exists(path))
        //    {
        //        if (!imgUrl.StartsWith("http://"))
        //        {
        //            imgUrl = "http://www.hong7.tv" + imgUrl.Trim();
        //        }
        //        else
        //        {

        //            newPath = "/Upload/imag/" + dtime.ToString("yyyyMMdd") + "/" + ImgName;
        //        }
        //        WebRequest Request = WebRequest.Create(imgUrl);
        //        try
        //        {
        //            using (WebResponse Response = Request.GetResponse())
        //            {
        //                Bitmap img = new Bitmap(Response.GetResponseStream());
        //                af.FileSize = img.Flags;
        //                img.Save(path);

        //            }
        //            CopyToFile(path);
        //        }
        //        catch (Exception ex)
        //        {

        //            backgroundWorker1.ReportProgress(1, new data(1, imgUrl + "下载失败" + ex.GetExceptionMsg()));
        //            backgroundWorker1.ReportProgress(1, new data(2, imgUrl));
        //        }

        //    }
        //    else
        //    {
        //        backgroundWorker1.ReportProgress(1, new data(1, "图片已存在，跳过下载"));

        //    }
        //    return af;
        //}
    }
}

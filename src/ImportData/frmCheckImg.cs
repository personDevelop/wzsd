using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sharp.Data;
using ImportData.OldEntity;
using EasyCms.Model;
using Sharp.Common;
using System.IO;
using System.Net;

namespace ImportData
{
    public partial class frmCheckImg : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        public frmCheckImg()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list = new List<AttachFile>();
            DataTable dt = newDb.From<AttachFile>().ToDataTable();
            foreach (DataRow item in dt.Rows)
            {
                string path = item["FilePath"] as string;
                path = path.Replace("~", textBox2.Text).Replace("/","\\");
                if (!File.Exists(path))
                {
                    list.Add(item.ToFirst<AttachFile>());
                }
            }
            gridControl1.DataSource = list;
            groupControl1.Text = "旧库" + list.Count;
           
            MessageBox.Show("加载成功");
        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<AdManage>(new Sharp.Common.WhereClip(" 1=1 "));
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_ad_manage>(h7_ad_manage._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<AdManage>(AdManage._.Code, false);
            groupControl2.Text = "新库" + dt2;
            MessageBox.Show("计算成功");
        }

        private void 开始同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list = gridControl1.DataSource as List<AttachFile>;
            foreach (var item in list)
            {
                DownLoadImg(item.FilePath);
            } 
           MessageBox.Show("同步完成"); 

        }

        private void DownLoadImg(string imgPaht)
        {
            string path = imgPaht.Replace("~", textBox2.Text).Replace("/", "\\");
            
            if (!File.Exists(path))
            {
           
               
                string fileName = imgPaht.Substring(imgPaht.LastIndexOf("/"));
                string yearday = fileName.Substring(1, 8);
                string url = imgPaht.Replace("~/Upload/image/", "/editgg/attached/file/"+yearday+"/");
                try
                {
                    WebRequest Request = WebRequest.Create("http://www.hong7.tv" + url);
                    using (WebResponse Response = Request.GetResponse())
                    {
                        Bitmap img = new Bitmap(Response.GetResponseStream());

                        img.Save(path);

                    }
                    CopyToFile(path);
                }
                catch (Exception)
                {
                    url = imgPaht.Replace("~/Upload/image/", "/upload/image/");
                    try
                    {
                        WebRequest Request = WebRequest.Create("http://www.hong7.tv" + url);
                        using (WebResponse Response = Request.GetResponse())
                        {
                            Bitmap img = new Bitmap(Response.GetResponseStream());

                            img.Save(path);

                        }
                        CopyToFile(path);
                    }
                    catch (Exception)
                    {
                        
                       
                    }
                }
            }

        }

      
        private void CopyToFile(string item)
        {
            item = item.ToLower();
            if (item.EndsWith(".jpg") || item.EndsWith(".gif") || item.EndsWith(".jpeg") || item.EndsWith(".png"))
            {


                string file = item.Substring(0, item.LastIndexOf("."));

                string ThumbnaifilePath = "Thumbnai.jpg";
                string compressionfilePath = "compression.jpg";
                //保存缩略图
                int with = 0, height = 0;
                ImgThumbnailType ThumbnailType = ImgThumbnailType.无;
                ImgThumbnail.ThumbnailRecommend(item, ref with, ref height, ref ThumbnailType);

                ImgThumbnail.Thumbnail(item, file + ThumbnaifilePath, with, height, 100, ThumbnailType);

                //保存压缩图 
                ImgThumbnail.ThumbnailRecommend(item, ref with, ref height, ref ThumbnailType, true);

                ImgThumbnail.Thumbnail(item, file + compressionfilePath, with, height, 100, ThumbnailType);
            }
        }

        private void 加载没有缩略图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list =   newDb.From<AttachFile>().Where(AttachFile._.ThumbnaifilePath.IsNullOrEmpty()).List<AttachFile>();
            
            gridControl1.DataSource = list;
            groupControl1.Text = "旧库" + list.Count;

            MessageBox.Show("加载成功");
        }

        private void 加载没有压缩图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list = newDb.From<AttachFile>().Where(AttachFile._.CompressionfilePath.IsNullOrEmpty()).List<AttachFile>();

            gridControl1.DataSource = list;
            groupControl1.Text = "旧库" + list.Count;

            MessageBox.Show("加载成功");
        }

        private void 更新缩略图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list = gridControl1.DataSource as List<AttachFile>;
            foreach (var item in list)
            {
                string oldPath = item.FilePath.Substring(0, item.FilePath.LastIndexOf("."));
                string newPath = oldPath + "Thumbnai.jpg";
                item.ThumbnaifilePath = newPath;
                 
            }
            newDb.Submit(list);
            MessageBox.Show("同步完成");
        }

        private void 更新压缩图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AttachFile> list = gridControl1.DataSource as List<AttachFile>;
            foreach (var item in list)
            {
                string oldPath = item.FilePath.Substring(0, item.FilePath.LastIndexOf("."));
                string newPath = oldPath + "compression.jpg";
                item.CompressionfilePath = newPath;

            }
            newDb.Submit(list);
            MessageBox.Show("同步完成");
        }
    }
}
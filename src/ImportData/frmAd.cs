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
    public partial class frmAd : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        public frmAd()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = oldDb.From<h7_ad_manage>().OrderBy(h7_ad_manage._.id).ToDataTable();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt.Rows.Count;
            DataTable dt2 = newDb.From<AdManage>().OrderBy(AdManage._.Code).ToDataTable();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Rows.Count;
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
            DataTable dt = gridControl1.DataSource as DataTable;
            List<AdPositon> listPosition = newDb.From<AdPositon>().List<AdPositon>();
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>();
                    foreach (DataRow item in dt.Rows)
                    {
                        h7_ad_manage h7 = item.ToFirst<h7_ad_manage>();
                        AdManage nb = new AdManage()
                        {
                            ID = Guid.NewGuid().ToString(),
                            Name = h7.name,
                            Code = h7.id.ToString(),
                             AdType=(AdType)h7.type,
                            Height=h7.height.ToString(),
                            Width=h7.width.ToString(),
                         PositionID= listPosition.Find(p=>p.Code==h7.position_id.ToString()).ID,
                           AdLinkType= AdLinkType.商品,
                            LinkUrl=h7.link,
                            OrderNo=h7.order,
                             Note=h7.description, 
                               
                        };
                        list.Add(nb);
                        if (!string.IsNullOrWhiteSpace(h7.content))
                        {
                            nb.ImgageID = Guid.NewGuid().ToString();
                            AttachFile af = DownLoadImg(h7.content, 0, nb.ImgageID);
                            list.Add(af);
                        }

                    }
                    SessionFactory dal = null;
                    IDbTransaction tr = newDb.BeginTransaction(out dal);
                    try
                    {
                        dal.SubmitNew(tr, ref dal, list);
                        dal.CommitTransaction(tr);
                        MessageBox.Show(" 同步成功");
                    }
                    catch (Exception)
                    {
                        dal.RollbackTransaction(tr);
                        throw;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.GetExceptionMsg());
                }
            }
            else
            { MessageBox.Show("没有需要同步的数据"); }

        }

        private AttachFile DownLoadImg(string imgUrl, int order, string refID)
        {
            AttachFile af = new AttachFile() { ID = Guid.NewGuid().ToString(), RefID = refID, OrderNo = order };

            if (!imgUrl.StartsWith("/"))
            {
                imgUrl = "/" + imgUrl;
            }
            string path = textBox2.Text;
            string imgExtend = ".jpg";
            int index = imgUrl.LastIndexOf(".");
            imgExtend = imgUrl.Substring(index + 1);
            index = imgUrl.LastIndexOf("/");
            string ImgName = imgUrl.Substring(index + 1);
            string temPath = imgUrl.Substring(0, index);
            DateTime dtime = DateTime.Now;
            //解析存储路径 /upload/2015/05/25/20150525022430736.jpg 和 /upload/image/20140924/20140924173349_82108.jpg
            if (imgUrl.StartsWith("/upload/image/"))
            {
                // /upload/image/20140924/20140924173349_82108.jpg 
                // 对应 /Upload/image/20160302/6359255402554279341476917.jpg


                string date = temPath.Replace(" /upload/image/", "");
                System.IFormatProvider format = new System.Globalization.CultureInfo("zh-cn", true);

                dtime = DateTime.ParseExact(date, "yyyyMMdd", format);
                af.UploadTime = dtime;
            }
            else
            {
                // /upload/2015/05/25/20150525022430736.jpg  
                //对应~/Upload/image/20160228/0001840b-07b4-445a-80a8-b05738e21482.jpg
                string date = temPath.Replace("/upload/", "").Replace("/", "-");
                dtime = DateTime.Parse(date);
                af.UploadTime = dtime;
                temPath = "/Upload/image/" + dtime.ToString("yyyyMMdd");

            }

            af.FileExtName = imgExtend;
            af.FileName = af.RealFileName = ImgName;
            af.FilePath = "~" + temPath + "/" + ImgName;
            af.BigClass = "image";

            temPath = "\\Upload\\image\\" + dtime.ToString("yyyyMMdd");
            if (temPath.StartsWith("\\"))
            {
                temPath = temPath.Substring(1);
            }
            path = Path.Combine(path, temPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, ImgName);
            if (!File.Exists(path))
            {
                WebRequest Request = WebRequest.Create("http://www.hong7.tv" + imgUrl.Trim());
                using (WebResponse Response = Request.GetResponse())
                {
                    Bitmap img = new Bitmap(Response.GetResponseStream());
                    af.FileSize = img.Flags;
                    img.Save(path);

                }
                CopyToFile(path);
            }
            return af;
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

    }
}
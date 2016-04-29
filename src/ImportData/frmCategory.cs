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
    public partial class frmCategory : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        public frmCategory()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = oldDb.From<h7_category>().OrderBy(h7_category._.parent_id, h7_category._.sort).ToDataTable();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt.Rows.Count;
            DataTable dt2 = newDb.From<ShopCategory>().OrderBy(ShopCategory._.Name).ToDataTable();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Rows.Count;
            MessageBox.Show("加载成功");
        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<ShopCategory>(new Sharp.Common.WhereClip(" 1=1 "));
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_category>(h7_category._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<ShopCategory>(ShopCategory._.Name, false);
            groupControl2.Text = "新库" + dt2;
            MessageBox.Show("计算成功");
        }

        private void 开始同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> hasSetParent = new List<string>();
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>();
                    List<ShopCategory> listShopCategory = new List<ShopCategory>();
                    foreach (DataRow item in dt.Rows)
                    {
                        h7_category h7 = item.ToFirst<h7_category>();
                        ShopCategory nb = new ShopCategory()
                        {
                            ID = Guid.NewGuid().ToString(),
                            Name = h7.name,
                            Code = h7.id.ToString(),
                            IsEnable = true,
                            IsShow = true,
                            IsMx = true,
                            Description = h7.descript,
                            OrderNo = h7.sort,
                            ClassCode = null,
                            Depth = 0,
                            ParentID = null
                        };
                        if (listShopCategory.Exists(p => p.Code == h7.parent_id.ToString()))
                        {
                            ShopCategory nbparent = listShopCategory.Find(p => p.Code == h7.parent_id.ToString());
                            if (!hasSetParent.Contains(nbparent.ID))
                            {
                                hasSetParent.Add(nbparent.ID);
                                nbparent.IsMx = false;
                            }

                            nb.ParentID = nbparent.ID;
                            nb.ClassCode = string.Format("{0};{1}", nbparent.ClassCode, nb.ID);
                            nb.Depth = nbparent.Depth + 1;

                        }
                        else
                        {
                            nb.ClassCode = nb.ID;

                        }
                        listShopCategory.Add(nb);

                        if (!string.IsNullOrWhiteSpace(h7.thumb))
                        {
                            nb.BigLogo = Guid.NewGuid().ToString();
                            AttachFile af = DownLoadImg(h7.thumb, 0, nb.BigLogo);
                            list.Add(af);
                        }
                    }
                    //创建商品类型
                    List<ShopCategory> mxList = listShopCategory.Where(p => p.IsMx).ToList();
                    foreach (ShopCategory item in mxList)
                    {
                        ShopProductType pt = new ShopProductType()
                        {
                            ID = Guid.NewGuid().ToString(),
                            Code = item.Code,
                            Name = item.Name
                        };
                        item.AssociatedProductType = pt.ID;
                        List<ShopCategory> parentList = listShopCategory.Where(p => item.ClassCode.StartsWith(p.ClassCode)).ToList();
                        foreach (var prent in parentList)
                        {
                            prent.AssociatedProductType = pt.ID;
                        }

                        list.Add(pt);
                    }
                    list.AddRange(listShopCategory);
                    SessionFactory dal = null;
                    IDbTransaction tr = newDb.BeginTransaction(out dal);
                    try
                    {
                        dal.SubmitNew(tr, ref dal, list);
                        dal.CommitTransaction(tr);
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
            //解析存储路径 /editgg/attached/file/20141124/20141124143756_18863.jpg

            string date = temPath.Replace("/editgg/attached/file/", "");
            System.IFormatProvider format = new System.Globalization.CultureInfo("zh-cn", true);

            dtime = DateTime.ParseExact(date, "yyyyMMdd", format);
            af.UploadTime = dtime;


            af.FileExtName = imgExtend;
            af.FileName = af.RealFileName = ImgName;
            af.FilePath = "~/Upload/image/" + ImgName;
            af.BigClass = "image";

            temPath = "Upload\\image\\" + dtime.ToString("yyyyMMdd");
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
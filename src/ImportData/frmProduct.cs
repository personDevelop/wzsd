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
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        Dictionary<string, string> brandCodeAndID = new Dictionary<string, string>();
        public frmProduct()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = oldDb.From<h7_goods>().OrderBy(h7_goods._.id.Desc).ToDataTable();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt.Rows.Count;
            DataTable dt2 = newDb.From<ShopProductInfo>().OrderBy(ShopProductInfo._.Code).ToDataTable();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Rows.Count;



            brandCodeAndID = new Dictionary<string, string>();
            DataTable dtBrand = newDb.From<ShopBrandInfo>().Select(ShopBrandInfo._.ID, ShopBrandInfo._.Code).ToDataTable();
            foreach (DataRow item in dtBrand.Rows)
            {
                brandCodeAndID.Add(item["Code"] as string, item["ID"] as string);
            }
            MessageBox.Show("加载成功");


        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<ShopProductInfo>(new Sharp.Common.WhereClip(" 1=1 "));
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_goods>(h7_goods._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<ShopProductInfo>(ShopProductInfo._.Name, false);
            groupControl2.Text = "新库" + dt2;
            MessageBox.Show("计算成功");
        }

        private void 开始同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            } 
        }

        private string DownLoadImg(string details)
        {
            string result = details;
            AttachFile af = new AttachFile();
            try
            {
                string key = "<img src=\""; string endKey = "\" alt=\"";
                int index = -1; int endIndex = -1;

                while (details.Contains(key))
                {
                    index = details.IndexOf(key); endIndex = details.IndexOf(endKey, index);
                    string code = details.Substring(index + key.Length, endIndex - index - key.Length);
                    string path = string.Empty;
                    DownLoadImg(code, 0, null,ref path);
                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        result = result.Replace(code, path);
                    }
                    details = details.Substring(endIndex);
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
        private AttachFile DownLoadImg(string imgUrl, int order, string refID,ref string newPath)
        {
            AttachFile af = null;
            newPath = string.Empty;
            string temPath = string.Empty;
            string path = textBox2.Text;
            DateTime dtime = DateTime.Now;
            string imgExtend = ".jpg";
            string ImgName = string.Empty;
            if (imgUrl.StartsWith("http://"))
            {
                int index = imgUrl.LastIndexOf(".");
                imgExtend = imgUrl.Substring(index + 1);
                index = imgUrl.LastIndexOf("/");
                  ImgName = imgUrl.Substring(index + 1);
            }
            else
            {
                  af = new AttachFile() { ID = Guid.NewGuid().ToString(), RefID = refID, OrderNo = order };

                if (!imgUrl.StartsWith("/"))
                {
                    imgUrl = "/" + imgUrl;
                }

                int index = imgUrl.LastIndexOf(".");
                imgExtend = imgUrl.Substring(index + 1);
                index = imgUrl.LastIndexOf("/");
                ImgName = imgUrl.Substring(index + 1);
                temPath = imgUrl.Substring(0, index);
               
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
                    try
                    {
                        dtime = DateTime.Parse(date);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    af.UploadTime = dtime;
                    temPath = "/Upload/image/" + dtime.ToString("yyyyMMdd");

                }

                af.FileExtName = imgExtend;
                af.FileName = af.RealFileName = ImgName;
                af.FilePath = "~" + temPath + "/" + ImgName;
                af.BigClass = "image";
            }
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
                if (!imgUrl.StartsWith("http://"))
                {
                    imgUrl = "http://www.hong7.tv" + imgUrl.Trim();
                }
                else
                {

                    newPath = "/Upload/imag/" + dtime.ToString("yyyyMMdd") + "/" + ImgName;
                }
                WebRequest Request = WebRequest.Create(imgUrl);
                try
                {
                    using (WebResponse Response = Request.GetResponse())
                    {
                        Bitmap img = new Bitmap(Response.GetResponseStream());
                        af.FileSize = img.Flags;
                        img.Save(path);

                    }
                    CopyToFile(path);
                }
                catch (Exception ex)
                {

                    backgroundWorker1.ReportProgress(1, new data(1, imgUrl + "下载失败" + ex.GetExceptionMsg())  );
                    backgroundWorker1.ReportProgress(1, new data(2,   imgUrl)  );
                }

            }
            else
            {
                backgroundWorker1.ReportProgress(1, new data(1, "图片已存在，跳过下载") );

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1, new data(1, "开始"));
            Dictionary<string, string> productCodeAndID = new Dictionary<string, string>();
            List<string> hasSetParent = new List<string>();
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>();
                    List<ShopProductInfo> listShopProductInfo = new List<ShopProductInfo>();
                    foreach (DataRow item in dt.Rows)
                    {
                        h7_goods h7 = item.ToFirst<h7_goods>();
                        ShopProductInfo nb = new ShopProductInfo()
                        {
                            ID = Guid.NewGuid().ToString(),
                            AddedDate = h7.create_time,
                            CommentCount = h7.comments,
                            CostPrice = h7.cost_price ?? 0,
                            Stock = h7.store_nums,
                            IsCashOnDelivery = true,
                            LaunchDate = h7.up_time,
                            MarketPrice = h7.market_price ?? 0,
                            Meta_Description = h7.description,
                            Meta_Keywords = h7.keywords,
                            Meta_Title = h7.name,
                            PCDescription = h7.content,
                            Weight = h7.weight,
                            VistiCounts = h7.visit,
                            Unit = h7.unit,
                            Points = h7.point,
                            SaleCounts = h7.sale,
                            SaleDate = h7.up_time ?? DateTime.Now,
                            SalePrice = h7.sell_price,
                            SaleNum = h7.sale,
                            SaleStatus = 1,
                            TypeId = "",
                            Tags = h7.search_words,
                            DisplaySequence = h7.sort,
                            RegionId = h7.id.ToString(),
                            SalesType = 1,
                            ShopCategoryID = "",
                            SKU = h7.goods_no,
                            Name = h7.name,
                            Code = h7.goods_no,
                            Description = h7.content,
                        };
                        switch (h7.is_del)
                        {
                            case 0: break;
                            case 1:
                            case 2:
                                nb.SaleStatus = 0; break;

                            default:
                                break;
                        }
                        productCodeAndID.Add(h7.id.ToString(), nb.ID);
                        if (h7.brand_id.HasValue && h7.brand_id > 0)
                        {
                            //查找其brandID
                            if (brandCodeAndID.ContainsKey(h7.brand_id.ToString()))
                            {
                                nb.BrandId = brandCodeAndID[h7.brand_id.ToString()];
                            }
                        }

                        listShopProductInfo.Add(nb);
                    }
                    //同步其商品分类ID 
                    List<ShopCategory> listCategory = newDb.From<ShopCategory>().List<ShopCategory>();
                    Dictionary<string, string> categoryCodeAndID = new Dictionary<string, string>();
                    foreach (var item in listCategory)
                    {
                        categoryCodeAndID.Add(item.Code, item.ID);
                    }

                    //同步其商品类型ID 
                    List<ShopProductType> listProductType = newDb.From<ShopProductType>().List<ShopProductType>();
                    Dictionary<string, string> ProductTypeCodeAndID = new Dictionary<string, string>();
                    foreach (var item in listProductType)
                    {
                        ProductTypeCodeAndID.Add(item.Code, item.ID);
                    }
                    List<h7_category_extend> dtCatory = oldDb.From<h7_category_extend>().List<h7_category_extend>();

                    foreach (h7_category_extend item in dtCatory)
                    {
                        ShopProductCategory sc = new ShopProductCategory()
                        {
                            ID = Guid.NewGuid().ToString(),
                            CategoryID = categoryCodeAndID[item.category_id.ToString()],
                            ProductID = productCodeAndID[item.goods_id.ToString()]
                        };
                        ShopProductInfo pro = listShopProductInfo.Find(p => p.RegionId == item.goods_id.ToString());
                        if (string.IsNullOrWhiteSpace(pro.TypeId) && ProductTypeCodeAndID.ContainsKey(sc.CategoryID.ToString()))
                        {
                            pro.TypeId = ProductTypeCodeAndID[sc.CategoryID.ToString()];
                        }
                        list.Add(sc);
                    }
                    List<goods_photo> goodPhotoList = oldDb.From<h7_goods_photo_relation>().Join<h7_goods_photo>(h7_goods_photo._.id == h7_goods_photo_relation._.photo_id)
                        .Select(h7_goods_photo_relation._.goods_id, h7_goods_photo._.img).List<goods_photo>();
                    string refString = string.Empty;
                    foreach (var item in listShopProductInfo)
                    {
                        backgroundWorker1.ReportProgress(1, new data(1, "开始下载图像"+item.RegionId));
                        List<goods_photo> listPhoto = goodPhotoList.Where(p => p.goods_id.ToString() == item.RegionId).ToList<goods_photo>();
                        for (int i = 0; i < listPhoto.Count; i++)
                        {
                            list.Add(DownLoadImg(listPhoto[i].img, i, item.ID, ref refString));

                        }
                        //下载描述文档里的图片 
                        string s = item.PCDescription;
                        backgroundWorker1.ReportProgress(1, new data(1, "开始下载图像文档里的图片"));
                        string result = DownLoadImg(s);
                        item.PCDescription = item.Description = result;
                    }

                    //同步其商品附件ID 
                    backgroundWorker1.ReportProgress(1, new data(1, "开始准备保存数据"));
                    list.AddRange(listShopProductInfo);
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
                    backgroundWorker1.ReportProgress(100, new data(1, "处理完成"));
                }
                catch (Exception ex)
                {
                    backgroundWorker1.ReportProgress(1, new data(100, "处理失败")+ ex.GetExceptionMsg());
                   
                }
            }
            else
            { backgroundWorker1.ReportProgress(1, new data(100, "没有需要同步的数据"));  }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            data d = e.UserState as data;
            if (d!=null)
            {
                switch (d.id)
                {
                    case 1:
                        memoEdit1.Text =d.msg+Environment.NewLine+ memoEdit1.Text;
                        break;
                    default:
                        memoEdit2.Text = d.msg + Environment.NewLine + memoEdit2.Text;
                        break;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("同步完成");
        }
        class data {
            

            public data(int v1, string v2)
            {
                this.id = v1;
                this.msg = v2;
            }

            public int id { get; set; }
            public string msg { get; set; }

        }

    }
}
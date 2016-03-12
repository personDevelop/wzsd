using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ImportData
{
    public partial class Form2 : Form
    {
        Sharp.Data.SessionFactory dal = Sharp.Data.SessionFactory.Default;
        public Form2()
        {
            InitializeComponent();

        }
        Dictionary<string, string> productTypeID = new Dictionary<string, string>();
        Dictionary<string, string> categoryDict = new Dictionary<string, string>();
        List<BaseEntity> list = new List<BaseEntity>();
        private void button1_Click(object sender, EventArgs e)
        {
            list = new List<BaseEntity>();
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false; 
        }
        private void DownLoadImg(string details)
        {
            AttachFile af = new AttachFile();
            try
            {
                string key = "<img src=\""; string endKey = "\" alt=\"\" />";
                int index = -1; int endIndex = -1;

                while (details.Contains(key))
                {
                    index = details.IndexOf(key); endIndex = details.IndexOf(endKey, index);
                    string code = details.Substring(index + key.Length, endIndex - index - key.Length);
                    DownLoadImg(code, 0, null);
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


        }
        private AttachFile DownLoadImg(string imgUrl, int order, string refID)
        {
            AttachFile af = new AttachFile();
            try
            {

                string path = textBox2.Text;
                string imgExtend = ".jpg";
                int index = imgUrl.LastIndexOf(".");

                imgExtend = imgUrl.Substring(index + 1);
                index = imgUrl.LastIndexOf("/");
                string ImgName = imgUrl.Substring(index + 1);
                string temPath = imgUrl.Substring(0, index);
                //解析存储路径 /upload/2015/05/25/20150525022430736.jpg 和 /upload/image/20140924/20140924173349_82108.jpg
                if (imgUrl.StartsWith("/upload/image/"))
                {
                    // /upload/image/20140924/20140924173349_82108.jpg 
                    // 对应 /Upload/image/20160302/6359255402554279341476917.jpg

                    temPath = temPath.Replace('/', '\\');
                }
                else
                {
                    // /upload/2015/05/25/20150525022430736.jpg  
                    //对应~/Upload/image/20160228/0001840b-07b4-445a-80a8-b05738e21482.jpg
                    string date = temPath.Replace("/upload/", "").Replace("/", "-");
                    DateTime dtime = DateTime.Parse(date);

                    temPath = "~/Upload/image/" + DateTime.Parse(date).ToString("yyyyMMdd");
                    af.UploadTime = dtime;
                    af.ID = Guid.NewGuid().ToString();
                    af.FileExtName = imgExtend;
                    af.FileName = af.RealFileName = ImgName;
                    af.FilePath = temPath+"/"+ImgName;
                    af.BigClass = "image";
                    af.OrderNo = order;
                    af.RefID = refID;
                    temPath = "\\Upload\\image\\" + DateTime.Parse(date).ToString("yyyyMMdd");


                }
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
                }

            }

            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            finally
            {

            }

            return af;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            productTypeID = new Dictionary<string, string>();
            categoryDict = new Dictionary<string, string>();
            List<ShopCategory> ShopCategoryList = dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.Name).List<ShopCategory>();
            foreach (var item in ShopCategoryList)
            {
                categoryDict.Add(item.Name, item.ID);
            }
            List<ShopProductType> productTypeList = dal.From<ShopProductType>().Select(ShopProductType._.ID, ShopProductType._.Name).List<ShopProductType>();


            foreach (var item in productTypeList)
            {
                productTypeID.Add(item.Name, item.ID);
            }

            int start = (int)numericUpDown1.Value;
            int end = (int)numericUpDown2.Value;
            for (int i = start; i < end; i++)
            {
                
                string url = string.Format(textBox1.Text, i);
                backgroundWorker1.ReportProgress(0, "第"+i+"个"+ url);
                WebRequest Request = WebRequest.Create(url.Trim());
                WebResponse Response = Request.GetResponse();
                StringBuilder sb = new StringBuilder();
                string rl;
                using (Stream resStream = Response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                    {
                        bool isZd = false;
                        while ((rl = sr.ReadLine()) != null)
                        {
                            if (rl.Contains("按钮绑定"))
                            { break; }
                            if (rl.Contains("<!-- 商品详情 end -->"))
                            {

                                sb.Append(rl);
                                isZd = true;

                            }
                            if (isZd)
                            {
                                if (rl.Contains("生成商品价格"))
                                { isZd = false; }
                            }
                            else
                            {
                                sb.Append(rl);
                            }
                        }
                    }
                }
                string str = sb.ToString().ToLower();
                if (str.Contains("传递的参数不正确") || str.Contains("这件商品不存在"))
                {
                    backgroundWorker1.ReportProgress(0, "第" + i + "个" + url+ "这件商品不存在");
                    continue;
                }
                else
                {

                    string producntid = Guid.NewGuid().ToString();
                    ShopProductInfo productInfo = new ShopProductInfo()
                    {

                        ID = producntid,
                        AddedDate = DateTime.Now,
                        DisplaySequence = i,
                        IsCashOnDelivery = true,
                        SaleDate = DateTime.Now,
                        SaleStatus = 1,
                        SalesType = 1,
                    };
                    //查找商品名称
                    string key = "<title>", endKey = "</title>";
                    int index = str.IndexOf(key), endIndex = str.IndexOf(endKey);
                    // index =1  endindex=9   s<title>亮</title>
                    string title = str.Substring(index + key.Length, endIndex - index - key.Length);
                    title = title.Replace("_红七商城", "");
                    productInfo.Name = title;
                    //查商品编号
                    key = "id=\"data_goodsno\">"; endKey = "</label>";
                    index = str.IndexOf(key); endIndex = str.IndexOf(endKey, index);
                    string code = str.Substring(index + key.Length, endIndex - index - key.Length);
                    productInfo.Code = productInfo.SKU = code;
                    //查商品分类  >运动机</a> » 海斯曼健康活力有氧运动机HM01-08VA减肥健身塑体</div>
                    key = ">"; endKey = "</a> » " + title + "</div>";
                    endIndex = str.IndexOf(endKey);
                    index = str.LastIndexOf(key, endIndex);
                    string categoryName = str.Substring(index + key.Length, endIndex - index - key.Length).Trim();
                    if (!string.IsNullOrWhiteSpace(categoryName))
                    {
                        if (categoryDict.ContainsKey(categoryName))
                        {
                            ShopProductCategory SC = new ShopProductCategory()
                            {
                                ID = Guid.NewGuid().ToString(),
                                ProductID = producntid,
                                CategoryID = categoryDict[categoryName]
                            };
                            list.Add(SC);
                        }

                        if (!productTypeID.ContainsKey(categoryName))
                        {
                            ShopProductType sp = new ShopProductType() { ID = Guid.NewGuid().ToString(), Name = categoryName, Code = categoryName };
                            productTypeID.Add(categoryName , sp.ID); 
                            list.Add(sp);
                        }

                    }
                    //查商品市场价
                    key = "市场价：<s id=\"data_marketprice\">￥"; endKey = "</s>";
                    index = str.IndexOf(key); endIndex = str.IndexOf(endKey, index);
                    string price = str.Substring(index + key.Length, endIndex - index - key.Length);
                    decimal outprice = 0;
                    if (decimal.TryParse(price, out outprice))
                    {
                        productInfo.MarketPrice = outprice;
                    }
                    //查商品销售价
                    key = ",\"sell_price\":\""; endKey = "\"});";
                    index = str.IndexOf(key); endIndex = str.IndexOf(endKey, index);
                    string saleprice = str.Substring(index + key.Length, endIndex - index - key.Length);

                    if (decimal.TryParse(saleprice, out outprice))
                    {
                        productInfo.SalePrice = outprice;
                    }
                    //查商品图像
                    key = "<ul id=\"thumblist\" class=\"pic_thumb\">"; endKey = "</ul>";

                    index = str.IndexOf(key); endIndex = str.IndexOf(endKey, index);
                    string tem = str.Substring(index + key.Length, endIndex - index - key.Length);
                    key = ",largeimage:'"; endKey = "'}\">";
                    int order = 1;
                    while (tem.IndexOf(key) > -1)
                    {
                        index = tem.IndexOf(key); endIndex = tem.IndexOf(endKey, index);
                        string imgUrl = tem.Substring(index + key.Length, endIndex - index - key.Length);
                        AttachFile af = DownLoadImg(imgUrl, order++, producntid);
                        if (af != null)
                        {
                            list.Add(af);
                        }
                        tem = tem.Substring(endIndex);
                    }
                    //查商品详情
                    key = "<div class=\"salebox\">"; endKey = @"</div>							</div>			<!-- 商品详情 end -->";
                    index = str.IndexOf(key); endIndex = str.IndexOf(endKey, index);
                    string details = str.Substring(index + key.Length, endIndex - index - key.Length);
                    DownLoadImg(details);
                    productInfo.Description = details;
                    productInfo.Points = productInfo.SalePrice;
                    list.Add(productInfo);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.UserState as string ;
            textBox3.Text = textBox3.Text + label1.Text + Environment.NewLine;
            if (true)
            {

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dal.Submit(list);
            label1.Text = "操作完成" ;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int v=(int)( numericUpDown2.Value - numericUpDown1.Value);
            numericUpDown1.Value = numericUpDown2.Value;
            numericUpDown2.Value = numericUpDown1.Value + v;
        }
    }
}

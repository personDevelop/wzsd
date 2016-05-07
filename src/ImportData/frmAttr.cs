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
using EasyCms.Web.Common;
namespace ImportData
{
    public partial class frmAttr : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        
        public frmAttr()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = oldDb.From<h7_spec>().Where(h7_spec._.is_del==0).OrderBy(h7_spec._.id.Desc).ToDataTable();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt.Rows.Count;
            DataTable dt2 = newDb.From<ShopExtendInfo>(). ToDataTable();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Rows.Count;
             
            MessageBox.Show("加载成功");


        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<ShopExtendInfo>(new Sharp.Common.WhereClip(" 1=1 "));
            newDb.Delete<ShopExtendInfoValue>(new Sharp.Common.WhereClip(" 1=1 ")); 
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_spec>(h7_spec._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<ShopExtendInfo>(ShopExtendInfo._.Name, false);
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
                    List<ShopExtendInfo> listShopExtendInfo = new List<ShopExtendInfo>();
                    foreach (DataRow item in dt.Rows)
                    {
                        h7_spec h7 = item.ToFirst<h7_spec>();
                        ShopExtendInfo nb = new ShopExtendInfo()
                        {
                            ID = Guid.NewGuid().ToString(),
                            CategoryID = "sd",
                            FullName = h7.name,
                            Name = h7.name,
                            ShowType = AttrShowType.单选,
                            DisplayOrder = h7.id,
                            UseAttrImg = h7.type == 2,
                            UsageMode= UsageMode.系统规格,
                            IsCanSearch=true 
                        };
                        string valinfo = h7.value.Replace("[","").Replace("]", "");
                        string[] vals = valinfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int i = 0;
                        List<ShopExtendInfoValue> listVals = new List<ShopExtendInfoValue>();
                        foreach (string v in vals)
                        {
                            ShopExtendInfoValue extendValue = new ShopExtendInfoValue()
                            {
                                ID = Guid.NewGuid().ToString(),
                                AttributeId = nb.ID,
                                DisplaySequence = i++
                            };
                            string temval = v.Replace("\\\"", "");

                            if (temval.StartsWith("upload/"))
                            {
                                string ff = string.Empty;
                                extendValue.ImageID = Guid.NewGuid().ToString();
                                AttachFile af = DownLoadImg(temval, i, extendValue.ImageID, ref ff);
                                list.Add(af);
                                extendValue.ValueStr = "图片";
                            }
                            else
                            {
                                extendValue.ValueStr = temval;
                            }
                            listVals.Add(extendValue);
                            list.Add(extendValue);
                        }
                        nb.ValInfo= JsonWithDataTable.Serialize(listVals);



                        list.Add(nb);
                    }
                      

                   
                    backgroundWorker1.ReportProgress(1, new data(1, "开始准备保存数据"));
                    list.AddRange(listShopExtendInfo);
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

        private void 更新值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ShopExtendInfo> list = newDb.From<ShopExtendInfo>().List<ShopExtendInfo>();
            List<ShopExtendInfoValue> listValue= newDb.From<ShopExtendInfoValue>()
                .Join<AttachFile>(ShopExtendInfoValue._.ImageID==AttachFile._.RefID,JoinType.leftJoin)
                .Select(ShopExtendInfoValue._.ID.All,AttachFile.GetThumbnaifilePath("", "ImgUrl"))
                .OrderBy(ShopExtendInfoValue._.AttributeId,ShopExtendInfoValue._.DisplaySequence).List<ShopExtendInfoValue>();
            foreach (var item in list)
            {
                List<ShopExtendInfoValue> ChildlistValue = listValue.Where(p => p.AttributeId == item.ID).ToList();
                 
                if (ChildlistValue.Count > 0)
                {
                    List<SimpalShopExtendInfoValue> childValue = new List<SimpalShopExtendInfoValue>();
                    foreach (var c in ChildlistValue)
                    {
                        childValue.Add(new SimpalShopExtendInfoValue() { ID= c.ID, ValueStr= c.ValueStr, ImgUrl= c.ImgUrl});
                    }

 

                    item.ValInfo = JsonWithDataTable.Serialize(childValue   );
                }
                else { item.ValInfo = ""; }
            }
            newDb.Submit(list);
            MessageBox.Show("更新完成");
        }
    }
}
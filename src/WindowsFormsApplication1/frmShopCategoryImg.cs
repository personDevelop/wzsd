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

namespace WindowsFormsApplication1
{
    public partial class frmShopCategoryImg : Form
    {
        List<ShopCategory> List = null;
        Sharp.Data.SessionFactory dal = Sharp.Data.SessionFactory.Default;
        public frmShopCategoryImg()
        {
            InitializeComponent();
            List = dal.From<ShopCategory>().Where(ShopCategory._.SmallLogo.IsNullOrEmpty()).List<ShopCategory>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "共" + List.Count + "条";
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();

            }
        }
        int i = 0;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            i = 0;

            foreach (var item in List)
            {
                i++;
                //获取第一个商品的第一个图片


                AttachFile af = dal.From<ShopProductCategory>().Join<ShopProductInfo>(
             ShopProductCategory._.ProductID == ShopProductInfo._.ID)
             .Join<ShopCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID)
             .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID)
             .OrderBy(AttachFile._.OrderNo)
             .Select(AttachFile._.ID.All).Where(ShopProductCategory._.CategoryID.In(getCategorys(item.ID))).ToFirst<AttachFile>();
                if (af != null)
                {
                    item.SmallLogo = Guid.NewGuid().ToString();
                    af.RecordStatus = StatusType.add;
                    af.ID = Guid.NewGuid().ToString();
                    af.RefID = item.SmallLogo;



                    try
                    {

                        dal.Submit(item);
                        dal.Submit(af);
                        backgroundWorker1.ReportProgress(1, new msg() { Msg = item.Name + "更新成功", index = i });

                    }
                    catch (Exception ex)
                    {
                        backgroundWorker1.ReportProgress(1, new msg() { Msg = item.Name + "更新失败" + ex.GetExceptionMsg(), index = i, isExeception = true });

                    }
                }
            }


        }
        class msg
        {
            public string Msg { get; set; }
            public int index { get; set; }

            public string url { get; set; }

            public bool isExeception { get; set; }
        }

        private string[] getCategorys(string categoryid)
        {
            return dal.From<ShopCategory>().Where(ShopCategory._.ClassCode.Contains(categoryid)).Select(ShopCategory._.ID).ToSinglePropertyArray();



        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            msg d = e.UserState as msg;
            if (d != null)
            {
                if (d.isExeception)
                {
                    textBox1.Text = d.Msg + Environment.NewLine + textBox1.Text;
                    textBox1.Text = Environment.NewLine + textBox1.Text;
                }
                else
                {
                    label2.Text = d.Msg + textBox1.Text;

                }

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("更新完成");

        }
    }
}

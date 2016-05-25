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
    public partial class frmaddress : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        Dictionary<string, string> brandCodeAndID = new Dictionary<string, string>();
        public frmaddress()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<h7_address> dt = oldDb.From<h7_address>().List<h7_address>();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt. Count;
            List<ShopShippingAddress> dt2 = newDb.From<ShopShippingAddress>().List< ShopShippingAddress>();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Count;

             
            MessageBox.Show("加载成功");


        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<ShopShippingAddress>(new WhereClip(" 1=1 ")); 
            oldDb.Delete<NewAndOldRalation>(NewAndOldRalation._.RalationType == (int)OldEntity.RalationType.地址);
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_address>(h7_address._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<ShopShippingAddress>(ShopShippingAddress._.ID, false);
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
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(1, new data(1, "开始")); 
            List<h7_address> dt = gridControl1.DataSource as List<h7_address>;
            List<NewAndOldRalation> NewAndOldRalationList = new List<NewAndOldRalation>();
            List<AdministrativeRegions> listregion = newDb.From<AdministrativeRegions>().List<AdministrativeRegions>();
            List<h7_areas> oldregion = newDb.From<h7_areas>().List<h7_areas>(); 
            List<NewAndOldRalation> listAccount= oldDb.From<NewAndOldRalation>().Where(NewAndOldRalation._.RalationType == (int)OldEntity.RalationType.会员).List<NewAndOldRalation>();
            if (dt != null && dt.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>(); 
                    foreach (h7_address item in dt )
                    {
                        string userid = listAccount.Find(p => p.OldID == item.user_id).NewID;
                        
                        ShopShippingAddress nb = new ShopShippingAddress()
                        {
                            ID =Guid.NewGuid().ToString(),
                                UserId= userid,
                                 Address= item.address,
                            TelPhone=item.telphone,
                                  CelPhone = item.mobile ,
                                   IsDefault=item.Isdefault==1,
                                   Zipcode=item.zip, 
                        };

                       


                        list.Add(nb);
                       
                        NewAndOldRalation adrord = new NewAndOldRalation() { NewID = nb.ID, OldID = item.id, RalationType = OldEntity.RalationType.地址 };
                        NewAndOldRalationList.Add(adrord);
                    } 
                    backgroundWorker1.ReportProgress(1, new data(1, "开始准备保存数据"));
                   
                    SessionFactory dal = null;
                    IDbTransaction tr = newDb.BeginTransaction(out dal);
                    try
                    {
                        dal.SubmitNew(tr, ref dal, list);
                        oldDb.Submit(NewAndOldRalationList);
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
                    backgroundWorker1.ReportProgress(1, new data(100, "处理失败") + ex.GetExceptionMsg());

                }
            }
            else
            { backgroundWorker1.ReportProgress(1, new data(100, "没有需要同步的数据")); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            data d = e.UserState as data;
            if (d != null)
            {
                switch (d.id)
                {
                    case 1:
                        memoEdit1.Text = d.msg + Environment.NewLine + memoEdit1.Text;
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
        class data
        {


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
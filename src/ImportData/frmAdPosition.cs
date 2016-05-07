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
    public partial class frmAdPosition : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        public frmAdPosition()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = oldDb.From<h7_ad_position>().OrderBy(h7_ad_position._.id).ToDataTable();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt.Rows.Count;
            DataTable dt2 = newDb.From<AdPositon>().OrderBy(AdPositon._.Code).ToDataTable();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Rows.Count;
            MessageBox.Show("加载成功");
        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<AdPositon>(new Sharp.Common.WhereClip(" 1=1 "));
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_ad_position>(h7_ad_position._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<AdPositon>(AdPositon._.Code, false);
            groupControl2.Text = "新库" + dt2;
            MessageBox.Show("计算成功");
        }

        private void 开始同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = gridControl1.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>();
                    foreach (DataRow item in dt.Rows)
                    {
                        h7_ad_position h7 = item.ToFirst<h7_ad_position>();
                        AdPositon nb = new AdPositon()
                        {
                            ID = Guid.NewGuid().ToString(),
                            Name = h7.name,
                            Code = h7.id.ToString(),
                             AdType=(AdType)h7.type,
                            Height=h7.height.ToString(),
                            Width=h7.width.ToString(),
                             IsEnable=true,
                             ShowNums=h7.ad_nums,
                              ShowType=(AdShowType)h7.fashion 
                        };
                        list.Add(nb);
                         
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


       
    }
}
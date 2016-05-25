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
    public partial class frmOrder : DevExpress.XtraEditors.XtraForm
    {
        SessionFactory newDb = SessionFactory.Default;
        SessionFactory oldDb = SessionFactory.SetTemporaryDatabase("hong7OldDb");
        Dictionary<string, string> brandCodeAndID = new Dictionary<string, string>();
        public frmOrder()
        {
            InitializeComponent();
        }

        private void 加载新库和旧库现有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<h7_order> dt = oldDb.From<h7_order>().List<h7_order>();
            gridControl1.DataSource = dt;
            groupControl1.Text = "旧库" + dt. Count;
            List<ShopOrder> dt2 = newDb.From<ShopOrder>().List< ShopOrder>();
            gridControl2.DataSource = dt2;
            groupControl2.Text = "新库" + dt2.Count;

             
            MessageBox.Show("加载成功");


        }

        private void 全部删除新库数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDb.Delete<ShopOrder>(new WhereClip(" 1=1 "));
            newDb.Delete<ShopOrderItem>(new WhereClip(" 1=1 "));
            newDb.Delete<ShopOrderAction>(new WhereClip(" 1=1 "));
            newDb.Delete<ShopShippingAddress>(new WhereClip(" 1=1 "));
            oldDb.Delete<NewAndOldRalation>(NewAndOldRalation._.RalationType==(int)OldEntity.RalationType.订单 );
         
            MessageBox.Show("删除成功");
        }

        private void 计算新库和旧库的数据个数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = oldDb.Count<h7_order>(h7_order._.id, false);

            groupControl1.Text = "旧库" + dt;
            int dt2 = newDb.Count<ShopOrder>(ShopOrder._.ID, false);
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
            List<h7_order> dt = gridControl1.DataSource as List<h7_order>;
            List<ShopProductInfo> newproduct = newDb.From<ShopProductInfo>().Join<AttachFile>(ShopProductInfo._.ID==AttachFile._.RefID&& AttachFile._.OrderNo==0,JoinType.leftJoin).Select(ShopProductInfo._.ID.All,AttachFile.GetThumbnaifilePath("", "ThumbImgUrl")).List<ShopProductInfo>();
            List <h7_order_goods> goodsList = oldDb.From<h7_order_goods>().List<h7_order_goods>();
            List<h7_address> oldaddress= oldDb.From<h7_address>().List<h7_address>();
            List<ShopShippingAddress> newaddress = newDb.From<ShopShippingAddress>().List<ShopShippingAddress>();
            List<AdministrativeRegions> area = newDb.From<AdministrativeRegions>().List<AdministrativeRegions>();
            List<h7_order_goods> dtChild = oldDb.From<h7_order_goods>().List<h7_order_goods>();
            List<NewAndOldRalation> listAccount= oldDb.From<NewAndOldRalation>().Where(NewAndOldRalation._.RalationType == (int)OldEntity.RalationType.会员).List<NewAndOldRalation>();
            List<NewAndOldRalation> listRagion = oldDb.From<NewAndOldRalation>().Where(NewAndOldRalation._.RalationType == (int)OldEntity.RalationType.地址).List<NewAndOldRalation>();
            h7_order itemt = null;
            if (dt != null && dt.Count > 0)
            {
                try
                {
                    List<BaseEntity> list = new List<BaseEntity>();
                    List<NewAndOldRalation> NewAndOldRalationList = new List<NewAndOldRalation>();
                    List<ManagerUserInfo> userInfoList =newDb.From<ManagerUserInfo>() . List<ManagerUserInfo>();
                    foreach (h7_order item in dt )
                    {
                        itemt = item;
                        NewAndOldRalation userlistAccount = listAccount.Find(p => p.OldID == item.user_id);
                        if (userlistAccount==null)
                        {
                            continue;
                        }
                        string userid = userlistAccount.NewID;
                        ManagerUserInfo user = userInfoList.Find(p => p.ID == userid);
                        string payTypeid=item.pay_type>0?"":null;
                        string payTypeName= item.pay_type > 0 ? "支付宝" : "货到付款";
                        ShopOrder nb = new ShopOrder()
                        {
                            ID =item.order_no,
                               MemberID= userid,
                                PayTypeID= payTypeid,
                                 PayTypeName= payTypeName,
                                  IsFreeShiping=true,
                                   TraceNo=item.trade_no,
                                    OrderType=item.type,
                                    OrderPoint=item.point,
                                     TotalPrice= item.order_amount,
                                      Discount=item.discount,
                            MemberName= user.Name,
                            MemberEmail=user.Email,
                            MemberCallPhone=user.ContactPhone,
                            RegionID=0,
                            ShipRegion="",
                            ShipAddress=item.address,
                             ShipZip=item.postcode,
                             ShipTel=item.mobile,
                             ShipName=item.accept_name,
                            ShipEmail=user.Email,
                            PayMoney=item.real_amount,
                            HasDelete= item.if_del==1,
                             InvoiceInfo=item.invoice_title,
                              IsInvoice=item.invoice==1,
                            Remark=item.postscript+ item.note,
                            FreightAdjust=item.promotions,
                            FreightActual=item.real_freight,
                            ShipStatus=  item.distribution_status .Value,
                            PayStatus=item.pay_status.Value,
                            CreateDate=item.create_time.Value,
                            PublishDateTime=item.send_time


                        };
                        switch (item.status)
                        {
                           
                            case 1:
                            case 2:
                                nb.OrderStatus = (int)OrderStatus.等待商家发货;

                                break;
                            case 3:
                                nb.OrderStatus = (int)OrderStatus.取消订单;

                                break;
                            case 4:
                                nb.OrderStatus = (int)OrderStatus.作废;

                                break;
                            default:
                                nb.OrderStatus = (int)OrderStatus.完成;
                                break;
                        }
                        NewAndOldRalation address = listRagion.Find(p => p.OtherInfo == item.area.ToString());
                        nb.RegionID = int.Parse(address.NewID);
                        nb.UpdateDate = DateTime.Now;
                        ShopShippingAddress ar = new ShopShippingAddress()
                        {
                            ID = Guid.NewGuid().ToString(),
                            UserId = userid,
                            Address = item.address,
                            TelPhone = item.telphone,
                            CelPhone = item.mobile,
                            IsDefault = true, 
                             RegionId= nb.RegionID,
                           ShipName=item.accept_name
                        };

                        nb.ShipRegion = area.Find(p => p.ID == nb.RegionID).Path.Replace("/", "");
                        IEnumerable<h7_order_goods> childList = goodsList.Where(p => p.order_id == item.id);
                        bool isHad = false;
                        foreach (h7_order_goods child  in childList)
                        {
                            ShopProductInfo pp = newproduct.Find(p => p.RegionId == child.goods_id.ToString());
                            if (pp==null)
                            {
                                break;
                            }
                            isHad = true;
                            ShopOrderItem childItem = new ShopOrderItem() {  ID=Guid.NewGuid().ToString(),
                                 OrderID=nb.ID,
                                    Count=child.goods_nums,
                                     Price=child.goods_price,
                                     TotalPrice=child.real_price,
                                      ProductID= pp.ID,
                                       ProductCode= pp.Code,
                                ProductName=pp.Name,
                                ProductThumb= pp.ThumbImgUrl,
                                 Unit=pp.Unit,
                                 Point=child.real_price, 
                            };
                            list.Add(childItem);
                        }
                        if (!isHad)
                        {
                            continue;
                        }
                        list.Add(nb);
                        list.Add(ar);
                        NewAndOldRalation ord = new NewAndOldRalation() { NewID=nb.ID, OldID= item.id, RalationType= OldEntity.RalationType.订单 };
                        NewAndOldRalationList.Add(ord);

                        
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
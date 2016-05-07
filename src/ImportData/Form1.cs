using EasyCms.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp.Common;
using Sharp.Data;
using System.Reflection;

namespace ImportData
{
    public partial class Form1 : Form
    {
        Sharp.Data.SessionFactory dal = Sharp.Data.SessionFactory.Default;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.EditValue = f.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = buttonEdit1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                DataTable dt, dt2, dt3;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    IWorkbook workBook = null;
                    if (path.ToLower().EndsWith(".xls"))
                    {
                        workBook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        workBook = new XSSFWorkbook(fs);

                    }


                    //获取excel的第一个sheet
                    dt = ReadSheet(workBook, 0);
                    dt2 = ReadSheet(workBook, 1);
                    dt3 = ReadSheet(workBook, 2);
                    workBook = null;
                }
                gridControl3.DataSource = dt;
                gridControl2.DataSource = dt2;
                gridControl1.DataSource = dt3;
            }
            else
            {
                MessageBox.Show("请先选择要导入的文件");
            }

        }

        private DataTable ReadSheet(IWorkbook workbook, int sheetIndex)
        {
            ISheet sheet = workbook.GetSheetAt(sheetIndex);

            int rowCount = sheet.LastRowNum + 1;
            IRow headerRow = sheet.GetRow(0);
            IRow secountRow = sheet.GetRow(1);
            if (headerRow == null || secountRow == null)
            {
                return null;
            }
            int colCount = headerRow.LastCellNum;
            DataTable dt = new DataTable();
            for (int i = 0; i < colCount; i++)
            {
                DataColumn dc = new DataColumn(headerRow.GetCell(i).ToString());
                dt.Columns.Add(dc);
            }
            for (int rowindex = 2; rowindex < rowCount; rowindex++)
            {
                IRow row = sheet.GetRow(rowindex);
                DataRow dataRow = dt.NewRow();
                for (int colindex = 0; colindex < colCount; colindex++)
                {
                    if (row.GetCell(colindex) != null)
                        dataRow[colindex] = row.GetCell(colindex).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            sheet = null;
            return dt;
        }
        Dictionary<string, string> categoryDict = new Dictionary<string, string>();
        Dictionary<string, string> brandDict = new Dictionary<string, string>();
        Dictionary<string, string> TypeDict = new Dictionary<string, string>();
        //开始导入商品
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                List<BaseEntity> list = new List<BaseEntity>();
                DataTable dt = gridControl3.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有要导入的商品信息");
                }
                else
                {
                    ShopProductInfo PP = new ShopProductInfo();
                    SetValue<ShopProductInfo>(list, dt, PP);
                    dal.Submit(list); MessageBox.Show("导入成功商品信息");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void SetValue<T>(List<BaseEntity> list, DataTable dt, BaseEntity PP) where T : BaseEntity, new()
        {

            foreach (DataRow row in dt.Rows)
            {
                T p = new T();
                PropertyInfo Key = PP.GetProperty("ID");
                string keyVal = Guid.NewGuid().ToString();
                Key.SetValue(p, keyVal, null);
                foreach (DataColumn col in dt.Columns)
                {
                    string valStr = row[col] as string;
                    object val = null;
                    PropertyInfo pi = null;
                    switch (col.ColumnName)
                    {
                        case "CategoryName":
                            if (!string.IsNullOrWhiteSpace(valStr))
                            {

                                valStr = valStr.Trim();
                                if (!categoryDict.ContainsKey(valStr))
                                {
                                    string valTEEE = dal.From<ShopCategory>().Where(ShopCategory._.Name == valStr).Select(ShopCategory._.ID).ToScalar() as string;

                                    categoryDict.Add(valStr, valTEEE);
                                }
                                string valTE = categoryDict[valStr];
                                if (!string.IsNullOrWhiteSpace(valTE))
                                {
                                    ShopProductCategory SC = new ShopProductCategory()
                                    {
                                        ID = Guid.NewGuid().ToString(),
                                        ProductID = keyVal,
                                        CategoryID = valTE

                                    };
                                    list.Add(SC);
                                }
                                 
                            }
                            break;
                        case "GG":
                        case "SS":
                            if (!string.IsNullOrWhiteSpace(valStr))
                            {
                                string[] ggs = valStr.Split(new char[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries);
                                int ggcount = 1;
                                foreach (var item in ggs)
                                {

                                    string[] gg = valStr.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (gg.Length == 2)
                                    {
                                        ShopExtendInfo SE = new ShopExtendInfo()
                                        {
                                            ID = Guid.NewGuid().ToString(),
                                            Name = gg[0],
                                            ShowType = AttrShowType.文本,
                                            UsageMode = col.ColumnName == "GG" ? UsageMode.系统规格 : UsageMode.系统属性,
                                            //luyonglie后续修正 ProductTypeID = keyVal,
                                            DisplayOrder = ggcount++

                                        };

                                        string[] ggvals = gg[1].Split(new char[] { ',', ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        int count = 1;
                                        foreach (var itemv in ggvals)
                                        {
                                            ShopExtendInfoValue siv = new ShopExtendInfoValue()
                                            {
                                                AttributeId = SE.ID,
                                                ID = Guid.NewGuid().ToString(),
                                                DisplaySequence = count++,
                                                ValueStr = itemv

                                            };
                                            list.Add(siv);

                                        }
                                        list.Add(SE);
                                    }

                                }
                            }
                            break;
                        case "BrandId":
                            pi = PP.GetProperty(col.ColumnName);
                            if (!string.IsNullOrWhiteSpace(valStr))
                            {
                                if (brandDict.ContainsKey(valStr))
                                {
                                    val = brandDict[valStr];
                                }
                                else
                                {
                                    val = dal.From<ShopBrandInfo>().Where(ShopBrandInfo._.Name == valStr).Select(ShopBrandInfo._.ID).ToScalar() as string;
                                    brandDict.Add(valStr, val as string);
                                }
                            }
                            break;
                        case "TypeId":
                            pi = PP.GetProperty(col.ColumnName);
                            if (!string.IsNullOrWhiteSpace(valStr))
                            {
                                if (TypeDict.ContainsKey(valStr))
                                {
                                    val = TypeDict[valStr];
                                }
                                else
                                {
                                    val = dal.From<ShopProductType>().Where(ShopProductType._.Name == valStr).Select(ShopProductType._.ID).ToScalar() as string;
                                    TypeDict.Add(valStr, val as string);
                                }
                            }
                            break;
                        default:
                            pi = PP.GetProperty(col.ColumnName);
                            if (pi.PropertyType.Equals(typeof(decimal)))
                            {
                                decimal v = 0;
                                decimal.TryParse(valStr, out v);
                                val = v;
                            }
                            else
                            {
                                val = valStr;
                            }
                            break;
                    }
                    if (pi != null)
                    {
                        try
                        {
                            pi.SetValue(p, val, null);
                        }
                        catch (Exception e)
                        {

                            throw new Exception( pi.Name+val,e);
                        }
                    }
                }
                list.Add(p);
            }
        }

        //开始导入品牌
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                List<BaseEntity> list = new List<BaseEntity>();
                DataTable dt = gridControl2.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有要导入的品牌信息");
                }
                else
                {
                    ShopBrandInfo PP = new ShopBrandInfo();
                    SetValue<ShopBrandInfo>(list, dt, PP);
                    dal.Submit(list);
                    MessageBox.Show("导入成功品牌信息");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }
        //开始导入类型
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            try
            {
                List<BaseEntity> list = new List<BaseEntity>();
                DataTable dt = gridControl1.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有要导入的商品类型信息");
                }
                else
                {
                    ShopProductType PP = new ShopProductType();
                    SetValue<ShopProductType>(list, dt, PP);
                    dal.Submit(list); MessageBox.Show("导入成功商品类型信息");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                simpleButton4_Click(sender, e);
                simpleButton3_Click(sender, e);
                simpleButton2_Click(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }
    }
}

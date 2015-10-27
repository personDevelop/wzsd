
namespace EasyCms.Web.App_Code
{
    public class ExcelOperator
    {
        /// <summary>
        /// 生成Excel的方法
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="url">Excel存在服务器的相对地址</param>
        /// <returns></returns>
        //private bool ExportExcel(DataSet ds, string path)
        //{
        //    //创建标题行
        //    IWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet("故障统计");
        //    IRow rowtitle = sheet.CreateRow(0);



        //    //DataSet是一个DataTale的集合，如果只是填充了1张表，则此表的ID为0
        //    DataTable dt = ds.Tables[0];
        //    int i = 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        HSSFRow newrow = sheet.CreateRow(i);
        //        newrow.CreateCell(0, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["R_XM"]));
        //        newrow.CreateCell(1, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["R_newzzbh"]));
        //        string jibie = string.Empty;
        //        if (row["R_jb"].ToString() == "1")
        //        {
        //            jibie = "一级";
        //        }
        //        else if (row["R_jb"].ToString() == "2")
        //        {
        //            jibie = "二级";
        //        }
        //        else if (row["R_jb"].ToString() == "3")
        //        {
        //            jibie = "三级";
        //        }
        //        newrow.CreateCell(2, HSSFCellType.STRING).SetCellValue(jibie);
        //        newrow.CreateCell(3, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["R_XB"]));
        //        newrow.CreateCell(4, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["user_id"]));
        //        newrow.CreateCell(5, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["R_KH"]));
        //        newrow.CreateCell(6, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["yjgmc"]));
        //        newrow.CreateCell(7, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["yjgbh"]));
        //        newrow.CreateCell(8, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["bjgmc"]));
        //        newrow.CreateCell(9, HSSFCellType.STRING).SetCellValue(Convert.ToString(row["bjgbh"]));
        //        i++;
        //    }
        //    try
        //    {
        //        using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //        {
        //            workbook.Write(stream);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }

        //}

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkExport_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //ds = apryManager.Export();
            //Random rd = new Random();
            //int rd1 = rd.Next(111111, 999999);
            //string path = this.Server.MapPath("~\\anxieExecl\\") + DateTime.Now.ToString("yyyyMMddhhmmss") + rd1.ToString() + ".xls";
            //if (!Directory.Exists(this.Server.MapPath("~\\anxieExecl\\")))
            //{
            //    Directory.CreateDirectory(this.Server.MapPath("~\\anxieExecl\\"));
            //}
            //bool status = ExportExcel(ds, path);
            //string Redirectpath = "~\\anxieExecl\\" + path.Substring(path.LastIndexOf("\\") + 1);
            //if (status)
            //{
            //    Response.Redirect(Redirectpath);
            //    File.Delete(path);
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('生成Excel失败！')", true);
            //}
        }



        public IWorkbook GenerateSheet(DataTable dt, string sheetname)
        {
            IWorkbook hssfworkbook = new HSSFWorkbook();
            ISheet sheet1 = hssfworkbook.CreateSheet(sheetname);

            IRow row = sheet1.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "ID")
                {
                    continue;
                }
                row.CreateCell(i, CellType.STRING).SetCellValue(dt.Columns[i].ColumnName);
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                IRow row1 = sheet1.CreateRow(j + 1);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName == "ID")
                    {
                        continue;
                    }
                    row1.CreateCell(i, CellType.STRING).SetCellValue(dt.Rows[j][i].ToString());

                }
            }

            return hssfworkbook;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp.Common;



namespace 接口测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string header = txtHeader.Text;
            string body = txtBody.Text;

            try
            {
                if (checkBox1.Checked)
                {
                    string ss = Sharp.Common.HttpModle.HttpPost(url, body, null, new string[] { header });


                    txtResponse.Text = ss;
                }
                else
                    txtResponse.Text = Sharp.Common.HttpModle.HttpGet(url, null, new string[] { header });

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frm签名测试().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            return;
            Class2 c = new Class2();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { 
                  new DataColumn("string1"),  
             new DataColumn("string2"),  
                new DataColumn("int1"),  
             new DataColumn("int2"),  
              new DataColumn("DateTime1"),  
               new DataColumn("DateTime2"),  
              new DataColumn("enumdd"),  
               new DataColumn("bool1"),  
              new DataColumn("bool2")  
            });
            
            DataRow dr = dt.NewRow();
            dr["string1"] = DBNull.Value;
            dr["string2"] = c.string2;
            dr["int1"] = c.int1;
            dr["int2"] = c.int2;
            dr["DateTime1"] = c.DateTime1;
            dr["DateTime2"] = c.DateTime2;
            dr["enumdd"] = c.enumdd;
            dr["bool1"] = c.bool1;
            dr["bool2"] = c.bool2;
            dt.AddRow(dr);
            DataRow dr2 = dt.NewRow();
            dt.AddRow(dr2);
            List<Class2> cl = dt.ToList<Class2>();
            if (cl.Count>0)
            {
                return;
            }
        }
    }
}

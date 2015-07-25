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
    }
}

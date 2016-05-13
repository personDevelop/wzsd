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
    public partial class frmDowLoadFile : Form
    {
        public frmDowLoadFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(textBox1.Text) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            using (Stream responseStream = response.GetResponseStream())
            {
                //创建本地文件写入流
                using (Stream stream = new FileStream(textBox2.Text, FileMode.Create))
                {


                    int p = 1024;
                    byte[] bArr = new byte[p];

                    int size = responseStream.Read(bArr, 0, p);
                    while (size > 0)
                    {
                        stream.Write(bArr, 0, size);

                        size = responseStream.Read(bArr, 0, p);
                    }
                }
            };
        
    }
    }
}

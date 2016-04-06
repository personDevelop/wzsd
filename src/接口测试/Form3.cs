using Sharp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 接口测试
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = buttonEdit1.Text;
            string[] files = System.IO.Directory.GetFileSystemEntries(path);
            foreach (var item in files)
            {
                if (Directory.Exists(item))
                {
                    //开始获取其文件
                    CopyToDirectory(item);
                }
                else
                { 
                    CopyToFile(item);
                }
            }
            MessageBox.Show("成功");
        }

        private void CopyToFile(string item)
        {
            item = item.ToLower();
            if (item.EndsWith(".jpg")|| item.EndsWith(".gif")|| item.EndsWith(".jpeg")|| item.EndsWith(".png"))
            {
                 
           
         string file=   item.Substring(0, item.LastIndexOf("."));
            
            string ThumbnaifilePath =  "Thumbnai.jpg";
            string compressionfilePath = "compression.jpg";
            //保存缩略图
            int with = 0, height = 0;
            ImgThumbnailType ThumbnailType = ImgThumbnailType.无;
            ImgThumbnail.ThumbnailRecommend(item,   ref with, ref height, ref ThumbnailType);
            
            ImgThumbnail.Thumbnail(item, file+ThumbnaifilePath, with, height, 100, ThumbnailType);

            //保存压缩图 
            ImgThumbnail.ThumbnailRecommend(item, ref with, ref height, ref ThumbnailType, true);
           
            ImgThumbnail.Thumbnail(item, file + compressionfilePath, with, height, 100, ThumbnailType);
            }
        }

        private void CopyToDirectory(string path)
        {
            string[] files = System.IO.Directory.GetFileSystemEntries(path);
            foreach (var item in files)
            {
                if (Directory.Exists(item))
                {
                    //开始获取其文件
                    CopyToDirectory(item);
                }
                else
                {
                    CopyToFile(item);
                }
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Imaging;
using Sharp.Common;

namespace 接口测试
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = f.FileName;
            }
        }
        public static bool gett()
        {
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Image img = Image.FromFile (buttonEdit1.Text);
                int width = Convert.ToInt32(spinEdit1.Value);
                int height = Convert.ToInt32(spinEdit2.Value);

                MakeThumbnail(buttonEdit1.Text, width, height);
                // SaveThumbnail(new  Bitmap (buttonEdit1.Text), width, height);
                //string extension = "Jpeg";
                //using (var encoderParameters = new EncoderParameters(1))
                //{
                //    ImageCodecInfo  codeinfo= ImageCodecInfo.GetImageEncoders()
                //                    .Where(x => x.FilenameExtension.Contains(extension.ToUpperInvariant()))
                //                    .FirstOrDefault(); 
                //    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                //    imgThumb.Save(Application.StartupPath + "\\格式\\" + textEdit1.Text + Guid.NewGuid().ToString() + "." + extension);
                //    imgThumb.Save(Application.StartupPath + "\\格式\\" + textEdit1.Text + Guid.NewGuid().ToString() + "." + extension,
                //            ImageFormat.Jpeg);
                //    List<string> formatAttr = new List<string>();
                //formatAttr.Add("Bmp"); formatAttr.Add("Icon"); formatAttr.Add("Png");
                //formatAttr.Add("Jpeg");
                //foreach (var item in formatAttr)
                //{
                //    ImageFormat iformat = null;
                //    switch (item)
                //    {
                //        case "Bmp":
                //            iformat = ImageFormat.Bmp;
                //            break;
                //        case "Gif": iformat = ImageFormat.Gif; break;

                //        case "Icon": iformat = ImageFormat.Icon; break;

                //        case "Jpeg": iformat = ImageFormat.Jpeg; break;

                //        case "Png": iformat = ImageFormat.Png; break;

                //    }
                //    imgThumb.Save(Application.StartupPath + "\\格式\\" + textEdit1.Text + Guid.NewGuid().ToString() + "." + item, iformat);

                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Image img = Image.FromFile(buttonEdit1.Text);
        //        int width = Convert.ToInt32(spinEdit1.Value);
        //        int height = Convert.ToInt32(spinEdit2.Value);
        //        //width = img.Width;
        //        //height = img.Height;
        //        System.Drawing.Image.GetThumbnailImageAbort callback = new System.Drawing.Image.GetThumbnailImageAbort(gett);
        //        //生成图片的大小  
        //        Image imgThumb = GetHvtThumbnail(img, width, height);
        //        //Image imgThumb = img.GetThumbnailImage(width, height, callback, new IntPtr());

        //        List<string> formatAttr = new List<string>();
        //        formatAttr.Add("Bmp"); formatAttr.Add("Icon"); formatAttr.Add("Png");
        //        formatAttr.Add("Jpeg"); 
        //        foreach (var item in formatAttr)
        //        {
        //            ImageFormat iformat= null;
        //            switch (item)
        //            {
        //                case "Bmp":
        //                    iformat = ImageFormat.Bmp;
        //                    break; 
        //case "Gif": iformat = ImageFormat.Gif; break;  

        //                case "Icon": iformat = ImageFormat.Icon; break;

        //                case "Jpeg": iformat = ImageFormat.Jpeg; break;

        //                case "Png": iformat = ImageFormat.Png; break;

        //            }
        //            imgThumb.Save(Application.StartupPath + "\\格式\\" + textEdit1.Text + Guid.NewGuid().ToString() + "."+ item,iformat );

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void SaveThumbnail(Bitmap originBitmap, int width, int height)
        {
            var physicalPath = Application.StartupPath + "\\格式\\" + textEdit1.Text + Guid.NewGuid().ToString() + ".jpeg";

            using (var newImage = new Bitmap(width, height))
            {
                using (var graphic = GetGraphic(originBitmap, newImage))
                {
                    graphic.DrawImage(originBitmap, 0, 0, width, height);
                    using (var encoderParameters = new EncoderParameters(1))
                    {
                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                        newImage.Save(physicalPath,
                                    ImageCodecInfo.GetImageEncoders()
                                        .Where(x => x.FilenameExtension.Contains(".jpeg".ToUpperInvariant()))
                                        .FirstOrDefault(),
                                    encoderParameters);
                    }
                }
            }
        }

        private Graphics GetGraphic(Image originImage, Bitmap newImage)
        {
            newImage.SetResolution(originImage.HorizontalResolution, originImage.VerticalResolution);
            var graphic = Graphics.FromImage(newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            return graphic;
        }
        /// <summary>
        /// 获得缩微图
        /// </summary>
        /// <returns></returns>
        public Image GetThumbImg(Image sourceImage, int thumbwidth, int thHeight)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            if (thumbwidth <= 0)
            {
                thumbwidth = 120;
            }
            if (thumbwidth >= width)
            {
                return null;
            }
            else
            {

                Image imgThumb = new System.Drawing.Bitmap(thumbwidth, height * thumbwidth / width);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(imgThumb);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(sourceImage, new Rectangle(0, 0, thumbwidth, height * thumbwidth / width), 0, 0, width, height, GraphicsUnit.Pixel);

                return imgThumb;

            }

        }

        /// <summary> 
        /// 为图片生成缩略图 by 何问起
        /// </summary> 
        /// <param name="phyPath">原图片的路径</param> 
        /// <param name="width">缩略图宽</param> 
        /// <param name="height">缩略图高</param> 
        /// <returns></returns> 
        public System.Drawing.Image GetHvtThumbnail(System.Drawing.Image image, int width, int height)
        {
            GetThumbSize(ref width, ref height, 0, 0);
            //代码是从开源项目HoverTreeCMS中获取的
            //更多信息请参考：http://hovertree.com/menu/hovertreecms/
            Bitmap m_hovertreeBmp = new Bitmap(width, height);
            //从Bitmap创建一个System.Drawing.Graphics 
            Graphics m_HvtGr = Graphics.FromImage(m_hovertreeBmp);
            //设置  
            m_HvtGr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //下面这个也设成高质量 
            m_HvtGr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High 
            m_HvtGr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //把原始图像绘制成上面所设置宽高的缩小图 
            Rectangle rectDestination = new Rectangle(0, 0, width, height);

            //int m_width, m_height;
            //if (image.Width * height > image.Height * width)
            //{
            //    m_height = image.Height;
            //    m_width = (image.Height * width) / height;
            //}
            //else
            //{
            //    m_width = image.Width;
            //    m_height = (image.Width * height) / width;
            //}

            m_HvtGr.DrawImage(image, rectDestination, 0, 0, width, height, GraphicsUnit.Pixel);

            return m_hovertreeBmp;
        }

        public static void GetThumbSize(ref int width, ref int height, int limitWidth, int limitHeight)
        {
            int scaling = width / height;
            if (width > limitWidth)
            {
                width = limitWidth;
                height = width / scaling;
            }
            if (height > limitHeight)
            {
                height = limitHeight;
                width = height * scaling;
            }
        }




        ///<summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param> 
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param> 
        /// <param name="mode">生成缩略图的方式</param>     
        public void MakeThumbnail(string originalImagePath, int width, int height)
        {
          
            string[] modes = new string[] { "无", "HW", "W", "H", "Cut" };//废掉 Cut H W
            foreach (var mode in modes)
            {

                ImgThumbnailType type = ImgThumbnailType.无;
                 
                    switch (mode)
                    {
                        case "HW"://指定高宽缩放（可能变形）
                            type = ImgThumbnailType.高宽缩放;
                            break;
                        case "W"://指定宽，高按比例     
                            type = ImgThumbnailType.宽高比;

                            break;
                        case "H"://指定高，宽按比例 
                            type = ImgThumbnailType.高宽比;
                            break;
                        case "Cut"://指定高宽裁减（不变形）                 
                            type = ImgThumbnailType.高宽裁减;
                            break;
                        default:
                            break;
                    }
               


                try
                {
                    ImgThumbnail.ThumbnailRecommend(originalImagePath, ref width, ref height, ref type);
                    string thumbnailPath = Application.StartupPath + "\\格式\\" +   mode + textEdit1.Text + Guid.NewGuid().ToString() + ".jpg";
                    ImgThumbnail.Thumbnail(originalImagePath, thumbnailPath, width, height, 80, type);

                }
                catch (System.Exception e)
                {
                    throw e;
                }


            }
        }
    }
}
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 接口测试
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<AdministrativeRegions> list = new List<AdministrativeRegions>();
        int startjb = 0, endjb = 0;
        string[] jbname = null;
        StringBuilder sb = null;
        private void button1_Click(object sender, EventArgs e)
        {
            startjb = int.Parse(textBox1.Text);
            endjb = int.Parse(textBox3.Text);
            jbname = textBox2.Text.Split(new char[] { ' ', ',', ';', '，', '；' }, StringSplitOptions.RemoveEmptyEntries);
            if (jbname.Length == (endjb - startjb + 1))
            {

                sb = new StringBuilder("<root>");
                list = Sharp.Data.SessionFactory.Default.From<AdministrativeRegions>().Where(AdministrativeRegions._.Jb >= startjb && AdministrativeRegions._.Jb <= endjb).List<AdministrativeRegions>();
                int jb = 0;
                foreach (AdministrativeRegions item in list.Where(p => p.Jb == startjb))
                {
                    jb = 0;
                    Generateor(item, jb);

                }
                sb.Append("</root>");
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    XDocument.Parse(sb.ToString()).Save(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show(string.Format("节点名称和级别个数不一致，级别节点名称个数{0} 级别个数{1}", jbname.Length, (endjb - startjb + 1)));
            }
        }

        private void Generateor(AdministrativeRegions item, int jb)
        {
            sb.AppendFormat("<{2} id=\"{0}\" name=\"{1}\">", item.ID, item.Name, jbname[jb]);
            //获取其子
            foreach (AdministrativeRegions child in list.Where(p => p.ParentID == item.ID))
            {
                Generateor(child, jb + 1);
            }
            sb.AppendFormat("</{0}>", jbname[jb]);

        }
    }
}

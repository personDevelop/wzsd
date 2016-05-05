using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sharp.Common;
namespace ImportData
{
    public partial class Form3 : DevExpress.XtraEditors.XtraForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                new frmBrand().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCategory().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                new frmProduct().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                new frmAttr().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                new frmAdPosition().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                new frmAd ().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                new frmCheckImg().Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.GetExceptionMsg());
            }
        }
    }
}
﻿namespace ImportData
{
    partial class frmAdPosition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.加载新库和旧库现有数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部删除新库数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算新库和旧库的数据个数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载新库和旧库现有数据ToolStripMenuItem,
            this.全部删除新库数据ToolStripMenuItem,
            this.开始同步ToolStripMenuItem,
            this.计算新库和旧库的数据个数ToolStripMenuItem,
            this.textBox2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1190, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 加载新库和旧库现有数据ToolStripMenuItem
            // 
            this.加载新库和旧库现有数据ToolStripMenuItem.Name = "加载新库和旧库现有数据ToolStripMenuItem";
            this.加载新库和旧库现有数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.加载新库和旧库现有数据ToolStripMenuItem.Text = "加载新库和旧库现有数据";
            this.加载新库和旧库现有数据ToolStripMenuItem.Click += new System.EventHandler(this.加载新库和旧库现有数据ToolStripMenuItem_Click);
            // 
            // 全部删除新库数据ToolStripMenuItem
            // 
            this.全部删除新库数据ToolStripMenuItem.Name = "全部删除新库数据ToolStripMenuItem";
            this.全部删除新库数据ToolStripMenuItem.Size = new System.Drawing.Size(116, 23);
            this.全部删除新库数据ToolStripMenuItem.Text = "全部删除新库数据";
            this.全部删除新库数据ToolStripMenuItem.Click += new System.EventHandler(this.全部删除新库数据ToolStripMenuItem_Click);
            // 
            // 开始同步ToolStripMenuItem
            // 
            this.开始同步ToolStripMenuItem.Name = "开始同步ToolStripMenuItem";
            this.开始同步ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.开始同步ToolStripMenuItem.Text = "开始同步";
            this.开始同步ToolStripMenuItem.Click += new System.EventHandler(this.开始同步ToolStripMenuItem_Click);
            // 
            // 计算新库和旧库的数据个数ToolStripMenuItem
            // 
            this.计算新库和旧库的数据个数ToolStripMenuItem.Name = "计算新库和旧库的数据个数ToolStripMenuItem";
            this.计算新库和旧库的数据个数ToolStripMenuItem.Size = new System.Drawing.Size(164, 23);
            this.计算新库和旧库的数据个数ToolStripMenuItem.Text = "计算新库和旧库的数据个数";
            this.计算新库和旧库的数据个数ToolStripMenuItem.Click += new System.EventHandler(this.计算新库和旧库的数据个数ToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(680, 23);
            this.textBox2.Text = "E:\\02-work2\\01-CMS\\03-源码\\EasyCms\\新图片爬虫路径";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1190, 364);
            this.splitContainerControl1.SplitterPosition = 558;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(558, 364);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "旧库";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(554, 341);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(627, 364);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "新库";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 21);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(623, 341);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // frmAdPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 391);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmAdPosition";
            this.Text = "导入广告位置";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载新库和旧库现有数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部删除新库数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算新库和旧库的数据个数ToolStripMenuItem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.ToolStripTextBox textBox2;
    }
}
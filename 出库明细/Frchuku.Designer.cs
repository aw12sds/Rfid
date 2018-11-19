namespace CsharpDemoWC.出库明细
{
    partial class Frchuku
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
            this.components = new System.ComponentModel.Container();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.写入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.仓库编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.物资身份识别码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.物资编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.物资描述 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.存储类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.仓位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.批次 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1095, 780);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.button2);
            this.xtraTabPage1.Controls.Add(this.button1);
            this.xtraTabPage1.Controls.Add(this.groupBox2);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1089, 751);
            this.xtraTabPage1.Text = "连接发卡机";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "断开";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "连接RFID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(85, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 96);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RS232";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(119, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 22);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(85, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Mode";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(213, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "USB";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(71, 48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "RS232";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel2);
            this.xtraTabPage2.Controls.Add(this.panel1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1089, 751);
            this.xtraTabPage2.Text = "写标签";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1089, 619);
            this.panel2.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1089, 619);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.写入数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 写入数据ToolStripMenuItem
            // 
            this.写入数据ToolStripMenuItem.Name = "写入数据ToolStripMenuItem";
            this.写入数据ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.写入数据ToolStripMenuItem.Text = "写入数据";
            this.写入数据ToolStripMenuItem.Click += new System.EventHandler(this.写入数据ToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.仓库编号,
            this.物资身份识别码,
            this.物资编号,
            this.物资描述,
            this.存储类型,
            this.仓位,
            this.批次});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // 仓库编号
            // 
            this.仓库编号.Caption = "仓库编号";
            this.仓库编号.FieldName = "LGNUM";
            this.仓库编号.Name = "仓库编号";
            this.仓库编号.Visible = true;
            this.仓库编号.VisibleIndex = 6;
            // 
            // 物资身份识别码
            // 
            this.物资身份识别码.Caption = "物资身份识别码";
            this.物资身份识别码.FieldName = "RFIDNO";
            this.物资身份识别码.Name = "物资身份识别码";
            this.物资身份识别码.Visible = true;
            this.物资身份识别码.VisibleIndex = 0;
            // 
            // 物资编号
            // 
            this.物资编号.Caption = "物资编号";
            this.物资编号.FieldName = "MAKBH";
            this.物资编号.Name = "物资编号";
            this.物资编号.Visible = true;
            this.物资编号.VisibleIndex = 1;
            // 
            // 物资描述
            // 
            this.物资描述.Caption = "物资描述";
            this.物资描述.FieldName = "MAKTX";
            this.物资描述.Name = "物资描述";
            this.物资描述.Visible = true;
            this.物资描述.VisibleIndex = 2;
            // 
            // 存储类型
            // 
            this.存储类型.Caption = "存储类型";
            this.存储类型.FieldName = "LGTYP";
            this.存储类型.Name = "存储类型";
            this.存储类型.Visible = true;
            this.存储类型.VisibleIndex = 3;
            // 
            // 仓位
            // 
            this.仓位.Caption = "仓位";
            this.仓位.FieldName = "LGPLAT";
            this.仓位.Name = "仓位";
            this.仓位.Visible = true;
            this.仓位.VisibleIndex = 4;
            // 
            // 批次
            // 
            this.批次.Caption = "批次";
            this.批次.FieldName = "CHARG";
            this.批次.Name = "批次";
            this.批次.Visible = true;
            this.批次.VisibleIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 132);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(896, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(716, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 31);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "状态提示";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.groupBox17);
            this.xtraTabPage3.Controls.Add(this.groupBox15);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1089, 751);
            this.xtraTabPage3.Text = "读标签";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label46);
            this.groupBox17.Controls.Add(this.label45);
            this.groupBox17.Controls.Add(this.label44);
            this.groupBox17.Controls.Add(this.label43);
            this.groupBox17.Controls.Add(this.button22);
            this.groupBox17.Controls.Add(this.button21);
            this.groupBox17.Controls.Add(this.textBox29);
            this.groupBox17.Controls.Add(this.label42);
            this.groupBox17.Location = new System.Drawing.Point(397, 364);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(293, 238);
            this.groupBox17.TabIndex = 3;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "读取数据";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(143, 156);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(31, 14);
            this.label46.TabIndex = 7;
            this.label46.Text = "数据";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(39, 155);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 14);
            this.label45.TabIndex = 6;
            this.label45.Text = "读取数据:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(143, 113);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(31, 14);
            this.label44.TabIndex = 5;
            this.label44.Text = "状态";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(39, 112);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 14);
            this.label43.TabIndex = 4;
            this.label43.Text = "读取状态:";
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(181, 52);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(100, 26);
            this.button22.TabIndex = 3;
            this.button22.Text = "停止读取";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(67, 51);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(100, 26);
            this.button21.TabIndex = 2;
            this.button21.Text = "开始读取";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(205, 18);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(75, 22);
            this.textBox29.TabIndex = 1;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(80, 23);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(75, 14);
            this.label42.TabIndex = 0;
            this.label42.Text = "间隔时间: 秒";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label4);
            this.groupBox15.Controls.Add(this.button18);
            this.groupBox15.Controls.Add(this.button17);
            this.groupBox15.Controls.Add(this.button16);
            this.groupBox15.Controls.Add(this.button15);
            this.groupBox15.Location = new System.Drawing.Point(29, 14);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(1011, 283);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Read data list";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 14);
            this.label4.TabIndex = 5;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(740, 230);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(149, 33);
            this.button18.TabIndex = 4;
            this.button18.Text = "保存到excel文件";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(561, 230);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(149, 33);
            this.button17.TabIndex = 3;
            this.button17.Text = "保存到txt文件";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(382, 230);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(149, 33);
            this.button16.TabIndex = 2;
            this.button16.Text = "清空数据列表";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(200, 230);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(149, 33);
            this.button15.TabIndex = 1;
            this.button15.Text = "删除选中数据";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Frchuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 780);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frchuku";
            this.Text = "发卡机";
            this.Load += new System.EventHandler(this.Frchuku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 写入数据ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Label label42;
        private DevExpress.XtraGrid.Columns.GridColumn 物资身份识别码;
        private DevExpress.XtraGrid.Columns.GridColumn 物资编号;
        private DevExpress.XtraGrid.Columns.GridColumn 物资描述;
        private DevExpress.XtraGrid.Columns.GridColumn 存储类型;
        private DevExpress.XtraGrid.Columns.GridColumn 仓位;
        private DevExpress.XtraGrid.Columns.GridColumn 批次;
        private DevExpress.XtraGrid.Columns.GridColumn 仓库编号;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
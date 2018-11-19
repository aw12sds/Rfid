using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CsharpDemoWC.出库明细;
using DevExpress.XtraTab;
using System.Drawing.Printing;

namespace CsharpDemoWC
{
    public partial class Frzhujiemian : DevExpress.XtraEditors.XtraForm
    {
        public Frzhujiemian()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Frchuku form1 = new Frchuku();
            form1.Show();
        }

        private void Frzhujiemian_Load(object sender, EventArgs e)
        {
         
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          


            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = "";
            Frchuku form1 = new Frchuku();
            form1.TopLevel = false;
            newPage.Controls.Add(form1);
            form1.Show();
            form1.Dock = DockStyle.Fill;
            xtraTabControl1.TabPages.Add(newPage);
            xtraTabControl1.SelectedTabPage = newPage;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString("aa", new Font("Arial", 7, FontStyle.Bold), Brushes.Black, -2, 10);
            // Create pen.
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter;
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(-10, -10, 200, 200);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
    }
    }
}
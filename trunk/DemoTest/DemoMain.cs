using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DXWindowsApplication1
{
    public partial class DemoMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DemoMain()
        {
            InitializeComponent();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            new DemoGoodsAdd().ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            new DemoGoods出库().ShowDialog();
        }
    }
}
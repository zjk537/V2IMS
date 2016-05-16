using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXWindowsApplication1
{
    public partial class DemoOrder : Form
    {
        public DemoOrder()
        {
            InitializeComponent();
        }

        private void DemoOrder_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}

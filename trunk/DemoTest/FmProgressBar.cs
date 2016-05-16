using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Vogue2_IMS.Common
{
    public partial class FmProgressBar : DevExpress.XtraEditors.XtraForm
    {
        public FmProgressBar(string runCaption="正在处理中.......")
        {
            InitializeComponent();

            //this.marqueeProgressBarControl1.Properties.
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            this.pictureEdit1.LoadImage();
        }
    }
}
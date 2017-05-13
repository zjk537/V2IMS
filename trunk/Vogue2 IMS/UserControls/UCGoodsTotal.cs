using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Vogue2_IMS.UserControls
{
    public partial class UCGoodsTotal : DevExpress.XtraEditors.XtraUserControl
    {
        public UCGoodsTotal()
        {
            InitializeComponent();
        }

        public LabelControl Desc
        {
            get { return this.labDesc; }
            set { this.labDesc = value; }
        }

        public LabelControl Title
        {
            get { return this.labTitle; }
            set { this.labTitle=value; }
        }

    }
}

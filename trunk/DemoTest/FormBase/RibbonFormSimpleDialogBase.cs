using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace DXWindowsApplication1.FormBase
{
    public partial class RibbonFormSimpleDialogBase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormSimpleDialogBase()
        {
            InitializeComponent();
        }

        public RibbonControl MainRibbonControl { get { return this.ribbon; } set { this.ribbon = value; } }
    }
}
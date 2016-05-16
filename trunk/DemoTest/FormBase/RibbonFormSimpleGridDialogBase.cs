using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXWindowsApplication1.FormBase
{
    public partial class RibbonFormSimpleGridDialogBase : RibbonFormSimpleDialogBase
    {
        public RibbonFormSimpleGridDialogBase()
        {
            InitializeComponent();

            this.MainRibbonControl.Pages.Clear();
        }
    }
}
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
    public partial class FormSimpleDialogBase : DevExpress.XtraEditors.XtraForm
    {
        public FormSimpleDialogBase()
        {
            InitializeComponent();
        }

        public SimpleButton Btn_OK { get { return this.btnOk; } set { this.btnOk = value; } }
        public SimpleButton Btn_Cancel { get { return this.btnCancel; } set { this.btnCancel = value; } }
    }
}
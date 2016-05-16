using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Vogue2_IMS.Common.FormBase
{
    public partial class FormSimpleDialogBase : DevExpress.XtraEditors.XtraForm
    {
        public FormSimpleDialogBase()
        {
            InitializeComponent();
        }

        public FormSimpleDialogBase(DialogResult btn_Ok_Dialog,DialogResult btn_Cancel_Dialog)
        {
            this.Btn_OK.DialogResult = btn_Ok_Dialog;
            this.Btn_Cancel.DialogResult = btn_Cancel_Dialog;
        }

        public SimpleButton Btn_OK { get { return this.btnOk; } set { this.btnOk = value; } }
        public SimpleButton Btn_Cancel { get { return this.btnCancel; } set { this.btnCancel = value; } }

        public PanelControl BtnContainer { get { return this.panelControl2; } set { this.panelControl2 = value; } }
    }
}
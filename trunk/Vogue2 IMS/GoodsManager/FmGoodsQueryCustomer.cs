using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsQueryCustomer :FormSimpleDialogBase
    {
        public FmGoodsQueryCustomer()
        {
            InitializeComponent();

            this.Btn_OK.Click += btnOk_Click;
        }

        public DateTime StartDate { get { return this.DateStart.DateTime; } set { this.DateStart.DateTime = value; } }
        public DateTime EndDate { get { return this.DateEnd.DateTime; } set { this.DateEnd.DateTime = value; } }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidatFail())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool ValidatFail()
        {
            if (StartDate > EndDate)
            {
                mErrorProvider.SetError(DateStart, "开始时间不得大于结束时间", ErrorType.Warning);
                mErrorProvider.SetError(DateStart, "结束时间不得小于开始时间", ErrorType.Warning);
            }

            return mErrorProvider.HasErrors;
        }
    }
}
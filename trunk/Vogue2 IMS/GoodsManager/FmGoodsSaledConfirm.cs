using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsSaledConfirm : FormSimpleDialogBase
    {
        public FmGoodsSaledConfirm(decimal totalPrice)
        {
            InitializeComponent();

            InitializeControls(totalPrice);
        }

        #region Fields
        private PayTypeInfo payType;

        public PayTypeInfo PayType
        {
            get
            {
                return payType;
            }
        }

        public decimal BankCharge
        {
            get
            {
                return (decimal)this.TxtBankCharge.EditValue;
            }
        }
        #endregion

        private void InitializeControls(decimal totalPrice)
        {
            this.lblTotalPrice.Text = string.Format("￥{0}", totalPrice);
            this.ComboxPayType.Properties.Items.AddRange(Business.SharedVariables.Instance.PayTypeInfos);
            this.ComboxPayType.SelectedIndex = 0;
            this.Btn_OK.Click += Btn_OK_Click;
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ComboxPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            payType = (PayTypeInfo)this.ComboxPayType.SelectedItem;
            this.TxtBankCharge.EditValue = payType.BankCharge.HasValue ? payType.BankCharge.Value : 0;
        }
    }
}

using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;
using System;
using Vogue2_IMS.Common.ModelBase;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Vogue2_IMS.SystemManager
{
    public partial class FmPayTypeInfo : FormSimpleDialogBase
    {
        PayTypeInfo mPayTypeInfo = new Model.DataModel.PayTypeInfo();
        PayTypeInfo mNewPayTypeInfo = new Model.DataModel.PayTypeInfo();
        private bool IsCreateNew { get { return mPayTypeInfo == null; } }

        public PayTypeInfo PayTypeInfo { get { return mNewPayTypeInfo; } }

        public FmPayTypeInfo(PayTypeInfo payTypeInfo = null)
        {
            InitializeComponent();
            InitializeControls(payTypeInfo);

        }

        void InitializeControls(PayTypeInfo oldModel = null)
        {
            this.mPayTypeInfo = oldModel;

            if (oldModel != null)
            {
                DBModelBase.Clone<PayTypeInfo>(oldModel, ref mNewPayTypeInfo);
            }

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            this.Text = IsCreateNew ? "结款类型-添加" : "结款类型-编辑";
            this.Btn_OK.Click += btnOk_Click;

            TxtName.DataBindings.Add("Text", mNewPayTypeInfo, "Name");//mNewPayTypeInfo.Name
            TxtBankCharge.EditValue = mNewPayTypeInfo.BankCharge ?? 0;//mNewPayTypeInfo.BankCharge 
        }

        private bool Validation()
        {
            mErrorProvider.ClearErrors();

            if (string.IsNullOrEmpty(this.TxtName.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtName, "不能为空", ErrorType.Warning);
            }
            mNewPayTypeInfo.BankCharge = (decimal?)TxtBankCharge.EditValue;
            return !mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation()) return;

                if (!mNewPayTypeInfo.Equals(mPayTypeInfo))
                {
                    if (IsCreateNew)
                    {
                        PayTypeBusiness.Instance.AddPayType(mNewPayTypeInfo);
                    }
                    else
                    {
                        mNewPayTypeInfo.Id = mPayTypeInfo.Id;
                        PayTypeBusiness.Instance.UpdatePayType(mNewPayTypeInfo);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("付款方式无更新，继续编辑请点击Y退出点击N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("保存失败,请联系管理员，信息如下：\r\n{0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }
    }
}
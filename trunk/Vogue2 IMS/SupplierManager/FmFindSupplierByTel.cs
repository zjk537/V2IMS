using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Business;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;

namespace Vogue2_IMS.SupplierManager
{
    public partial class FmFindSupplierByTel : Common.FormBase.FormSimpleDialogBase
    {
        SourceType mRKType = SourceType.JiShou;

        private SupplierInfo mSupplierCondition = new SupplierInfo();
        private SupplierInfo mSupplier = null;
        public SupplierInfo Supplier
        {
            get { return mSupplier == null ? mSupplierCondition : mSupplier; }
            private set { mSupplier = value; }
        }

        public FmFindSupplierByTel(SourceType rkType)
            : base()
        {
            InitializeComponent();
          
            InitializeComponentExtend(rkType);
        }

        private void InitializeComponentExtend(SourceType rkType)
        {
            mRKType = rkType;

            #region UI Format

            this.Text = string.Format("查找{0}", SharedVariables.SupplierCNNames[mRKType]);

            #endregion

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            Btn_OK.Click += btnOk_Click;

            SupplierTelText.DataBindings.Add("Text", mSupplierCondition, "Phone");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier = SupplierBusiness.Instance.GetSupplier(mSupplierCondition);

                if (Supplier != null && !string.IsNullOrEmpty(Supplier.Phone))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (MessageBox.Show(string.Format("手机号码为：【{0}】的{1}不存在\r\n继续 Yes，取消 No"
                        , SupplierTelText.Text.Trim(),SharedVariables.SupplierCNNames[mRKType]), "提示"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        ==DialogResult.No)
                    {
                        Supplier = mSupplierCondition;
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FmFindSupplierByTel_FormClosed(object sender, FormClosedEventArgs e)
        {          
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
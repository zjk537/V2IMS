using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Model.DataModel;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business;

namespace Vogue2_IMS.SystemManager
{
    public partial class FmShopInfo : FormSimpleDialogBase
    {
        ShopInfo mShopInfo = null;
        ShopInfo mNewShopInfo = new ShopInfo();
        private bool IsCreateNew { get { return mShopInfo == null; } }

        public ShopInfo ShopInfo
        {
            get { return mNewShopInfo; }
        }

        public FmShopInfo(ShopInfo shop = null)
        {
            InitializeComponent();
            InitializeControls(shop);          
        }

        void InitializeControls(ShopInfo shop = null)
        {
            if (shop != null)
            {
                DBModelBase.Clone<ShopInfo>(shop, ref mNewShopInfo);
                mShopInfo = shop;
            }

            ControlsBinding();          
        }

        private void ControlsBinding()
        {
            this.Text = mShopInfo == null ? "店铺信息-添加" : "店铺信息-编辑";
            this.Btn_OK.Click += btnOk_Click;

            TxtAddress.DataBindings.Add("Text",mNewShopInfo,"Address");//newShopInfo.Address
            TxtName.DataBindings.Add("Text", mNewShopInfo, "Name");//newShopInfo.Name
            TxtPhone.DataBindings.Add("Text", mNewShopInfo, "Phone");//newShopInfo.Phone
            TxtDesc.DataBindings.Add("Text", mNewShopInfo, "Desc"); //newShopInfo.Desc;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation()) return;

                if (!mNewShopInfo.Equals(mShopInfo))
                {
                    if (IsCreateNew)
                    {
                        ShopBusiness.Instance.AddShop(mNewShopInfo);
                    }
                    else
                    {
                        mNewShopInfo.Id = mShopInfo.Id;
                        ShopBusiness.Instance.UpdateShop(mNewShopInfo);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("店铺信息无更新，继续编辑请点击Y退出点击N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("保存失败,请联系管理员，信息如下：\r\n{0}",ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

        private bool Validation()
        {
            mErrorProvider.ClearErrors();
           
            if (string.IsNullOrEmpty(this.TxtName.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtName, "不能为空", ErrorType.Warning);
            }

            if (string.IsNullOrEmpty(this.TxtPhone.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtPhone, "不能为空", ErrorType.Warning);
            }

            if (string.IsNullOrEmpty(this.TxtAddress.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtAddress, "不能为空", ErrorType.Warning);
            }

            return !mErrorProvider.HasErrors;
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }
    }
}
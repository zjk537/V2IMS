using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.Business;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Common;
using System.Collections.Generic;

namespace Vogue2_IMS.OrderManager
{
    public partial class FmGoodsInfo : Common.FormBase.FormSimpleDialogBase
    {
        SourceType mRKType = SourceType.JiShou;
        private string formText = "";
        /// <summary>
        /// 编辑对象
        /// </summary>
        PurchaseGoodsInfo newPurchaseGoodsInfo = new PurchaseGoodsInfo();
        /// <summary>
        /// 原始对象（仅在处于编辑时有值）
        /// </summary>
        PurchaseGoodsInfo mPurchaseGoodsInfo = null;

        /// <summary>
        /// 编辑好的对象
        /// </summary>
        public PurchaseGoodsInfo PurchaseGoodsInfo
        {
            get
            {
                return newPurchaseGoodsInfo;
            }
        }

        public FmGoodsInfo(SourceType rkType)
            : base()
        {
            InitializeComponent();
            mRKType = rkType;
            InitializeControls();
            newPurchaseGoodsInfo.Goods.SourceType = (int)mRKType;
            newPurchaseGoodsInfo.LoginUser = SharedVariables.Instance.LoginUser.User;
            newPurchaseGoodsInfo.PurchaseRecord.Operator = SharedVariables.Instance.LoginUser.User.Name;
        }

        public FmGoodsInfo(DialogResult btn_Ok_Dialog, DialogResult btn_Cancel_Dialog)
            : base(btn_Ok_Dialog, btn_Cancel_Dialog)
        {
            InitializeComponent();
            InitializeControls();
        }

        public FmGoodsInfo(PurchaseGoodsInfo purchaseGoodsViewInfo)
            : base()
        {
            InitializeComponent();
            InitializeControls(purchaseGoodsViewInfo);
        }

        private void InitializeControls(PurchaseGoodsInfo purchaseGoodsViewInfo = null)
        {
            if (purchaseGoodsViewInfo != null)
            {
                newPurchaseGoodsInfo = purchaseGoodsViewInfo.Clone();

                mPurchaseGoodsInfo = purchaseGoodsViewInfo;
                this.mRKType = (SourceType)mPurchaseGoodsInfo.Goods.SourceType;
            }

            this.ComboxCategoryType.Properties.Items.AddRange(Business.SharedVariables.Instance.CategoryInfos);
            this.ComboxPayType.Properties.Items.AddRange(Business.SharedVariables.Instance.PayTypeInfos);
            this.ComboxGoodsOperator.Properties.Items.AddRange(Business.SharedVariables.Instance.UserInfos);
            this.ComBoxPaid.Properties.Items.AddRange(Business.SharedVariables.GoodsPaids);

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            if (mPurchaseGoodsInfo == null)
            {
                formText = "商品详情-添加";
            }
            else
            {
                formText = "商品详情";
                switch ((GoodsStatus)mPurchaseGoodsInfo.Goods.Status)
                {
                    case GoodsStatus.In:
                        formText += "-编辑";
                        SetControlStatus(true);
                        break;
                    case GoodsStatus.Catch:
                        SetControlStatus(false);
                        formText = "[已预定] " + formText;
                        break;
                    case GoodsStatus.Saled:
                        SetControlStatus(false);
                        formText = "[已售出] " + formText;
                        break;
                    case GoodsStatus.GetOut:
                        SetControlStatus(false);
                        formText = "[已取回] " + formText;
                        break;
                }
            }

            this.Text = formText;
            this.Btn_OK.Click += btnOk_Click;
            labelControl9.Text = mRKType == SourceType.JinHuo ? "打款状态" : "结束时间";

            DateEnd.Visible = mRKType == SourceType.JiShou;
            ComBoxPaid.Visible = mRKType == SourceType.JinHuo;
            //ComBoxPaid.SelectedIndex = 0;

            GoodsInfo goods = newPurchaseGoodsInfo.Goods;
            GoodsOriginalCodeTxt.DataBindings.Add("Text", goods, "OriginalCode");//bindSource.Goods.OriginalCode
            GoodsNameTxt.DataBindings.Add("Text", goods, "Name");//bindSource.Goods.Name
            GoodsColorTxt.DataBindings.Add("Text", goods, "Color");//bindSource.Goods.Color
            GoodsQualityTxt.DataBindings.Add("Text", goods, "Quality");//bindSource.Goods.Quality
            //GoodsPrimePriceTxt.DataBindings.Add("Text", newPurchaseGoodsInfo, "Goods.PrimePrice.Value"); //bindSource.Goods.PrimePrice;
            //GoodsMarkPriceTxt.DataBindings.Add("Text", newPurchaseGoodsInfo, "Goods.MarkPrice.Value"); //bindSource.Goods.MarkPrice.Value
            GoodsPartsTxt.DataBindings.Add("Text", goods, "Parts");//bindSource.Goods.Parts;
            GoodsDescTxt.DataBindings.Add("Text", goods, "Desc");//bindSource.Goods.Desc
            //GoodsPictureImage.DataBindings.Add("EditValue", newPurchaseGoodsInfo, "GoodsImageBytes");
            //DateEnd.DataBindings.Add("EditValue", newPurchaseGoodsInfo, "Goods.ConsignEndDate.Value");//bindSource.Goods.ConsignEndDate

            GoodsPictureImage.EditValue = this.GetGoodsLargeImage();

            var purchaseRecord = newPurchaseGoodsInfo.PurchaseRecord;

            ComboxCategoryType.DataBindings.Add("EditValue", newPurchaseGoodsInfo, "Category");
            ComboxGoodsOperator.DataBindings.Add("Text", purchaseRecord, "Operator");
            ComboxPayType.DataBindings.Add("EditValue", newPurchaseGoodsInfo, "PayType");
            //ComBoxPaid.DataBindings.Add("EditValue", newPurchaseGoodsInfo, "GoodsPaid");
            if (this.mRKType == SourceType.JinHuo)
            {
                ComBoxPaid.SelectedIndex = 0;
                ComBoxPaid.Enabled = false;
            }
            else
            {
                ComBoxPaid.SelectedIndex = 1;
            }
            GoodsPrimePriceTxt.EditValue = newPurchaseGoodsInfo.Goods.PrimePrice ?? 0;
            GoodsMarkPriceTxt.EditValue = newPurchaseGoodsInfo.Goods.MarkPrice ?? 0;
            DateEnd.EditValue = newPurchaseGoodsInfo.Goods.ConsignEndDate.HasValue ? newPurchaseGoodsInfo.Goods.ConsignEndDate.Value.ToString("yyyy/MM/dd") : "";
        }

        private byte[] GetGoodsLargeImage()
        {
            if (newPurchaseGoodsInfo.Goods.Id > 0 && string.IsNullOrEmpty(newPurchaseGoodsInfo.Goods.Image))
            {
                newPurchaseGoodsInfo.Goods.Image = GoodsBusiness.Instance.GetGoodsImage(newPurchaseGoodsInfo.Goods.Id);
            }
            if (!string.IsNullOrEmpty(newPurchaseGoodsInfo.Goods.Image))
                return Convert.FromBase64String(newPurchaseGoodsInfo.Goods.Image);

            return new List<byte>().ToArray();
        }

        private void SetControlStatus(bool status)
        {
            status = status && SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId;
            this.ComboxPayType.Enabled =
            this.ComBoxPaid.Enabled =
            this.ComboxGoodsOperator.Enabled =
            this.ComboxCategoryType.Enabled =
            this.GoodsColorTxt.Enabled =
            this.GoodsDescTxt.Enabled =
            this.GoodsMarkPriceTxt.Enabled =
            this.GoodsNameTxt.Enabled =
            this.GoodsOriginalCodeTxt.Enabled =
            this.GoodsPartsTxt.Enabled =
            this.GoodsPrimePriceTxt.Enabled =
                //this.GoodsPictureImage.Enabled =
            this.GoodsQualityTxt.Enabled =
            this.DateEnd.Enabled =
            this.Btn_OK.Enabled = status;

            this.Btn_OK.Enabled =
            this.GoodsPartsTxt.Enabled =
            this.GoodsDescTxt.Enabled = status || SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.PMRoleId;
        }

        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();
            //double validationTryDouble = 0;
            decimal validationTryDecimal = 0;
            if (this.ComboxCategoryType.SelectedIndex < 0)
            {
                mErrorProvider.SetError(this.ComboxCategoryType, "请选择类别", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.GoodsOriginalCodeTxt.Text.Trim()))
            {
                mErrorProvider.SetError(this.GoodsOriginalCodeTxt, "不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.GoodsNameTxt.Text.Trim()))
            {
                mErrorProvider.SetError(this.GoodsNameTxt, "不能为空", ErrorType.Warning);
            }
            //商品颜色默认：未知          
            //商品成色默认：未知           
            if (this.ComboxPayType.SelectedIndex < 0)
            {
                mErrorProvider.SetError(this.ComboxPayType, "请选择付款方式", ErrorType.Warning);
            }

            if (GoodsPrimePriceTxt.EditValue == null || !decimal.TryParse(GoodsPrimePriceTxt.EditValue.ToString().Trim(), out validationTryDecimal))
            {
                mErrorProvider.SetError(this.GoodsPrimePriceTxt, "请输入正确的价格", ErrorType.Warning);
            }
            else newPurchaseGoodsInfo.Goods.PrimePrice = validationTryDecimal;

            if (GoodsMarkPriceTxt.EditValue == null || !decimal.TryParse(GoodsMarkPriceTxt.EditValue.ToString(), out validationTryDecimal))
            {
                mErrorProvider.SetError(this.GoodsMarkPriceTxt, "请输入正确的价格", ErrorType.Warning);
            }
            else newPurchaseGoodsInfo.Goods.MarkPrice = validationTryDecimal;

            if (string.IsNullOrEmpty(this.ComboxGoodsOperator.Text.Trim()))
            {
                mErrorProvider.SetError(this.ComboxGoodsOperator, "请选择经手人", ErrorType.Warning);
            }
            if (mRKType == SourceType.JiShou && (this.DateEnd.EditValue == null || this.DateEnd.EditValue.Equals("")))
            {
                mErrorProvider.SetError(this.DateEnd, "请输入寄售结束时间", ErrorType.Warning);
            }

            //配件默认：为空         
            //描述默认：为空 
            //商品图片默认：为空
            //if (GoodsPictureImage.IsLoading)
            //{
            //    ErrorProvider.SetError(this.GoodsPictureImage, "请选择商品图片", ErrorType.Warning);
            //}

            return mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidatFail())
            {
                if (string.IsNullOrEmpty(DateEnd.EditValue.ToString()))
                    newPurchaseGoodsInfo.Goods.ConsignEndDate = null;
                else
                    newPurchaseGoodsInfo.Goods.ConsignEndDate = (this.DateEnd.EditValue == null || this.DateEnd.EditValue.Equals("")) ? new Nullable<DateTime>() : Convert.ToDateTime(DateEnd.EditValue);
                //进货为已打款1，寄售为未打款2
                newPurchaseGoodsInfo.Goods.Paid = ((GoodsPaidInfo)ComBoxPaid.EditValue).Id;

                if (!newPurchaseGoodsInfo.Equals(mPurchaseGoodsInfo))
                {

                    newPurchaseGoodsInfo.Goods.IdSpecify = true;
                    if (mPurchaseGoodsInfo != null) mPurchaseGoodsInfo = newPurchaseGoodsInfo.Clone();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("商品信息无更新，继续编辑请点击Y退出点击N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        private void GoodsPictureImage_DoubleClick(object sender, EventArgs e)
        {
            GoodsPictureImage.LoadImage();
            newPurchaseGoodsInfo.GoodsImageBytes = (byte[])GoodsPictureImage.EditValue;
        }

        private void ComboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidatFail();
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender) == GoodsNameTxt)
            {
                this.Text = formText + (string.IsNullOrEmpty(GoodsNameTxt.Text) ? "" : "-" + GoodsNameTxt.Text);
            }

            ValidatFail();
        }

        private void TextEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }


    }
}
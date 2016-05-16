using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsSaledMondify : FormSimpleDialogBase
    {
        /// <summary>
        /// 编辑对象
        /// </summary>
        SaledGoodsInfo newSaledGoodsInfo = new SaledGoodsInfo();
        GoodsInfo newGoodsInfo = new GoodsInfo();
        /// <summary>
        /// 原始对象（仅在处于编辑时有值）
        /// </summary>
        //GoodsInfo mGoodsInfo = null;
        SaledGoodsInfo mSaledGoodsInfo = new SaledGoodsInfo();
        /// <summary>
        /// 编辑好的对象
        /// </summary>
        public SaledGoodsInfo SaledGoodsInfo
        {
            get
            {
                return newSaledGoodsInfo;
            }
        }

        public FmGoodsSaledMondify(GoodsInfo goodsInfo)
        {
            InitializeComponent();

            InitializeControls(new SaledGoodsInfo()
            {
                Goods = goodsInfo,
                LoginUser = SharedVariables.Instance.LoginUser.User
            });
        }

        public FmGoodsSaledMondify(SaledGoodsInfo saledGoodsInfo)
        {
            InitializeComponent();

            InitializeControls(saledGoodsInfo);
        }

        private void InitializeControls(SaledGoodsInfo saledGoodsInfo = null)
        {
            if (saledGoodsInfo != null)
            {
                newSaledGoodsInfo = saledGoodsInfo.Clone();
                //newSaledGoodsInfo.SaledRecord.Operator = SharedVariables.Instance.LoginUser.User.Name;
                mSaledGoodsInfo = saledGoodsInfo;
            }

            this.ComboxGoodsOperator.Properties.Items.AddRange(Business.SharedVariables.Instance.UserInfos);
            //this.ComboxPayType.Properties.Items.AddRange(Business.SharedVariables.Instance.PayTypeInfos);

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            //this.Text = mPurchaseGoodsInfo == null ? "商品详情-添加" : "商品详情-编辑";
            this.Btn_OK.Click += btnOk_Click;

            newSaledGoodsInfo.Goods.Discount = newSaledGoodsInfo.Goods.Discount ?? 0;
            newSaledGoodsInfo.Goods.MarkPrice = newSaledGoodsInfo.Goods.MarkPrice ?? 0;
            newSaledGoodsInfo.Goods.Prepay = newSaledGoodsInfo.Goods.Prepay ?? 0;
            newSaledGoodsInfo.Goods.SalePrice = newSaledGoodsInfo.Goods.SalePrice ?? 0;

            var goods = newSaledGoodsInfo.Goods;
            TxtGoodsCode.DataBindings.Add("Text", goods, "Code");
            TxtGoodsName.DataBindings.Add("Text", goods, "Name");

            var category = newSaledGoodsInfo.Category;
            TxtGoodsCategory.DataBindings.Add("Text", category, "Name");

            var saledRecord = newSaledGoodsInfo.SaledRecord;
            ComboxGoodsOperator.DataBindings.Add("Text", saledRecord, "Operator");
            if (string.IsNullOrEmpty(ComboxGoodsOperator.Text))
                ComboxGoodsOperator.Text = SharedVariables.Instance.LoginUser.User.Name;

            //ComboxPayType.DataBindings.Add("EditValue", newSaledGoodsInfo, "PayType");

            //TxtGoodsDiscount.DataBindings.Add("EditValue", newSaledGoodsInfo, "Goods.Discount.Value");
            TxtGoodsMarkPrice.EditValue = newSaledGoodsInfo.Goods.MarkPrice;
            TxtGoodsDiscount.EditValue = newSaledGoodsInfo.Goods.Discount;
            TxtGoodsPrepay.EditValue = newSaledGoodsInfo.Goods.Prepay;
            TxtRealSaled.EditValue = newSaledGoodsInfo.Goods.MarkPrice - newSaledGoodsInfo.Goods.Discount;
            //GoodsPictureImage.EditValue = newSaledGoodsInfo.GoodsImageBytes;
            TxtGoodsDiscount.EditValue = newSaledGoodsInfo.Goods.Discount.HasValue ? newSaledGoodsInfo.Goods.Discount.Value : (decimal)0;
            GoodsPictureImage.EditValue = this.GetGoodsLargeImage();
            TxtRealSaled.Enabled =
            TxtGoodsDiscount.Enabled =
            ComboxStatus.Enabled =
            ComboxGoodsOperator.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == (int)SharedVariables.AdminRoleId
                                        || (newSaledGoodsInfo.Goods.Status != (int)GoodsStatus.Catch 
                                        || newSaledGoodsInfo.Goods.StatusSpecify);//预订商品不可编辑

            var index = newSaledGoodsInfo.Goods.Status - (int)GoodsStatus.Catch;
            ComboxStatus.SelectedIndex = index < 0 ? 1 : index;//默认售出
        }

        private byte[] GetGoodsLargeImage()
        {
            if (newSaledGoodsInfo.Goods.Id > 0 && string.IsNullOrEmpty(newSaledGoodsInfo.Goods.Image))
            {
                newSaledGoodsInfo.Goods.Image = GoodsBusiness.Instance.GetGoodsImage(newSaledGoodsInfo.Goods.Id);
            }
            if (!string.IsNullOrEmpty(newSaledGoodsInfo.Goods.Image))
                return Convert.FromBase64String(newSaledGoodsInfo.Goods.Image);

            return new List<byte>().ToArray();
        }

        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();

            if (newSaledGoodsInfo.Goods.Discount + newSaledGoodsInfo.Goods.SalePrice != (newSaledGoodsInfo.Goods.MarkPrice ?? 0))
            {
                mErrorProvider.SetError(this.TxtGoodsDiscount, "请调整折扣", ErrorType.Warning);
                mErrorProvider.SetError(this.TxtRealSaled, "请调整实售价格", ErrorType.Warning);
            }

            if (newSaledGoodsInfo.Goods.Prepay > newSaledGoodsInfo.Goods.SalePrice)
            {
                mErrorProvider.SetError(this.TxtGoodsPrepay, "预付应该<=实售", ErrorType.Warning);
            }

            //预付每次累加还是始终为总和???
            if (newSaledGoodsInfo.Goods.Prepay < (mSaledGoodsInfo.Goods.Prepay ?? 0))
            {
                mErrorProvider.SetError(this.TxtGoodsPrepay, "小于上次预付", ErrorType.Warning);
            }

            newSaledGoodsInfo.Goods.PrepaySpecify = newSaledGoodsInfo.Goods.Prepay == (mSaledGoodsInfo.Goods.Prepay ?? 0);

            if (ComboxStatus.SelectedIndex < 0)
            {
                mErrorProvider.SetError(this.ComboxStatus, "请选择售出方式", ErrorType.Warning);
            }
            else newSaledGoodsInfo.Goods.Status = SharedVariables.GoodsStatusName.IndexOf(ComboxStatus.Text.Trim());


            if (string.IsNullOrEmpty(this.ComboxGoodsOperator.Text.Trim()))
            {
                mErrorProvider.SetError(this.ComboxGoodsOperator, "请选择经手人", ErrorType.Warning);
            }

            return mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidatFail())
            {
                //商品被取回不修改任何当前信息
                if (newSaledGoodsInfo.Goods.Status == (int)GoodsStatus.GetOut)
                {
                    newSaledGoodsInfo = new SaledGoodsInfo() { Goods = mSaledGoodsInfo.Goods };
                    newSaledGoodsInfo.Goods.Status = (int)GoodsStatus.GetOut;
                }
                else
                {
                    //???是否预付款完成修改商品状态为售出                    
                    if (newSaledGoodsInfo.Goods.Prepay == newSaledGoodsInfo.Goods.SalePrice)
                    {
                        newSaledGoodsInfo.Goods.Status = (int)GoodsStatus.Saled;
                    }
                }

                if (!newSaledGoodsInfo.Equals(mSaledGoodsInfo))
                {
                    mSaledGoodsInfo = newSaledGoodsInfo.Clone();

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

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            newSaledGoodsInfo.Goods.Discount = (decimal)TxtGoodsDiscount.EditValue;
            newSaledGoodsInfo.Goods.SalePrice = (decimal)TxtRealSaled.EditValue;
            newSaledGoodsInfo.Goods.Prepay = (decimal)TxtGoodsPrepay.EditValue;

            if (sender == TxtRealSaled)
            {
                TxtGoodsDiscount.EditValue = newSaledGoodsInfo.Goods.MarkPrice - newSaledGoodsInfo.Goods.SalePrice;
            }
            if (sender == TxtGoodsDiscount)
            {
                TxtRealSaled.EditValue = newSaledGoodsInfo.Goods.MarkPrice - newSaledGoodsInfo.Goods.Discount;
            }

            ValidatFail();
        }

        private void ComboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TxtRealSaled.Enabled = ComboxStatus.SelectedIndex == 0;

            ValidatFail();
        }
    }
}
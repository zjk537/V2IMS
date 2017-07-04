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
        ProSalesInfo newProSalesInfo = new ProSalesInfo();
        ProInfo ProInfo = new ProInfo();
        /// <summary>
        /// 原始对象（仅在处于编辑时有值）
        /// </summary>
        //GoodsInfo mGoodsInfo = null;
        ProSalesInfo mProSalesInfo = new ProSalesInfo();
        /// <summary>
        /// 编辑好的对象
        /// </summary>
        public ProSalesInfo SaledGoodsInfo
        {
            get
            {
                return newProSalesInfo;
            }
        }

        List<WebUserInfo> users = new List<WebUserInfo>();

        public FmGoodsSaledMondify(ProInfo proInfo)
        {
            InitializeComponent();

            users = UserWebBusiness.GetUserInfoList();

            this.ProInfo = proInfo;
            newProSalesInfo = this.ProInfo.ProSalesInfo;
            mProSalesInfo = this.ProInfo.ProSalesInfo;

            newProSalesInfo.JUser = users.Find(a => { return a.id == newProSalesInfo.juid; });

            InitializeControls();
        }

        private void InitializeControls()
        {
            this.outjuser.Properties.Items.AddRange(users);
            this.paystatus.Properties.Items.AddRange(ConfigManager.ProPayStatus);

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            this.Btn_OK.Click += btnOk_Click;

            profenlei.DataBindings.Add("Text", newProSalesInfo, "fenlei");
            projcode.DataBindings.Add("Text", newProSalesInfo, "jpid");
            proname.DataBindings.Add("Text", newProSalesInfo, "jpname");
            probjiage.DataBindings.Add("Text", newProSalesInfo, "bjiage");

            outcustname.DataBindings.Add("Text", newProSalesInfo, "custname");
            outcustphone.DataBindings.Add("Text", newProSalesInfo, "custphone");
            zhekou.DataBindings.Add("EditValue", newProSalesInfo, "zhekou");
            sjiage.DataBindings.Add("EditValue", newProSalesInfo, "jpsjiage");
            paystatus.DataBindings.Add("Text", newProSalesInfo, "paytype");
            yufu.DataBindings.Add("EditValue", newProSalesInfo, "yufu");
            outjuser.DataBindings.Add("EditValue", newProSalesInfo, "JUser");  

            //newProSalesInfo.Goods.Discount = newProSalesInfo.Goods.Discount ?? 0;
            //newProSalesInfo.Goods.MarkPrice = newProSalesInfo.Goods.MarkPrice ?? 0;
            //newProSalesInfo.Goods.Prepay = newProSalesInfo.Goods.Prepay ?? 0;
            //newProSalesInfo.Goods.SalePrice = newProSalesInfo.Goods.SalePrice ?? 0;

            //var goods = newProSalesInfo.Goods;
            //projcode.DataBindings.Add("Text", goods, "Code");
            //proname.DataBindings.Add("Text", goods, "Name");

            //var category = newProSalesInfo.Category;
            //profenlei.DataBindings.Add("Text", category, "Name");

            //var saledRecord = newProSalesInfo.SaledRecord;
            //outjuser.DataBindings.Add("Text", saledRecord, "Operator");
            //if (string.IsNullOrEmpty(outjuser.Text))
            //    outjuser.Text = ConfigManager.LoginUser.username; //SharedVariables.Instance.LoginUser.User.Name;

            ////ComboxPayType.DataBindings.Add("EditValue", newSaledGoodsInfo, "PayType");

            ////TxtGoodsDiscount.DataBindings.Add("EditValue", newSaledGoodsInfo, "Goods.Discount.Value");
            //probjiage.EditValue = newProSalesInfo.bjiage;
            //zhekou.EditValue = newProSalesInfo.Goods.Discount;
            //yufu.EditValue = newProSalesInfo.Goods.Prepay;
            //sjiage.EditValue = newProSalesInfo.Goods.MarkPrice - newProSalesInfo.Goods.Discount;
            ////GoodsPictureImage.EditValue = newSaledGoodsInfo.GoodsImageBytes;
            //zhekou.EditValue = newProSalesInfo.Goods.Discount.HasValue ? newProSalesInfo.Goods.Discount.Value : (decimal)0;
            //GoodsPictureImage.EditValue = this.GetGoodsLargeImage();
            //sjiage.Enabled =
            //zhekou.Enabled =
            //paystatus.Enabled =
            //outjuser.Enabled = 
            ////SharedVariables.Instance.LoginUser.User.RoleId == (int)SharedVariables.AdminRoleId
            ////                            || 
            //                            (newProSalesInfo.Goods.Status != (int)GoodsStatus.Catch 
            //                            || newProSalesInfo.Goods.StatusSpecify);//预订商品不可编辑

            //var index = newProSalesInfo.Goods.Status - (int)GoodsStatus.Catch;
            //paystatus.SelectedIndex = index < 0 ? 1 : index;//默认售出
        }

        private byte[] GetGoodsLargeImage()
        {
        //    if (newProSalesInfo.Goods.Id > 0 && string.IsNullOrEmpty(newProSalesInfo.Goods.Image))
        //    {
        //        newProSalesInfo.Goods.Image = GoodsBusiness.Instance.GetGoodsImage(newProSalesInfo.Goods.Id);
        //    }
        //    if (!string.IsNullOrEmpty(newProSalesInfo.Goods.Image))
        //        return Convert.FromBase64String(newProSalesInfo.Goods.Image);

            return new List<byte>().ToArray();
        }

        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();

            if (newProSalesInfo.zhekou + newProSalesInfo.jpsjiage != newProSalesInfo.bjiage)
            {
                mErrorProvider.SetError(this.zhekou, "请调整折扣", ErrorType.Warning);
                mErrorProvider.SetError(this.sjiage, "请调整实售价格", ErrorType.Warning);
            }

            if (newProSalesInfo.yufu > newProSalesInfo.jpsjiage)
            {
                mErrorProvider.SetError(this.yufu, "预付应该<=实售", ErrorType.Warning);
            }

            //预付每次累加还是始终为总和???
            if (newProSalesInfo.yufu < mProSalesInfo.yufu)
            {
                mErrorProvider.SetError(this.yufu, "小于上次预付", ErrorType.Warning);
            }
          
            if (string.IsNullOrEmpty(paystatus.Text))
            {
                mErrorProvider.SetError(this.paystatus, "请选择售出方式", ErrorType.Warning);
            }

            //if (string.IsNullOrEmpty(this.projuser.Text.Trim()))
            if (this.outjuser.SelectedItem == null)
            {
                mErrorProvider.SetError(this.outjuser, "请选择经手人", ErrorType.Warning);
            }
            else
            {
                newProSalesInfo.JUser = this.outjuser.SelectedItem as WebUserInfo;
            }

            return mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidatFail())
            {
                //商品被取回不修改任何当前信息
                if (newProSalesInfo.paytype!= ConfigManager.QuHui)
                {
                    //???是否预付款完成修改商品状态为售出                    
                    if (newProSalesInfo.yufu == newProSalesInfo.jpsjiage)
                    {
                        newProSalesInfo.paytype = ConfigManager.ShouChu;
                    }
                }

                GoodsWebBusiness.ProOut(newProSalesInfo);

                this.DialogResult = DialogResult.OK;
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            newProSalesInfo.zhekou = (decimal)zhekou.EditValue;
            newProSalesInfo.jpsjiage = (decimal)sjiage.EditValue;
            newProSalesInfo.yufu = (decimal)yufu.EditValue;
            ;
            if (sender == sjiage)
            {
                zhekou.EditValue = newProSalesInfo.bjiage - newProSalesInfo.jpsjiage;
            }
            if (sender == zhekou)
            {
                sjiage.EditValue = newProSalesInfo.bjiage - newProSalesInfo.zhekou;
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
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
        public ProInfo NewProInfo = new ProInfo();
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

            newProSalesInfo.images = GoodsWebBusiness.GetProImages(proInfo.proid.Value);
            newProSalesInfo.JUser = users.Find(a => { return a.id == newProSalesInfo.juid; });

            InitializeControls();
        }

        private void InitializeControls()
        {
            this.outjuser.Properties.Items.AddRange(users);
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
            paystatus.DataBindings.Add("Text", newProSalesInfo, "status");
            yufu.DataBindings.Add("EditValue", newProSalesInfo, "yufu");
            outjuser.DataBindings.Add("EditValue", newProSalesInfo, "JUser");

            GoodsPictureImage.EditValue = newProSalesInfo.imagebytes;

            zhekou.TextChanged += TextEdit_TextChanged;
            sjiage.TextChanged += TextEdit_TextChanged;

            yufu.TextChanged += TextEdit_TextChanged;
        }


        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();

            if (!string.IsNullOrEmpty(paystatus.Text) && paystatus.Text.Equals("取回"))
            {
                return mErrorProvider.HasErrors;
            }

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
                if (newProSalesInfo.status!= ConfigManager.QuHui)
                {
                    //???是否预付款完成修改商品状态为售出                    
                    if (newProSalesInfo.yufu == newProSalesInfo.jpsjiage)
                    {
                        newProSalesInfo.status = ConfigManager.ShouChu;
                    }
                }

                NewProInfo = GoodsWebBusiness.ProOut(newProSalesInfo);
                
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
           
            newProSalesInfo.yufu = (decimal)yufu.EditValue;
            ;
            if (sender == sjiage)
            {
                newProSalesInfo.zhekou = (decimal)zhekou.EditValue;
                newProSalesInfo.jpsjiage = (decimal)sjiage.EditValue;
                zhekou.EditValue = newProSalesInfo.bjiage - newProSalesInfo.jpsjiage;
            }
            if (sender == zhekou)
            {
                newProSalesInfo.zhekou = (decimal)zhekou.EditValue;
                newProSalesInfo.jpsjiage = (decimal)sjiage.EditValue;
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
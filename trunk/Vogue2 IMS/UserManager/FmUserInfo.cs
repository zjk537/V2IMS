using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Model.DataModel;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business;

namespace Vogue2_IMS.UserManager
{
    public partial class FmUserInfo : FormSimpleDialogBase
    {
        /// <summary>
        /// 编辑对象
        /// </summary>
        UserShopRoleInfo mNewUserShopRoleInfoInfo = new UserShopRoleInfo();
        /// <summary>
        /// 原始对象（仅在处于编辑时有值）
        /// </summary>
        UserShopRoleInfo mUserShopRoleInfo = null;

        /// <summary>
        /// 编辑好的对象
        /// </summary>
        public UserShopRoleInfo UserShopRoleInfoInfo
        {
            get
            {
                return mNewUserShopRoleInfoInfo;
            }
        }

        public FmUserInfo(UserShopRoleInfo userShopRoleInfo = null)
        {
            InitializeComponent();
            InitializeControls(userShopRoleInfo);
        }

        private void InitializeControls(UserShopRoleInfo userShopRoleInfo = null)
        {
            if (userShopRoleInfo != null)
            {
                UserInfo tempUser = new UserInfo();
                DBModelBase.Clone<UserInfo>(userShopRoleInfo.User, ref tempUser);
                mNewUserShopRoleInfoInfo.User = tempUser;

                mUserShopRoleInfo = userShopRoleInfo;
            }

            this.ComboxShop.Properties.Items.AddRange(Business.SharedVariables.Instance.ShopInfos);
            this.ComboxRole.Properties.Items.AddRange(Business.SharedVariables.Instance.RoleInfos);
            this.ComboxSex.Properties.Items.AddRange(Business.SharedVariables.SexName);

            ControlsBinding();
        }

        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();

            if (this.ComboxShop.SelectedIndex < 0)
            {
                mErrorProvider.SetError(this.ComboxShop, "请选择所属店铺", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.TxtRealName.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtRealName, "真实性名不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.TxtPhone.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtPhone, "联系方式不能为空", ErrorType.Warning);
            }
            if (this.ComboxRole.SelectedIndex < 0)
            {
                mErrorProvider.SetError(this.ComboxRole, "请选择职位", ErrorType.Warning);
            }

            if (string.IsNullOrEmpty(this.TxtLogUserName.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtLogUserName, "登录用户名不能为空", ErrorType.Warning);
            }

            if (TxtLogUserPwd.Enabled)
                if (string.IsNullOrEmpty(this.TxtLogUserPwd.Text.Trim()))
                {
                    mErrorProvider.SetError(this.TxtLogUserPwd, "登录密码不能为空", ErrorType.Warning);
                }

            if (TxtAgainPwd.Enabled)
                if (!this.TxtLogUserPwd.Text.Equals(this.TxtAgainPwd.Text))
                {
                    //mErrorProvider.SetError(this.TxtLogUserPwd, "登录密码不能为空", ErrorType.Warning);
                    mErrorProvider.SetError(this.TxtAgainPwd, "两次输入密码不相同", ErrorType.Warning);
                }

            return mErrorProvider.HasErrors;
        }

        private void ControlsBinding()
        {
            this.Text = mUserShopRoleInfo == null ? "用户信息-添加" : "用户信息-编辑";
            mNewUserShopRoleInfoInfo.User.Sex = mNewUserShopRoleInfoInfo.User.Sex.HasValue ? mNewUserShopRoleInfoInfo.User.Sex.Value : 0;
            this.Btn_OK.Click += btnOk_Click;

            //mNewUserShopRoleInfoInfo.OwnerShop;
            ComboxShop.DataBindings.Add("EditValue", mNewUserShopRoleInfoInfo, "OwnerShop");
            //mNewUserShopRoleInfoInfo.Role;
            ComboxRole.DataBindings.Add("EditValue", mNewUserShopRoleInfoInfo, "Role");

            var user = mNewUserShopRoleInfoInfo.User;
            //mNewUserShopRoleInfoInfo.User.RealName
            TxtRealName.DataBindings.Add("Text", user, "RealName");
            //mNewUserShopRoleInfoInfo.User.Phone;
            TxtPhone.DataBindings.Add("Text", user, "Phone");
            //mNewUserShopRoleInfoInfo.User.Name
            TxtLogUserName.DataBindings.Add("Text", user, "Name");
            //mNewUserShopRoleInfoInfo.User.Pwd
            TxtLogUserPwd.DataBindings.Add("Text", user, "Pwd");
            //TxtAgainPwd.Text = mNewUserShopRoleInfoInfo.User.Pwd;

            ComboxSex.SelectedIndex = mNewUserShopRoleInfoInfo.User.Sex.Value;
            ComboxShop.Enabled = ComboxRole.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId;

            TxtLogUserName.Enabled = TxtLogUserPwd.Enabled = mUserShopRoleInfo == null;

            //TxtAgainPwd.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId
            //    || (mUserShopRoleInfo == null && mUserShopRoleInfo.Role.Id > SharedVariables.Instance.LoginUser.User.RoleId);           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidatFail())
            {
                if (!mNewUserShopRoleInfoInfo.User.Equals(mUserShopRoleInfo == null ? null : mUserShopRoleInfo.User ?? null))
                {
                    if (!UserBusiness.Instance.ValidateUserName(mNewUserShopRoleInfoInfo.User.Id, mNewUserShopRoleInfoInfo.User.Name))
                    {
                        mErrorProvider.SetError(this.TxtLogUserName, "用户名已被占用!", ErrorType.Warning);
                        return;
                    }
                    if (mUserShopRoleInfo != null)
                    {
                        mNewUserShopRoleInfoInfo.User.IdSpecify = true;
                        mNewUserShopRoleInfoInfo.User.PwdSpecify = false;
                        //mUserShopRoleInfo.User = mNewUserShopRoleInfoInfo.User;
                        UserBusiness.Instance.UpdateUser(mNewUserShopRoleInfoInfo.User);
                    }
                    else
                    {
                        UserBusiness.Instance.AddUser(mNewUserShopRoleInfoInfo.User);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("用户信息无更新，继续编辑请点击Y退出点击N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        private void ComboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == ComboxSex)
            {
                mNewUserShopRoleInfoInfo.User.Sex = ComboxSex.SelectedIndex;
            }

            ValidatFail();
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidatFail();
        }
    }
}
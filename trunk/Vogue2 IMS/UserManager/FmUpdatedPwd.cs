using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Business;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.UserManager
{
    public partial class FmUpdatedPwd : FormSimpleDialogBase
    {
        public FmUpdatedPwd()
        {
            InitializeComponent();
            Btn_OK.Click += btnOk_Click;
        }

        private void TxtPwd_EditValueChanged(object sender, System.EventArgs e)
        {
            ValidatorFail();
        }

        private bool ValidatorFail()
        {
            mErrorProvider.ClearErrors();
            string oldPwd = TxtOldPwd.Text.Trim();
            string newPwd = TxtNewPwd.Text.Trim();
            string newPwd2 = TxtNewPwd2.Text.Trim();

            //if (!oldPwd.Equals(SharedVariables.Instance.LoginUser.User.Pwd))
            //{
            //    mErrorProvider.SetError(TxtOldPwd, "原始密码不符", ErrorType.Warning);
            //}

            if (string.IsNullOrEmpty(newPwd))
            {
                mErrorProvider.SetError(TxtNewPwd, "密码不能为空", ErrorType.Warning);
            }

            if (!string.IsNullOrEmpty(newPwd) && newPwd.Equals(oldPwd))
            {
                mErrorProvider.SetError(TxtNewPwd, "原始密码与新密码一致", ErrorType.Warning);
            }

            if (!newPwd.Equals(newPwd2))
            {
                mErrorProvider.SetError(TxtNewPwd2, "两次输入密码不一致", ErrorType.Warning);
            }

            return mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!ValidatorFail())
            {
                //SharedVariables.Instance.LoginUser.User.IdSpecify = true;
                //SharedVariables.Instance.LoginUser.User.Pwd = TxtNewPwd.Text;
                //UserBusiness.Instance.UpdateUser(SharedVariables.Instance.LoginUser.User);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

    }
}
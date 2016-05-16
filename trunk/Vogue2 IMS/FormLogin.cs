using DevExpress.XtraEditors;
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;
using Vogue2_IMS.Business;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Vogue2_IMS
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        private ManualResetEvent waitMdiInitializeHandler = null;
        public ManualResetEvent waitLoginHandler = new ManualResetEvent(false);
        private delegate void LoginHandler();
        public delegate void SetDialogResultHandler(DialogResult dialogResult);
        public event SetDialogResultHandler SetDialogResult;

        public FormLogin(ManualResetEvent waitMdiInitializeHandler)
        {
            InitializeComponent();
            this.waitMdiInitializeHandler = waitMdiInitializeHandler;

            InitializeComponentExtend();

            ControlBindings();
        }

        private void ControlBindings()
        {
            //this.TxtUserName.DataBindings.Add("Text", SharedVariables.Instance.LoginUser, "User.Name");
            //this.TxtPwd.DataBindings.Add("Text", SharedVariables.Instance.LoginUser, "User.Pwd");
        }

        private void InitializeComponentExtend()
        {
            this.TopMost = true;
            this.ShowInTaskbar = true;

            //Btn_OK.Text = "登录(&L)";
            //Btn_Cancel.Text = "退出(&Q)";
            //Btn_OK.Click += BtnOK_Click;
            //Btn_Cancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            EndLogin(DialogResult.Cancel);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!ValidatingFail())
            {
                UserInfo user = UserBusiness.Instance.GetUserByName(this.TxtUserName.Text.Trim(), this.TxtPwd.Text.Trim());
                if (user == null)
                {
                    XtraMessageBox.Show("用户名或密码不正确，请重新输入！");
                    return;
                }

                SharedVariables.Instance.LoginUser.User = user;

                new LoginHandler(Login).BeginInvoke(new AsyncCallback(LoginCallBack), null);
            }
        }

        #region Login Call Back

        private void LoginCallBack(IAsyncResult ar)
        {
            try
            {
                ((LoginHandler)((AsyncResult)ar).AsyncDelegate).EndInvoke(ar);
            }
            catch
            {

            }
        }

        private void Login()
        {
            try
            {
                EndLogin(DialogResult.OK);
                //if (UserManagementService.Login(userTextEdit.Text, pwdTextEdit.Text))
                //{
                //    EndLogin(DialogResult.OK);
                //}
                //else
                //{
                //    Reload(true);
                //}
            }
            catch (Exception e)
            {
            }
        }

        private void EndLogin(DialogResult dialogResult)
        {
            //通知Main窗体登录结果
            if (SetDialogResult != null)
            {
                SetDialogResult(dialogResult);
            }

            //释放Main窗体初始化信号
            waitMdiInitializeHandler.Set();
            //等待Main窗体初始化完成
            waitLoginHandler.WaitOne();

            //返回登录结果，并释放登录窗体
            this.DialogResult = dialogResult;
        }

        #endregion

        private void fm_Disposed(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidatingFail();
        }

        private bool ValidatingFail()
        {
            mErrorProvider.ClearErrors();

            if (string.IsNullOrEmpty(TxtUserName.Text.Trim()))
            {
                mErrorProvider.SetError(TxtUserName, "用户名不能为空", ErrorType.Warning);
            }

            if (string.IsNullOrEmpty(TxtPwd.Text.Trim()))
            {
                mErrorProvider.SetError(TxtPwd, "密码不能为空", ErrorType.Critical);
            }

            return mErrorProvider.HasErrors;
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnCancel.PerformClick();
        }
    }
}

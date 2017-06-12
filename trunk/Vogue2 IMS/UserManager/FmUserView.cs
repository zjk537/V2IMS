using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using System.Linq;

namespace Vogue2_IMS.UserManager
{
    public partial class FmUserView : DevExpress.XtraEditors.XtraForm
    {
        public FmUserView()
        {
            InitializeComponent();

            UserBusiness.Instance.OnUserUpdated+=new EventHandler<CusEventArgs>(Instance_OnUserUpdated);

            colShopName.Group();
        }
        
        private void Instance_OnUserUpdated(object sender, CusEventArgs args)
        {
            if (BtnRefResh != null)
            {
                BtnRefResh.PerformClick();
            }
        }

        private BarButtonItem btnAdd = null;
        public BarButtonItem BtnAdd
        {
            get { return btnAdd; }
            set
            {
                btnAdd = value;
                if (btnAdd != null)
                {
                    btnAdd.ItemClick += new ItemClickEventHandler(btnAdd_ItemClick);
                    //btnAdd.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId;
                }
            }
        }

        private BarButtonItem btnUpdate = null;
        public BarButtonItem BtnUpdate
        {
            get { return btnUpdate; }
            set
            {
                btnUpdate = value;
                if (btnUpdate != null)
                    btnUpdate.ItemClick += new ItemClickEventHandler(btnUpdate_ItemClick);
            }
        }

        private BarButtonItem btnResetPwd = null;
        public BarButtonItem BtnResetPwd
        {
            get { return btnResetPwd; }
            set
            {
                btnResetPwd = value;
                if (btnResetPwd != null)
                    btnResetPwd.ItemClick += new ItemClickEventHandler(btnResetPwd_ItemClick);
            }
        }

        private BarButtonItem btnRefResh = null;
        public BarButtonItem BtnRefResh
        {
            get { return btnRefResh; }
            set
            {
                btnRefResh = value;
                if (btnRefResh != null)
                    btnRefResh.ItemClick += new ItemClickEventHandler(btnRefResh_ItemClick);
            }
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs args)
        {
            var fmUserInfo = new FmUserInfo();
            fmUserInfo.ShowDialog();
        }

        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs args)
        {
            if (SelectedUser != null)
            {
                var fmUserInfo = new FmUserInfo(SelectedUser);
                fmUserInfo.ShowDialog();
            }
        }

        private void btnResetPwd_ItemClick(object sender, ItemClickEventArgs args)
        {
            if (SelectedUser != null)
            {
                try
                {
                    SelectedUser.User.IdSpecify = true;
                    SelectedUser.User.Pwd = "123456";
                    UserBusiness.Instance.UpdateUser(SelectedUser.User);                   

                    XtraMessageBox.Show("密码重置成功，默认为123456", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //if (SelectedUser.User.Id == SharedVariables.Instance.LoginUser.User.Id)
                    //{
                    //    SharedVariables.Instance.LoginUser.User.Pwd = SelectedUser.User.Pwd;
                    //}

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(string.Format("密码重置失败：\r\n{0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        List<UserShopRoleInfo> dataSource = new List<UserShopRoleInfo>();
        IList<UserShopRoleInfo> mDataSource
        {
            get
            {
                dataSource = dataSource ?? new List<UserShopRoleInfo>();

                return dataSource;
            }
            set
            {
                if (dataSource != null) dataSource.Clear();

                dataSource.AddRange(value);

                this.GridControlUserInfo.MainView.RefreshData();

                UserGridDefautlView.ExpandAllGroups();
            }
        }

        private void btnRefResh_ItemClick(object sender, ItemClickEventArgs args)
        {
            mDataSource = UserBusiness.Instance.GetUserShopRoleInfos();
        }

        private void FmUserView_Load(object sender, EventArgs e)
        {
            this.GridControlUserInfo.DataSource = mDataSource;

            if (BtnRefResh != null)
                BtnRefResh.PerformClick();
        }

        private void UserGridDefautlView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (UserGridDefautlView.SelectedRowsCount > 0)
            {
                //SelectedUser = UserGridDefautlView.GetRow(UserGridDefautlView.GetSelectedRows().First()) as UserShopRoleInfo;
                var selectUser = SelectedUser.User;
                var loginUser = ConfigManager.LoginUser; //SharedVariables.Instance.LoginUser.User;

                //btnResetPwd.Enabled = loginUser.RoleId == SharedVariables.AdminRoleId
                //    || (loginUser.RoleId == SharedVariables.PMRoleId &&
                //        selectUser.ShopId == loginUser.ShopId && loginUser.Id != selectUser.Id);

                //btnUpdate.Enabled=loginUser.RoleId == SharedVariables.AdminRoleId
                //    || (loginUser.RoleId == SharedVariables.PMRoleId &&
                //        selectUser.ShopId == loginUser.ShopId);

                //BtnAdd.Enabled = SelectedUser.User.RoleId == SharedVariables.AdminRoleId;
            }
        }

        public UserShopRoleInfo SelectedUser { get { return UserGridDefautlView.GetRow(UserGridDefautlView.GetSelectedRows().FirstOrDefault()) as UserShopRoleInfo; } }

        private void UserGridDefautlView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (UserGridDefautlView.SelectedRowsCount > 0)
            {
                //SelectedUser = UserGridDefautlView.GetRow(UserGridDefautlView.GetSelectedRows().First()) as UserShopRoleInfo;
                var selectUser = SelectedUser.User;
                var loginUser = ConfigManager.LoginUser; ;

                //btnResetPwd.Enabled = loginUser.RoleId == SharedVariables.AdminRoleId
                //    || (loginUser.RoleId == SharedVariables.PMRoleId &&
                //        selectUser.ShopId == loginUser.ShopId && loginUser.Id != selectUser.Id);

                //btnUpdate.Enabled = loginUser.RoleId == SharedVariables.AdminRoleId
                //    || (loginUser.RoleId == SharedVariables.PMRoleId &&
                //        selectUser.ShopId == loginUser.ShopId);

                //BtnAdd.Enabled = loginUser.RoleId == SharedVariables.AdminRoleId;
            }
        }
    }
}
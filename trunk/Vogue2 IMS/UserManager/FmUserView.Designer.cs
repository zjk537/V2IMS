namespace Vogue2_IMS.UserManager
{
    partial class FmUserView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GridControlUserInfo = new DevExpress.XtraGrid.GridControl();
            this.userShopRoleInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserGridDefautlView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRealName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userShopRoleInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridDefautlView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControlUserInfo
            // 
            this.GridControlUserInfo.DataSource = this.userShopRoleInfoBindingSource;
            this.GridControlUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlUserInfo.Location = new System.Drawing.Point(0, 0);
            this.GridControlUserInfo.MainView = this.UserGridDefautlView;
            this.GridControlUserInfo.Name = "GridControlUserInfo";
            this.GridControlUserInfo.Size = new System.Drawing.Size(708, 399);
            this.GridControlUserInfo.TabIndex = 0;
            this.GridControlUserInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UserGridDefautlView});
            // 
            // userShopRoleInfoBindingSource
            // 
            this.userShopRoleInfoBindingSource.DataSource = typeof(Vogue2_IMS.Business.BusinessModel.UserShopRoleInfo);
            // 
            // UserGridDefautlView
            // 
            this.UserGridDefautlView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShopName,
            this.colRoleName,
            this.colUserName,
            this.colRealName,
            this.colSex,
            this.colPhone});
            this.UserGridDefautlView.GridControl = this.GridControlUserInfo;
            this.UserGridDefautlView.Name = "UserGridDefautlView";
            this.UserGridDefautlView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.UserGridDefautlView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.UserGridDefautlView.OptionsBehavior.Editable = false;
            this.UserGridDefautlView.OptionsBehavior.ReadOnly = true;
            this.UserGridDefautlView.OptionsMenu.EnableColumnMenu = false;
            this.UserGridDefautlView.OptionsMenu.EnableFooterMenu = false;
            this.UserGridDefautlView.OptionsMenu.EnableGroupPanelMenu = false;
            this.UserGridDefautlView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.UserGridDefautlView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.UserGridDefautlView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.UserGridDefautlView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.UserGridDefautlView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.UserGridDefautlView.OptionsView.EnableAppearanceEvenRow = true;
            this.UserGridDefautlView.OptionsView.ShowGroupPanel = false;
            this.UserGridDefautlView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.UserGridDefautlView_SelectionChanged);
            this.UserGridDefautlView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.UserGridDefautlView_FocusedRowChanged);
            // 
            // colShopName
            // 
            this.colShopName.Caption = "店铺";
            this.colShopName.FieldName = "OwnerShop.Name";
            this.colShopName.Name = "colShopName";
            this.colShopName.Visible = true;
            this.colShopName.VisibleIndex = 0;
            // 
            // colRoleName
            // 
            this.colRoleName.Caption = "角色";
            this.colRoleName.FieldName = "Role.Name";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Visible = true;
            this.colRoleName.VisibleIndex = 1;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "用户名";
            this.colUserName.FieldName = "User.Name";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            // 
            // colRealName
            // 
            this.colRealName.Caption = "真实性名";
            this.colRealName.FieldName = "User.RealName";
            this.colRealName.Name = "colRealName";
            this.colRealName.Visible = true;
            this.colRealName.VisibleIndex = 3;
            // 
            // colSex
            // 
            this.colSex.Caption = "性别";
            this.colSex.FieldName = "SexName";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 4;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "联系方式";
            this.colPhone.FieldName = "User.Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 5;
            // 
            // FmUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 399);
            this.Controls.Add(this.GridControlUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmUserView";
            this.Text = "FmUserVIew";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FmUserView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userShopRoleInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridDefautlView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlUserInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView UserGridDefautlView;
        private System.Windows.Forms.BindingSource userShopRoleInfoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colShopName;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn colRealName;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
    }
}
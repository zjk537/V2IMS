namespace Vogue2_IMS.UserManager
{
    partial class FmUserInfo
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
            this.ComboxShop = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ComboxRole = new DevExpress.XtraEditors.ComboBoxEdit();
            this.权限 = new DevExpress.XtraEditors.LabelControl();
            this.TxtRealName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.TxtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtLogUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtLogUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ComboxSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.TxtAgainPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxShop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRealName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgainPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboxShop
            // 
            this.ComboxShop.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.ComboxShop, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.ComboxShop.Location = new System.Drawing.Point(67, 30);
            this.ComboxShop.Name = "ComboxShop";
            this.ComboxShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxShop.Size = new System.Drawing.Size(166, 20);
            this.ComboxShop.TabIndex = 0;
            this.ComboxShop.SelectedIndexChanged += new System.EventHandler(this.ComboxEdit_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 999;
            this.labelControl1.Text = "所属店铺";
            // 
            // ComboxRole
            // 
            this.ComboxRole.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.ComboxRole, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.ComboxRole.Location = new System.Drawing.Point(67, 57);
            this.ComboxRole.Name = "ComboxRole";
            this.ComboxRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxRole.Size = new System.Drawing.Size(166, 20);
            this.ComboxRole.TabIndex = 1;
            this.ComboxRole.SelectedIndexChanged += new System.EventHandler(this.ComboxEdit_SelectedIndexChanged);
            // 
            // 权限
            // 
            this.权限.Location = new System.Drawing.Point(12, 59);
            this.权限.Name = "权限";
            this.权限.Size = new System.Drawing.Size(24, 13);
            this.权限.TabIndex = 1001;
            this.权限.Text = "职位";
            // 
            // TxtRealName
            // 
            this.TxtRealName.EditValue = "";
            this.TxtRealName.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtRealName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtRealName.Location = new System.Drawing.Point(67, 84);
            this.TxtRealName.Name = "TxtRealName";
            this.TxtRealName.Properties.NullValuePrompt = "默认为空";
            this.TxtRealName.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtRealName.Size = new System.Drawing.Size(166, 20);
            this.TxtRealName.TabIndex = 2;
            this.TxtRealName.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 87);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 13);
            this.labelControl5.TabIndex = 1003;
            this.labelControl5.Text = "真实姓名";
            // 
            // TxtPhone
            // 
            this.TxtPhone.EditValue = "";
            this.TxtPhone.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtPhone, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtPhone.Location = new System.Drawing.Point(67, 138);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Properties.NullValuePrompt = "默认为空";
            this.TxtPhone.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtPhone.Size = new System.Drawing.Size(166, 20);
            this.TxtPhone.TabIndex = 4;
            this.TxtPhone.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1005;
            this.labelControl2.Text = "联系方式";
            // 
            // TxtLogUserName
            // 
            this.TxtLogUserName.EditValue = "";
            this.TxtLogUserName.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtLogUserName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtLogUserName.Location = new System.Drawing.Point(69, 56);
            this.TxtLogUserName.Name = "TxtLogUserName";
            this.TxtLogUserName.Properties.NullValuePrompt = "默认为空";
            this.TxtLogUserName.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtLogUserName.Size = new System.Drawing.Size(166, 20);
            this.TxtLogUserName.TabIndex = 0;
            this.TxtLogUserName.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 1007;
            this.labelControl3.Text = "登录用户";
            // 
            // TxtLogUserPwd
            // 
            this.TxtLogUserPwd.EditValue = "";
            this.TxtLogUserPwd.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtLogUserPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtLogUserPwd.Location = new System.Drawing.Point(69, 83);
            this.TxtLogUserPwd.Name = "TxtLogUserPwd";
            this.TxtLogUserPwd.Properties.NullValuePrompt = "默认为空";
            this.TxtLogUserPwd.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtLogUserPwd.Properties.PasswordChar = '*';
            this.TxtLogUserPwd.Size = new System.Drawing.Size(166, 20);
            this.TxtLogUserPwd.TabIndex = 1;
            this.TxtLogUserPwd.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 1009;
            this.labelControl4.Text = "密码";
            // 
            // ComboxSex
            // 
            this.ComboxSex.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.ComboxSex, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.ComboxSex.Location = new System.Drawing.Point(67, 111);
            this.ComboxSex.Name = "ComboxSex";
            this.ComboxSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxSex.Size = new System.Drawing.Size(166, 20);
            this.ComboxSex.TabIndex = 3;
            this.ComboxSex.SelectedIndexChanged += new System.EventHandler(this.ComboxEdit_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 113);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 13);
            this.labelControl6.TabIndex = 1011;
            this.labelControl6.Text = "性别";
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // TxtAgainPwd
            // 
            this.TxtAgainPwd.EditValue = "";
            this.TxtAgainPwd.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtAgainPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtAgainPwd.Location = new System.Drawing.Point(69, 110);
            this.TxtAgainPwd.Name = "TxtAgainPwd";
            this.TxtAgainPwd.Properties.NullValuePrompt = "默认为空";
            this.TxtAgainPwd.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtAgainPwd.Properties.PasswordChar = '*';
            this.TxtAgainPwd.Size = new System.Drawing.Size(166, 20);
            this.TxtAgainPwd.TabIndex = 2;
            this.TxtAgainPwd.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 113);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 13);
            this.labelControl7.TabIndex = 1013;
            this.labelControl7.Text = "重复密码";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.ComboxShop);
            this.groupControl1.Controls.Add(this.权限);
            this.groupControl1.Controls.Add(this.ComboxSex);
            this.groupControl1.Controls.Add(this.ComboxRole);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.TxtRealName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.TxtPhone);
            this.groupControl1.Location = new System.Drawing.Point(9, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(244, 172);
            this.groupControl1.TabIndex = 1014;
            this.groupControl1.Text = "基本信息";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.TxtLogUserName);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.TxtAgainPwd);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.TxtLogUserPwd);
            this.groupControl2.Location = new System.Drawing.Point(260, 13);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(246, 171);
            this.groupControl2.TabIndex = 1015;
            this.groupControl2.Text = "登录信息";
            // 
            // FmUserInfo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 238);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MaximumSize = new System.Drawing.Size(532, 272);
            this.MinimumSize = new System.Drawing.Size(522, 264);
            this.Name = "FmUserInfo";
            this.Text = "用户信息";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ComboxShop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRealName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAgainPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit ComboxShop;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit ComboxRole;
        private DevExpress.XtraEditors.LabelControl 权限;
        private DevExpress.XtraEditors.TextEdit TxtRealName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit TxtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtLogUserName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtLogUserPwd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit ComboxSex;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
        private DevExpress.XtraEditors.TextEdit TxtAgainPwd;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}
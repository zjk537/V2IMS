using System.Drawing;
namespace Vogue2_IMS
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.TxtUserName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.TxtPwd = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtUserName
            // 
            this.mErrorProvider.SetIconAlignment(this.TxtUserName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            resources.ApplyResources(this.TxtUserName, "TxtUserName");
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("TxtUserName.Properties.Appearance.Font")));
            this.TxtUserName.Properties.Appearance.Options.UseFont = true;
            this.TxtUserName.Properties.NullValuePrompt = resources.GetString("TxtUserName.Properties.NullValuePrompt");
            this.TxtUserName.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TxtUserName.Properties.NullValuePromptShowForEmptyValue")));
            this.TxtUserName.StyleController = this.layoutControl2;
            this.TxtUserName.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.TxtPwd);
            this.layoutControl2.Controls.Add(this.btnCancel);
            this.layoutControl2.Controls.Add(this.TxtUserName);
            this.layoutControl2.Controls.Add(this.btnOK);
            this.layoutControl2.Controls.Add(this.pictureEdit2);
            resources.ApplyResources(this.layoutControl2, "layoutControl2");
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            // 
            // TxtPwd
            // 
            this.mErrorProvider.SetIconAlignment(this.TxtPwd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            resources.ApplyResources(this.TxtPwd, "TxtPwd");
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("TxtPwd.Properties.Appearance.Font")));
            this.TxtPwd.Properties.Appearance.Options.UseFont = true;
            this.TxtPwd.Properties.NullValuePrompt = resources.GetString("TxtPwd.Properties.NullValuePrompt");
            this.TxtPwd.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TxtPwd.Properties.NullValuePromptShowForEmptyValue")));
            this.TxtPwd.Properties.PasswordChar = '*';
            this.TxtPwd.StyleController = this.layoutControl2;
            this.TxtPwd.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.StyleController = this.layoutControl2;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnOK.Appearance.Font")));
            this.btnOK.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.StyleController = this.layoutControl2;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::Vogue2_IMS.Properties.Resources.login_V2;
            resources.ApplyResources(this.pictureEdit2, "pictureEdit2");
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pictureEdit2.Properties.Appearance.BackColor")));
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ReadOnly = true;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit2.StyleController = this.layoutControl2;
            // 
            // layoutControlGroup2
            // 
            resources.ApplyResources(this.layoutControlGroup2, "layoutControlGroup2");
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.layoutControlItem1,
            this.emptySpaceItem7,
            this.emptySpaceItem8,
            this.emptySpaceItem9,
            this.layoutControlItem5,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.emptySpaceItem12,
            this.emptySpaceItem13,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup1";
            this.layoutControlGroup2.Size = new System.Drawing.Size(477, 333);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(181, 198);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(263, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem1";
            this.emptySpaceItem3.Size = new System.Drawing.Size(457, 15);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureEdit2;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(11, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(160, 267);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem4, "emptySpaceItem4");
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 294);
            this.emptySpaceItem4.Name = "emptySpaceItem3";
            this.emptySpaceItem4.Size = new System.Drawing.Size(171, 19);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem5, "emptySpaceItem5");
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 27);
            this.emptySpaceItem5.Name = "emptySpaceItem4";
            this.emptySpaceItem5.Size = new System.Drawing.Size(11, 267);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem6, "emptySpaceItem6");
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 15);
            this.emptySpaceItem6.Name = "emptySpaceItem5";
            this.emptySpaceItem6.Size = new System.Drawing.Size(171, 12);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOK;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(263, 222);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(86, 29);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem7, "emptySpaceItem7");
            this.emptySpaceItem7.Location = new System.Drawing.Point(181, 157);
            this.emptySpaceItem7.Name = "emptySpaceItem6";
            this.emptySpaceItem7.Size = new System.Drawing.Size(263, 14);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem8, "emptySpaceItem8");
            this.emptySpaceItem8.Location = new System.Drawing.Point(181, 15);
            this.emptySpaceItem8.Name = "emptySpaceItem7";
            this.emptySpaceItem8.Size = new System.Drawing.Size(263, 115);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem9, "emptySpaceItem9");
            this.emptySpaceItem9.Location = new System.Drawing.Point(181, 251);
            this.emptySpaceItem9.Name = "emptySpaceItem8";
            this.emptySpaceItem9.Size = new System.Drawing.Size(276, 62);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCancel;
            resources.ApplyResources(this.layoutControlItem5, "layoutControlItem5");
            this.layoutControlItem5.Location = new System.Drawing.Point(364, 222);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 29);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem10, "emptySpaceItem10");
            this.emptySpaceItem10.Location = new System.Drawing.Point(181, 222);
            this.emptySpaceItem10.Name = "emptySpaceItem9";
            this.emptySpaceItem10.Size = new System.Drawing.Size(82, 29);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem11, "emptySpaceItem11");
            this.emptySpaceItem11.Location = new System.Drawing.Point(444, 15);
            this.emptySpaceItem11.Name = "emptySpaceItem10";
            this.emptySpaceItem11.Size = new System.Drawing.Size(13, 236);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem12, "emptySpaceItem12");
            this.emptySpaceItem12.Location = new System.Drawing.Point(349, 222);
            this.emptySpaceItem12.Name = "emptySpaceItem11";
            this.emptySpaceItem12.Size = new System.Drawing.Size(15, 29);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem13, "emptySpaceItem13");
            this.emptySpaceItem13.Location = new System.Drawing.Point(171, 15);
            this.emptySpaceItem13.Name = "emptySpaceItem12";
            this.emptySpaceItem13.Size = new System.Drawing.Size(10, 298);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlItem6.AppearanceItemCaption.Font")));
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = ((System.Drawing.Color)(resources.GetObject("layoutControlItem6.AppearanceItemCaption.ForeColor")));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.TxtUserName;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(181, 130);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(263, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(42, 17);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("layoutControlItem7.AppearanceItemCaption.Font")));
            this.layoutControlItem7.AppearanceItemCaption.ForeColor = ((System.Drawing.Color)(resources.GetObject("layoutControlItem7.AppearanceItemCaption.ForeColor")));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem7.Control = this.TxtPwd;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(181, 171);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(263, 27);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(42, 17);
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // panelControl1
            // 
            this.panelControl1.ContentImage = global::Vogue2_IMS.Properties.Resources.bg;
            this.panelControl1.Controls.Add(this.layoutControl2);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnOK;
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("FormLogin.Appearance.BackColor")));
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("FormLogin.Appearance.Font")));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TxtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtUserName;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
        private DevExpress.XtraEditors.TextEdit TxtPwd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
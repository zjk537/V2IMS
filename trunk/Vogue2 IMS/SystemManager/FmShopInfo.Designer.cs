namespace Vogue2_IMS.SystemManager
{
    partial class FmShopInfo
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
            this.TxtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.TxtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtName.Location = new System.Drawing.Point(44, 20);
            this.TxtName.Name = "TxtName";
            this.TxtName.Properties.NullValuePrompt = "<必填>";
            this.TxtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtName.Size = new System.Drawing.Size(206, 21);
            this.TxtName.TabIndex = 998;
            this.TxtName.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 21);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 999;
            this.labelControl7.Text = "名称";
            // 
            // TxtPhone
            // 
            this.TxtPhone.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtPhone, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtPhone.Location = new System.Drawing.Point(308, 20);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Properties.NullValuePrompt = "<必填>";
            this.TxtPhone.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtPhone.Size = new System.Drawing.Size(166, 21);
            this.TxtPhone.TabIndex = 1000;
            this.TxtPhone.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(278, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 1001;
            this.labelControl1.Text = "电话";
            // 
            // TxtAddress
            // 
            this.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAddress.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtAddress, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtAddress.Location = new System.Drawing.Point(44, 50);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Properties.NullValuePrompt = "<必填>";
            this.TxtAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtAddress.Size = new System.Drawing.Size(430, 21);
            this.TxtAddress.TabIndex = 1002;
            this.TxtAddress.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 1003;
            this.labelControl2.Text = "地址";
            // 
            // TxtDesc
            // 
            this.TxtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDesc.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtDesc, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.TxtDesc.Location = new System.Drawing.Point(44, 80);
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(430, 21);
            this.TxtDesc.TabIndex = 1006;
            this.TxtDesc.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 1007;
            this.labelControl3.Text = "描述";
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // FmShopInfo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 159);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtDesc);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.labelControl7);
            this.MaximumSize = new System.Drawing.Size(504, 195);
            this.MinimumSize = new System.Drawing.Size(504, 195);
            this.Name = "FmShopInfo";
            this.ShowInTaskbar = false;
            this.Text = "店铺信息";
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.TxtName, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.TxtPhone, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.TxtAddress, 0);
            this.Controls.SetChildIndex(this.TxtDesc, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit TxtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TxtDesc;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
    }
}
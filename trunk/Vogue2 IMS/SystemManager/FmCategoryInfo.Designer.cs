namespace Vogue2_IMS.SystemManager
{
    partial class FmCategoryInfo
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtDesc = new DevExpress.XtraEditors.TextEdit();
            this.TxtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 1015;
            this.labelControl3.Text = "描述";
            // 
            // TxtDesc
            // 
            this.TxtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDesc.EditValue = "";
            this.TxtDesc.Location = new System.Drawing.Point(44, 46);
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(236, 21);
            this.TxtDesc.TabIndex = 1014;
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtName.Location = new System.Drawing.Point(44, 19);
            this.TxtName.Name = "TxtName";
            this.TxtName.Properties.NullValuePrompt = "<必填>";
            this.TxtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtName.Size = new System.Drawing.Size(236, 21);
            this.TxtName.TabIndex = 1008;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 20);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 1009;
            this.labelControl7.Text = "名称";
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // FmCategoryInfo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 133);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TxtDesc);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.labelControl7);
            this.Name = "FmCategoryInfo";
            this.ShowInTaskbar = false;
            this.Text = "商品分类信息";
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.TxtName, 0);
            this.Controls.SetChildIndex(this.TxtDesc, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TxtDesc;
        private DevExpress.XtraEditors.TextEdit TxtName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
    }
}
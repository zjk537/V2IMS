namespace Vogue2_IMS.SystemManager
{
    partial class FmPayTypeInfo
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
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.TxtBankCharge = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCharge.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.EditValue = "";
            this.mErrorProvider.SetIconAlignment(this.TxtName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtName.Location = new System.Drawing.Point(70, 21);
            this.TxtName.Name = "TxtName";
            this.TxtName.Properties.NullValuePrompt = "<必填>";
            this.TxtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtName.Size = new System.Drawing.Size(189, 20);
            this.TxtName.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 24);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 13);
            this.labelControl7.TabIndex = 1011;
            this.labelControl7.Text = "类型名称";
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // TxtBankCharge
            // 
            this.TxtBankCharge.EnterMoveNextControl = true;
            this.mErrorProvider.SetIconAlignment(this.TxtBankCharge, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.TxtBankCharge.Location = new System.Drawing.Point(70, 56);
            this.TxtBankCharge.Name = "TxtBankCharge";
            this.TxtBankCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtBankCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtBankCharge.Properties.Mask.EditMask = "c";
            this.TxtBankCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtBankCharge.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TxtBankCharge.Properties.NullValuePrompt = "数字格式<必填>";
            this.TxtBankCharge.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtBankCharge.Size = new System.Drawing.Size(189, 20);
            this.TxtBankCharge.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 1012;
            this.labelControl1.Text = "手  续  费";
            // 
            // FmPayTypeInfo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 136);
            this.Controls.Add(this.TxtBankCharge);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.labelControl7);
            this.Name = "FmPayTypeInfo";
            this.Text = "结款类型信息";
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.TxtName, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.TxtBankCharge, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TxtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCharge.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtBankCharge;
    }
}
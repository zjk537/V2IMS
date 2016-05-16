namespace Vogue2_IMS.SupplierManager
{
    partial class FmFindSupplierByTel
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SupplierTelText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTelText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "手机号";
            // 
            // SupplierTelText
            // 
            this.SupplierTelText.Location = new System.Drawing.Point(61, 30);
            this.SupplierTelText.Name = "SupplierTelText";
            this.SupplierTelText.Size = new System.Drawing.Size(245, 21);
            this.SupplierTelText.TabIndex = 3;
            // 
            // FmFindSupplierByTel
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 121);
            this.Controls.Add(this.SupplierTelText);
            this.Controls.Add(this.labelControl1);
            this.MaximumSize = new System.Drawing.Size(338, 157);
            this.MinimumSize = new System.Drawing.Size(338, 157);
            this.Name = "FmFindSupplierByTel";
            this.ShowInTaskbar = false;
            this.Text = "查找供应商";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FmFindSupplierByTel_FormClosed);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.SupplierTelText, 0);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTelText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit SupplierTelText;
    }
}
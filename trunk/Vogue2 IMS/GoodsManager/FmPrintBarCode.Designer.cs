namespace Vogue2_IMS.GoodsManager
{
    partial class FmPrintBarCode
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
            this.progessBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.labTextNow = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progessBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progessBar
            // 
            this.progessBar.Location = new System.Drawing.Point(16, 29);
            this.progessBar.Name = "progessBar";
            this.progessBar.Size = new System.Drawing.Size(583, 31);
            this.progessBar.TabIndex = 1;
            this.progessBar.EditValueChanged += new System.EventHandler(this.progessBar_EditValueChanged);
            // 
            // labTextNow
            // 
            this.labTextNow.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.labTextNow.Location = new System.Drawing.Point(287, 66);
            this.labTextNow.Name = "labTextNow";
            this.labTextNow.Size = new System.Drawing.Size(35, 29);
            this.labTextNow.TabIndex = 2;
            this.labTextNow.Text = "0/0";
            this.labTextNow.Click += new System.EventHandler(this.labTextNow_Click);
            // 
            // FmPrintBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 107);
            this.Controls.Add(this.labTextNow);
            this.Controls.Add(this.progessBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(617, 135);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(617, 135);
            this.Name = "FmPrintBarCode";
            this.Text = "打印进度";
            ((System.ComponentModel.ISupportInitialize)(this.progessBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progessBar;
        private DevExpress.XtraEditors.LabelControl labTextNow;

    }
}
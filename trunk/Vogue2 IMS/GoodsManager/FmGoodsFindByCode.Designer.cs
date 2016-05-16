namespace Vogue2_IMS.GoodsManager
{
    partial class FmGoodsFindByCode
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
            this.GoodsCodeText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCodeText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GoodsCodeText
            // 
            this.GoodsCodeText.Location = new System.Drawing.Point(61, 32);
            this.GoodsCodeText.Name = "GoodsCodeText";
            this.GoodsCodeText.Size = new System.Drawing.Size(245, 20);
            this.GoodsCodeText.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 998;
            this.labelControl1.Text = "编号";
            // 
            // FmGoodsFindByCode
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 121);
            this.Controls.Add(this.GoodsCodeText);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(18, 27, 18, 27);
            this.MaximumSize = new System.Drawing.Size(338, 157);
            this.MinimumSize = new System.Drawing.Size(338, 155);
            this.Name = "FmGoodsFindByCode";
            this.Text = "查找商品";
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.GoodsCodeText, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsCodeText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit GoodsCodeText;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
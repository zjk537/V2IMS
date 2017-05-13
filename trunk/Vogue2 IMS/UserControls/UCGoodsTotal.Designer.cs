namespace Vogue2_IMS.UserControls
{
    partial class UCGoodsTotal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labDesc = new DevExpress.XtraEditors.LabelControl();
            this.labTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl2.Controls.Add(this.labDesc);
            this.panelControl2.Controls.Add(this.labTitle);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(123, 96);
            this.panelControl2.TabIndex = 3;
            // 
            // labDesc
            // 
            this.labDesc.Appearance.BackColor = System.Drawing.Color.White;
            this.labDesc.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labDesc.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labDesc.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labDesc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labDesc.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labDesc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDesc.LineVisible = true;
            this.labDesc.Location = new System.Drawing.Point(2, 65);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(119, 29);
            this.labDesc.TabIndex = 3;
            this.labDesc.Text = "待打款";
            // 
            // labTitle
            // 
            this.labTitle.AllowDrop = true;
            this.labTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTitle.LineColor = System.Drawing.SystemColors.Control;
            this.labTitle.Location = new System.Drawing.Point(2, 2);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(119, 63);
            this.labTitle.TabIndex = 2;
            this.labTitle.Text = "0";
            // 
            // UCGoodsTotal
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "UCGoodsTotal";
            this.Size = new System.Drawing.Size(123, 96);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labDesc;
        private DevExpress.XtraEditors.LabelControl labTitle;



    }
}

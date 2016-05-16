namespace Vogue2_IMS.GoodsManager
{
    partial class FmWarningMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmWarningMessageBox));
            this.labelUserName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.linkViewInfo = new DevExpress.XtraEditors.HyperLinkEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblEndDate = new DevExpress.XtraEditors.TextEdit();
            this.lblStartDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.linkViewInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.Location = new System.Drawing.Point(10, 11);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(43, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "嗨 {0}：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.Location = new System.Drawing.Point(10, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "系统中待打款的寄售商品统计如下：\r\n";
            // 
            // linkViewInfo
            // 
            this.linkViewInfo.EditValue = "【{0}】查看详情";
            this.linkViewInfo.Location = new System.Drawing.Point(67, 12);
            this.linkViewInfo.MinimumSize = new System.Drawing.Size(154, 21);
            this.linkViewInfo.Name = "linkViewInfo";
            this.linkViewInfo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.linkViewInfo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.linkViewInfo.Properties.Appearance.Options.UseBackColor = true;
            this.linkViewInfo.Properties.Appearance.Options.UseFont = true;
            this.linkViewInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.linkViewInfo.Size = new System.Drawing.Size(175, 21);
            this.linkViewInfo.StyleController = this.layoutControl1;
            this.linkViewInfo.TabIndex = 4;
            this.linkViewInfo.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.linkViewInfo_OpenLink);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lblEndDate);
            this.layoutControl1.Controls.Add(this.linkViewInfo);
            this.layoutControl1.Controls.Add(this.lblStartDate);
            this.layoutControl1.Location = new System.Drawing.Point(0, 58);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(254, 97);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblEndDate
            // 
            this.lblEndDate.EditValue = "";
            this.lblEndDate.Location = new System.Drawing.Point(67, 59);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Properties.AllowFocused = false;
            this.lblEndDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblEndDate.Properties.Appearance.Options.UseBackColor = true;
            this.lblEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblEndDate.Properties.ReadOnly = true;
            this.lblEndDate.Size = new System.Drawing.Size(175, 18);
            this.lblEndDate.StyleController = this.layoutControl1;
            this.lblEndDate.TabIndex = 5;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(67, 37);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Properties.AllowFocused = false;
            this.lblStartDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblStartDate.Properties.Appearance.Options.UseBackColor = true;
            this.lblStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblStartDate.Properties.ReadOnly = true;
            this.lblStartDate.Size = new System.Drawing.Size(175, 18);
            this.lblStartDate.StyleController = this.layoutControl1;
            this.lblStartDate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(254, 97);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblEndDate;
            this.layoutControlItem2.CustomizationFormText = "最近时间:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 47);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(234, 30);
            this.layoutControlItem2.Text = "最近时间:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblStartDate;
            this.layoutControlItem1.CustomizationFormText = "开始时间:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(234, 22);
            this.layoutControlItem1.Text = "最远时间:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.linkViewInfo;
            this.layoutControlItem3.CustomizationFormText = "统计个数";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(234, 25);
            this.layoutControlItem3.Text = "统计个数:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
            // 
            // FmWarningMessageBox
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 175);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmWarningMessageBox";
            this.ShowInTaskbar = false;
            this.Text = "提醒";
            ((System.ComponentModel.ISupportInitialize)(this.linkViewInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelUserName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.HyperLinkEdit linkViewInfo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit lblEndDate;
        private DevExpress.XtraEditors.TextEdit lblStartDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;




    }
}
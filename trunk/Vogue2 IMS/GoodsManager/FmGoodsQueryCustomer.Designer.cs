namespace Vogue2_IMS.GoodsManager
{
    partial class FmGoodsQueryCustomer
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
            this.DateStart = new DevExpress.XtraEditors.DateEdit();
            this.labStartDate = new DevExpress.XtraEditors.LabelControl();
            this.labEndDate = new DevExpress.XtraEditors.LabelControl();
            this.DateEnd = new DevExpress.XtraEditors.DateEdit();
            this.mErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // DateStart
            // 
            this.DateStart.EditValue = null;
            this.mErrorProvider.SetIconAlignment(this.DateStart, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.DateStart.Location = new System.Drawing.Point(68, 26);
            this.DateStart.Name = "DateStart";
            this.DateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateStart.Size = new System.Drawing.Size(229, 20);
            this.DateStart.TabIndex = 998;
            // 
            // labStartDate
            // 
            this.labStartDate.Location = new System.Drawing.Point(14, 29);
            this.labStartDate.Name = "labStartDate";
            this.labStartDate.Size = new System.Drawing.Size(48, 13);
            this.labStartDate.TabIndex = 999;
            this.labStartDate.Text = "开始时间";
            // 
            // labEndDate
            // 
            this.labEndDate.Location = new System.Drawing.Point(14, 67);
            this.labEndDate.Name = "labEndDate";
            this.labEndDate.Size = new System.Drawing.Size(48, 13);
            this.labEndDate.TabIndex = 1001;
            this.labEndDate.Text = "结束时间";
            // 
            // DateEnd
            // 
            this.DateEnd.EditValue = null;
            this.mErrorProvider.SetIconAlignment(this.DateEnd, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.DateEnd.Location = new System.Drawing.Point(68, 64);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateEnd.Size = new System.Drawing.Size(229, 20);
            this.DateEnd.TabIndex = 1000;
            // 
            // mErrorProvider
            // 
            this.mErrorProvider.ContainerControl = this;
            // 
            // FmGoodsQueryCustomer
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 156);
            this.Controls.Add(this.labEndDate);
            this.Controls.Add(this.DateEnd);
            this.Controls.Add(this.labStartDate);
            this.Controls.Add(this.DateStart);
            this.Name = "FmGoodsQueryCustomer";
            this.Text = "自定义时间段";
            this.Controls.SetChildIndex(this.DateStart, 0);
            this.Controls.SetChildIndex(this.labStartDate, 0);
            this.Controls.SetChildIndex(this.DateEnd, 0);
            this.Controls.SetChildIndex(this.labEndDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit DateStart;
        private DevExpress.XtraEditors.LabelControl labStartDate;
        private DevExpress.XtraEditors.LabelControl labEndDate;
        private DevExpress.XtraEditors.DateEdit DateEnd;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider mErrorProvider;
    }
}
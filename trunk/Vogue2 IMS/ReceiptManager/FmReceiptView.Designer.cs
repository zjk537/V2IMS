namespace Vogue2_IMS.ReceiptManager
{
    partial class FmReceiptView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmReceiptView));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.PurchaseJsGoodsOrderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.SaledGoodsOrderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseJhGoodsOrderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseJsGoodsOrderInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaledGoodsOrderInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseJhGoodsOrderInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutGroupCaption.Image")));
            this.layoutControl1.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutItem.GradientMode")));
            this.layoutControl1.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("layoutControl1.Appearance.DisabledLayoutItem.Image")));
            this.layoutControl1.Controls.Add(this.reportViewer1);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // reportViewer1
            // 
            resources.ApplyResources(this.reportViewer1, "reportViewer1");
            reportDataSource1.Name = "GoodsJsSource";
            reportDataSource1.Value = this.PurchaseJsGoodsOrderInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Vogue2_IMS.ReceiptManager.JsReceipt.rdlc";
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlGroup1.Size = new System.Drawing.Size(814, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // PurchaseJsGoodsOrderInfoBindingSource
            // 
            this.PurchaseJsGoodsOrderInfoBindingSource.DataSource = typeof(Vogue2_IMS.Business.BusinessModel.PurchaseJsGoodsOrderInfo);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.reportViewer1;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(802, 422);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // SaledGoodsOrderInfoBindingSource
            // 
            this.SaledGoodsOrderInfoBindingSource.DataSource = typeof(Vogue2_IMS.Business.BusinessModel.SaledGoodsOrderInfo);
            // 
            // PurchaseJhGoodsOrderInfoBindingSource
            // 
            this.PurchaseJhGoodsOrderInfoBindingSource.DataSource = typeof(Vogue2_IMS.Business.BusinessModel.PurchaseJhGoodsOrderInfo);
            // 
            // FmReceiptView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FmReceiptView";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ReceiptView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseJsGoodsOrderInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaledGoodsOrderInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseJhGoodsOrderInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource PurchaseJsGoodsOrderInfoBindingSource;
        private System.Windows.Forms.BindingSource SaledGoodsOrderInfoBindingSource;
        private System.Windows.Forms.BindingSource PurchaseJhGoodsOrderInfoBindingSource;

    }
}
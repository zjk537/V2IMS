namespace Vogue2_IMS.Common.FormBase
{
    partial class NavBarFormBase
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
            this.functionTypeGroupContainer = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.functionTypeGroupContainer)).BeginInit();
            this.functionTypeGroupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // functionTypeGroupContainer
            // 
            this.functionTypeGroupContainer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.functionTypeGroupContainer.Appearance.Options.UseBackColor = true;
            this.functionTypeGroupContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.functionTypeGroupContainer.Controls.Add(this.navBarControl);
            this.functionTypeGroupContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.functionTypeGroupContainer.Location = new System.Drawing.Point(0, 0);
            this.functionTypeGroupContainer.Name = "functionTypeGroupContainer";
            this.functionTypeGroupContainer.Size = new System.Drawing.Size(193, 421);
            this.functionTypeGroupContainer.TabIndex = 3;
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.navBarGroup1;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 193;
            this.navBarControl.Size = new System.Drawing.Size(193, 421);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(193, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(498, 421);
            this.panelControl1.TabIndex = 4;
            // 
            // NavBarFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 421);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.functionTypeGroupContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NavBarFormBase";
            this.Text = "FmSystemConfigView";
            ((System.ComponentModel.ISupportInitialize)(this.functionTypeGroupContainer)).EndInit();
            this.functionTypeGroupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl functionTypeGroupContainer;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraNavBar.NavBarControl navBarControl;
        public DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
    }
}
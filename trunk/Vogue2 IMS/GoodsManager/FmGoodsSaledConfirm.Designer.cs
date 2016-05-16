namespace Vogue2_IMS.GoodsManager
{
    partial class FmGoodsSaledConfirm
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
            this.labStartDate = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalPrice = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ComboxPayType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.TxtBankCharge = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxPayType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCharge.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labStartDate
            // 
            this.labStartDate.Location = new System.Drawing.Point(40, 33);
            this.labStartDate.Name = "labStartDate";
            this.labStartDate.Size = new System.Drawing.Size(60, 13);
            this.labStartDate.TabIndex = 1000;
            this.labStartDate.Text = "合计金额：";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(106, 28);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(50, 19);
            this.lblTotalPrice.TabIndex = 1001;
            this.lblTotalPrice.Text = "aaaaa";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 74);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 1002;
            this.labelControl1.Text = "付款方式：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(40, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 1003;
            this.labelControl2.Text = "手  续  费：";
            // 
            // ComboxPayType
            // 
            this.ComboxPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboxPayType.EnterMoveNextControl = true;
            this.ComboxPayType.Location = new System.Drawing.Point(106, 71);
            this.ComboxPayType.Name = "ComboxPayType";
            this.ComboxPayType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxPayType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ComboxPayType.Size = new System.Drawing.Size(166, 20);
            this.ComboxPayType.TabIndex = 1033;
            this.ComboxPayType.SelectedIndexChanged += new System.EventHandler(this.ComboxPayType_SelectedIndexChanged);
            // 
            // TxtBankCharge
            // 
            this.TxtBankCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtBankCharge.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TxtBankCharge.EnterMoveNextControl = true;
            this.TxtBankCharge.Location = new System.Drawing.Point(106, 112);
            this.TxtBankCharge.Name = "TxtBankCharge";
            this.TxtBankCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtBankCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TxtBankCharge.Properties.Mask.EditMask = "c";
            this.TxtBankCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtBankCharge.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TxtBankCharge.Properties.MaxLength = 9;
            this.TxtBankCharge.Properties.NullValuePrompt = "数字格式";
            this.TxtBankCharge.Properties.NullValuePromptShowForEmptyValue = true;
            this.TxtBankCharge.Size = new System.Drawing.Size(166, 20);
            this.TxtBankCharge.TabIndex = 1034;
            // 
            // FmGoodsSaledConfirm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 219);
            this.Controls.Add(this.TxtBankCharge);
            this.Controls.Add(this.ComboxPayType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.labStartDate);
            this.Name = "FmGoodsSaledConfirm";
            this.Text = "出售确认";
            this.Controls.SetChildIndex(this.labStartDate, 0);
            this.Controls.SetChildIndex(this.lblTotalPrice, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.ComboxPayType, 0);
            this.Controls.SetChildIndex(this.TxtBankCharge, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ComboxPayType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBankCharge.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labStartDate;
        private DevExpress.XtraEditors.LabelControl lblTotalPrice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit ComboxPayType;
        private DevExpress.XtraEditors.TextEdit TxtBankCharge;
    }
}
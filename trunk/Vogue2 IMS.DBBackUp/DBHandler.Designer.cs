namespace Vogue2_IMS.DBBackUp
{
    partial class DBHandler
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_BackUpDB = new System.Windows.Forms.Button();
            this.btn_RestoreDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BackUpDB
            // 
            this.btn_BackUpDB.Location = new System.Drawing.Point(25, 35);
            this.btn_BackUpDB.MaximumSize = new System.Drawing.Size(95, 37);
            this.btn_BackUpDB.MinimumSize = new System.Drawing.Size(95, 37);
            this.btn_BackUpDB.Name = "btn_BackUpDB";
            this.btn_BackUpDB.Size = new System.Drawing.Size(95, 37);
            this.btn_BackUpDB.TabIndex = 0;
            this.btn_BackUpDB.Text = "备份数据库";
            this.btn_BackUpDB.UseVisualStyleBackColor = true;
            this.btn_BackUpDB.Click += new System.EventHandler(this.btn_BackUpDB_Click);
            // 
            // btn_RestoreDb
            // 
            this.btn_RestoreDb.Location = new System.Drawing.Point(140, 35);
            this.btn_RestoreDb.Name = "btn_RestoreDb";
            this.btn_RestoreDb.Size = new System.Drawing.Size(95, 37);
            this.btn_RestoreDb.TabIndex = 1;
            this.btn_RestoreDb.Text = "还原数据库";
            this.btn_RestoreDb.UseVisualStyleBackColor = true;
            this.btn_RestoreDb.Click += new System.EventHandler(this.btn_RestoreDb_Click);
            // 
            // DBHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 107);
            this.Controls.Add(this.btn_RestoreDb);
            this.Controls.Add(this.btn_BackUpDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(268, 133);
            this.MinimumSize = new System.Drawing.Size(268, 133);
            this.Name = "DBHandler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vogue2 IMS 数据库备份还原工作";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BackUpDB;
        private System.Windows.Forms.Button btn_RestoreDb;
    }
}


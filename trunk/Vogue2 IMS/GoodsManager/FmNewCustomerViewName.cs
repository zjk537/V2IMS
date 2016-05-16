using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using DevExpress.XtraEditors.DXErrorProvider;
using System.IO;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmNewCustomerViewName : FormSimpleDialogBase
    {
        private CustomerViewLayout newCustomerView;

        public FmNewCustomerViewName(string viewName = "")
        {
            InitializeComponent();

            Btn_OK.Click += new EventHandler(Btn_OK_Click);
        }

        public FmNewCustomerViewName(CustomerViewLayout newCustomerView)
        {
            InitializeComponent();

            Btn_OK.Click += new EventHandler(Btn_OK_Click);
            // TODO: Complete member initialization
            this.newCustomerView = newCustomerView;
        }

        public string NewName
        {
            get { return textEdit1.Text.Trim(); }
        }

        public void Btn_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text.Trim()))
            {
                dxErrorProvider1.SetError(textEdit1, "名称不能为空", ErrorType.Critical);
            }
            else
            {
                newCustomerView.ViewName = textEdit1.Text.Trim();

                if (File.Exists(newCustomerView.FilePath))
                {
                    if (XtraMessageBox.Show("名称已存在，是否替换？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) 
                        == DialogResult.No)
                    {
                        dxErrorProvider1.SetError(textEdit1, "名称已存在", ErrorType.Critical);
                    }
                }
            }

            if (!dxErrorProvider1.HasErrors)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
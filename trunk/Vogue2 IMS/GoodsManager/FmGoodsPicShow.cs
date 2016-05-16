using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsPicShow : FormSimpleDialogBase
    {
        public FmGoodsPicShow(byte[] imageBytes)
        {
            InitializeComponent();

            this.pictureEdit1.EditValue = imageBytes;

            BtnContainer.Visible = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsFindByCode : Common.FormBase.FormSimpleDialogBase
    {
        private PurchaseGoodsInfo mGoodsInfoCondition = new PurchaseGoodsInfo();
        private List<GoodsInfo> mGoodses = null;
        public List<GoodsInfo> Goodses
        {
            get { return mGoodses; }
            private set { mGoodses = value; }
        }


        public FmGoodsFindByCode()
        {
            InitializeComponent();
            this.Btn_OK.Click += this.btnOk_Click;
            this.GoodsCodeText.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string goodsCode = this.GoodsCodeText.Text.Trim();
                if(string.IsNullOrEmpty(goodsCode))
                {
                    return;
                }
                GoodsInfo info = new GoodsInfo() { 
                    Code = goodsCode
                };
                mGoodses = GoodsBusiness.Instance.GetGoodsInfos(info);
                if (mGoodses != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (MessageBox.Show(string.Format("编号为：【{0}】的商品不存在\r\n重新输入点击Yes，取消点击 No"
                        , GoodsCodeText.Text.Trim()), "提示"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void FmGoodsFindByCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
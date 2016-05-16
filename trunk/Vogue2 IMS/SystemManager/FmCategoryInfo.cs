using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using System;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Business;
using System.Windows.Forms;

namespace Vogue2_IMS.SystemManager
{
    public partial class FmCategoryInfo : FormSimpleDialogBase
    {
        CategoryInfo mCategoryInfo;
        CategoryInfo mNewCategoryInfo = new Model.DataModel.CategoryInfo();
        private bool IsCreateNew { get { return mCategoryInfo == null; } }

        public CategoryInfo CategoryInfo { get { return mNewCategoryInfo; } }

        public FmCategoryInfo(CategoryInfo categoryInfo = null)
        {
            InitializeComponent();
            InitializeControls(categoryInfo);
        }

        void InitializeControls(CategoryInfo oldModel = null)
        {
            if (oldModel != null)
            {
                DBModelBase.Clone<CategoryInfo>(oldModel, ref mNewCategoryInfo);
                mCategoryInfo = oldModel;
            }

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            this.Text = mCategoryInfo == null ? "商品分类-添加" : "商品分类-编辑";
            this.Btn_OK.Click += btnOk_Click;

            TxtName.DataBindings.Add("Text", mNewCategoryInfo, "Name");//mNewCategoryInfo.Name
            TxtDesc.DataBindings.Add("Text", mNewCategoryInfo, "Desc"); //mNewCategoryInfo.Desc;
        }

        private bool Validation()
        {
            mErrorProvider.ClearErrors();

            if (string.IsNullOrEmpty(this.TxtName.Text.Trim()))
            {
                mErrorProvider.SetError(this.TxtName, "不能为空", ErrorType.Warning);
            }

            return !mErrorProvider.HasErrors;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation()) return;

                if (!mNewCategoryInfo.Equals(mCategoryInfo))
                {
                    if (IsCreateNew)
                        CategoryBusiness.Instance.AddCategory(mNewCategoryInfo);
                    else
                    {
                        mNewCategoryInfo.Id = mCategoryInfo.Id;
                        CategoryBusiness.Instance.UpdateCategory(mNewCategoryInfo);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("商品分类无更新，继续编辑请点击Y退出点击N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("保存失败,请联系管理员，信息如下：\r\n{0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;
using DevExpress.XtraEditors;
using Vogue2_IMS.ReceiptManager;

namespace Vogue2_IMS.OrderManager
{
    public partial class FmGoodsAdd : RibbonFormSimpleDialogBase
    {
        SourceType mRKType;

        #region Property

        SupplierInfo mSupplier = new SupplierInfo();
        public ColumnView MainView
        {
            get { return GridViewGoodsInfo.MainView as ColumnView; }
            private set
            {
                GridViewGoodsInfo.MainView = value;
                LoadCusomterLayout();
            }
        }

        List<PurchaseGoodsInfo> _ListGoods = new List<PurchaseGoodsInfo>();
        public List<PurchaseGoodsInfo> mListGoods
        {
            get { return _ListGoods; }
            set
            {
                _ListGoods = value;
            }
        }

        #endregion

        public FmGoodsAdd(SourceType rkType)
            : base(Common.Language.Chinese)
        {
            InitializeComponent();

            btnPrint.PerformClick();

            InitializeComponentExtend(rkType);

            //_ListGoods.CollectionChanged += new System.ComponentModel.CollectionChangeEventHandler(_ListGoods_CollectionChanged);          
        }

        private void InitializeComponentExtend(SourceType rkType)
        {
            mRKType = rkType;
            this.GridViewGoodsInfo.DataSource = mListGoods;

            #region UI Format

            this.Text = SharedVariables.SourceTypeRKCNNames[rkType];// "寄售入库";
            btnFindSupplier.Caption = string.Format("查找{0}", SharedVariables.SupplierCNNames[rkType]);
            labelCustomer.Text = SharedVariables.SupplierCNNames[rkType];
            btnAdd.LargeImageIndex = SharedVariables.SupplierIconIndexs[rkType];

            btnSave.Enabled = SharedVariables.Instance.LoginUser.User.RoleId != SharedVariables.AdminRoleId;
            SetDefaultMainView();

            #endregion

            #region SupplierSexCmbox Items Bind

            SupplierSexCmbox.Properties.Items.Add("未知");
            SupplierSexCmbox.Properties.Items.Add("男");
            SupplierSexCmbox.Properties.Items.Add("女");
            SupplierSexCmbox.Properties.AllowNullInput = DefaultBoolean.False;

            #endregion

            SupplierControlDataBind();
        }

        private void SupplierControlDataBind(bool isRefresh = false)
        {
            if (!isRefresh)
            {
                SupplierBankCardTxt.DataBindings.Add("Text", mSupplier, "BankCard");
                SupplierBankTxt.DataBindings.Add("Text", mSupplier, "BankName");
                SupplierAddressTxt.DataBindings.Add("Text", mSupplier, "Address");
                SupplierIdCardTxt.DataBindings.Add("Text", mSupplier, "IdCard");
                SupplierNameTxt.DataBindings.Add("Text", mSupplier, "Name");
                SupplierTelTxt.DataBindings.Add("Text", mSupplier, "Phone");
                //SupplierSexCmbox.DataBindings.Add("SelectedIndex", mSupplier, "Sex.Value");

                SupplierSexCmbox.SelectedIndex = mSupplier.Sex ?? 0;
            }
            else
            {
                SupplierBankCardTxt.DataBindings.Clear();
                SupplierBankTxt.DataBindings.Clear();
                SupplierAddressTxt.DataBindings.Clear();
                SupplierIdCardTxt.DataBindings.Clear();
                SupplierNameTxt.DataBindings.Clear();
                SupplierTelTxt.DataBindings.Clear();
                SupplierSexCmbox.DataBindings.Clear();

                SupplierControlDataBind();
            }
        }

        private bool Validation()
        {
            mErrorProvider.ClearErrors();
            //double validationTryDouble = 0;
            if (string.IsNullOrEmpty(this.SupplierNameTxt.Text))
            {
                mErrorProvider.SetError(this.SupplierNameTxt, "供应商名称不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.SupplierTelTxt.Text))
            {
                mErrorProvider.SetError(this.SupplierTelTxt, "联系方式不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.SupplierBankTxt.Text))
            {
                mErrorProvider.SetError(this.SupplierBankTxt, "开户行不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.SupplierBankCardTxt.Text))
            {
                mErrorProvider.SetError(this.SupplierBankCardTxt, "银行卡号不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.SupplierIdCardTxt.Text))
            {
                mErrorProvider.SetError(this.SupplierIdCardTxt, "证件号码不能为空", ErrorType.Warning);
            }

            if (SupplierSexCmbox.SelectedIndex < 0)
            {
                SupplierSexCmbox.SelectedIndex = 0;
            }

            mSupplier.Sex = SupplierSexCmbox.SelectedIndex;
            //性别默认：未知          
            //通讯地址默认：未知

            return mErrorProvider.HasErrors;
        }

        #region Layout

        private string DefaultLayoutFile
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("DefaultLayout.{0}.{1}.{2}.xml", this.Name, MainView.Name, mRKType.ToString()));
            }
        }

        private string CustomerLayoutFile
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("CustomerLayout.{0}.{1}.{2}.xml", this.Name, this.MainView.Name, mRKType.ToString()));
            }
        }

        public void SaveLayout(bool saveDefault = false)
        {
            var layoutFile = saveDefault ? DefaultLayoutFile : CustomerLayoutFile;

            if (File.Exists(layoutFile))
            {
                File.Delete(layoutFile);
            }

            this.MainView.SaveLayoutToXml(layoutFile, OptionsLayoutBase.FullLayout);
        }

        public void RestoreLayout()
        {
            if (MainView != null)
            {
                if (!File.Exists(DefaultLayoutFile))
                {
                    var tempThis = new FmGoodsAdd(mRKType);

                    foreach (ColumnView cv in tempThis.GridViewGoodsInfo.Views)
                    {
                        if (cv.Name.Equals(MainView.Name))
                        {
                            tempThis.MainView = cv;
                        }
                    }
                    tempThis.SaveLayout(true);
                }

                MainView.RestoreLayoutFromXml(DefaultLayoutFile, OptionsLayoutBase.FullLayout);

                File.Delete(CustomerLayoutFile);
            }
        }

        private void LoadCusomterLayout()
        {
            if (File.Exists(CustomerLayoutFile))
            {
                MainView.RestoreLayoutFromXml(CustomerLayoutFile, OptionsLayoutBase.FullLayout);
            }
        }

        #endregion

        #region Default View

        string DefaultViewPath { get { return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("DefaultMainViewSet.{0}.config", this.Name)); } }

        public void SaveDefaultMainViewName()
        {
            File.Delete(DefaultViewPath);
            File.AppendAllText(DefaultViewPath, MainView.Name);
        }

        private void SetDefaultMainView()
        {
            if (File.Exists(DefaultViewPath))
            {
                var viewName = File.ReadAllText(DefaultViewPath);
                foreach (ColumnView cv in GridViewGoodsInfo.Views)
                {
                    if (cv.Name.Equals(viewName))
                    {
                        MainView = cv;
                        return;
                    }
                }
            }

            MainView = GridDefaultView;
        }

        #endregion

        #region Event

        void ListGoods_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            decimal purchaseSum = 0;
            decimal markSum = 0;
            var tempList = sender as List<PurchaseGoodsInfo>;
            if (tempList != null)
            {
                tempList.ForEach(purGoods =>
                {
                    if (purGoods != null)
                    {
                        purchaseSum += purGoods.Goods.PrimePrice.HasValue ? purGoods.Goods.PrimePrice.Value : 0;
                        markSum += purGoods.Goods.MarkPrice.HasValue ? purGoods.Goods.MarkPrice.Value : 0;
                    }
                });
            }

            TxtPrimeSum.EditValue = purchaseSum;
            TxtMarkSum.EditValue = markSum;
        }

        private void barBtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnFindSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  SupplierInfo mSupplierCondition =
            // mSupplier = SupplierBusiness.Instance.GetSupplier(new SupplierInfo() { Phone = SupplierTelTxt.Text.Trim() });
            var phone = SupplierTelTxt.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                return;
            }
            var tempSupplier = SharedVariables.Instance.SupplierInfos.Find(supplier => { return supplier.Phone.Contains(phone); });
            if (tempSupplier != null)
            {
                this.mSupplier = tempSupplier;
                SupplierControlDataBind(true);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var tpSupplier = SharedVariables.Instance.SupplierInfos.Where(supplier => supplier.Phone == mSupplier.Phone).FirstOrDefault();
                if (tpSupplier != null && this.mSupplier.Id == 0)
                {
                    if (XtraMessageBox.Show(string.Format("手机号码【{0}】已被【{1}】占用，是否要修改该号码对应的用户信息？", tpSupplier.Phone, tpSupplier.Name),
                       "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                this.GridViewGoodsInfo.Focus();

                if (!Validation())
                {
                    if (mSupplier.IsUpdated())
                    {
                        if (mSupplier.Id == 0)
                        {
                            Business.SupplierBusiness.Instance.AddSupplier(mSupplier);
                        }
                        else
                        {
                            Business.SupplierBusiness.Instance.UpdateSupplier(mSupplier);
                        }
                    }
                    var tempSupplier = SharedVariables.Instance.SupplierInfos.Find(supplier => { return supplier.Phone == mSupplier.Phone; });
                    if (tempSupplier != null)
                    {
                        mListGoods.ForEach(goods => { goods.Supplier = new SupplierInfo() { Id = tempSupplier.Id }; });

                        var newGoodsList = Business.PurchaseGoodsBusiness.Instance.BatchAddPurchaseGoods(mListGoods);
                        if (saveWithPrint)
                        {
                            Print(newGoodsList);
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(String.Format("入库失败:\r\n{0}", ex.ToString()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print(List<PurchaseGoodsInfo> newGoodsList)
        {
            if (newGoodsList == null || newGoodsList.Count == 0) return;

            var totalPrice = newGoodsList.Sum(record => record.Goods.PrimePrice);
            var receiptView = new FmReceiptView();

            if (this.mRKType == SourceType.JinHuo)
            {
                List<PurchaseJhGoodsOrderInfo> jhOrderList = new List<PurchaseJhGoodsOrderInfo>();
                newGoodsList.ForEach(record =>
                {
                    jhOrderList.Add(new PurchaseJhGoodsOrderInfo(record, 1)
                    {
                        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                    });
                    jhOrderList.Add(new PurchaseJhGoodsOrderInfo(record, 2)
                    {
                        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                    });
                });
                receiptView.InitializeReceiptView<PurchaseJhGoodsOrderInfo>(jhOrderList);
            }
            else if (this.mRKType == SourceType.JiShou)
            {
                List<PurchaseJsGoodsOrderInfo> jsOrderList = new List<PurchaseJsGoodsOrderInfo>();
                newGoodsList.ForEach(record =>
                {
                    jsOrderList.Add(new PurchaseJsGoodsOrderInfo(record, 1)
                    {
                        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                    });
                    jsOrderList.Add(new PurchaseJsGoodsOrderInfo(record, 2)
                    {
                        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                    });
                });
                receiptView.InitializeReceiptView<PurchaseJsGoodsOrderInfo>(jsOrderList);
            }

            receiptView.ShowDialog();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainView.DeleteSelectedRows();

            ListGoods_CollectionChanged(_ListGoods, null);
        }

        private void GoodsView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.btnUpdate.Enabled = MainView.SelectedRowsCount > 0;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FmGoodsInfo fmGoodsInfo = new FmGoodsInfo(mRKType);
            if (fmGoodsInfo.ShowDialog() == DialogResult.OK)
            {
                var goodsInfo = fmGoodsInfo.PurchaseGoodsInfo;
                goodsInfo.Supplier = this.mSupplier;
                mListGoods.Add(goodsInfo);

                MainView.RefreshData();
                ListGoods_CollectionChanged(mListGoods, null);
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainView.SelectedRowsCount > 0)
            {
                var dataRowIndex = MainView.GetDataSourceRowIndex(MainView.GetSelectedRows()[0]);

                FmGoodsInfo goodsInfo = new FmGoodsInfo(mListGoods[dataRowIndex]);
                if (goodsInfo.ShowDialog() == DialogResult.OK)
                {
                    mListGoods[dataRowIndex] = goodsInfo.PurchaseGoodsInfo;
                    MainView.RefreshData();

                    ListGoods_CollectionChanged(mListGoods, null);
                }
            }
        }

        private void ComboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validation();

            if (sender == SupplierSexCmbox)
            {
                mSupplier.Sex = SupplierSexCmbox.SelectedIndex;
            }
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainView.SelectedRowsCount > 0)
            {
                var fromInfo = MainView.GetRow(MainView.GetSelectedRows()[0]) as PurchaseGoodsInfo;

                var newInfo = new PurchaseGoodsInfo();
                newInfo = fromInfo.Clone();

                newInfo.Goods.Name = string.Format("{0}(副本)", newInfo.Goods.Name);

                mListGoods.Add(newInfo);
                MainView.RefreshData();
                ListGoods_CollectionChanged(mListGoods, null);
            }

        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDefaultLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridViewGoodsInfo.MainView = GridDefaultView;
        }

        private void btnAdvBandedLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridViewGoodsInfo.MainView = GridAdvBandedView;
        }

        private void btnCardLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridViewGoodsInfo.MainView = GridLayoutView;
        }

        private void btnRestoreViewLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.RestoreLayout();
        }

        private void btnSaveViewLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveLayout();
        }

        private void btnSetMainView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveDefaultMainViewName();
        }

        #endregion

        bool saveWithPrint = false;
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveWithPrint = !saveWithPrint;
        }
    }
}
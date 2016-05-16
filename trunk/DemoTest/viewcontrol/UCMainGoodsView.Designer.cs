namespace Vogue2_IMS.ViewControls
{
    partial class UCMainGoodsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridViewControl = new DevExpress.XtraGrid.GridControl();
            this.viewMainGoodsInfosBindingSource = new System.Windows.Forms.BindingSource();
            this.gridDefaultView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGoodsOriginalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaledUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComboxSex = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colGoodsParts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ViewPrictureEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComboxGoodStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colGoodsDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsPrimePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsMarkPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaledPayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsDisCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsPrepay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOodsSaledDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaledOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierBankCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierIdCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridAdvBandedView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCardView = new DevExpress.XtraGrid.Views.Card.CardView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMainGoodsInfosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefaultView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPrictureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxGoodStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvBandedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCardView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewControl
            // 
            this.gridViewControl.DataSource = this.viewMainGoodsInfosBindingSource;
            this.gridViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewControl.Location = new System.Drawing.Point(0, 0);
            this.gridViewControl.MainView = this.gridDefaultView;
            this.gridViewControl.Name = "gridViewControl";
            this.gridViewControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ComboxGoodStatus,
            this.ComboxSex,
            this.ViewPrictureEdit});
            this.gridViewControl.Size = new System.Drawing.Size(880, 466);
            this.gridViewControl.TabIndex = 17;
            this.gridViewControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDefaultView,
            this.gridAdvBandedView,
            this.gridCardView});
            // 
            // viewMainGoodsInfosBindingSource
            // 
           // this.viewMainGoodsInfosBindingSource.DataSource = typeof(Vogue2_IMS.Business.ViewModel.ViewMainGoodsInfos);
            // 
            // gridDefaultView
            // 
            this.gridDefaultView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGoodsOriginalCode,
            this.colSourceName,
            this.colPurchaseUser,
            this.colSaledUser,
            this.colShopPhone,
            this.colShopAddress,
            this.colSupplierSex,
            this.colGoodsParts,
            this.colShop,
            this.colGoodsCode,
            this.colCategory,
            this.colGoodsImage,
            this.colGoodsName,
            this.colGoodsColor,
            this.colGoodsQuality,
            this.colGoodsStatus,
            this.colGoodsDesc,
            this.colPayType,
            this.colGoodsPrimePrice,
            this.colGoodsMarkPrice,
            this.colPurchaseOperator,
            this.colSaledPayType,
            this.colGoodsSalePrice,
            this.colGoodsDisCount,
            this.colGoodsPrepay,
            this.colGoodsCreateDate,
            this.colGOodsSaledDate,
            this.colGoodsLastUpdatedDate,
            this.colSaledOperator,
            this.colSupplierName,
            this.colSupplierPhone,
            this.colSupplierBankName,
            this.colSupplierBankCard,
            this.colSupplierIdCard});
            this.gridDefaultView.GridControl = this.gridViewControl;
            this.gridDefaultView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Goods.PrimePrice.Value", this.colGoodsPrimePrice, "")});
            this.gridDefaultView.Name = "gridDefaultView";
            this.gridDefaultView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridDefaultView.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridDefaultView.OptionsFilter.AllowMRUFilterList = false;
            this.gridDefaultView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gridDefaultView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridDefaultView.OptionsFind.AllowFindPanel = false;
            this.gridDefaultView.OptionsLayout.Columns.StoreLayout = false;
            this.gridDefaultView.OptionsPrint.PrintSelectedRowsOnly = true;
            this.gridDefaultView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDefaultView.OptionsSelection.MultiSelect = true;
            this.gridDefaultView.OptionsView.ColumnAutoWidth = false;
            // 
            // colGoodsOriginalCode
            // 
            this.colGoodsOriginalCode.Caption = "原厂编码";
            this.colGoodsOriginalCode.FieldName = "Goods.OriginalCode";
            this.colGoodsOriginalCode.Name = "colGoodsOriginalCode";
            // 
            // colSourceName
            // 
            this.colSourceName.Caption = "来源";
            this.colSourceName.FieldName = "SourceName";
            this.colSourceName.Name = "colSourceName";
            this.colSourceName.OptionsColumn.ReadOnly = true;
            // 
            // colPurchaseUser
            // 
            this.colPurchaseUser.Caption = "入库录入人";
            this.colPurchaseUser.FieldName = "PurchaseUser";
            this.colPurchaseUser.Name = "colPurchaseUser";
            this.colPurchaseUser.OptionsColumn.ReadOnly = true;
            // 
            // colSaledUser
            // 
            this.colSaledUser.Caption = "出库录入人";
            this.colSaledUser.FieldName = "SaledUser";
            this.colSaledUser.Name = "colSaledUser";
            this.colSaledUser.OptionsColumn.ReadOnly = true;
            // 
            // colShopPhone
            // 
            this.colShopPhone.Caption = "店铺通讯";
            this.colShopPhone.FieldName = "Shop.Phone";
            this.colShopPhone.Name = "colShopPhone";
            // 
            // colShopAddress
            // 
            this.colShopAddress.Caption = "店铺地址";
            this.colShopAddress.FieldName = "Shop.Address";
            this.colShopAddress.Name = "colShopAddress";
            // 
            // colSupplierSex
            // 
            this.colSupplierSex.Caption = "性别";
            this.colSupplierSex.ColumnEdit = this.ComboxSex;
            this.colSupplierSex.FieldName = "Supplier.Sex";
            this.colSupplierSex.Name = "colSupplierSex";
            // 
            // ComboxSex
            // 
            this.ComboxSex.AutoHeight = false;
            this.ComboxSex.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxSex.Items.AddRange(new object[] {
            "未知",
            "男",
            "女"});
            this.ComboxSex.Name = "ComboxSex";
            this.ComboxSex.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colGoodsParts
            // 
            this.colGoodsParts.Caption = "配件";
            this.colGoodsParts.FieldName = "Goods.Parts";
            this.colGoodsParts.Name = "colGoodsParts";
            // 
            // colShop
            // 
            this.colShop.Caption = "店铺";
            this.colShop.FieldName = "Shop.Name";
            this.colShop.Name = "colShop";
            this.colShop.OptionsColumn.ReadOnly = true;
            this.colShop.Visible = true;
            this.colShop.VisibleIndex = 0;
            // 
            // colGoodsCode
            // 
            this.colGoodsCode.Caption = "编码";
            this.colGoodsCode.FieldName = "Goods.Code";
            this.colGoodsCode.Name = "colGoodsCode";
            this.colGoodsCode.Visible = true;
            this.colGoodsCode.VisibleIndex = 1;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "类别";
            this.colCategory.FieldName = "Category.Name";
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.ReadOnly = true;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 2;
            // 
            // colGoodsImage
            // 
            this.colGoodsImage.Caption = "图片";
            this.colGoodsImage.ColumnEdit = this.ViewPrictureEdit;
            this.colGoodsImage.FieldName = "Goods.GoodsImageBytes";
            this.colGoodsImage.Name = "colGoodsImage";
            this.colGoodsImage.Visible = true;
            this.colGoodsImage.VisibleIndex = 3;
            // 
            // ViewPrictureEdit
            // 
            this.ViewPrictureEdit.Name = "ViewPrictureEdit";
            this.ViewPrictureEdit.NullText = "无可用图片";
            this.ViewPrictureEdit.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "名称";
            this.colGoodsName.FieldName = "Goods.Name";
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 4;
            // 
            // colGoodsColor
            // 
            this.colGoodsColor.Caption = "颜色";
            this.colGoodsColor.FieldName = "Goods.Color";
            this.colGoodsColor.Name = "colGoodsColor";
            this.colGoodsColor.Visible = true;
            this.colGoodsColor.VisibleIndex = 5;
            // 
            // colGoodsQuality
            // 
            this.colGoodsQuality.Caption = "成色";
            this.colGoodsQuality.FieldName = "Goods.Quality";
            this.colGoodsQuality.Name = "colGoodsQuality";
            this.colGoodsQuality.Visible = true;
            this.colGoodsQuality.VisibleIndex = 6;
            // 
            // colGoodsStatus
            // 
            this.colGoodsStatus.Caption = "状态";
            this.colGoodsStatus.ColumnEdit = this.ComboxGoodStatus;
            this.colGoodsStatus.FieldName = "Goods.Status";
            this.colGoodsStatus.Name = "colGoodsStatus";
            this.colGoodsStatus.Visible = true;
            this.colGoodsStatus.VisibleIndex = 7;
            // 
            // ComboxGoodStatus
            // 
            this.ComboxGoodStatus.AutoHeight = false;
            this.ComboxGoodStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboxGoodStatus.Items.AddRange(new object[] {
            "未知",
            "在库",
            "预定",
            "售出",
            "取回"});
            this.ComboxGoodStatus.Name = "ComboxGoodStatus";
            this.ComboxGoodStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colGoodsDesc
            // 
            this.colGoodsDesc.Caption = "描述";
            this.colGoodsDesc.FieldName = "Goods.Desc";
            this.colGoodsDesc.Name = "colGoodsDesc";
            this.colGoodsDesc.Visible = true;
            this.colGoodsDesc.VisibleIndex = 8;
            // 
            // colPayType
            // 
            this.colPayType.Caption = "付款类型";
            this.colPayType.FieldName = "PurchasePayType.PayName";
            this.colPayType.Name = "colPayType";
            this.colPayType.OptionsColumn.ReadOnly = true;
            this.colPayType.Visible = true;
            this.colPayType.VisibleIndex = 9;
            // 
            // colGoodsPrimePrice
            // 
            this.colGoodsPrimePrice.Caption = "进价";
            this.colGoodsPrimePrice.FieldName = "Goods.PrimePrice";
            this.colGoodsPrimePrice.Name = "colGoodsPrimePrice";
            this.colGoodsPrimePrice.Visible = true;
            this.colGoodsPrimePrice.VisibleIndex = 10;
            // 
            // colGoodsMarkPrice
            // 
            this.colGoodsMarkPrice.Caption = "标价";
            this.colGoodsMarkPrice.FieldName = "Goods.MarkPrice";
            this.colGoodsMarkPrice.Name = "colGoodsMarkPrice";
            this.colGoodsMarkPrice.Visible = true;
            this.colGoodsMarkPrice.VisibleIndex = 11;
            // 
            // colPurchaseOperator
            // 
            this.colPurchaseOperator.Caption = "进货经手人";
            this.colPurchaseOperator.FieldName = "PurchaseRecord.Operator";
            this.colPurchaseOperator.Name = "colPurchaseOperator";
            this.colPurchaseOperator.Visible = true;
            this.colPurchaseOperator.VisibleIndex = 12;
            // 
            // colSaledPayType
            // 
            this.colSaledPayType.Caption = "收款类型";
            this.colSaledPayType.FieldName = "SaledPayType.PayName";
            this.colSaledPayType.Name = "colSaledPayType";
            this.colSaledPayType.Visible = true;
            this.colSaledPayType.VisibleIndex = 13;
            // 
            // colGoodsSalePrice
            // 
            this.colGoodsSalePrice.Caption = "实售价";
            this.colGoodsSalePrice.FieldName = "Goods.SalePrice";
            this.colGoodsSalePrice.Name = "colGoodsSalePrice";
            this.colGoodsSalePrice.Visible = true;
            this.colGoodsSalePrice.VisibleIndex = 14;
            // 
            // colGoodsDisCount
            // 
            this.colGoodsDisCount.Caption = "折扣金额";
            this.colGoodsDisCount.FieldName = "Goods.Discount";
            this.colGoodsDisCount.Name = "colGoodsDisCount";
            this.colGoodsDisCount.Visible = true;
            this.colGoodsDisCount.VisibleIndex = 15;
            // 
            // colGoodsPrepay
            // 
            this.colGoodsPrepay.Caption = "预付款";
            this.colGoodsPrepay.FieldName = "Goods.Prepay";
            this.colGoodsPrepay.Name = "colGoodsPrepay";
            this.colGoodsPrepay.Visible = true;
            this.colGoodsPrepay.VisibleIndex = 16;
            // 
            // colGoodsCreateDate
            // 
            this.colGoodsCreateDate.Caption = "进货时间";
            this.colGoodsCreateDate.FieldName = "Goods.CreatedDate";
            this.colGoodsCreateDate.Name = "colGoodsCreateDate";
            this.colGoodsCreateDate.Visible = true;
            this.colGoodsCreateDate.VisibleIndex = 17;
            // 
            // colGOodsSaledDate
            // 
            this.colGOodsSaledDate.Caption = "售出时间";
            this.colGOodsSaledDate.FieldName = "Goods.SaledDate.Value";
            this.colGOodsSaledDate.Name = "colGOodsSaledDate";
            this.colGOodsSaledDate.Visible = true;
            this.colGOodsSaledDate.VisibleIndex = 18;
            // 
            // colGoodsLastUpdatedDate
            // 
            this.colGoodsLastUpdatedDate.Caption = "最近更新时间";
            this.colGoodsLastUpdatedDate.FieldName = "Goods.UpdatedDate.Value";
            this.colGoodsLastUpdatedDate.Name = "colGoodsLastUpdatedDate";
            this.colGoodsLastUpdatedDate.Visible = true;
            this.colGoodsLastUpdatedDate.VisibleIndex = 19;
            // 
            // colSaledOperator
            // 
            this.colSaledOperator.Caption = "售出经手人";
            this.colSaledOperator.FieldName = "SaledRecord.Operator";
            this.colSaledOperator.Name = "colSaledOperator";
            this.colSaledOperator.Visible = true;
            this.colSaledOperator.VisibleIndex = 20;
            // 
            // colSupplierName
            // 
            this.colSupplierName.Caption = "供应商";
            this.colSupplierName.FieldName = "Supplier.Name";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.Visible = true;
            this.colSupplierName.VisibleIndex = 21;
            // 
            // colSupplierPhone
            // 
            this.colSupplierPhone.Caption = "联系方式";
            this.colSupplierPhone.FieldName = "Supplier.Phone";
            this.colSupplierPhone.Name = "colSupplierPhone";
            this.colSupplierPhone.Visible = true;
            this.colSupplierPhone.VisibleIndex = 22;
            // 
            // colSupplierBankName
            // 
            this.colSupplierBankName.Caption = "开户行";
            this.colSupplierBankName.FieldName = "Supplier.BankName";
            this.colSupplierBankName.Name = "colSupplierBankName";
            this.colSupplierBankName.Visible = true;
            this.colSupplierBankName.VisibleIndex = 23;
            // 
            // colSupplierBankCard
            // 
            this.colSupplierBankCard.Caption = "卡号";
            this.colSupplierBankCard.FieldName = "Supplier.BankCard";
            this.colSupplierBankCard.Name = "colSupplierBankCard";
            this.colSupplierBankCard.Visible = true;
            this.colSupplierBankCard.VisibleIndex = 24;
            // 
            // colSupplierIdCard
            // 
            this.colSupplierIdCard.Caption = "证件号";
            this.colSupplierIdCard.FieldName = "Supplier.IdCard";
            this.colSupplierIdCard.Name = "colSupplierIdCard";
            this.colSupplierIdCard.Visible = true;
            this.colSupplierIdCard.VisibleIndex = 25;
            // 
            // gridAdvBandedView
            // 
            this.gridAdvBandedView.BandPanelRowHeight = 1;
            this.gridAdvBandedView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand5,
            this.gridBand1});
            this.gridAdvBandedView.GridControl = this.gridViewControl;
            this.gridAdvBandedView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "GoodsName", null, "")});
            this.gridAdvBandedView.Name = "gridAdvBandedView";
            this.gridAdvBandedView.OptionsPrint.PrintFooter = false;
            this.gridAdvBandedView.OptionsView.AllowHtmlDrawHeaders = true;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "详情";
            this.gridBand5.MinWidth = 20;
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 1126;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "图片";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 126;
            // 
            // gridCardView
            // 
            this.gridCardView.FocusedCardTopFieldIndex = 0;
            this.gridCardView.GridControl = this.gridViewControl;
            this.gridCardView.Name = "gridCardView";
            // 
            // UCMainGoodsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridViewControl);
            this.Name = "UCMainGoodsView";
            this.Size = new System.Drawing.Size(880, 466);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMainGoodsInfosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDefaultView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPrictureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboxGoodStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvBandedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCardView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridViewControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDefaultView;
        private DevExpress.XtraGrid.Columns.GridColumn colShop;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceName;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colPayType;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseUser;
        private DevExpress.XtraGrid.Columns.GridColumn colSaledUser;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsColor;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsOriginalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ComboxGoodStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsQuality;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsParts;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsMarkPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsPrimePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsPrepay;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsDisCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGOodsSaledDate;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colSaledOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colSaledPayType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ComboxSex;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridAdvBandedView;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Card.CardView gridCardView;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsImage;
        private System.Windows.Forms.BindingSource viewMainGoodsInfosBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit ViewPrictureEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierBankName;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierBankCard;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierIdCard;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierSex;
        private DevExpress.XtraGrid.Columns.GridColumn colShopPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colShopAddress;
    }
}

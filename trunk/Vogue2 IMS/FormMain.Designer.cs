using System.Drawing;
using DevExpress.XtraBars.Ribbon;
namespace Vogue2_IMS
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPageCategory2 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.rPageGoodsManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rPageGoodsGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnAddConsignmentGoods = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddBuyGoods = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaleGoods = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateGoods = new DevExpress.XtraBars.BarButtonItem();
            this.btnPayment = new DevExpress.XtraBars.BarButtonItem();
            this.btnRollBackGoods = new DevExpress.XtraBars.BarButtonItem();
            this.rPageViewGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnSystemViews = new DevExpress.XtraBars.BarSubItem();
            this.BtnQueryThisWeek = new DevExpress.XtraBars.BarButtonItem();
            this.BtnQueryThisMonth = new DevExpress.XtraBars.BarButtonItem();
            this.BtnQueryThisQuarter = new DevExpress.XtraBars.BarButtonItem();
            this.BtnQueryThisYear = new DevExpress.XtraBars.BarButtonItem();
            this.BtnQueryAll = new DevExpress.XtraBars.BarButtonItem();
            this.BtnQueryCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewRefrence = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerViewOption = new DevExpress.XtraBars.BarButtonGroup();
            this.btnSaveCustomView = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveNewCustomView = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetToDefaultView = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomViewDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewOptions = new DevExpress.XtraBars.BarButtonGroup();
            this.btnShowFindPanel = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowFilterRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowGroupPanel = new DevExpress.XtraBars.BarButtonItem();
            this.riggonPageGroupSum = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.TxtJHPrimiceSum = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TxtJHSaledSum = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TxtJSPrimiceSum = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TxtJSSaledSum = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnViewExport = new DevExpress.XtraBars.BarSubItem();
            this.BtnExportXls = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportMhtml = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarSubItem();
            this.BtnPrintView = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPrintJH = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPrintJS = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPrintXS = new DevExpress.XtraBars.BarButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnDefaultView = new DevExpress.XtraBars.BarButtonItem();
            this.btnFormatView = new DevExpress.XtraBars.BarButtonItem();
            this.btnCardView = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnAllViewAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnGoodsRefrence = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnViewLayout = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.rPageSystemConfig = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rPageGroupConfigManager = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnAddNewConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefreshConfigView = new DevExpress.XtraBars.BarButtonItem();
            this.rPageUserManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RPageGroupLoginUser = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BtnUserLoginName = new DevExpress.XtraBars.BarSubItem();
            this.btnUserUpdateSelf = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserUpdatePwd = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserLogout = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BtnUserAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnUserMondify = new DevExpress.XtraBars.BarButtonItem();
            this.BtnUserRestorePwd = new DevExpress.XtraBars.BarButtonItem();
            this.RPageGroupUserOther = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BtnUserViewRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ViewContainers = new DevExpress.XtraEditors.PanelControl();
            this.TxtLogInUserName = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.rPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPgroupDashboard = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnDasbhoard = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewContainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddConsignmentGoods,
            this.btnAddBuyGoods,
            this.btnSaleGoods,
            this.btnUpdateGoods,
            this.btnGoodsRefrence,
            this.btnViewLayout,
            this.btnViewRefrence,
            this.btnCardView,
            this.btnSystemViews,
            this.btnAllViewAll,
            this.btnViewExport,
            this.btnPrint,
            this.BtnPrintJH,
            this.BtnPrintView,
            this.btnDefaultView,
            this.btnFormatView,
            this.barButtonItem1,
            this.btnAddNewConfig,
            this.btnUpdateConfig,
            this.btnDeleteConfig,
            this.btnRefreshConfigView,
            this.BtnQueryThisWeek,
            this.BtnQueryThisMonth,
            this.BtnQueryThisQuarter,
            this.BtnQueryAll,
            this.BtnQueryCustomer,
            this.TxtJHPrimiceSum,
            this.TxtJHSaledSum,
            this.BtnQueryThisYear,
            this.BtnExportPdf,
            this.BtnExportHtml,
            this.BtnExportXlsx,
            this.BtnExportXls,
            this.BtnExportMhtml,
            this.BtnUserAdd,
            this.BtnUserMondify,
            this.BtnUserRestorePwd,
            this.TxtLogInUserName,
            this.barEditItem1,
            this.BtnUserLoginName,
            this.btnUserUpdateSelf,
            this.btnUserLogout,
            this.BtnUserViewRefresh,
            this.btnUserUpdatePwd,
            this.BtnPrintJS,
            this.BtnPrintXS,
            this.btnPayment,
            this.barButtonItem3,
            this.btnCustomerViewOption,
            this.btnSaveCustomView,
            this.btnSaveNewCustomView,
            this.btnSetToDefaultView,
            this.btnCustomViewDelete,
            this.btnViewOptions,
            this.btnShowFindPanel,
            this.btnShowFilterRow,
            this.btnShowGroupPanel,
            this.TxtJSPrimiceSum,
            this.TxtJSSaledSum,
            this.btnImport,
            this.btnRollBackGoods,
            this.btnDasbhoard});
            this.ribbon.MaxItemId = 182;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rPageHome,
            this.rPageUserManager,
            this.rPageGoodsManager,
            this.rPageSystemConfig});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemDateEdit3,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemTextEdit5,
            this.repositoryItemTextEdit6});
            this.ribbon.SelectedPage = this.rPageHome;
            resources.ApplyResources(this.ribbon, "ribbon");
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            resources.ApplyResources(this.ribbonPageCategory1, "ribbonPageCategory1");
            // 
            // ribbonPageCategory2
            // 
            this.ribbonPageCategory2.Name = "ribbonPageCategory2";
            resources.ApplyResources(this.ribbonPageCategory2, "ribbonPageCategory2");
            // 
            // rPageGoodsManager
            // 
            this.rPageGoodsManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rPageGoodsGroup,
            this.rPageViewGroup,
            this.riggonPageGroupSum,
            this.ribbonPageGroup1});
            this.rPageGoodsManager.Name = "rPageGoodsManager";
            resources.ApplyResources(this.rPageGoodsManager, "rPageGoodsManager");
            // 
            // rPageGoodsGroup
            // 
            this.rPageGoodsGroup.ItemLinks.Add(this.btnAddConsignmentGoods);
            this.rPageGoodsGroup.ItemLinks.Add(this.btnAddBuyGoods);
            this.rPageGoodsGroup.ItemLinks.Add(this.btnSaleGoods);
            this.rPageGoodsGroup.ItemLinks.Add(this.btnUpdateGoods, true);
            this.rPageGoodsGroup.ItemLinks.Add(this.btnPayment);
            this.rPageGoodsGroup.ItemLinks.Add(this.btnRollBackGoods);
            this.rPageGoodsGroup.Name = "rPageGoodsGroup";
            this.rPageGoodsGroup.ShowCaptionButton = false;
            resources.ApplyResources(this.rPageGoodsGroup, "rPageGoodsGroup");
            // 
            // btnAddConsignmentGoods
            // 
            resources.ApplyResources(this.btnAddConsignmentGoods, "btnAddConsignmentGoods");
            this.btnAddConsignmentGoods.Id = 3;
            this.btnAddConsignmentGoods.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAddConsignmentGoods.LargeImageIndex = 26;
            this.btnAddConsignmentGoods.Name = "btnAddConsignmentGoods";
            this.btnAddConsignmentGoods.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddConsignmentGoods.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJS_ItemClick);
            // 
            // btnAddBuyGoods
            // 
            resources.ApplyResources(this.btnAddBuyGoods, "btnAddBuyGoods");
            this.btnAddBuyGoods.Id = 4;
            this.btnAddBuyGoods.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N));
            this.btnAddBuyGoods.LargeImageIndex = 24;
            this.btnAddBuyGoods.Name = "btnAddBuyGoods";
            this.btnAddBuyGoods.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddBuyGoods.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJH_ItemClick);
            // 
            // btnSaleGoods
            // 
            resources.ApplyResources(this.btnSaleGoods, "btnSaleGoods");
            this.btnSaleGoods.Id = 5;
            this.btnSaleGoods.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSaleGoods.LargeImageIndex = 0;
            this.btnSaleGoods.Name = "btnSaleGoods";
            this.btnSaleGoods.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSaleGoods.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCK_ItemClick);
            // 
            // btnUpdateGoods
            // 
            resources.ApplyResources(this.btnUpdateGoods, "btnUpdateGoods");
            this.btnUpdateGoods.Id = 6;
            this.btnUpdateGoods.ImageIndex = 25;
            this.btnUpdateGoods.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnUpdateGoods.LargeImageIndex = 31;
            this.btnUpdateGoods.Name = "btnUpdateGoods";
            this.btnUpdateGoods.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnUpdateGoods.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateGoods_ItemClick);
            // 
            // btnPayment
            // 
            resources.ApplyResources(this.btnPayment, "btnPayment");
            this.btnPayment.Id = 144;
            this.btnPayment.ImageIndex = 45;
            this.btnPayment.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.S));
            this.btnPayment.LargeImageIndex = 51;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPayment_ItemClick);
            // 
            // btnRollBackGoods
            // 
            resources.ApplyResources(this.btnRollBackGoods, "btnRollBackGoods");
            this.btnRollBackGoods.Enabled = false;
            this.btnRollBackGoods.Id = 171;
            this.btnRollBackGoods.ImageIndex = 46;
            this.btnRollBackGoods.Name = "btnRollBackGoods";
            this.btnRollBackGoods.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRollBackGoods_ItemClick);
            // 
            // rPageViewGroup
            // 
            this.rPageViewGroup.ItemLinks.Add(this.btnSystemViews);
            this.rPageViewGroup.ItemLinks.Add(this.btnViewRefrence);
            this.rPageViewGroup.ItemLinks.Add(this.btnCustomerViewOption, true);
            this.rPageViewGroup.ItemLinks.Add(this.btnViewOptions);
            this.rPageViewGroup.Name = "rPageViewGroup";
            this.rPageViewGroup.ShowCaptionButton = false;
            resources.ApplyResources(this.rPageViewGroup, "rPageViewGroup");
            // 
            // btnSystemViews
            // 
            resources.ApplyResources(this.btnSystemViews, "btnSystemViews");
            this.btnSystemViews.Id = 22;
            this.btnSystemViews.LargeImageIndex = 16;
            this.btnSystemViews.LargeImageIndexDisabled = 19;
            this.btnSystemViews.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryThisWeek),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryThisMonth),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryThisQuarter),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryThisYear),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnQueryCustomer, true)});
            this.btnSystemViews.Name = "btnSystemViews";
            this.btnSystemViews.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnQueryThisWeek
            // 
            resources.ApplyResources(this.BtnQueryThisWeek, "BtnQueryThisWeek");
            this.BtnQueryThisWeek.Id = 104;
            this.BtnQueryThisWeek.Name = "BtnQueryThisWeek";
            this.BtnQueryThisWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryThisWeek_ItemClick);
            // 
            // BtnQueryThisMonth
            // 
            resources.ApplyResources(this.BtnQueryThisMonth, "BtnQueryThisMonth");
            this.BtnQueryThisMonth.Id = 105;
            this.BtnQueryThisMonth.Name = "BtnQueryThisMonth";
            this.BtnQueryThisMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryThisMonth_ItemClick);
            // 
            // BtnQueryThisQuarter
            // 
            resources.ApplyResources(this.BtnQueryThisQuarter, "BtnQueryThisQuarter");
            this.BtnQueryThisQuarter.Id = 106;
            this.BtnQueryThisQuarter.Name = "BtnQueryThisQuarter";
            this.BtnQueryThisQuarter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryThisQuarter_ItemClick);
            // 
            // BtnQueryThisYear
            // 
            resources.ApplyResources(this.BtnQueryThisYear, "BtnQueryThisYear");
            this.BtnQueryThisYear.Id = 114;
            this.BtnQueryThisYear.Name = "BtnQueryThisYear";
            this.BtnQueryThisYear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryThisYear_ItemClick);
            // 
            // BtnQueryAll
            // 
            resources.ApplyResources(this.BtnQueryAll, "BtnQueryAll");
            this.BtnQueryAll.Id = 107;
            this.BtnQueryAll.Name = "BtnQueryAll";
            this.BtnQueryAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryAll_ItemClick);
            // 
            // BtnQueryCustomer
            // 
            resources.ApplyResources(this.BtnQueryCustomer, "BtnQueryCustomer");
            this.BtnQueryCustomer.Id = 108;
            this.BtnQueryCustomer.ImageIndex = 19;
            this.BtnQueryCustomer.Name = "BtnQueryCustomer";
            this.BtnQueryCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnQueryCustomer_ItemClick);
            // 
            // btnViewRefrence
            // 
            resources.ApplyResources(this.btnViewRefrence, "btnViewRefrence");
            this.btnViewRefrence.Id = 18;
            this.btnViewRefrence.ImageIndex = 16;
            this.btnViewRefrence.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnViewRefrence.LargeImageIndex = 21;
            this.btnViewRefrence.Name = "btnViewRefrence";
            this.btnViewRefrence.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnViewRefrence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewRefrence_ItemClick);
            // 
            // btnCustomerViewOption
            // 
            resources.ApplyResources(this.btnCustomerViewOption, "btnCustomerViewOption");
            this.btnCustomerViewOption.Id = 152;
            this.btnCustomerViewOption.ItemLinks.Add(this.btnSaveCustomView);
            this.btnCustomerViewOption.ItemLinks.Add(this.btnSaveNewCustomView);
            this.btnCustomerViewOption.ItemLinks.Add(this.btnSetToDefaultView);
            this.btnCustomerViewOption.ItemLinks.Add(this.btnCustomViewDelete);
            this.btnCustomerViewOption.Name = "btnCustomerViewOption";
            // 
            // btnSaveCustomView
            // 
            resources.ApplyResources(this.btnSaveCustomView, "btnSaveCustomView");
            this.btnSaveCustomView.Id = 153;
            this.btnSaveCustomView.ImageIndex = 9;
            this.btnSaveCustomView.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSaveCustomView.Name = "btnSaveCustomView";
            this.btnSaveCustomView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveCustomView_ItemClick);
            // 
            // btnSaveNewCustomView
            // 
            resources.ApplyResources(this.btnSaveNewCustomView, "btnSaveNewCustomView");
            this.btnSaveNewCustomView.Id = 154;
            this.btnSaveNewCustomView.ImageIndex = 10;
            this.btnSaveNewCustomView.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.S));
            this.btnSaveNewCustomView.Name = "btnSaveNewCustomView";
            this.btnSaveNewCustomView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveNewCustomView_ItemClick);
            // 
            // btnSetToDefaultView
            // 
            resources.ApplyResources(this.btnSetToDefaultView, "btnSetToDefaultView");
            this.btnSetToDefaultView.Id = 155;
            this.btnSetToDefaultView.ImageIndex = 6;
            this.btnSetToDefaultView.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnSetToDefaultView.Name = "btnSetToDefaultView";
            this.btnSetToDefaultView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetToDefaultView_ItemClick);
            // 
            // btnCustomViewDelete
            // 
            resources.ApplyResources(this.btnCustomViewDelete, "btnCustomViewDelete");
            this.btnCustomViewDelete.Id = 156;
            this.btnCustomViewDelete.ImageIndex = 8;
            this.btnCustomViewDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnCustomViewDelete.Name = "btnCustomViewDelete";
            this.btnCustomViewDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomViewDelete_ItemClick);
            // 
            // btnViewOptions
            // 
            resources.ApplyResources(this.btnViewOptions, "btnViewOptions");
            this.btnViewOptions.Id = 157;
            this.btnViewOptions.ItemLinks.Add(this.btnShowFindPanel);
            this.btnViewOptions.ItemLinks.Add(this.btnShowFilterRow);
            this.btnViewOptions.ItemLinks.Add(this.btnShowGroupPanel);
            this.btnViewOptions.Name = "btnViewOptions";
            // 
            // btnShowFindPanel
            // 
            resources.ApplyResources(this.btnShowFindPanel, "btnShowFindPanel");
            this.btnShowFindPanel.Id = 158;
            this.btnShowFindPanel.ImageIndex = 12;
            this.btnShowFindPanel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.btnShowFindPanel.Name = "btnShowFindPanel";
            this.btnShowFindPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowFindPanel_ItemClick);
            // 
            // btnShowFilterRow
            // 
            resources.ApplyResources(this.btnShowFilterRow, "btnShowFilterRow");
            this.btnShowFilterRow.Id = 159;
            this.btnShowFilterRow.ImageIndex = 17;
            this.btnShowFilterRow.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.F));
            this.btnShowFilterRow.Name = "btnShowFilterRow";
            this.btnShowFilterRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowFilterRow_ItemClick);
            // 
            // btnShowGroupPanel
            // 
            resources.ApplyResources(this.btnShowGroupPanel, "btnShowGroupPanel");
            this.btnShowGroupPanel.Id = 160;
            this.btnShowGroupPanel.ImageIndex = 13;
            this.btnShowGroupPanel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G));
            this.btnShowGroupPanel.Name = "btnShowGroupPanel";
            this.btnShowGroupPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowGroupPanel_ItemClick);
            // 
            // riggonPageGroupSum
            // 
            this.riggonPageGroupSum.ItemLinks.Add(this.TxtJHPrimiceSum);
            this.riggonPageGroupSum.ItemLinks.Add(this.TxtJHSaledSum);
            this.riggonPageGroupSum.ItemLinks.Add(this.TxtJSPrimiceSum, true);
            this.riggonPageGroupSum.ItemLinks.Add(this.TxtJSSaledSum);
            this.riggonPageGroupSum.Name = "riggonPageGroupSum";
            this.riggonPageGroupSum.ShowCaptionButton = false;
            resources.ApplyResources(this.riggonPageGroupSum, "riggonPageGroupSum");
            // 
            // TxtJHPrimiceSum
            // 
            resources.ApplyResources(this.TxtJHPrimiceSum, "TxtJHPrimiceSum");
            this.TxtJHPrimiceSum.Edit = this.repositoryItemTextEdit1;
            this.TxtJHPrimiceSum.EditValue = "0";
            this.TxtJHPrimiceSum.Id = 111;
            this.TxtJHPrimiceSum.Name = "TxtJHPrimiceSum";
            // 
            // repositoryItemTextEdit1
            // 
            resources.ApplyResources(this.repositoryItemTextEdit1, "repositoryItemTextEdit1");
            this.repositoryItemTextEdit1.Mask.EditMask = resources.GetString("repositoryItemTextEdit1.Mask.EditMask");
            this.repositoryItemTextEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit1.Mask.MaskType")));
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // TxtJHSaledSum
            // 
            resources.ApplyResources(this.TxtJHSaledSum, "TxtJHSaledSum");
            this.TxtJHSaledSum.Edit = this.repositoryItemTextEdit2;
            this.TxtJHSaledSum.EditValue = "0";
            this.TxtJHSaledSum.Id = 112;
            this.TxtJHSaledSum.Name = "TxtJHSaledSum";
            // 
            // repositoryItemTextEdit2
            // 
            resources.ApplyResources(this.repositoryItemTextEdit2, "repositoryItemTextEdit2");
            this.repositoryItemTextEdit2.Mask.EditMask = resources.GetString("repositoryItemTextEdit2.Mask.EditMask");
            this.repositoryItemTextEdit2.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit2.Mask.MaskType")));
            this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            // 
            // TxtJSPrimiceSum
            // 
            resources.ApplyResources(this.TxtJSPrimiceSum, "TxtJSPrimiceSum");
            this.TxtJSPrimiceSum.Edit = this.repositoryItemTextEdit5;
            this.TxtJSPrimiceSum.EditValue = "0";
            this.TxtJSPrimiceSum.Id = 167;
            this.TxtJSPrimiceSum.Name = "TxtJSPrimiceSum";
            // 
            // repositoryItemTextEdit5
            // 
            resources.ApplyResources(this.repositoryItemTextEdit5, "repositoryItemTextEdit5");
            this.repositoryItemTextEdit5.Mask.EditMask = resources.GetString("repositoryItemTextEdit5.Mask.EditMask");
            this.repositoryItemTextEdit5.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit5.Mask.MaskType")));
            this.repositoryItemTextEdit5.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit5.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            this.repositoryItemTextEdit5.ReadOnly = true;
            // 
            // TxtJSSaledSum
            // 
            resources.ApplyResources(this.TxtJSSaledSum, "TxtJSSaledSum");
            this.TxtJSSaledSum.Edit = this.repositoryItemTextEdit6;
            this.TxtJSSaledSum.EditValue = "0";
            this.TxtJSSaledSum.Id = 168;
            this.TxtJSSaledSum.Name = "TxtJSSaledSum";
            // 
            // repositoryItemTextEdit6
            // 
            resources.ApplyResources(this.repositoryItemTextEdit6, "repositoryItemTextEdit6");
            this.repositoryItemTextEdit6.Mask.EditMask = resources.GetString("repositoryItemTextEdit6.Mask.EditMask");
            this.repositoryItemTextEdit6.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit6.Mask.MaskType")));
            this.repositoryItemTextEdit6.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit6.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            this.repositoryItemTextEdit6.ReadOnly = true;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnViewExport, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnImport, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // btnViewExport
            // 
            resources.ApplyResources(this.btnViewExport, "btnViewExport");
            this.btnViewExport.Id = 62;
            this.btnViewExport.LargeImageIndex = 17;
            this.btnViewExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnExportXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnExportXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnExportPdf, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnExportHtml, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnExportMhtml)});
            this.btnViewExport.Name = "btnViewExport";
            this.btnViewExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnExportXls
            // 
            resources.ApplyResources(this.BtnExportXls, "BtnExportXls");
            this.BtnExportXls.Id = 118;
            this.BtnExportXls.Name = "BtnExportXls";
            this.BtnExportXls.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BtnExportXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportXls_ItemClick);
            // 
            // BtnExportXlsx
            // 
            resources.ApplyResources(this.BtnExportXlsx, "BtnExportXlsx");
            this.BtnExportXlsx.Id = 117;
            this.BtnExportXlsx.Name = "BtnExportXlsx";
            this.BtnExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportXlsx_ItemClick);
            // 
            // BtnExportPdf
            // 
            resources.ApplyResources(this.BtnExportPdf, "BtnExportPdf");
            this.BtnExportPdf.Id = 115;
            this.BtnExportPdf.Name = "BtnExportPdf";
            this.BtnExportPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportPdf_ItemClick);
            // 
            // BtnExportHtml
            // 
            resources.ApplyResources(this.BtnExportHtml, "BtnExportHtml");
            this.BtnExportHtml.Id = 116;
            this.BtnExportHtml.Name = "BtnExportHtml";
            this.BtnExportHtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BtnExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportHtml_ItemClick);
            // 
            // BtnExportMhtml
            // 
            resources.ApplyResources(this.BtnExportMhtml, "BtnExportMhtml");
            this.BtnExportMhtml.Id = 119;
            this.BtnExportMhtml.Name = "BtnExportMhtml";
            this.BtnExportMhtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.BtnExportMhtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportMhtml_ItemClick);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Id = 63;
            this.btnPrint.LargeImageIndex = 20;
            this.btnPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnPrintView),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnPrintJH),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnPrintJS),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnPrintXS)});
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnPrintView
            // 
            resources.ApplyResources(this.BtnPrintView, "BtnPrintView");
            this.BtnPrintView.Id = 66;
            this.BtnPrintView.Name = "BtnPrintView";
            this.BtnPrintView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrintView_ItemClick);
            // 
            // BtnPrintJH
            // 
            resources.ApplyResources(this.BtnPrintJH, "BtnPrintJH");
            this.BtnPrintJH.Id = 65;
            this.BtnPrintJH.Name = "BtnPrintJH";
            this.BtnPrintJH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrintJH_ItemClick);
            // 
            // BtnPrintJS
            // 
            resources.ApplyResources(this.BtnPrintJS, "BtnPrintJS");
            this.BtnPrintJS.Id = 142;
            this.BtnPrintJS.Name = "BtnPrintJS";
            this.BtnPrintJS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrintJS_ItemClick);
            // 
            // BtnPrintXS
            // 
            resources.ApplyResources(this.BtnPrintXS, "BtnPrintXS");
            this.BtnPrintXS.Id = 143;
            this.BtnPrintXS.Name = "BtnPrintXS";
            this.BtnPrintXS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPrintXS_ItemClick);
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Id = 170;
            this.btnImport.LargeImageIndex = 34;
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnDefaultView
            // 
            this.btnDefaultView.Id = 146;
            this.btnDefaultView.Name = "btnDefaultView";
            // 
            // btnFormatView
            // 
            this.btnFormatView.Id = 147;
            this.btnFormatView.Name = "btnFormatView";
            // 
            // btnCardView
            // 
            this.btnCardView.Id = 145;
            this.btnCardView.Name = "btnCardView";
            // 
            // repositoryItemDateEdit1
            // 
            resources.ApplyResources(this.repositoryItemDateEdit1, "repositoryItemDateEdit1");
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit1.Buttons"))))});
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.ReadOnly = true;
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemDateEdit2
            // 
            resources.ApplyResources(this.repositoryItemDateEdit2, "repositoryItemDateEdit2");
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit2.Buttons"))))});
            this.repositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            this.repositoryItemDateEdit2.ReadOnly = true;
            this.repositoryItemDateEdit2.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemTextEdit3
            // 
            resources.ApplyResources(this.repositoryItemTextEdit3, "repositoryItemTextEdit3");
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // btnAllViewAll
            // 
            resources.ApplyResources(this.btnAllViewAll, "btnAllViewAll");
            this.btnAllViewAll.Id = 58;
            this.btnAllViewAll.Name = "btnAllViewAll";
            // 
            // btnGoodsRefrence
            // 
            resources.ApplyResources(this.btnGoodsRefrence, "btnGoodsRefrence");
            this.btnGoodsRefrence.Id = 8;
            this.btnGoodsRefrence.Name = "btnGoodsRefrence";
            this.btnGoodsRefrence.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // repositoryItemComboBox1
            // 
            resources.ApplyResources(this.repositoryItemComboBox1, "repositoryItemComboBox1");
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemComboBox1.Buttons"))))});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // btnViewLayout
            // 
            resources.ApplyResources(this.btnViewLayout, "btnViewLayout");
            this.btnViewLayout.Id = 11;
            this.btnViewLayout.Name = "btnViewLayout";
            this.btnViewLayout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 73;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // rPageSystemConfig
            // 
            this.rPageSystemConfig.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rPageGroupConfigManager});
            this.rPageSystemConfig.Name = "rPageSystemConfig";
            resources.ApplyResources(this.rPageSystemConfig, "rPageSystemConfig");
            // 
            // rPageGroupConfigManager
            // 
            this.rPageGroupConfigManager.ItemLinks.Add(this.btnAddNewConfig);
            this.rPageGroupConfigManager.ItemLinks.Add(this.btnUpdateConfig);
            this.rPageGroupConfigManager.ItemLinks.Add(this.btnDeleteConfig);
            this.rPageGroupConfigManager.ItemLinks.Add(this.btnRefreshConfigView, true);
            this.rPageGroupConfigManager.Name = "rPageGroupConfigManager";
            this.rPageGroupConfigManager.ShowCaptionButton = false;
            resources.ApplyResources(this.rPageGroupConfigManager, "rPageGroupConfigManager");
            // 
            // btnAddNewConfig
            // 
            resources.ApplyResources(this.btnAddNewConfig, "btnAddNewConfig");
            this.btnAddNewConfig.Id = 99;
            this.btnAddNewConfig.LargeImageIndex = 29;
            this.btnAddNewConfig.Name = "btnAddNewConfig";
            this.btnAddNewConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUpdateConfig
            // 
            resources.ApplyResources(this.btnUpdateConfig, "btnUpdateConfig");
            this.btnUpdateConfig.Id = 100;
            this.btnUpdateConfig.LargeImageIndex = 31;
            this.btnUpdateConfig.Name = "btnUpdateConfig";
            this.btnUpdateConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnDeleteConfig
            // 
            resources.ApplyResources(this.btnDeleteConfig, "btnDeleteConfig");
            this.btnDeleteConfig.Id = 101;
            this.btnDeleteConfig.LargeImageIndex = 32;
            this.btnDeleteConfig.Name = "btnDeleteConfig";
            this.btnDeleteConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnRefreshConfigView
            // 
            resources.ApplyResources(this.btnRefreshConfigView, "btnRefreshConfigView");
            this.btnRefreshConfigView.Id = 102;
            this.btnRefreshConfigView.LargeImageIndex = 21;
            this.btnRefreshConfigView.Name = "btnRefreshConfigView";
            this.btnRefreshConfigView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // rPageUserManager
            // 
            this.rPageUserManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RPageGroupLoginUser,
            this.ribbonPageGroup2,
            this.RPageGroupUserOther});
            this.rPageUserManager.Name = "rPageUserManager";
            resources.ApplyResources(this.rPageUserManager, "rPageUserManager");
            // 
            // RPageGroupLoginUser
            // 
            this.RPageGroupLoginUser.ItemLinks.Add(this.BtnUserLoginName);
            this.RPageGroupLoginUser.Name = "RPageGroupLoginUser";
            this.RPageGroupLoginUser.ShowCaptionButton = false;
            resources.ApplyResources(this.RPageGroupLoginUser, "RPageGroupLoginUser");
            // 
            // BtnUserLoginName
            // 
            resources.ApplyResources(this.BtnUserLoginName, "BtnUserLoginName");
            this.BtnUserLoginName.Id = 134;
            this.BtnUserLoginName.LargeImageIndex = 47;
            this.BtnUserLoginName.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUserUpdateSelf),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUserUpdatePwd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUserLogout, true)});
            this.BtnUserLoginName.Name = "BtnUserLoginName";
            this.BtnUserLoginName.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUserUpdateSelf
            // 
            resources.ApplyResources(this.btnUserUpdateSelf, "btnUserUpdateSelf");
            this.btnUserUpdateSelf.Id = 135;
            this.btnUserUpdateSelf.ImageIndex = 36;
            this.btnUserUpdateSelf.Name = "btnUserUpdateSelf";
            this.btnUserUpdateSelf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserUpdateSelf_ItemClick);
            // 
            // btnUserUpdatePwd
            // 
            resources.ApplyResources(this.btnUserUpdatePwd, "btnUserUpdatePwd");
            this.btnUserUpdatePwd.Id = 140;
            this.btnUserUpdatePwd.ImageIndex = 40;
            this.btnUserUpdatePwd.Name = "btnUserUpdatePwd";
            this.btnUserUpdatePwd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserUpdatePwd_ItemClick);
            // 
            // btnUserLogout
            // 
            resources.ApplyResources(this.btnUserLogout, "btnUserLogout");
            this.btnUserLogout.Id = 136;
            this.btnUserLogout.ImageIndex = 37;
            this.btnUserLogout.Name = "btnUserLogout";
            this.btnUserLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserLogout_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnUserAdd);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnUserMondify, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnUserRestorePwd);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            resources.ApplyResources(this.ribbonPageGroup2, "ribbonPageGroup2");
            // 
            // BtnUserAdd
            // 
            resources.ApplyResources(this.BtnUserAdd, "BtnUserAdd");
            this.BtnUserAdd.Id = 120;
            this.BtnUserAdd.LargeImageIndex = 40;
            this.BtnUserAdd.Name = "BtnUserAdd";
            this.BtnUserAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnUserMondify
            // 
            resources.ApplyResources(this.BtnUserMondify, "BtnUserMondify");
            this.BtnUserMondify.Id = 121;
            this.BtnUserMondify.LargeImageIndex = 42;
            this.BtnUserMondify.Name = "BtnUserMondify";
            this.BtnUserMondify.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnUserRestorePwd
            // 
            resources.ApplyResources(this.BtnUserRestorePwd, "BtnUserRestorePwd");
            this.BtnUserRestorePwd.Id = 122;
            this.BtnUserRestorePwd.LargeImageIndex = 46;
            this.BtnUserRestorePwd.Name = "BtnUserRestorePwd";
            this.BtnUserRestorePwd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // RPageGroupUserOther
            // 
            this.RPageGroupUserOther.ItemLinks.Add(this.BtnUserViewRefresh);
            this.RPageGroupUserOther.Name = "RPageGroupUserOther";
            this.RPageGroupUserOther.ShowCaptionButton = false;
            resources.ApplyResources(this.RPageGroupUserOther, "RPageGroupUserOther");
            // 
            // BtnUserViewRefresh
            // 
            resources.ApplyResources(this.BtnUserViewRefresh, "BtnUserViewRefresh");
            this.BtnUserViewRefresh.Id = 139;
            this.BtnUserViewRefresh.LargeImageIndex = 45;
            this.BtnUserViewRefresh.Name = "BtnUserViewRefresh";
            this.BtnUserViewRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ViewContainers
            // 
            this.ViewContainers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.ViewContainers, "ViewContainers");
            this.ViewContainers.Name = "ViewContainers";
            // 
            // TxtLogInUserName
            // 
            resources.ApplyResources(this.TxtLogInUserName, "TxtLogInUserName");
            this.TxtLogInUserName.Edit = this.repositoryItemTextEdit4;
            this.TxtLogInUserName.Id = 124;
            this.TxtLogInUserName.Name = "TxtLogInUserName";
            // 
            // repositoryItemTextEdit4
            // 
            resources.ApplyResources(this.repositoryItemTextEdit4, "repositoryItemTextEdit4");
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemDateEdit3
            // 
            resources.ApplyResources(this.repositoryItemDateEdit3, "repositoryItemDateEdit3");
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemDateEdit3.Buttons"))))});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            this.repositoryItemDateEdit3.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = this.repositoryItemPictureEdit1;
            this.barEditItem1.Id = 129;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Id = 149;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonGroup1
            // 
            resources.ApplyResources(this.barButtonGroup1, "barButtonGroup1");
            this.barButtonGroup1.Id = 148;
            this.barButtonGroup1.ItemLinks.Add(this.barButtonItem3);
            this.barButtonGroup1.ItemLinks.Add(this.barButtonItem3);
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // rPageHome
            // 
            this.rPageHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPgroupDashboard});
            this.rPageHome.Name = "rPageHome";
            resources.ApplyResources(this.rPageHome, "rPageHome");
            // 
            // rbnPgroupDashboard
            // 
            this.rbnPgroupDashboard.ItemLinks.Add(this.btnDasbhoard);
            this.rbnPgroupDashboard.Name = "rbnPgroupDashboard";
            resources.ApplyResources(this.rbnPgroupDashboard, "rbnPgroupDashboard");
            // 
            // btnDasbhoard
            // 
            resources.ApplyResources(this.btnDasbhoard, "btnDasbhoard");
            this.btnDasbhoard.Id = 181;
            this.btnDasbhoard.LargeImageIndex = 21;
            this.btnDasbhoard.Name = "btnDasbhoard";
            this.btnDasbhoard.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDasbhoard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDasbhoard_ItemClick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ViewContainers);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.ViewContainers, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewContainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory2;
        private DevExpress.XtraBars.BarButtonItem btnAddConsignmentGoods;
        private DevExpress.XtraBars.BarButtonItem btnAddBuyGoods;
        private DevExpress.XtraBars.Ribbon.RibbonPage rPageGoodsManager;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rPageGoodsGroup;
        private DevExpress.XtraBars.BarButtonItem btnSaleGoods;
        private DevExpress.XtraBars.BarButtonItem btnUpdateGoods;
        private DevExpress.XtraBars.BarButtonItem btnGoodsRefrence;
        private DevExpress.XtraBars.BarSubItem btnViewLayout;
        private DevExpress.XtraBars.BarButtonItem btnCardView;
        private DevExpress.XtraBars.BarButtonItem btnViewRefrence;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rPageViewGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarSubItem btnSystemViews;    
        private DevExpress.XtraBars.BarButtonItem btnAllViewAll;
        private DevExpress.XtraBars.BarSubItem btnViewExport;
        private DevExpress.XtraBars.BarSubItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem BtnPrintJH;
        private DevExpress.XtraBars.BarButtonItem BtnPrintView;
        private RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnDefaultView;
        private DevExpress.XtraBars.BarButtonItem btnFormatView;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private RibbonPage rPageSystemConfig;
        private RibbonPage rPageUserManager;
        private RibbonPageGroup rPageGroupConfigManager;
        private DevExpress.XtraBars.BarButtonItem btnAddNewConfig;
        private DevExpress.XtraBars.BarButtonItem btnUpdateConfig;
        private DevExpress.XtraBars.BarButtonItem btnDeleteConfig;
        private DevExpress.XtraBars.BarButtonItem btnRefreshConfigView;
        private DevExpress.XtraBars.BarButtonItem BtnQueryThisWeek;
        private DevExpress.XtraBars.BarButtonItem BtnQueryThisMonth;
        private DevExpress.XtraBars.BarButtonItem BtnQueryThisQuarter;
        private DevExpress.XtraBars.BarButtonItem BtnQueryAll;
        private DevExpress.XtraBars.BarButtonItem BtnQueryCustomer;
        private DevExpress.XtraEditors.PanelControl ViewContainers;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarEditItem TxtJHPrimiceSum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem TxtJHSaledSum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.BarButtonItem BtnQueryThisYear;
        private DevExpress.XtraBars.BarButtonItem BtnExportXls;
        private DevExpress.XtraBars.BarButtonItem BtnExportXlsx;
        private DevExpress.XtraBars.BarButtonItem BtnExportPdf;
        private DevExpress.XtraBars.BarButtonItem BtnExportHtml;
        private DevExpress.XtraBars.BarButtonItem BtnExportMhtml;
        private DevExpress.XtraBars.BarButtonItem BtnUserAdd;
        private DevExpress.XtraBars.BarButtonItem BtnUserMondify;
        private DevExpress.XtraBars.BarButtonItem BtnUserRestorePwd;
        private DevExpress.XtraBars.BarEditItem TxtLogInUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RibbonPageGroup RPageGroupLoginUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraBars.BarSubItem BtnUserLoginName;
        private DevExpress.XtraBars.BarButtonItem btnUserUpdateSelf;
        private DevExpress.XtraBars.BarButtonItem btnUserLogout;
        private RibbonPageGroup RPageGroupUserOther;
        private DevExpress.XtraBars.BarButtonItem BtnUserViewRefresh;
        private DevExpress.XtraBars.BarButtonItem btnUserUpdatePwd;
        private DevExpress.XtraBars.BarButtonItem BtnPrintJS;
        private DevExpress.XtraBars.BarButtonItem BtnPrintXS;
        private DevExpress.XtraBars.BarButtonItem btnPayment;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonGroup btnCustomerViewOption;
        private DevExpress.XtraBars.BarButtonItem btnSaveCustomView;
        private DevExpress.XtraBars.BarButtonItem btnSaveNewCustomView;
        private DevExpress.XtraBars.BarButtonItem btnSetToDefaultView;
        private DevExpress.XtraBars.BarButtonItem btnCustomViewDelete;
        private DevExpress.XtraBars.BarButtonGroup btnViewOptions;
        private DevExpress.XtraBars.BarButtonItem btnShowFindPanel;
        private DevExpress.XtraBars.BarButtonItem btnShowFilterRow;
        private DevExpress.XtraBars.BarButtonItem btnShowGroupPanel;
        private DevExpress.XtraBars.BarEditItem TxtJSPrimiceSum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraBars.BarEditItem TxtJSSaledSum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private RibbonPageGroup riggonPageGroupSum;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private DevExpress.XtraBars.BarButtonItem btnRollBackGoods;
        private RibbonPage rPageHome;
        private DevExpress.XtraBars.BarButtonItem btnDasbhoard;
        private RibbonPageGroup rbnPgroupDashboard;
       // private ViewControls.UCMainGoodsView MainGoodsView;

    }
}
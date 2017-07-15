using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Business.ViewModel;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.GoodsManager;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.OrderManager;
using Vogue2_IMS.ReceiptManager;
using Vogue2_IMS.SystemManager;
using Vogue2_IMS.UserManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using System.Drawing;
using System.Configuration;

namespace Vogue2_IMS
{
    public partial class FormMain : RibbonFormSimpleDialogBase
    {   

        #region About Log In

        private ManualResetEvent waitInitializeHandler = new ManualResetEvent(false);
        private ManualResetEvent waitloginHandler = null;
        private delegate void FormShowHandler();
        public DialogResult loginResult = DialogResult.Abort;

        private bool isLoaded = false;
        private void Login()
        {
            FormLogin flogin = new FormLogin(waitInitializeHandler);
            waitloginHandler = flogin.waitLoginHandler;
            flogin.SetDialogResult += SetDialogResult;

            loginResult = flogin.ShowDialog();
        }

        private void SetDialogResult(DialogResult dialogResult)
        {
            this.loginResult = dialogResult;
        }

        private void LoginCallback(IAsyncResult ar)
        {
            try
            {
                AsyncResult result = (AsyncResult)ar;

                ((FormShowHandler)result.AsyncDelegate).EndInvoke(ar);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Method: LoginCallback \r\bMssage:{0}", ex.Message));
            }
        }

        #endregion

        public FormMain()
            : base(Common.Language.Chinese)
        {
            InitializeComponent();

            new FormShowHandler(Login).BeginInvoke(new AsyncCallback(LoginCallback), null);

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            waitInitializeHandler.WaitOne();
        }

        #region This

        /// <summary>
        /// 加载视图
        /// </summary>
        private void RegiserView()
        {
            mRibbonPageViews.Add(rPageGoodsManager, mFmGoodsMainView);//商品管理
            //mRibbonPageViews.Add(rPageSystemConfig, mFmSystemConfigView);//系统设置
            //mRibbonPageViews.Add(rPageUserManager, mFmUserView);//用户管理
            mRibbonPageViews.Add(rPageHome, mFmBI);

            ribbon.SelectedPage = null;
            ribbon.SelectedPage = rPageHome;          
        }

        /// <summary>
        /// 视图当前查询条件 
        /// </summary>
        private ProListRequest mCurrentQueryInfo
        {
            get
            {
                if (mFmGoodsMainView.DefaultQueryInfo == null)
                    mFmGoodsMainView.DefaultQueryInfo = new ProListRequest() { DateRange = QueryDateRange.ThisWeek };

                return mFmGoodsMainView.DefaultQueryInfo;
            }

            set { mFmGoodsMainView.DefaultQueryInfo = value; }
        }
        Dictionary<RibbonPage, Form> mRibbonPageViews = new Dictionary<RibbonPage, Form>();

        private void ribbon_SelectedPageChanged(object sender, System.EventArgs e)
        {
            if (ribbon.SelectedPage != null && mRibbonPageViews.ContainsKey(ribbon.SelectedPage))
            {
                ViewContainers.Controls.Clear();
                var view = mRibbonPageViews[ribbon.SelectedPage];
                if (view != null && view is Form)
                {
                    mRibbonPageViews[ribbon.SelectedPage].TopLevel = false;
                    mRibbonPageViews[ribbon.SelectedPage].Dock = DockStyle.Fill;
                    ViewContainers.Controls.Add(mRibbonPageViews[ribbon.SelectedPage]);
                    mRibbonPageViews[ribbon.SelectedPage].Show();
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (loginResult == DialogResult.OK)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.ShowInTaskbar = true;
                    this.Text += string.Format("{0}", ConfigManager.LoginUser.username);
                    RegiserView();
                    // 起线程取预警消息
                    //SCWarning();
                    //LoadWarningMessages();
                    //btnPayment.Enabled = SharedVariables.Instance.LoginUser.User.RoleId <= SharedVariables.PMRoleId;
                    //this.btnAddBuyGoods.Enabled =
                    //this.btnAddConsignmentGoods.Enabled = !(SharedVariables.Instance.LoginUser.User.RoleId > SharedVariables.PMRoleId);
                    //btnImport.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.PMRoleId;
                    //this.btnRollBackGoods.Enabled = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch
            {
                throw;
            }
            finally
            {

                this.MainRibbonControl.Pages.Remove(this.MainPage);

                if (waitloginHandler != null)
                {
                    waitloginHandler.Set();
                }
            }
        }

        private void SCWarning()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                Thread thread = new Thread(new ThreadStart(LoadWarningMessages));
                thread.Start();
            }
        }

        #endregion

        #region System Config

        FmSystemConfigView _FmSystemConfigView = null;
        FmSystemConfigView mFmSystemConfigView
        {
            get
            {
                if (_FmSystemConfigView == null)
                {
                    _FmSystemConfigView = new FmSystemConfigView();
                    _FmSystemConfigView.TopLevel = false;
                    _FmSystemConfigView.Dock = DockStyle.Fill;
                    _FmSystemConfigView.ButtonAdd = btnAddNewConfig;
                    _FmSystemConfigView.ButtonUpdate = btnUpdateConfig;
                    _FmSystemConfigView.ButtonDelete = btnDeleteConfig;
                    _FmSystemConfigView.ButtonRefresh = btnRefreshConfigView;

                    //btnAddNewConfig.Enabled=btnUpdateConfig.Enabled=btnRefreshConfigView.Enabled
                    rPageGroupConfigManager.Visible = false;
                    _FmSystemConfigView.BtnClicked += new System.EventHandler<NavBarClickedArgs>((object sender, NavBarClickedArgs args)
                        =>
                    {
                        rPageGroupConfigManager.Visible = true;

                        rPageGroupConfigManager.Text = string.Format("[{0}]-管理", args.FunctionTypeName);
                        btnAddNewConfig.Caption = string.Format("新建[{0}]", args.FunctionTypeName);
                        btnUpdateConfig.Caption = string.Format("更新[{0}]", args.FunctionTypeName);
                        btnDeleteConfig.Caption = string.Format("删除[{0}]", args.FunctionTypeName);
                        btnRefreshConfigView.Caption = string.Format("刷新视图", args.FunctionTypeName);
                    });

                    this.rPageSystemConfig.Groups.Insert(0, this.MainThemePageGroup);
                }

                return _FmSystemConfigView;
            }
            set { _FmSystemConfigView = value; }
        }

        #endregion

        #region Home

        FmBI _fmBI = null;
        FmBI mFmBI
        {
            get
            {
                if (_fmBI == null)
                {
                    _fmBI = new FmBI();
                    _fmBI.Load += FmBI_Load;
               
                    this.rPageHome.Groups.Insert(0, this.MainThemePageGroup);

                    _fmBI.TotalJSCQ.Click += UCGoodsTotalJSCQ_Click;
                    _fmBI.TotalJSKC.Click += UCGoodsTotalJSKC_Click;
                    _fmBI.TotalJSWDK.Click += UCGoodsTotalJSWDK_Click;
                    _fmBI.TotalZYCQ.Click += UCGoodsTotalZYCQ_Click;
                    _fmBI.TotalZYKC.Click += UCGoodsTotalZYKC_Click;
                    _fmBI.TotalZYWDK.Click += UCGoodsTotalZYWDK_Click;
                }
               
                return _fmBI;
            }
            set { _fmBI = value; }
        }

        private void RefreshGoodsViewByDashboard(ViewCondition condition)
        {
            mFmGoodsMainView.Condition = condition;
            mFmGoodsMainView.DefaultQueryInfo = new ProListRequest() { DateRange = QueryDateRange.AllYear10 };
            StartRefreshGoodsView(this, null);
        }

        private void UCGoodsTotalJSCQ_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.JSChaoQi);
            ribbon.SelectedPage = rPageGoodsManager;
        }
        private void UCGoodsTotalJSKC_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.JSZaiKu); 
            ribbon.SelectedPage = rPageGoodsManager;
        }
        private void UCGoodsTotalJSWDK_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.JSWeiDaKuan);
            ribbon.SelectedPage = rPageGoodsManager;
        }
        private void UCGoodsTotalZYCQ_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.ZYChaoQi);
            ribbon.SelectedPage = rPageGoodsManager;
        }
        private void UCGoodsTotalZYKC_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.ZYZaiKu);
            ribbon.SelectedPage = rPageGoodsManager;
        }
        private void UCGoodsTotalZYWDK_Click(object sender, EventArgs e)
        {
            RefreshGoodsViewByDashboard(ViewCondition.ZYWeiDaKuan);
            ribbon.SelectedPage = rPageGoodsManager;
        }

        private void FmBI_Load(object sender, EventArgs e)
        {
            StartRefreshBIView(this, null);                       
        }

        private void StartRefreshBIView(object sender, CusEventArgs e)
        {
            mFmBI.Enabled = false; 

            Task task = new Task(() =>
            {
                if (!isLoaded)
                {
                    Thread.Sleep(500);
                }
                try
                {
                    string endDateStr = ConfigurationManager.AppSettings["DashBoardEndDate"];
                    string daySpanStr = ConfigurationManager.AppSettings["DashBoardDaySpan"];
                    int daySpan = 0 - (string.IsNullOrEmpty(daySpanStr) ? 7 : Convert.ToInt32(daySpanStr));
                    var endDate = string.IsNullOrEmpty(endDateStr) ? DateTime.Now : Convert.ToDateTime(endDateStr);

                    var queryDateInfo = new ProListRequest(); 
                    queryDateInfo.oetime = endDate;
                    queryDateInfo.ostime = queryDateInfo.oetime.Value.AddDays(daySpan);
                
                    mFmBI.SalesDataSource = GoodsWebBusiness.GetProInfoList(queryDateInfo);

                    var viewQuaryTotal = new ViewQuaryTotal();
                    string jhTimeOutDaySpanStr = ConfigurationManager.AppSettings["JinHuoTimeoutDaySpan"];
                    int jhTimeOutDaySpan = 0 - (string.IsNullOrEmpty(daySpanStr) ? 180 : Convert.ToInt32(jhTimeOutDaySpanStr));
                    viewQuaryTotal.DaySpan = jhTimeOutDaySpan;
                    viewQuaryTotal.EndDate=endDate;
                    viewQuaryTotal.StartDate = viewQuaryTotal.EndDate.Value.AddDays(daySpan);

                    mFmBI.ViewDasboardSource = GoodsWebBusiness.GetProTongJi(new DashBoardRequest() { dayspan = jhTimeOutDaySpan });
                   
                   
                }
                catch
                {
                    mFmBI.SalesDataSource = new List<ProInfo>();
                    throw;
                }
                finally
                {
                    //mFmBI.DataSource = new List<ViewMainGoodsInfos>();
                }

            });

            task.Start();
        }

        /// <summary>
        /// 获取（全记录）时间查询条件 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private ViewQueryGoodsInfo GetBIViewDateQuery(QueryDateRange dateRange)
        {
            var dateNow = DateTime.Now;
            var startDate = DateTime.Now;

            if (dateRange == QueryDateRange.ThisWeek)
                startDate = dateNow.AddDays(1 - Convert.ToInt32(dateNow.DayOfWeek.ToString("d")));

            if (dateRange == QueryDateRange.ThisMonth)
                startDate = dateNow.AddDays(1 - dateNow.Day);

            if (dateRange == QueryDateRange.ThisQuarter)
                startDate = dateNow.AddMonths(0 - (dateNow.Month - 1) % 3).AddDays(1 - dateNow.Day);

            if (dateRange == QueryDateRange.ThisYear)
                startDate = new DateTime(dateNow.Year, 1, 1);

            if (dateRange == QueryDateRange.AllYear10)
                startDate = new DateTime(dateNow.Year - 10, 1, 1);

            return new ViewQueryGoodsInfo() { DateRange = dateRange, SalesStartDate = startDate, SalesEndDate = dateNow };
            //return new ViewQueryGoodsInfo() { DateRange = dateRange, StartPurchaseDate = startDate, StartSaledDate = startDate, EndPurchaseDate = dateNow, EndSaledDate = dateNow };
        }

        private void btnDasbhoard_ItemClick(object sender, ItemClickEventArgs e)
        {
            StartRefreshBIView(this, null);
        }        

        #endregion

        #region User Manager

        FmUserView _FmUserView = null;
        FmUserView mFmUserView
        {
            get
            {
                if (_FmUserView == null)
                {
                    _FmUserView = new FmUserView();
                    _FmUserView.BtnAdd = BtnUserAdd;
                    _FmUserView.BtnRefResh = BtnUserViewRefresh;
                    _FmUserView.BtnResetPwd = BtnUserRestorePwd;
                    _FmUserView.BtnUpdate = BtnUserMondify;

                    BtnUserLoginName.Caption = ConfigManager.LoginUser.username;
                }

                return _FmUserView;
            }
        }

        private void btnUserLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnUserUpdateSelf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FmUserInfo(new UserShopRoleInfo() { User = SharedVariables.Instance.LoginUser.User }).ShowDialog();
        }

        private void btnUserUpdatePwd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FmUpdatedPwd().ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mFmGoodsMainView.MainView.ShowPrintPreview();
        }

        #endregion

        #region Goods Manager

        List<ViewMainGoodsInfos> GoodsMainViewDataSource = new List<ViewMainGoodsInfos>();
        FmGoodsMainView _FmGoodsMainView = null;
        FmGoodsMainView mFmGoodsMainView
        {
            get
            {
                if (_FmGoodsMainView == null)
                {
                    _FmGoodsMainView = new FmGoodsMainView();
                    _FmGoodsMainView.Load += mFmGoodsMainView_Load;

                    _FmGoodsMainView.TopLevel = false;
                    _FmGoodsMainView.Dock = DockStyle.Fill;
                    _FmGoodsMainView.GridDefaultView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridDefaultView_SelectionChanged);
                    _FmGoodsMainView.GridLayoutView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridDefaultView_SelectionChanged);
                    _FmGoodsMainView.GridAdvBandedView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridDefaultView_SelectionChanged);

                    _FmGoodsMainView.GridDefaultView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(GridDefaultView_RowStyle);
                    //_FmGoodsMainView.GridLayoutView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(GridDefaultView_RowStyle);
                    _FmGoodsMainView.GridAdvBandedView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(GridDefaultView_RowStyle);

                    _FmGoodsMainView.GridDefaultView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(GridDefaultView_RowCellClick);
                    //_FmGoodsMainView.GridLayoutView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(GridDefaultView_RowCellClick);
                    _FmGoodsMainView.GridAdvBandedView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(GridDefaultView_RowCellClick);

                    _FmGoodsMainView.GridDefaultView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GridDefaultView_CustomDrawRowIndicator);
                    _FmGoodsMainView.GridAdvBandedView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GridDefaultView_CustomDrawRowIndicator);


                    _FmGoodsMainView.GridDefaultView.MouseDown += new MouseEventHandler(GridDefaultView_MouseDown);
                    //_FmGoodsMainView.GridLayoutView.MouseDown += new MouseEventHandler(GridDefaultView_MouseDown);
                    _FmGoodsMainView.GridAdvBandedView.MouseDown += new MouseEventHandler(GridDefaultView_MouseDown);
                    PurchaseGoodsBusiness.Instance.OnPurchaseGoodsUpdated += new EventHandler<CusEventArgs>(StartRefreshGoodsView);
                    SaleGoodsBusiness.Instance.OnSaledGoodsUpdated += new EventHandler<CusEventArgs>(StartRefreshGoodsView);

                   // StartRefreshView(this, null);
                }

                return _FmGoodsMainView;
            }
            set { _FmGoodsMainView = value; }
        }

        private void mFmGoodsMainView_Load(object sender, EventArgs e)
        {
            StartRefreshGoodsView(this, null);
        }

        private void StartRefreshGoodsView(object sender, CusEventArgs e)
        {
            mFmGoodsMainView.Enabled = false;

            Task task = new Task(() =>
            {
                try
                {
                    if (!isLoaded)
                    {
                        Thread.Sleep(500);
                    }

                    mFmGoodsMainView.DefaultQueryInfo = mCurrentQueryInfo;
                    mFmGoodsMainView.DataSource = GoodsWebBusiness.GetProInfoList(mCurrentQueryInfo.Clone());

                   // mCurrentQueryInfo = mFmGoodsMainView.DefaultQueryInfo;
                }
                finally
                {
                    if (mFmGoodsMainView.DataSource == null) mFmGoodsMainView.DataSource = new List<ProInfo>();

                    MainViewSource_Changed();
                }
            });

            task.Start();
        }   

        #region Warning Message Box

        private void LoadWarningMessages()
        {
            var warMsgDict = GoodsBusiness.Instance.GetWarningGoodsMsg(WarningType.JSWarning, (int)(DateTime.Now - DateTime.Now.AddYears(-10)).TotalDays);

            if (warMsgDict.Count == 0 || (int)warMsgDict["GoodsCount"] == 0)
            {
                return;
            }
            int goodsCount = (int)warMsgDict["GoodsCount"];
            DateTime startDate = (DateTime)warMsgDict["MinDate"];
            DateTime endDate = (DateTime)warMsgDict["MaxDate"];
            FmWarningMessageBox fmWarning = new FmWarningMessageBox(this, ConfigManager.LoginUser.username, goodsCount, startDate, endDate);
            fmWarning.linkViewInfo_Clicked += new EventHandler(linkViewInfo_Click);

            warMsgDict.Clear();

            this.BeginInvoke(new MethodInvoker(delegate { fmWarning.Show(); }));
        }

        private void linkViewInfo_Click(object sender, EventArgs e)
        {
            //mFmGoodsMainView.DataSource = GoodsBusiness.Instance.GetWarningGoods(WarningType.JSWarning, (int)(DateTime.Now - DateTime.Now.AddYears(-10)).TotalDays);
            //MainViewSource_Changed();
        }

        #endregion

        #region Layout Event

        private void btnShowFindPanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!mFmGoodsMainView.MainView.IsFindPanelVisible)
                mFmGoodsMainView.MainView.ShowFindPanel();
            else
                mFmGoodsMainView.MainView.HideFindPanel();
        }

        private void btnShowFilterRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridOptionsView optionView = mFmGoodsMainView.MainView.OptionsView as GridOptionsView;

            if (optionView != null)
                optionView.ShowAutoFilterRow = !optionView.ShowAutoFilterRow;
            else
            {
                e.Link.UserPaintStyle = BarItemPaintStyle.Standard; ;//..Reset();
            }
        }

        private void btnShowGroupPanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridOptionsView optionView = mFmGoodsMainView.MainView.OptionsView as GridOptionsView;

            if (optionView != null)
                optionView.ShowGroupPanel = !optionView.ShowGroupPanel;
            else
            {
                e.Item.Reset();
            }
        }

        private void btnSaveCustomView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("您确证要覆盖当前视图?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                mFmGoodsMainView.SaveCustomerViewLayout(false);
            }
        }

        private void btnSaveNewCustomView_ItemClick(object sender, ItemClickEventArgs e)
        {
            mFmGoodsMainView.SaveCustomerViewLayout(true);
        }

        private void btnSetToDefaultView_ItemClick(object sender, ItemClickEventArgs e)
        {
            mFmGoodsMainView.SaveDefaultMainView();
        }

        #endregion Layout Event

        #region View Event

        private List<ProInfo> GetSelectedGoodsInfos()
        {
            var gridMainView = mFmGoodsMainView.MainView;
            if (gridMainView.SelectedRowsCount > 0)
            {
                var mainGoodsInfos = new List<ProInfo>();
                int[] rowIndexs = gridMainView.GetSelectedRows();
                foreach (var rowIndex in rowIndexs)
                {
                    var mainGoodsInfo = gridMainView.GetRow(rowIndex) as ProInfo;
                    mainGoodsInfos.Add(mainGoodsInfo);
                }
                return mainGoodsInfos;
            }
            return null;
        }

        private List<ProInfo> GetCheckedGoodsInfos()
        {
            var gridMainView = mFmGoodsMainView.MainView;
            var chkedGoodsInfos = new List<ProInfo>();
            for (var i = 0; i < gridMainView.RowCount; i++)
            {
                var rowObj = gridMainView.GetRow(i);
                if (rowObj == null)
                {
                    continue;
                }
                var mainGoodsInfo = gridMainView.GetRow(i) as ProInfo;
                if (mainGoodsInfo.CheckEdit)
                {
                    chkedGoodsInfos.Add(mainGoodsInfo);
                }
            }
            return chkedGoodsInfos;
        }
        private void btnFindGoods_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mFmGoodsMainView.MainView.ShowFindPanel();
        }

        private void btnUpdateGoods_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    if (mFmGoodsMainView.MainView.SelectedRowsCount > 0)
            //    {
            //        var goodsInfo = mFmGoodsMainView.MainView.GetRow(mFmGoodsMainView.MainView.GetSelectedRows()[0]) as ProInfo;
            //        if (goodsInfo == null) return;

            //        if (goodsInfo.pros == GoodsStatus.In)
            //        {
            //            var fmGoodsInfo = new FmGoodsInfo(goodsInfo);
            //            if (fmGoodsInfo.ShowDialog() == DialogResult.OK)
            //            {
            //                var result = fmGoodsInfo.PurchaseGoodsInfo;
            //                Business.PurchaseGoodsBusiness.Instance.UpdatePurchaseGoods(result);
            //            }
            //        }
            //        else if (goodsInfo.GoodsStatus == GoodsStatus.Catch)
            //        {
            //            var fmGoodsInfo = new FmGoodsSaledMondify(goodsInfo.GetSaledGoodsInfo());
            //            if (fmGoodsInfo.ShowDialog() == DialogResult.OK)
            //            {
            //                var result = fmGoodsInfo.SaledGoodsInfo;
            //                Business.SaleGoodsBusiness.Instance.UpdateSaledGoods(result);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(String.Format("更新失败:\r\n{0}", ex.ToString()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var mainGoodsInfos = this.GetCheckedGoodsInfos();
            if (mainGoodsInfos == null) return;

            var tempGoodsInfos = mainGoodsInfos.Where(info =>
            {
                return info.protype == ConfigManager.JiShou && info.prostatus == ConfigManager.ZaiKu;
            }).ToList();

            if (tempGoodsInfos.Count > 0)
            {
                string noticeMsg = "所选商品包含寄售且未售出的商品:\r\n{0} 是否打款？";
                StringBuilder sb = new StringBuilder();
                tempGoodsInfos.ForEach(info =>
                {
                    sb.AppendFormat("【{0}】 {1}\r\n", info.procode, info.proname);
                });
                if (XtraMessageBox.Show(string.Format(noticeMsg, sb.ToString()), "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            else
            {
                if (XtraMessageBox.Show("您确定要打款？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            GoodsWebBusiness.ProDaKuan(mainGoodsInfos.Select(a => { return a.proid.Value; }).ToList());
            StartRefreshGoodsView(this, null);
        }

        private void btnRollBackGoods_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chkedMainGoodsInfos = this.GetCheckedGoodsInfos();

            if (chkedMainGoodsInfos.Count > 0)
            {
                var rollBackEnabledGoods = new List<ProInfo>();
                chkedMainGoodsInfos.ForEach(pro =>
                {
                    if (pro.prostatus == ConfigManager.ShouChu || pro.prostatus == ConfigManager.YuDing)
                    {
                        rollBackEnabledGoods.Add(pro);
                    }
                });

                if (rollBackEnabledGoods.Count > 0 &&
                    XtraMessageBox.Show("您确定要退货?", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GoodsWebBusiness.ProTuiHuo(rollBackEnabledGoods.Select(a => { return a.proid.Value; }).ToList());
                    StartRefreshGoodsView(this, null);
                }
            }
        }

        private void btnJS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fmProInfo = new FmGoodsInfo(ConfigManager.JiShou);
            if (fmProInfo.ShowDialog() == DialogResult.OK)
            {
                StartRefreshGoodsView(this, null);
            }
        }

        private void btnJH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fmProInfo = new FmGoodsInfo(ConfigManager.JinHuo);
            if (fmProInfo.ShowDialog() == DialogResult.OK)
            {
                StartRefreshGoodsView(this, null);
            }
        }

        private void btnCK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                  var gridMainView = mFmGoodsMainView.MainView;
                  if (gridMainView.SelectedRowsCount > 0)
                  {
                      var dialogresult = DialogResult.Cancel;
                      int[] rowIndexs = gridMainView.GetSelectedRows();
                      var fmGoodsSales = new FmGoodsSaledMondify(gridMainView.GetRow(rowIndexs.First()) as ProInfo);
                      dialogresult = fmGoodsSales.ShowDialog();
                      if (dialogresult == DialogResult.OK)
                      {
                          StartRefreshGoodsView(this, null);
                      }
                  }
              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }

        }

        private void GridDefaultView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var gridMainView = mFmGoodsMainView.MainView;
                var mainGoodsInfo = gridMainView.GetRow(e.RowHandle) as ProInfo;

                if (mainGoodsInfo == null) return;

                if (mainGoodsInfo.prostatus == ConfigManager.ShouChu)
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (mainGoodsInfo.prostatus == ConfigManager.QuHui)
                {
                    e.Appearance.ForeColor = Color.SeaGreen;
                }
                if (mainGoodsInfo.prostatus == ConfigManager.YuDing)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void GridDefaultView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "CheckEdit")
            {
                var gridMainView = mFmGoodsMainView.MainView;
                gridMainView.SetRowCellValue(e.RowHandle, e.Column, !(bool)(e.CellValue ?? false));

                var chkedGoodsInfos = this.GetCheckedGoodsInfos();
                // 包含取回和已售出的商品时，商品售出按钮不可用
                this.btnSaleGoods.Enabled = chkedGoodsInfos.Count(goods =>
                {
                    return goods.prostatus == ConfigManager.ShouChu || goods.prostatus == ConfigManager.QuHui;
                }) == 0;
            }
        }

        private void GridDefaultView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listSelectedGoods = GetSelectedGoodsInfos();
            if (listSelectedGoods == null || listSelectedGoods.Count == 0)
            {
                btnUpdateGoods.Enabled = BtnPrintJH.Enabled = BtnPrintJS.Enabled = BtnPrintXS.Enabled = true;
                return;
            }

            btnUpdateGoods.Enabled = false;
            btnPayment.Enabled = listSelectedGoods.Count(goods => goods.procode.StartsWith("ZY")) == 0 ||
                    listSelectedGoods.Count(goods => goods.propaystatus == ConfigManager.YiDaKuan) == listSelectedGoods.Count;

            if (listSelectedGoods.Count == 1)
            {
                var curGoods = listSelectedGoods.FirstOrDefault();
                btnUpdateGoods.Enabled = (curGoods.prostatus == ConfigManager.ZaiKu || curGoods.prostatus == ConfigManager.YuDing);
                BtnPrintXS.Enabled = curGoods.prostatus == ConfigManager.ShouChu || curGoods.prostatus == ConfigManager.YuDing;
                BtnPrintJH.Enabled = curGoods.protype == ConfigManager.JinHuo;
                BtnPrintJS.Enabled = curGoods.protype == ConfigManager.JiShou;
                return;
            }

            BtnPrintXS.Enabled = listSelectedGoods.Count == listSelectedGoods.Count(item => item.prostatus != ConfigManager.ZaiKu);
            BtnPrintJH.Enabled = listSelectedGoods.Count == listSelectedGoods.Count(item => item.protype == ConfigManager.JinHuo);
            BtnPrintJS.Enabled = listSelectedGoods.Count == listSelectedGoods.Count(item => item.protype == ConfigManager.JiShou);
        }

        private void GridDefaultView_MouseDown(object sender, MouseEventArgs e)
        {
            var gridMainView = (GridView)sender;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridMainView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    if (!hInfo.InRowCell) return;
                    //取得选定行信息  
                    var goodsInfo = gridMainView.GetRow(hInfo.RowHandle) as ProInfo;

                    if (goodsInfo == null) return;

                    var dialogresult = DialogResult.Cancel;

                    if (goodsInfo.prostatus != ConfigManager.ZaiKu)
                    {
                        var fmGoodsSales = new FmGoodsSaledMondify(goodsInfo);
                        dialogresult = fmGoodsSales.ShowDialog();
                    }
                    else
                    {
                        var fmGoodsInfo = new FmGoodsInfo(goodsInfo);
                        dialogresult = fmGoodsInfo.ShowDialog();
                    }

                    if (dialogresult == DialogResult.OK)
                    {
                        StartRefreshGoodsView(this, null);
                    }
                }
            }
        }

        private GridView curGridView = null;
        private void GridDefaultView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
            }

            var curGridView = (GridView)sender;
            curGridView.IndicatorWidth = e.Info.DisplayText.Length + 25;
        }

        /// <summary>
        /// 更新查询时间与统计项
        /// </summary>
        private void MainViewSource_Changed()
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                if (mFmGoodsMainView.DataSource != null)
                {
                    decimal sumJHPrimice = 0;
                    decimal sumJHSaled = 0;
                    decimal sumJSPrimice = 0;
                    decimal sumJSSaled = 0;

                    Dictionary<string, decimal> dictJSCharge = new Dictionary<string, decimal>();
                    Dictionary<string, decimal> dictJHCharge = new Dictionary<string, decimal>();

                    mFmGoodsMainView.DataSource.ForEach(source =>
                    {
                        if (source.protype == ConfigManager.JinHuo)
                        {
                            if (source.prostatus == ConfigManager.ZaiKu)
                                sumJHPrimice += source.projiage.HasValue ? source.projiage.Value : 0;

                            if (source.prostatus == ConfigManager.ShouChu)
                            {
                                sumJHSaled += source.prosjiage.HasValue ? source.prosjiage.Value : 0; 
                            }


                        }
                        else
                        {
                            if (source.prostatus == ConfigManager.ZaiKu)
                                sumJSPrimice += source.projiage.HasValue ? source.projiage.Value : 0;

                            if (source.prostatus == ConfigManager.ShouChu)
                            {
                                sumJSSaled += source.prosjiage.HasValue ? source.prosjiage.Value : 0;

                            }
                        }
                    });

                    TxtJHPrimiceSum.EditValue = sumJHPrimice;
                    TxtJHSaledSum.EditValue = sumJHSaled;// string.Format("{0}({1})", sumJHSaled, dictJHCharge.Sum(charge => charge.Value));
                    TxtJSPrimiceSum.EditValue = sumJSPrimice;
                    TxtJSSaledSum.EditValue = sumJSSaled;// string.Format("{0}({1})", sumJSSaled, dictJSCharge.Sum(charge => charge.Value)); ;
                }

                mFmGoodsMainView.Enabled = true;
            }));
        }

        private void btnViewRefrence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryThisWeek_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mCurrentQueryInfo.DateRange = QueryDateRange.ThisWeek;
          
            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryThisMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mCurrentQueryInfo.DateRange = QueryDateRange.ThisMonth;

            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryThisQuarter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mCurrentQueryInfo.DateRange = QueryDateRange.ThisQuarter;

            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryThisYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mCurrentQueryInfo.DateRange = QueryDateRange.ThisYear;

            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mCurrentQueryInfo.DateRange = QueryDateRange.AllYear10;        
            StartRefreshGoodsView(this, null);
        }

        private void BtnQueryCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FmGoodsQueryCustomer fmQueryCustomer = new FmGoodsQueryCustomer();

            fmQueryCustomer.StartDate = mCurrentQueryInfo.stime.HasValue ? mCurrentQueryInfo.stime.Value : DateTime.Now;
            fmQueryCustomer.EndDate = mCurrentQueryInfo.etime.HasValue ? mCurrentQueryInfo.etime.Value : DateTime.Now;

            if (fmQueryCustomer.ShowDialog() == DialogResult.OK)
            {
                var temp = new ProListRequest();             
                temp.stime = fmQueryCustomer.StartDate;
                temp.etime = fmQueryCustomer.EndDate;

                mCurrentQueryInfo = temp;
                mCurrentQueryInfo.DateRange = QueryDateRange.Customer;
                StartRefreshGoodsView(this, null);
            }
        }

        private void btnCustomViewDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            mFmGoodsMainView.RemoveCustomerView();
        }

        #endregion  View Event

        #region Export

        private string CheckExportToFile(string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = filter;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        private void BtnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = CheckExportToFile("Excel|*.xls");
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    mFmGoodsMainView.MainView.ExportToXls(fileName, true);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("保存失败：{0}", ex.ToString()), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExportXlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = CheckExportToFile("Excel|*.xlsx");
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    mFmGoodsMainView.MainView.ExportToXlsx(fileName,
                        new XlsxExportOptions() { ShowGridLines = true, ExportHyperlinks = true, ExportMode = XlsxExportMode.SingleFile, TextExportMode = TextExportMode.Text });
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("保存失败：{0}", ex.ToString()), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExportPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = CheckExportToFile("PDF|*.pdf");
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    mFmGoodsMainView.MainView.ExportToPdf(fileName, new PdfExportOptions() { ConvertImagesToJpeg = true });
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("保存失败：{0}", ex.ToString()), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExportHtml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = CheckExportToFile("HTML|*.html");
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    mFmGoodsMainView.MainView.ExportToHtml(fileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("保存失败：{0}", ex.ToString()), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnExportMhtml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileName = CheckExportToFile("HTML|*.mhtml");
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    mFmGoodsMainView.MainView.ExportToMht(fileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("保存失败：{0}", ex.ToString()), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Import

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FmGoodsImport().ShowDialog();
        }

        #endregion

        #region Print

        private void BtnPrintJH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listSelectedGoods = GetCheckedGoodsInfos();
            if (listSelectedGoods == null) return;

            if (listSelectedGoods.Count(item => item.protype == ConfigManager.JiShou) > 0)
            {
                XtraMessageBox.Show("进货回单里不能包含寄售商品!");
                return;
            }
            List<PurchaseJhGoodsOrderInfo> listJHGoods = new List<PurchaseJhGoodsOrderInfo>();
            var totalPrice = listSelectedGoods.Sum(item => item.projiage);
            listSelectedGoods.ForEach(item =>
            {
                item.images = GoodsWebBusiness.GetProImages(item.proid.Value);

                listJHGoods.Add(new PurchaseJhGoodsOrderInfo(item, 1)
                {
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                });
                listJHGoods.Add(new PurchaseJhGoodsOrderInfo(item, 2)
                {
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                });
            });
            var receiptView = new FmReceiptView();
            receiptView.InitializeReceiptView<PurchaseJhGoodsOrderInfo>(listJHGoods);
            receiptView.ShowDialog();
        }

        private void BtnPrintJS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listSelectedGoods = GetCheckedGoodsInfos();
            if (listSelectedGoods == null) return;

            if (listSelectedGoods.Count(item => item.protype == ConfigManager.JinHuo) > 0)
            {
                XtraMessageBox.Show("寄售回单里不能包含自有商品!");
                return;
            }
            List<PurchaseJsGoodsOrderInfo> listJsGoods = new List<PurchaseJsGoodsOrderInfo>();
            var totalPrice = listSelectedGoods.Sum(item => item.projiage);
            listSelectedGoods.ForEach(item =>
            {
                item.images = GoodsWebBusiness.GetProImages(item.proid.Value);

                listJsGoods.Add(new PurchaseJsGoodsOrderInfo(item, 1)
                {
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                });
                listJsGoods.Add(new PurchaseJsGoodsOrderInfo(item, 2)
                {
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0.00
                });
            });
            var receiptView = new FmReceiptView();
            receiptView.InitializeReceiptView<PurchaseJsGoodsOrderInfo>(listJsGoods);
            receiptView.ShowDialog();
        }

        private void BtnPrintXS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listSelectedGoods = GetCheckedGoodsInfos();
            if (listSelectedGoods == null) return;

            if (listSelectedGoods.Count(item => item.prostatus == ConfigManager.ZaiKu) > 0)
            {
                XtraMessageBox.Show("未售出商品不能在此处打印销售回单!");
                return;
            }

            var listSaledOrderInfo = new List<SaledGoodsOrderInfo>();
            var totalMarkPrice = listSelectedGoods.Sum(record => record.probjiage);
            var totalPrice = listSelectedGoods.Sum(record => record.prosjiage);
            var totalDiscount = listSelectedGoods.Sum(record => record.prozhekou);
            listSelectedGoods.ForEach(item =>
            {
                item.images = GoodsWebBusiness.GetProImages(item.proid.Value);
                listSaledOrderInfo.Add(new SaledGoodsOrderInfo(item, 1)
                {
                    TotalMarkPrice = totalMarkPrice.HasValue ? totalMarkPrice.Value : (decimal)0,
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0,
                    TotalDiscount = totalDiscount.HasValue ? totalDiscount.Value : (decimal)0
                });
                listSaledOrderInfo.Add(new SaledGoodsOrderInfo(item, 2)
                {
                    TotalMarkPrice = totalMarkPrice.HasValue ? totalMarkPrice.Value : (decimal)0,
                    TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0,
                    TotalDiscount = totalDiscount.HasValue ? totalDiscount.Value : (decimal)0
                });
            });

            var receiptView = new FmReceiptView();
            receiptView.InitializeReceiptView<SaledGoodsOrderInfo>(listSaledOrderInfo);
            receiptView.ShowDialog();
        }

        private void BtnPrintView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mFmGoodsMainView.MainView.ShowPrintPreview();
        }

        #endregion


        #endregion       

    }
}
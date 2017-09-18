using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraNavBar;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.ViewModel;
using Vogue2_IMS.Common;
using System.Linq;
using System.Configuration;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsMainView : DevExpress.XtraEditors.XtraForm
    {
        #region property

        List<ProInfo> _DataSource = new List<ProInfo>();
        public List<ProInfo> DataSource
        {
            get
            {
                if (_DataSource == null) _DataSource = new List<ProInfo>();

                return _DataSource;
            }
            set
            {
                DataSource.Clear();

                _DataSource.AddRange(value);

                RefreshData();
            }
        }

        public GridControl Grid
        {
            get { return this.gridViewControl; }
            set { this.gridViewControl = value; }
        }

        public GridView GridDefaultView
        {
            get { return this.mGridDefaultViewAll; }
            set { this.mGridDefaultViewAll = value; }
        }

        public LayoutView GridLayoutView
        {
            get { return this.mGridLayoutView; }
            set { this.mGridLayoutView = value; }
        }

        public AdvBandedGridView GridAdvBandedView
        {
            get { return this.mGridAdvBandedViewAll; }
            set { this.mGridAdvBandedViewAll = value; }
        }

        public CardView GridCardView
        {
            get { return this.mGridCardViewAll; }
            set { this.mGridCardViewAll = value; }
        }

        public ColumnView MainView
        {
            get { return Grid.MainView as ColumnView; }
            set
            {
                Grid.MainView = value;
                
                //LoadCusomterLayout();
            }
        }

        #endregion

        public FmGoodsMainView(bool fromConfig=false)
        {
            InitializeComponent();
            InitializeNavBar();

           gridViewControl.DataSource = DataSource;

            DevViewDefine.ResetToNormalView(GridDefaultView, false, true, false);

            //DevViewDefine.ResetToNormalView(GridLayoutView, false, true, false);
            //DevViewDefine.ResetToNormalView(GridAdvBandedView, false, true, false);

            if (!fromConfig)
                SetDefaultMainView();

            if (MainView != null)
            {
               //LoadCusomterLayout();
                MainView.ActiveFilterString = GetViewConditionStr(Condition);
            }
        }

        public void RefreshData()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { Grid.MainView.RefreshData(); }));

                return;
            }

            Grid.MainView.RefreshData();
        }

        #region Layout

        private CustomerViewLayout _CurrentCustomerViewLayout = null;
        private CustomerViewLayout mCurrentCustomerViewLayout
        {
            get { return _CurrentCustomerViewLayout; }
            set {
                _CurrentCustomerViewLayout = value;
                if (_CurrentCustomerViewLayout != null)
                {
                    SetCusomterDefaltView(_CurrentCustomerViewLayout);
                }
            }
        }

        private string UserSystemViewLayoutFile
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("UserSystemDefaultLayout.{0}.{1}.{2}.xml",
                     ConfigManager.LoginUser.username, this.Name, this.MainView.Name));
            }
        }

        Dictionary<string, CustomerViewLayout> mDicUserSystemViewLayout = new Dictionary<string, CustomerViewLayout>();
        private Dictionary<string, CustomerViewLayout> DicUserSysetmViewLayout
        {
            get
            {
                mDicUserSystemViewLayout = mDicUserSystemViewLayout ?? new Dictionary<string, CustomerViewLayout>();
                if (mDicUserSystemViewLayout.Count == 0)
                {
                    var filePathFormat = Path.Combine(SharedVariables.Instance.LayoutXmlPath);
                    var filesTemp = Directory.GetFiles(filePathFormat);

                    foreach (var file in filesTemp)
                    {
                        if (file.Contains(string.Format("CustomerLayout.{0}.{1}", ConfigManager.LoginUser.username, this.Name)))
                            using (StringReader strReader = new StringReader(File.ReadAllText(file, Encoding.Unicode)))
                            {
                                try
                                {
                                    XmlSerializer xmlser = new XmlSerializer(typeof(CustomerViewLayout));
                                    var customerView = xmlser.Deserialize(strReader) as CustomerViewLayout;
                                    if (customerView != null)
                                        mDicUserSystemViewLayout[customerView.ViewName] = customerView;
                                }
                                catch
                                {

                                }
                            }

                    }
                }

                return mDicUserSystemViewLayout;
            }
        }

        public void SaveCustomerViewLayout(bool isNew=false)
        {
            CustomerViewLayout customerViewTemp = new CustomerViewLayout();
            var update = !isNew && mCurrentCustomerViewLayout != null;
            if (update)
            {
                customerViewTemp = mCurrentCustomerViewLayout;
                customerViewTemp.UpdateTime = DateTime.Now;
            }
            else
            {
                customerViewTemp.UserName = ConfigManager.LoginUser.username;
                customerViewTemp.FromUIName = this.Name;
                customerViewTemp.BaseViewName = MainView.Name;
                
                if (new FmNewCustomerViewName(customerViewTemp).ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            File.Delete(@".\customerlayouttemp.xml");
            MainView.SaveLayoutToXml(@".\customerlayouttemp.xml", OptionsLayoutBase.FullLayout);
            customerViewTemp.LayoutXml = File.ReadAllText(@".\customerlayouttemp.xml");
            File.Delete(@".\customerlayouttemp.xml");

            if (!update)
            {
                NavBarItem item = new NavBarItem(customerViewTemp.ViewName);
                item.LinkClicked += BtnCustomer_LinkClicked;
                NavBtnCustomerViewGroup.ItemLinks.Add(item);

                DicUserSysetmViewLayout[customerViewTemp.ViewName] = customerViewTemp;               
                item.Links[0].PerformClick();
            }

            NavBtnCustomerViewGroup.NavigationPaneVisible = true;
            File.Delete(customerViewTemp.FilePath);
            StringBuilder sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                XmlSerializer xlser = new XmlSerializer(typeof(CustomerViewLayout));
                xlser.Serialize(writer, customerViewTemp);
            }

            File.AppendAllText(customerViewTemp.FilePath, sb.ToString(),Encoding.Unicode);

            //XtraMessageBox.Show("自定义视图保存成功.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RestoreLayout()
        {
            mCurrentCustomerViewLayout = null;
            if (MainView != null)
            {
                if (!File.Exists(UserSystemViewLayoutFile))
                {
                    var tempThis = new FmGoodsMainView(true);
                    if (MainView.Name == GridDefaultView.Name)
                    {
                        tempThis.MainView = tempThis.GridDefaultView;
                    }
                    if (MainView.Name == GridLayoutView.Name)
                    {
                        tempThis.MainView = tempThis.GridLayoutView;
                    }
                    if (MainView.Name == GridAdvBandedView.Name)
                    {
                        tempThis.MainView = tempThis.GridAdvBandedView;
                    }

                    tempThis.MainView.SaveLayoutToXml(UserSystemViewLayoutFile, OptionsLayoutBase.FullLayout);
                }

                MainView.RestoreLayoutFromXml(UserSystemViewLayoutFile, OptionsLayoutBase.FullLayout);
            }
        }

        private void btnDefaultView_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBtnSystemViewGroup.Expanded = true;
            NavBtnSystemViewGroup.SelectedLink = e.Link;
            MainView = GridDefaultView;
            RestoreLayout();
        }

        private void btnAdvBandedView_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBtnSystemViewGroup.Expanded = true;
            NavBtnSystemViewGroup.SelectedLink = e.Link;
            MainView = GridAdvBandedView;
            RestoreLayout();
        }

        private void btnCardView_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBtnSystemViewGroup.Expanded = true;
            NavBtnSystemViewGroup.SelectedLink = e.Link;
            MainView = GridLayoutView;
            RestoreLayout();
        }

        private void BtnCustomer_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBtnCustomerViewGroup.Expanded = true;
            NavBtnCustomerViewGroup.SelectedLink = e.Link;
            if (DicUserSysetmViewLayout.ContainsKey(e.Link.Caption))
            {
                mCurrentCustomerViewLayout = DicUserSysetmViewLayout[e.Link.Caption];
            }
        }

        public void RemoveCustomerView()
        {
            if (mCurrentCustomerViewLayout != null)
            {
                if(XtraMessageBox.Show(string.Format("删除视图【{0}】?",mCurrentCustomerViewLayout.ViewName)
                    ,"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    File.Delete(mCurrentCustomerViewLayout.FilePath);
                    NavBtnCustomerViewGroup.ItemLinks.RemoveAt(NavBtnCustomerViewGroup.SelectedLinkIndex);
                    mDicUserSystemViewLayout.Clear();

                    if (NavBtnCustomerViewGroup.ItemLinks.Count > 0)
                    {
                        NavBtnCustomerViewGroup.ItemLinks[0].PerformClick();
                    }
                    else
                    {
                        btnDefaultView.Links[0].PerformClick();
                    }
                }
            }
        }

        #endregion

        #region Default View

        ProListRequest mDefaultQueryInfo = null;
        public ProListRequest DefaultQueryInfo
        {
            get { return mDefaultQueryInfo; }
            set
            {
                mDefaultQueryInfo = value;
                if (value != null)
                {
                    if (this.InvokeRequired)
                        this.BeginInvoke(new MethodInvoker(delegate() { labSourceCondition.Text = value.ToString(); }));
                    else
                    {
                        labSourceCondition.Text = value.ToString();
                    }
                }
            }
        }
 
        string DefaultViewPath { get { return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("DefaultMainViewSet.{0}.{1}.config", this.Name,ConfigManager.LoginUser.username)); } }

        /// <summary>
        /// 保存默认视图选项
        /// </summary>
        public void SaveDefaultMainView()
        {
            File.Delete(DefaultViewPath);
            StringBuilder sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                XmlSerializer xlser = new XmlSerializer(typeof(DefaultQueryAndView));
                xlser.Serialize(writer, new DefaultQueryAndView()
                {
                    IsSystemView = mCurrentCustomerViewLayout == null,
                    DefaultMainViewName = mCurrentCustomerViewLayout == null ? MainView.Name : mCurrentCustomerViewLayout.ViewName,
                    DefaultQuery = DefaultQueryInfo
                });
            }

            File.AppendAllText(DefaultViewPath, sb.ToString(),Encoding.Unicode);

            XtraMessageBox.Show("默认视图保存成功.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetDefaultMainView()
        {
            if (File.Exists(DefaultViewPath))
            {
                var defaultQueryAndViewStr = File.ReadAllText(DefaultViewPath,Encoding.Unicode);
                using (StringReader strReader = new StringReader(defaultQueryAndViewStr))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(DefaultQueryAndView));
                    var defaultQueryView = xmlser.Deserialize(strReader) as DefaultQueryAndView;

                    if (defaultQueryView.IsSystemView)
                    {
                        SetSystemDefaultMainView(defaultQueryView);
                    }
                    else
                    {
                        SetUserDefaultView(defaultQueryView);
                    }

                    DefaultQueryInfo = defaultQueryView.DefaultQuery;
                }
            }
        }

        private void SetUserDefaultView(DefaultQueryAndView defaultQueryView)
        {
            if (defaultQueryView != null)
            {
                if (DicUserSysetmViewLayout.ContainsKey(defaultQueryView.DefaultMainViewName))
                {
                    foreach (NavBarItemLink link in NavBtnCustomerViewGroup.ItemLinks)
                    {
                        if (link.Caption == defaultQueryView.DefaultMainViewName)
                            link.PerformClick();
                    }
                }
            }
        }

        private void SetCusomterDefaltView(CustomerViewLayout customerViewLayout)
        {
            if (customerViewLayout != null)
            {
                if (customerViewLayout.BaseViewName.Equals(GridLayoutView.Name))
                {
                    MainView = GridLayoutView;
                }
                else if (customerViewLayout.BaseViewName.Equals(GridAdvBandedView.Name))
                {
                    MainView = GridAdvBandedView;
                }
                else
                {
                    MainView = GridDefaultView;
                }
            }

            File.Delete(@".\customerlayoutTemp.xml");
            File.AppendAllText(@".\customerlayoutTemp.xml", customerViewLayout.LayoutXml);

            MainView.RestoreLayoutFromXml(@".\customerlayoutTemp.xml", OptionsLayoutBase.FullLayout);
            File.Delete(@".\customerlayoutTemp.xml");
        }

        private void SetSystemDefaultMainView(DefaultQueryAndView defaultQueryView)
        {
            if (defaultQueryView != null)
            {
                if (defaultQueryView.DefaultMainViewName.Equals(GridLayoutView.Name))
                {
                    btnCardView.Links[0].PerformClick();
                }
                else if (defaultQueryView.DefaultMainViewName.Equals(GridAdvBandedView.Name))
                {
                    btnAdvBandedView.Links[0].PerformClick();
                }
                else
                {
                    btnDefaultView.Links[0].PerformClick();
                }
            }
        }

        #endregion

        private void mNavBarControl_Resize(object sender, EventArgs e)
        {
            var control = ((NavBarControl)sender);
            int width = control.Width + ViewTypeContainer.Padding.Left;
            ViewTypeContainer.Width = width;
        }

        private void InitializeNavBar()
        {
            mNavBarControl.AllowSelectedLink = true;
            mNavBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            mNavBarControl.Location = new System.Drawing.Point(0, 0);
            mNavBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            mNavBarControl.Resize += mNavBarControl_Resize;

            foreach (var customerView in DicUserSysetmViewLayout.Values)
            {
                NavBarItem item = new NavBarItem(customerView.ViewName);
                item.LinkClicked += BtnCustomer_LinkClicked;
                NavBtnCustomerViewGroup.ItemLinks.Add(item);
                NavBtnCustomerViewGroup.SelectedLink = null;
            }
        }

        ViewCondition _condition = ViewCondition.Normal;
        public ViewCondition Condition
        {
            get { return _condition; }
            set
            {
                _condition = value;

                MainView.ActiveFilterString = GetViewConditionStr(Condition);
            }
        }

        private string GetViewConditionStr(ViewCondition condition)
        {
            string returnStr = string.Empty;
            switch(condition)
            {
                case ViewCondition.ZYWeiDaKuan:
                    returnStr = "[prostatus] = '售出' And [protype] = '进货' And [propaystatus] = '未打款'";
                    break;
                case ViewCondition.ZYZaiKu:
                    returnStr = "[prostatus] = '在库' And [protype] = '进货'";
                    break;
                case ViewCondition.ZYChaoQi:
                    var daySpanStr = ConfigurationManager.AppSettings["JinHuoTimeoutDaySpan"];
                    var daySpan = string.IsNullOrEmpty(daySpanStr) ? 180 : Convert.ToInt32(daySpanStr);

                    returnStr = "[prostatus] = '在库' And [protype] = '进货' And [proupdatetime.Value] <= '" + DateTime.Now.AddDays(0 - daySpan).ToShortDateString() + "'";
                    break;
                case ViewCondition.JSWeiDaKuan:
                    returnStr = "[prostatus] = '售出' And [protype] = '寄售' And [propaystatus] = '未打款'";
                    break;
                case ViewCondition.JSZaiKu:
                    returnStr = "[prostatus] = '在库' And [protype] = '寄售'";
                    break;
                case ViewCondition.JSChaoQi:
                    returnStr = "[prostatus] = '在库' And [protype] = '寄售' and [proendtime.Value]" + "< '" + DateTime.Now.ToShortDateString() + "'";
                    break;
            }

            return returnStr;
        }

        private void viewMainGoodsInfosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public enum ViewCondition
    {
        Normal
        ,ZYWeiDaKuan
        ,ZYZaiKu
        ,ZYChaoQi
        ,JSWeiDaKuan
        ,JSZaiKu
        ,JSChaoQi
    }

    [Serializable]
    public class DefaultQueryAndView
    {
        public bool IsSystemView { get; set; }

        public string DefaultMainViewName { get; set; }

        public ProListRequest DefaultQuery { get; set; }
    }

    [Serializable]
    public class CustomerViewLayout
    {
        public string FromUIName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 视图名称
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// 来源系统视图
        /// </summary>
        public string BaseViewName { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public string LayoutXml { get; set; }

        private DateTime createTime = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get { return createTime; } set { createTime = value; } }

        private DateTime updateTime = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get { return updateTime; } set { updateTime = value; } }

        public string FilePath
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("CustomerLayout.{0}.{1}.{2}.{3}.xml",
                    UserName, FromUIName, BaseViewName, ViewName));
            }
        }
    }
}
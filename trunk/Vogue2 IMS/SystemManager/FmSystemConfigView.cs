using System;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraNavBar;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.SystemManager
{
    public partial class FmSystemConfigView : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<NavBarClickedArgs> BtnClicked;
        public ColumnView GridDefaultView
        {
            get;
            set;
        }

        public FmSystemConfigView()
        {
            InitializeComponent();
            InitializeNavBar();

            ShopBusiness.Instance.OnShopUpdated += new EventHandler<CusEventArgs>((object sender, CusEventArgs args) => { RefreshView(); });
            CategoryBusiness.Instance.OnCategoryUpdated += new EventHandler<CusEventArgs>((object sender, CusEventArgs args) => { RefreshView(); });
            PayTypeBusiness.Instance.OnPayTypeUpdated += new EventHandler<CusEventArgs>((object sender, CusEventArgs args) => { RefreshView(); });
            RoleBusiness.Instance.OnRoleColumnsUpdated += new EventHandler<CusEventArgs>((object sender, CusEventArgs args) => { RefreshView(); });
        }

        #region Initialize All Button

        BarButtonItem mButtonAdd = null;
        public BarButtonItem ButtonAdd
        {
            get { return mButtonAdd; }
            set
            {
                mButtonAdd = value;
                if (value != null)
                {
                    mButtonAdd.ItemClick += new ItemClickEventHandler(ButtonAdd_ItemClick);
                }
            }
        }

        BarButtonItem mButtonUpdate = null;
        public BarButtonItem ButtonUpdate
        {
            get { return mButtonUpdate; }
            set
            {
                mButtonUpdate = value;
                if (value != null)
                {
                    //mButtonUpdate.Enabled = false;
                    mButtonUpdate.ItemClick += new ItemClickEventHandler(ButtonUpdate_ItemClick);
                }
            }
        }

        BarButtonItem mButtonDelete = null;
        public BarButtonItem ButtonDelete
        {
            get { return mButtonAdd; }
            set
            {
                mButtonDelete = value;
                if (value != null)
                {
                    mButtonDelete.ItemClick += new ItemClickEventHandler(ButtonDelete_ItemClick);
                    mButtonDelete.Enabled = false;
                }
            }
        }

        BarButtonItem mButtonRefresh = null;
        public BarButtonItem ButtonRefresh
        {
            get { return mButtonRefresh; }
            set
            {
                mButtonRefresh = value;
                if (value != null)
                {
                    mButtonRefresh.ItemClick += new ItemClickEventHandler(ButtonRefresh_ItemClick);
                }
            }
        }

        private void InitializeNavBar()
        {
            mNavBarControl.AllowSelectedLink = true;
            mNavBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            mNavBarControl.Location = new System.Drawing.Point(0, 0);
            mNavBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            mNavBarControl.Resize += mNavBarControl_Resize;

            GridControlCategory.Dock = GridControlPayType.Dock = GridControlShop.Dock = GridControlRoleColumn.Dock = DockStyle.Fill;
            GridControlCategory.Visible = GridControlPayType.Visible = GridControlShop.Visible = GridControlRoleColumn.Visible = false;
            
            NavBtnGroupRoleConfig.Visible = SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId; //超管可见
            NavBtnGroupSystemConfig.Visible = SharedVariables.Instance.LoginUser.User.RoleId <= SharedVariables.PMRoleId; // 店长，超管可见
        }

        #endregion

        #region Refresh View

        private void RefreshView()
        {
            try
            {
                RefreshShopView();
                RefreshCategoryView();
                RefreshPayTypeView();
                RefreshRoleColumnView();
            }
            catch
            {
                XtraMessageBox.Show("获取数据失败，请稍后重试", "提示", MessageBoxButtons.OK);
            }
        }

        private void RefreshPayTypeView()
        {
            if (GridControlPayType.Visible)
            {
                var listResult = PayTypeBusiness.Instance.GetPayTypes();
                GridControlPayType.DataSource = listResult;
                GridViewDefaultPayType.RefreshData();

                GridDefaultView = GridViewDefaultPayType as ColumnView;
            }
        }

        private void RefreshCategoryView()
        {
            if (GridControlCategory.Visible)
            {
                var listResult = CategoryBusiness.Instance.GetCategories();
                GridControlCategory.DataSource = listResult;
                GridViewDefaultCategory.RefreshData();

                GridDefaultView = GridViewDefaultCategory as ColumnView;
            }
        }

        private void RefreshShopView()
        {
            if (GridControlShop.Visible)
            {
                var listResult = ShopBusiness.Instance.GetShops();
                GridControlShop.DataSource = listResult;
                GridViewDefaultShop.RefreshData();

                GridDefaultView = GridViewDefaultShop as ColumnView;
            }
        }

        private void RefreshRoleColumnView()
        {
            if (GridControlRoleColumn.Visible)
            {
                var listRoleColumn = RoleBusiness.Instance.GetRoleColumns();
                GridControlRoleColumn.DataSource = listRoleColumn;
                GridViewDefaultRoleColumn.RefreshData();

                GridDefaultView = GridViewDefaultRoleColumn as ColumnView;
            }
        }

        #endregion

        private void mNavBarControl_Resize(object sender, EventArgs e)
        {
            var control = ((NavBarControl)sender);
            int width = control.Width + FuncGroupContainer.Padding.Left;
            FuncGroupContainer.Width = width;
        }

        private void NBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (BtnClicked != null)
            {
                BtnClicked(this, new NavBarClickedArgs() { FunctionTypeName = ((NavBarItem)sender).Caption });
            }

            GridControlShop.Visible = sender == NBarItemShop;
            GridControlCategory.Visible = sender == NBarItemCategory;
            GridControlPayType.Visible = sender == NBarItemPayType;
            GridControlRoleColumn.Visible = sender == NBarItemRoleColumn;

            ButtonAdd.Enabled = sender != NBarItemRoleColumn;
            ButtonUpdate.Enabled = true;
            RefreshView();
        }

        private void ButtonAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NBarItemShop.Links[0].State == ObjectState.Selected)
            {
                new FmShopInfo().ShowDialog();
            }
            else if (NBarItemCategory.Links[0].State == ObjectState.Selected)
            {
                new FmCategoryInfo().ShowDialog();
            }
            else if (NBarItemPayType.Links[0].State == ObjectState.Selected)
            {
                new FmPayTypeInfo().ShowDialog();
            }

        }

        private void ButtonUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GridDefaultView == null || GridDefaultView.SelectedRowsCount <= 0)
                return;

            if (NBarItemShop.Links[0].State == ObjectState.Selected)
            {
                new FmShopInfo(GridViewDefaultShop.GetRow(GridViewDefaultShop.GetSelectedRows()[0]) as ShopInfo).ShowDialog();
            }
            else if (NBarItemCategory.Links[0].State == ObjectState.Selected)
            {
                new FmCategoryInfo(GridViewDefaultCategory.GetRow(GridViewDefaultCategory.GetSelectedRows()[0]) as CategoryInfo).ShowDialog();
            }
            else if (NBarItemPayType.Links[0].State == ObjectState.Selected)
            {
                new FmPayTypeInfo(GridViewDefaultPayType.GetRow(GridViewDefaultPayType.GetSelectedRows()[0]) as PayTypeInfo).ShowDialog();
            }
            else if (NBarItemRoleColumn.Links[0].State == ObjectState.Selected)
            {
                var curRoleColumnsInfo = GridViewDefaultRoleColumn.GetRow(GridViewDefaultRoleColumn.GetSelectedRows()[0]) as RoleColumnsInfo;

                new FmRoleDataViewInfo(curRoleColumnsInfo.Role.Id).ShowDialog();
            }
        }

        private void ButtonDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UICommon.DeleteWarning())
            {
                if (NBarItemShop.Links[0].State == ObjectState.Selected)
                {

                }
                else if (NBarItemCategory.Links[0].State == ObjectState.Selected)
                {

                }
                else if (NBarItemPayType.Links[0].State == ObjectState.Selected)
                {

                }
            }
        }

        private void ButtonRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshView();
        }

        private void GridViewDefault_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridDefaultView = sender as ColumnView;

            if (GridDefaultView != null)
            {
                if (GridDefaultView.IsRowSelected(e.ControllerRow))
                {
                    GridDefaultView.SelectRow(e.ControllerRow);
                }

                //ButtonUpdate.Enabled = GridDefaultView.SelectedRowsCount > 0;
            }
        }

        private void GridViewDefaultRoleColumn_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridDefaultView = sender as ColumnView;
            if (GridDefaultView != null)
            {
                var curRoleColumnsInfo = GridDefaultView.GetRow(e.FocusedRowHandle) as RoleColumnsInfo;
                ButtonUpdate.Enabled = curRoleColumnsInfo.Role.Id != SharedVariables.AdminRoleId;
            }
        }
    }

    public class NavBarClickedArgs : EventArgs
    {
        public string FunctionTypeName { get; set; }
    }
}

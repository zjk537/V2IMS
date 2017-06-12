using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Business;
using DevExpress.XtraGrid.Views.Base;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.SystemManager
{
    public partial class FmRoleDataViewInfo : FormSimpleDialogBase
    {
        private int roleId = 1;// 超管
        public FmRoleDataViewInfo()
        {
            InitializeComponent();
            InitializeComponentExtend();
        }

        public FmRoleDataViewInfo(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
            InitializeComponentExtend();
        }
        private void InitializeComponentExtend()
        {
            RefreshView();
            ControlsBinding();
        }

        private List<TableColumnInfo> mListDisabledColumn = null;
        private List<TableColumnInfo> ListDisabledColumn
        {
            get
            {
                if (mListDisabledColumn == null)
                {
                    mListDisabledColumn = RoleBusiness.Instance.GetRoleColumns(roleId, false);
                }
                mListDisabledColumn = mListDisabledColumn ?? new List<TableColumnInfo>();
                return mListDisabledColumn;
            }
            set
            {
                mListDisabledColumn = value;
            }
        }

        private List<TableColumnInfo> mListEnabledColumn = null;
        private List<TableColumnInfo> ListEnabledColumn
        {
            get
            {
                if (mListEnabledColumn == null)
                {
                    mListEnabledColumn = RoleBusiness.Instance.GetRoleColumns(roleId, true);
                }
                mListEnabledColumn = mListEnabledColumn ?? new List<TableColumnInfo>();

                return mListEnabledColumn;
            }
            set
            {
                mListEnabledColumn = value;
            }
        }


        private void ControlsBinding()
        {
            Btn_OK.Click += btnOk_Click;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                RoleBusiness.Instance.UpdateRoleColumns(roleId, this.ListEnabledColumn);
                //if (roleId == SharedVariables.Instance.LoginUser.User.RoleId)
                //{
                //    SharedVariables.Instance.LoginUser.ResetRoleColumns();
                //}
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        public void RefreshView()
        {
            btnRight.Enabled = btnRightAll.Enabled = !(this.ListDisabledColumn.Count == 0);
            btnLeft.Enabled = btnLeftAll.Enabled = !(this.ListEnabledColumn.Count == 0);

            GridControlDisableColumn.DataSource = this.ListDisabledColumn;
            GridViewDisabledColumn.RefreshData();
            GridControlDisableColumn.MainView = GridViewDisabledColumn as ColumnView;

            GridControlEnabledColumn.DataSource = this.ListEnabledColumn;
            GridViewEnabledColumn.RefreshData();

            GridControlEnabledColumn.MainView = GridViewEnabledColumn as ColumnView;
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            ListEnabledColumn.AddRange(ListDisabledColumn);
            ListDisabledColumn.Clear();
            RefreshView();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            var disabledView = GridControlDisableColumn.MainView as ColumnView;

            if (disabledView.SelectedRowsCount > 0)
            {
                var curColumnInfo = disabledView.GetRow(disabledView.GetSelectedRows()[0]) as TableColumnInfo;
                if (curColumnInfo == null) return;

                ListDisabledColumn.Remove(curColumnInfo);
                ListEnabledColumn.Add(curColumnInfo);
                RefreshView();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            var enabledView = GridControlEnabledColumn.MainView as ColumnView;

            if (enabledView.SelectedRowsCount > 0)
            {
                var curColumnInfo = enabledView.GetRow(enabledView.GetSelectedRows()[0]) as TableColumnInfo;
                if (curColumnInfo == null) return;

                ListEnabledColumn.Remove(curColumnInfo);
                ListDisabledColumn.Add(curColumnInfo);
                RefreshView();
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {

            ListDisabledColumn.AddRange(ListEnabledColumn);
            ListEnabledColumn.Clear();
            RefreshView();
        }
    }
}
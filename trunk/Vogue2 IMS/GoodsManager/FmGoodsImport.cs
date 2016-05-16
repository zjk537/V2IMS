using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Business;
using System.Threading.Tasks;
using Vogue2_IMS.Common;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsImport : DevExpress.XtraEditors.XtraForm
    {
        DataTable _DataSource = new DataTable("SourceTable");
        DataTable mDataSource
        {
            get { if (_DataSource == null) _DataSource = new DataTable("SourceTable"); return _DataSource; }
            set
            {
                _DataSource = value ?? new DataTable("SourceTable");
                _DataSource.TableName = "SourceTable";
            }
        }

        public FmGoodsImport()
        {
            InitializeComponent();

            Vogue2_IMS.Common.DevViewDefine.ResetToNormalView(this.gridControl1.MainView,false);           
        }

        private void btnCheckFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.InitialDirectory = "C:\\";
                ofd.Filter = "Excel(*.xls;*.xlsx)|*.xls;*.xlsx";
                //ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFilePath.Text = ofd.FileName;
                    mDataSource.Dispose();//释放原表

                    mDataSource = DataImportBusiness.Instance.ToDataTable(txtSourceFilePath.Text);
                }
            }
            catch (Exception ex)
            {
                mDataSource.Dispose();//释放原表
                XtraMessageBox.Show("读取文件失败，文件可能正在使用中，请重新选择文件！", "提示", MessageBoxButtons.OK);              
            }
            finally
            {
                this.gridControl1.DataSource = mDataSource;
                this.gridControl1.MainView.RefreshData();
            }
        }

        private void btnUpLoadAndRefresh_Click(object sender, EventArgs e)
        {
            if (mDataSource.Rows != null && mDataSource.Rows.Count > 0)
            {
                FmProgressBar progressBar = new FmProgressBar("数据导入中........");
                var tempTable = mDataSource.Copy();
                string runMsg = string.Empty;
                //bool isError = false;
                Task task = new Task(() =>
                {
                    try
                    {
                        DataColumn dataColumn = new DataColumn("UserId", typeof(int));
                        tempTable.Columns.Add(dataColumn);
                     
                        dataColumn.SetOrdinal(0);
                        foreach (DataRow datarow in tempTable.Rows)
                        {
                            datarow[dataColumn] = SharedVariables.Instance.LoginUser.User.Id;
                        }

                        PurchaseGoodsBusiness.Instance.BulkInsertPurchaseGoods(tempTable);
                        runMsg = "导入成功";
                    }
                    catch (Exception ex)
                    {
                        runMsg = string.Format("导入失败：{0}", ex.ToString());
                    }
                    finally
                    {
                        tempTable.Dispose();
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            progressBar.DialogResult = DialogResult.OK;
                            XtraMessageBox.Show(runMsg, "提示", MessageBoxButtons.OK);
                        }));
                    }
                });

                task.Start();

                progressBar.ShowDialog();

                if (PayTypeBusiness.Instance.OnPayTypeUpdated != null)
                {
                    PayTypeBusiness.Instance.OnPayTypeUpdated(this, null);
                }
                if (SupplierBusiness.Instance.OnSupplierUpdated != null)
                {
                    SupplierBusiness.Instance.OnSupplierUpdated(this, null);
                }
                if (CategoryBusiness.Instance.OnCategoryUpdated != null)
                {
                    CategoryBusiness.Instance.OnCategoryUpdated(this, null);
                }

                if (PurchaseGoodsBusiness.Instance.OnPurchaseGoodsUpdated != null)
                {
                    PurchaseGoodsBusiness.Instance.OnPurchaseGoodsUpdated(this, null);
                }
            }
        }
    }
}
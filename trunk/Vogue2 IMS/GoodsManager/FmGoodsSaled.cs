using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common.FormBase;
using DevExpress.XtraEditors;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.ReceiptManager;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmGoodsSaled : RibbonFormSimpleDialogBase
    {
        private List<SaledGoodsInfo> mListGoods = null;

        public ColumnView MainView
        {
            get { return GridViewGoodsInfo.MainView as ColumnView; }

            private set { GridViewGoodsInfo.MainView = value; LoadCusomterLayout(); }
        }

        bool saveWithPrint = false;
        public FmGoodsSaled(List<SaledGoodsInfo> listGoods = null)
            : base(Common.Language.Chinese)
        {
            InitializeComponent();
            mListGoods = listGoods ?? new List<SaledGoodsInfo>();

            mListGoods.ForEach(saledGoodsInfo =>
                {
                    //在库的商品，走默认的付款方式，标价为售价，没折扣，未付款
                    // 预定的商品，不做修改
                    if (saledGoodsInfo.Goods.Status == (int)GoodsStatus.In)
                    {
                        saledGoodsInfo.Goods.SalePrice = saledGoodsInfo.Goods.MarkPrice;
                        saledGoodsInfo.Goods.Discount = 0;
                        saledGoodsInfo.Goods.Paid = (int)GoodsPaid.NoPaid;
                    }

                    saledGoodsInfo.SaledRecord.GoodsId = saledGoodsInfo.Goods.Id;

                    if (string.IsNullOrEmpty(saledGoodsInfo.SaledRecord.Operator))
                    {
                        saledGoodsInfo.SaledRecord.CreatedDate = DateTime.Now;
                        saledGoodsInfo.SaledRecord.UserId = ConfigManager.LoginUser.uid; //SharedVariables.Instance.LoginUser.User.Id;
                        saledGoodsInfo.SaledRecord.Operator = ConfigManager.LoginUser.username; //SharedVariables.Instance.LoginUser.User.Name;
                    }
                });
            InitializeComponentExtend();
        }

        private void InitializeComponentExtend()
        {
            GridViewGoodsInfo.DataSource = mListGoods;
            SetDefaultMainView();
            btnPrint.PerformClick();
            this.ComBoxPayType.Items.AddRange(SharedVariables.Instance.PayTypeInfos);
        }

        #region Layout

        private string DefaultLayoutFile
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("DefaultLayout.{0}.{1}.xml", this.Name, this.MainView.Name));
            }
        }

        private string CustomerLayoutFile
        {
            get
            {
                return Path.Combine(SharedVariables.Instance.LayoutXmlPath, string.Format("CustomerLayout.{0}.{1}.xml", this.Name, this.MainView.Name));
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
                    var tempThis = new FmGoodsSaled();

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
            if (Directory.Exists(DefaultViewPath) && File.Exists(DefaultViewPath))
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

        void ListGoods_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            decimal markSum = 0;
            decimal discountSum = 0;
            decimal saledSum = 0;
            var tempList = sender as List<SaledGoodsInfo>;
            if (tempList != null)
            {
                tempList.ForEach(saledGoods =>
                {
                    if (saledGoods != null)
                    {
                        discountSum += saledGoods.Goods.PrimePrice.HasValue ? saledGoods.Goods.PrimePrice.Value : 0;
                        markSum += saledGoods.Goods.MarkPrice.HasValue ? saledGoods.Goods.MarkPrice.Value : 0;
                        saledSum += saledGoods.Goods.SalePrice.HasValue ? saledGoods.Goods.SalePrice.Value : 0;
                    }
                });
            }

            TxtMarkSum.EditValue = markSum;
            TxtDiscountSum.EditValue = discountSum;
            TxtSaledSum.EditValue = saledSum;
        }

        private void barBtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var totalPrice = mListGoods.Sum(goods => goods.Goods.MarkPrice.HasValue ? goods.Goods.MarkPrice.Value : 0);
                FmGoodsSaledConfirm fmSaledConfirm = new FmGoodsSaledConfirm(totalPrice);

                if (fmSaledConfirm.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }


                //在库的商品，改为售出状态，预定的商品不变
                var saledGoods = new List<SaledGoodsInfo>();
                var catchGoods = new List<SaledGoodsInfo>();
                var selectedPayType = (PayTypeInfo)fmSaledConfirm.PayType;
                var bankCharge = fmSaledConfirm.BankCharge;

                int i = 0;
                mListGoods.ForEach(goods =>
                {
                    i++;
                    goods.PayType = selectedPayType;
                    goods.SaledRecord.PayCharge = i == 1 ? (goods.SaledRecord.PayCharge.HasValue ? goods.SaledRecord.PayCharge.Value + bankCharge : bankCharge) : 0;
                    goods.SaledRecord.UserId = ConfigManager.LoginUser.uid; //SharedVariables.Instance.LoginUser.User.Id;
                    goods.SaledRecord.CustomerName = txtCustomerName.Text.Trim();
                    goods.SaledRecord.CustomerPhone = txtCustomerPhone.Text.Trim();
                    //在库商品，改为售出状态， 
                    if (goods.Goods.Status == (int)GoodsStatus.Saled || goods.Goods.Status == (int)GoodsStatus.In)
                    {
                        goods.Goods.Status = (int)GoodsStatus.Saled;
                        saledGoods.Add(goods);
                    }

                    //预定和取回的,只做修改操作 
                    if (goods.Goods.Status == (int)GoodsStatus.Catch || goods.Goods.Status == (int)GoodsStatus.GetOut)
                    {
                        catchGoods.Add(goods);
                    }

                });

                //上面一步把在库的改为了售出，这里要查列表中所有售出状态的商品，做售出操作
                Business.SaleGoodsBusiness.Instance.BatchAddSaledGoods(saledGoods);
                Business.SaleGoodsBusiness.Instance.BatchUpdateSaledGoods(catchGoods);

                if (saveWithPrint)
                {
                    Print(mListGoods);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(String.Format("售出失败:\r\n{0}", ex.ToString()), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print(List<SaledGoodsInfo> listSaledGoods)
        {
            //if (listSaledGoods == null || listSaledGoods.Count == 0) return;

            //var listSaledOrderInfo = new List<SaledGoodsOrderInfo>();
            //var totalMarkPrice = listSaledGoods.Sum(record => record.Goods.MarkPrice);
            //var totalPrice = listSaledGoods.Sum(record => record.Goods.SalePrice);
            //var totalDiscount = listSaledGoods.Sum(record => record.Goods.Discount);
            //listSaledGoods.ForEach(goods =>
            //{
            //    listSaledOrderInfo.Add(new SaledGoodsOrderInfo(goods, 1)
            //    {
            //        TotalMarkPrice = totalMarkPrice.HasValue ? totalMarkPrice.Value : (decimal)0,
            //        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0,
            //        TotalDiscount = totalDiscount.HasValue ? totalDiscount.Value : (decimal)0
            //    });
            //    listSaledOrderInfo.Add(new SaledGoodsOrderInfo(goods, 2)
            //    {
            //        TotalMarkPrice = totalMarkPrice.HasValue ? totalMarkPrice.Value : (decimal)0,
            //        TotalPrice = totalPrice.HasValue ? totalPrice.Value : (decimal)0,
            //        TotalDiscount = totalDiscount.HasValue ? totalDiscount.Value : (decimal)0
            //    });
            //});

            //var receiptView = new FmReceiptView();
            //receiptView.InitializeReceiptView<SaledGoodsOrderInfo>(listSaledOrderInfo);
            //receiptView.ShowDialog();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            saveWithPrint = !saveWithPrint;
            //MessageBox.Show(saveWithPrint.ToString());
        }

        private void btnDefaultLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainView = GridDefaultView;
        }

        private void btnAdvBandedLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainView = GridAdvBandedView;
        }

        private void btnCardLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainView = GridLayoutView;
        }

        private void btnSaveViewLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveLayout();
        }

        private void btnRestoreViewLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.RestoreLayout();
        }

        private void btnSetMainView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SaveDefaultMainViewName();
        }

        private void btnUpdatedGoods_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainView.SelectedRowsCount > 0)
            {
                var dataIndex = MainView.GetDataSourceRowIndex(MainView.GetSelectedRows()[0]);

                //FmGoodsSaledMondify goodsInfo = new FmGoodsSaledMondify(mListGoods[dataIndex]);
                //if (goodsInfo.ShowDialog() == DialogResult.OK)
                //{
                //    mListGoods[dataIndex] = goodsInfo.SaledGoodsInfo;
                //    MainView.RefreshData();
                //    ListGoods_CollectionChanged(mListGoods, null);
                //}
            }
        }

        private void btnDeleteGoods_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainView.DeleteSelectedRows();

            ListGoods_CollectionChanged(mListGoods, null);
        }

        private void GridLayoutView_MouseDown(object sender, MouseEventArgs e)
        {
            var gridMainView = (GridView)sender;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridMainView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    //取得选定行信息  
                    var goodsInfo = gridMainView.GetRow(hInfo.RowHandle) as SaledGoodsInfo;

                    //var fmGoodsInfo = new FmGoodsSaledMondify(goodsInfo);
                    //if (fmGoodsInfo.ShowDialog() == DialogResult.OK)
                    //{
                    //    var result = fmGoodsInfo.SaledGoodsInfo;
                    //    Business.SaleGoodsBusiness.Instance.UpdateSaledGoods(result);
                    //}
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var goodsCode = this.txtGoodsCode.Text.Trim();
            if (!string.IsNullOrEmpty(goodsCode))
            {
                try
                {
                    GoodsInfo info = new GoodsInfo() { Code = goodsCode };
                    var goodsList = GoodsBusiness.Instance.GetGoodsInfos(info);
                    if (goodsList == null)
                    {
                        if (MessageBox.Show(string.Format("编号为：【{0}】的商品不存在\r\n重新输入点击Yes，取消点击 No", goodsCode), "提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            this.txtGoodsCode.SelectAll();
                        }
                        return;
                    }


                    foreach (GoodsInfo goods in goodsList)
                    {
                        if (mListGoods.FirstOrDefault(g => g.Goods.Id == goods.Id) != null)
                            continue;
                        //在库的商品，走默认的付款方式，标价为售价，没折扣，未付款
                        // 预定的商品，不做修改
                        if (goods.Status == (int)GoodsStatus.In)
                        {
                            goods.SalePrice = goods.MarkPrice;
                            goods.Discount = 0;
                            goods.Paid = (int)GoodsPaid.NoPaid;
                        }

                        var saledGoodsinfo = new SaledGoodsInfo()
                        {
                            Goods = goods,
                            SaledRecord = new Model.DataModel.SaledRecordInfo()
                            {
                                CreatedDate = DateTime.Now,
                                GoodsId = goods.Id,
                                UserId = ConfigManager.LoginUser.uid, //SharedVariables.Instance.LoginUser.User.Id,
                                Operator = ConfigManager.LoginUser.username,
                            }
                        };

                        mListGoods.Add(saledGoodsinfo);
                    }

                    MainView.RefreshData();
                    ListGoods_CollectionChanged(mListGoods, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.txtGoodsCode.SelectAll();
            }
        }

    }
}
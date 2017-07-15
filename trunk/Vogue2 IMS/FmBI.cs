using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Common.FormBase;
using Vogue2_IMS.Business.ViewModel;
using DevExpress.XtraCharts;
using Vogue2_IMS.Business;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using Vogue2_IMS.UserControls;

namespace Vogue2_IMS
{
    public partial class FmBI : DevExpress.XtraEditors.XtraForm
    {
        List<ProInfo> salesDataSource = new List<ProInfo>();
        public List<ProInfo> SalesDataSource
        {
            get
            {
                if (salesDataSource == null)
                {
                    salesDataSource = new List<ProInfo>();
                }

                return salesDataSource;
            }
            set
            {
                salesDataSource.Clear();

                chartQuShi.Series[0].DataSource = SalesDataSource;
                chartQuShi.Series[1].DataSource = SalesDataSource;
                chartBFB.Series[0].DataSource = SalesDataSource;
                chartBFB.Series[1].DataSource = SalesDataSource;

                salesDataSource.AddRange(value);

                chartQuShi.Series[0].DataSource = SalesDataSource;
                chartQuShi.Series[1].DataSource = SalesDataSource;
                chartBFB.Series[0].DataSource = SalesDataSource;
                chartBFB.Series[1].DataSource = SalesDataSource;

             
                //chartQuShi.Refresh();
               RefreshData();
            }
        }

        DashBoard viewDasboardSource = new DashBoard();
        public DashBoard ViewDasboardSource
        {
            get { return viewDasboardSource; }
            set
            {
                viewDasboardSource = value == null ? new DashBoard() : value;

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.ucGoodsTotalJiHuo.Title.Text = viewDasboardSource.jinhuoliang.ToString();
                        this.ucGoodsTotalShouChu.Title.Text = viewDasboardSource.xiaoshouliang.ToString();

                        this.ucTotalJSWDK.Title.Text = viewDasboardSource.jsweidakuan.ToString();
                        this.ucTotalJSKC.Title.Text = viewDasboardSource.jskucun.ToString();
                        this.ucTotalJSCQ.Title.Text = viewDasboardSource.jschaoqi.ToString();

                        this.ucTotalZYWDK.Title.Text = viewDasboardSource.jhweidakuan.ToString();
                        this.ucTotalZYKC.Title.Text = viewDasboardSource.jhkucun.ToString();
                        this.ucTotalZYCQ.Title.Text = viewDasboardSource.jhchaoqi.ToString();
                    }));

                    return;
                }

                this.ucGoodsTotalJiHuo.Title.Text = viewDasboardSource.jinhuoliang.ToString();
                this.ucGoodsTotalShouChu.Title.Text = viewDasboardSource.xiaoshouliang.ToString();

                this.ucTotalJSWDK.Title.Text = viewDasboardSource.jsweidakuan.ToString();
                this.ucTotalJSKC.Title.Text = viewDasboardSource.jskucun.ToString();
                this.ucTotalJSCQ.Title.Text = viewDasboardSource.jschaoqi.ToString();

                this.ucTotalZYWDK.Title.Text = viewDasboardSource.jhweidakuan.ToString();
                this.ucTotalZYKC.Title.Text = viewDasboardSource.jhkucun.ToString();
                this.ucTotalZYCQ.Title.Text = viewDasboardSource.jhchaoqi.ToString();
            }
        }

        public FmBI()
        {
            InitializeComponent();

            this.ucGoodsTotalJiHuo.Desc.Text = "进货量";
            this.ucGoodsTotalJiHuo.Title.Text = "0";
            this.ucGoodsTotalJiHuo.Title.ForeColor = Color.Green;
            this.ucGoodsTotalJiHuo.Title.Cursor = DefaultCursor;
            //this.ucGoodsTotalJiHuo.Font.Underline = false;

            this.ucGoodsTotalShouChu.Desc.Text = "销售量";
            this.ucGoodsTotalShouChu.Title.Text = "0";
            this.ucGoodsTotalShouChu.Title.ForeColor = Color.Blue;
            this.ucGoodsTotalShouChu.Title.Cursor = DefaultCursor;

            #region init total

            this.ucTotalJSWDK.Desc.Text = "待打款";
            this.ucTotalJSWDK.Title.Text = "0";
            this.ucTotalJSWDK.Title.ForeColor = Color.Blue;

            this.ucTotalJSKC.Desc.Text = "库存";
            this.ucTotalJSKC.Title.Text = "0";
            this.ucTotalJSKC.Title.ForeColor = Color.Green;

            this.ucTotalJSCQ.Desc.Text = "超期";
            this.ucTotalJSCQ.Title.Text = "0";
            this.ucTotalJSCQ.Title.ForeColor = Color.Red;

            this.ucTotalZYWDK.Desc.Text = "待打款";
            this.ucTotalZYWDK.Title.Text = "0";
            this.ucTotalZYWDK.Title.ForeColor = Color.Blue;

            this.ucTotalZYKC.Desc.Text = "库存";
            this.ucTotalZYKC.Title.Text = "0";
            this.ucTotalZYKC.Title.ForeColor = Color.Green;

            this.ucTotalZYCQ.Desc.Text = "超半年";
            this.ucTotalZYCQ.Title.Text = "0";
            this.ucTotalZYCQ.Title.ForeColor = Color.Red;

            #endregion
        }

        public void RefreshData()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    chartBFB.Refresh();
                    chartQuShi.Refresh();
                    this.Enabled = true;
                }));

                return;
            }

            chartBFB.Refresh();
            chartQuShi.Refresh();
            this.Enabled = true;
        }


        public LabelControl TotalJinHuo
        {
            get
            {
                return this.ucGoodsTotalJiHuo.Title;
            }
            set { this.ucGoodsTotalJiHuo.Title = value; }
        }

        public LabelControl TotalShouChu
        {
            get
            {
                return this.ucGoodsTotalShouChu.Title;
            }
            set { this.ucGoodsTotalShouChu.Title = value; }
        }

        public LabelControl TotalJSCQ
        {
            get { return this.ucTotalJSCQ.Title; }
            set { this.ucTotalJSCQ.Title = value; }
        }

        public LabelControl TotalJSKC
        {
            get { return this.ucTotalJSKC.Title; }
            set { this.ucTotalJSKC.Title = value; }
        }

        public LabelControl TotalJSWDK
        {
            get { return this.ucTotalJSWDK.Title; }
            set { this.ucTotalJSWDK.Title = value; }
        }

        public LabelControl TotalZYCQ
        {
            get { return this.ucTotalZYCQ.Title; }
            set { this.ucTotalZYCQ.Title = value; }
        }

        public LabelControl TotalZYKC
        {
            get { return this.ucTotalZYKC.Title; }
            set { this.ucTotalZYKC.Title = value; }
        }

        public LabelControl TotalZYWDK
        {
            get { return this.ucTotalZYWDK.Title; }
            set { this.ucTotalZYWDK.Title = value; }
        }
    }
}
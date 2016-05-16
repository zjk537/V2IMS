using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DXWindowsApplication1
{
    public partial class FmNewCustReport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CustReport custReport = null;

        public FmNewCustReport()
        {
            InitializeComponent();
        }

        public FmNewCustReport(CustReport custReport)
        {
            InitializeComponent();
            this.custReport = custReport;
        }

        public CustReport ReportTemp
        {
            get
            {
                bool isChange = true;
                if (custReport == null)
                    custReport = new CustReport();

                custReport.Id = custReport.Id;
                custReport.Name = txtReportName.EditValue.ToString();
                custReport.Remarks = txtReportRemarts.EditValue.ToString();
                custReport.Columns.Add(new CustReportColumn());

                var index = 0;
                foreach (var item in lbIImpressCol.Items)
                {
                    if (custReport.Columns.FindIndex(col => col.Name == item.ToString()) < 0)
                    {
                        custReport.Add<CustReportColumn>(new CustReportColumn() { Index = index, Name = item.ToString(), IsCustomer = false });

                        index++;
                    }
                }

                return custReport;
            }
        }   

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var item = lbCheckCol.SelectedItem;
            lbIImpressCol.Items.Add(item);

            lbCheckCol.Items.Remove(item);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //if(lbIImpressCol.SelectedValue)

            var item = lbIImpressCol.SelectedItem;
            lbCheckCol.Items.Add(item);

            lbIImpressCol.Items.Remove(item);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            int indexTemp = lbIImpressCol.SelectedIndex;
            var item = lbIImpressCol.SelectedItem;
            lbIImpressCol.Items.RemoveAt(indexTemp);

            indexTemp = indexTemp == 0 ? indexTemp : indexTemp - 1;

            lbIImpressCol.Items.Insert(indexTemp, item);

            lbIImpressCol.SelectedIndex = indexTemp;
        }

        private void FmNewCustReport_Load(object sender, EventArgs e)
        {
            if (custReport != null)
            {
                this.txtReportName.EditValue = custReport.Name;
                this.txtReportRemarts.EditValue = custReport.Remarks;
            }

            #region Load Can Check Column (no body)

            #endregion
        }


    }
}
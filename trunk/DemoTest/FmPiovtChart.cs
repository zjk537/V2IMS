using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

namespace DXWindowsApplication1
{
    public partial class FmPiovtChart : RibbonForm
    {
        private CustPovitChartType ChartType = CustPovitChartType.Line;
        private CustReport custReport = null;

        public FmPiovtChart(CustReport custReport)
        {
            InitializeComponent();
            BindEvent();

            this.custReport = custReport;
        }

        public FmPiovtChart(CustReport custReport, CustPovitChartType chartType)
        {
            InitializeComponent();
            BindEvent();

            this.custReport = custReport;
            this.ChartType = chartType;
        }

        private void FmPiovtChart_Load(object sender, EventArgs e)
        {

            lbCalColumns.DisplayMember = lbCampaignByColumns.DisplayMember = lbGroupByColumns.DisplayMember = lbReportColumns.DisplayMember = "Name";

            custReport.Columns.ForEach(
                col =>
                {
                    lbReportColumns.Items.Add(col);
                }
                );
        }


        #region ListBoxItemMoveEvent

        private void BindEvent()
        {

            lbReportColumns.DragDrop += listBox_DragDrop;
            lbGroupByColumns.DragDrop += listBox_DragDrop;
            lbCampaignByColumns.DragDrop += listBox_DragDrop;
            lbCalColumns.DragDrop += listBox_DragDrop;

            lbReportColumns.DragEnter += listBox_DragEnter;
            lbGroupByColumns.DragEnter += listBox_DragEnter;
            lbCampaignByColumns.DragEnter += listBox_DragEnter;
            lbCalColumns.DragEnter += listBox_DragEnter;

            lbReportColumns.MouseDown += listBox_MouseDown;
            lbGroupByColumns.MouseDown += listBox_MouseDown;
            lbCampaignByColumns.MouseDown += listBox_MouseDown;
            lbCalColumns.MouseDown += listBox_MouseDown;

            lbReportColumns.MouseMove += listBox_MouseMove;
            lbGroupByColumns.MouseMove += listBox_MouseMove;
            lbCampaignByColumns.MouseMove += listBox_MouseMove;
            lbCalColumns.MouseMove += listBox_MouseMove;

            lbReportColumns.MouseUp += listBox_MouseUp;
            lbGroupByColumns.MouseUp += listBox_MouseUp;
            lbCampaignByColumns.MouseUp += listBox_MouseUp;
            lbCalColumns.MouseUp += listBox_MouseUp;
        }

        private bool isLeftMouseButtonDown = false;

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (isLeftMouseButtonDown)
            {
                var destListBox = sender as ListBoxControl;
                int indexoftarget = destListBox.IndexFromPoint(destListBox.PointToClient(new Point(e.X, e.Y)));

                if (e.Data.GetDataPresent(typeof(ListBoxControl)))
                {
                    var srcListBox = e.Data.GetData(typeof(ListBoxControl)) as ListBoxControl;
                    var item = srcListBox.SelectedItem;

                    if (srcListBox != lbReportColumns)
                    {
                        srcListBox.Items.Remove(item);
                    }

                    if (indexoftarget >= 0)
                    {
                        destListBox.Items.Insert(indexoftarget, item);
                    }
                    else
                    {
                        destListBox.Items.Add(item);
                    }

                    destListBox.SelectedIndex = indexoftarget;
                }

                isLeftMouseButtonDown = false;
            }
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            isLeftMouseButtonDown = true;
        }

        private void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLeftMouseButtonDown)
            {
                var lb = sender as ListBoxControl;
                if (lb.SelectedItem != null)
                {
                    lb.DoDragDrop(lb, DragDropEffects.Move);
                }
            }
        }

        private void listBox_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftMouseButtonDown = false;
        }

        #endregion

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public CustPovitChart CurrentPiovtChart
        {
            get
            {
                var custPovitChart = new CustPovitChart();
                custPovitChart.Title = txtChartTitle.EditValue.ToString();
                custPovitChart.Width = int.Parse(txtWidth.EditValue.ToString());
                custPovitChart.Height = int.Parse(txtHeight.EditValue.ToString());
                custPovitChart.SheetName = txtWidth.EditValue.ToString();

                custPovitChart.PovitTable = new CustPovitTable();
                custPovitChart.PovitTable.Visible = false;
                custPovitChart.PovitTable.Name = string.Format("{0}Table", custPovitChart.Title);

                foreach (var item in lbGroupByColumns.Items)
                {
                    custPovitChart.PovitTable.RowField.Add(item as CustReportColumn);
                }
                foreach (var item in lbCampaignByColumns.Items)
                {
                    custPovitChart.PovitTable.ColumnField.Add(item as CustReportColumn);
                }
                foreach (var item in lbCalColumns.Items)
                {
                    custPovitChart.PovitTable.DataField.Add(item as CustReportColumn);
                }

                return custPovitChart;
            }
        }
    }
}
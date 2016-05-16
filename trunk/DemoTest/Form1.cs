using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Reflection;
using DevExpress.XtraBars.Ribbon;
using DXWindowsApplication1;

namespace WindowsApplication1
{
    public partial class Form1 : RibbonForm
    {
        #region Excel Applaction

        object missing = Type.Missing;
        Excel._Workbook currentBook;
        Excel._Worksheet currentSheet;
        Excel._Application excelInstance;
        Excel._Application ExcelInstance
        {
            get
            {
                if (excelInstance == null)
                {
                    excelInstance = new Excel.ApplicationClass();

                    excelInstance.Visible = true;
                }

                return excelInstance;
            }
        }

        #endregion
        CustReport currentCustReport = null;
        List<CustReport> listItem = new List<CustReport>();

        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = listItem;
        }

        public void CreateBook()
        {
            var reportTemp = gridView1.GetFocusedRow() as CustReport;
            currentBook = ExcelInstance.Workbooks.Add();
            currentSheet = (Excel._Worksheet)currentBook.Sheets.Add();
            currentSheet.Name = reportTemp.Name;

            DataTable dt = new DataTable(reportTemp.Name);
            reportTemp.Columns.ForEach(col => { dt.Columns.Add(col.Name); });

            AddSourceToExcels(dt, null);

            //currentSheet.p
        }

        public void AddSourceToExcels(DataTable dt, Excel._Worksheet sheet)
        {
            #region Columns

            var cell = currentSheet.Cells[1, 1];
            var cellEnd = currentSheet.Cells[1, dt.Columns.Count];
            var range = currentSheet.Range[cell, cellEnd];

            object[,] columns = new object[1, dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columns[0, i] = dt.Columns[i].ColumnName;
            }

            range.Value2 = columns;

            #endregion

            #region Rows

            var rows = new object[dt.Rows.Count, dt.Columns.Count];

            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    rows[rowIndex, colIndex] = dt.Rows[rowIndex][colIndex];
                }
            }

            cell = currentSheet.Cells[2, 1];
            cellEnd = currentSheet.Cells[dt.Rows.Count + 1, dt.Columns.Count];
            range = currentSheet.Range[cell, cellEnd];

            range.Value2 = rows;

            range = currentSheet.Range[currentSheet.Cells[1, 1], currentSheet.Cells[dt.Rows.Count + 1, dt.Columns.Count]];

            var objects = currentSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,
                range, Missing.Value, Excel.XlYesNoGuess.xlYes, Missing.Value);

            Excel.PivotTables tables = (Excel.PivotTables)currentSheet.PivotTables();

            objects.Name = dt.TableName;

            //objects.ShowTotals = true;

            #endregion
        }

        private void InsertPivot()
        {
            var reportTemp = gridView1.GetFocusedRow() as CustReport;

            #region temp

            //var sheet = (Excel._Worksheet)currentBook.Sheets.Add();
            //sheet.Name = "saaaa";

            //Excel.PivotTable pTable = sheet.PivotTableWizard(Excel.XlPivotTableSourceType.xlDatabase,
            //    reportTemp.Name, sheet.get_Range("A5"), "aaaa");

            //var item = ((Excel.PivotField)pTable.PivotFields(2));
            //item.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
            //var item2 = ((Excel.PivotField)pTable.PivotFields(3));
            //item2.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
            //var item3 = ((Excel.PivotField)pTable.PivotFields(1));
            //item3.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;


            //#endregion

            //#region PiovtChart

            //var charts = (Excel.ChartObjects)sheet.ChartObjects();
            //var chart = charts.Add(10, 100, 400, 240);
            //chart.Chart.HasTitle = true;
            //chart.Chart.HasLegend = false;
            //chart.Chart.ChartWizard("aaaa");
            //chart.Chart.ChartTitle.Text = "Value";

            //chart.Chart.Name = "";

            //var se = (Excel.Series)chart.Chart.SeriesCollection(3);

            //var reportTemp = gridView1.GetFocusedRow() as CustReport;
            #endregion

            #region PivotTable

            reportTemp.PovitTables.ForEach(tab =>
            {
                var sheet = (Excel._Worksheet)currentBook.Sheets.Add();
                sheet.Name = tab.Name;
                //sheet.Visible = !tab.Visible ? Excel.XlSheetVisibility.xlSheetVeryHidden : Excel.XlSheetVisibility.xlSheetVisible;

                Excel.PivotTable pTable = sheet.PivotTableWizard(Excel.XlPivotTableSourceType.xlDatabase,
                  reportTemp.Name, sheet.get_Range("A1"), tab.Name);

                tab.RowField.ForEach(row =>
                {
                    var item = ((Excel.PivotField)pTable.PivotFields(row.Index + 1));
                    item.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                });

                var item2 = ((Excel.PivotField)pTable.PivotFields("数值"));
                item2.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;

                pTable.CalculatedMembers = Excel.XlPivotFieldOrientation.xlColumnField;
                
                //tab.ColumnField.ForEach(row =>
                //{
                //    var item3 = ((Excel.PivotField)pTable.PivotFields(row.Index + 1));
                //    item3.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                //});
                tab.DataField.ForEach(row =>
                {
                    var item = ((Excel.PivotField)pTable.PivotFields(row.Index+1));
                    item.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
                });
            });

            #endregion

            #region PiovtChart
            reportTemp.PovitCharts.ForEach(item =>
            {
                Excel._Worksheet sheet = null;
                try
                {
                    sheet = currentBook.Sheets.get_Item(item.SheetName) as Excel._Worksheet;
                }
                catch
                {
                    sheet = sheet == null ? (Excel._Worksheet)currentBook.Sheets.Add() : sheet;
                }

                var charts = (Excel.ChartObjects)sheet.ChartObjects();
                var chart = charts.Add(10, 100, item.Width, item.Height);
                chart.Chart.HasTitle = true;
                chart.Chart.HasLegend = false;
                chart.Chart.ChartWizard(item.PovitTable.Name);
                chart.Chart.ChartTitle.Text = item.Title;
            });

            #endregion
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateBook();
            InsertPivot();
        }

        private void btnNewCustReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fmNewReport = new FmNewCustReport();
            if (fmNewReport.ShowDialog() == DialogResult.OK)
            {
                var item = fmNewReport.ReportTemp;
                listItem.Add(item);
                gridView1.RefreshData();
            }
        }

        private void btnUpdateCustReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fmNewReport = new FmNewCustReport(gridView1.GetFocusedRow() as CustReport);
            if (fmNewReport.ShowDialog() == DialogResult.OK)
            {
                var item = fmNewReport.ReportTemp;
                gridView1.RefreshData();
            }
        }

        private void btnPLineChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = gridView1.GetFocusedRow() as CustReport;
            if (report != null)
            {
                var fmPiovtChart = new FmPiovtChart(report, CustPovitChartType.Line);
                if (fmPiovtChart.ShowDialog() == DialogResult.OK)
                {
                    report.Add<CustPovitChart>(fmPiovtChart.CurrentPiovtChart);
                }
            }
            else
            {
                MessageBox.Show("请先创建自定义报表");
            }
        }
    }
}

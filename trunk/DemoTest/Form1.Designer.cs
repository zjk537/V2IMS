using System.Runtime.InteropServices;
namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (excelInstance != null)
            {
                ExcelInstance.Quit();
                Marshal.ReleaseComObject(ExcelInstance);
                excelInstance = null;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNewCustReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateCustReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveCustReport = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnReView = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPivotTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdatePivotTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemovePivotTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnPieChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnColumnChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnLineChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdatePivotChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemovePivotChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewCaColumn = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateCaColumn = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveCaColumn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdatePTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeletePTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnPLineChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnPColumnChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnPPieChart = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.glReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glReportMarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 9;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 8;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "透视表";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "报表";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewCustReport);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUpdateCustReport);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRemoveCustReport);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "报表";
            // 
            // btnNewCustReport
            // 
            this.btnNewCustReport.Caption = "新建";
            this.btnNewCustReport.Id = 7;
            this.btnNewCustReport.LargeGlyph = global::DXWindowsApplication1.Properties.Resources.Ribbon_Report_32x32;
            this.btnNewCustReport.Name = "btnNewCustReport";
            this.btnNewCustReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewCustReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCustReport_ItemClick);
            // 
            // btnUpdateCustReport
            // 
            this.btnUpdateCustReport.Caption = "修改";
            this.btnUpdateCustReport.Id = 26;
            this.btnUpdateCustReport.ImageIndex = 7;
            this.btnUpdateCustReport.ImageIndexDisabled = 7;
            this.btnUpdateCustReport.Name = "btnUpdateCustReport";
            this.btnUpdateCustReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUpdateCustReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateCustReport_ItemClick);
            // 
            // btnRemoveCustReport
            // 
            this.btnRemoveCustReport.Caption = "删除";
            this.btnRemoveCustReport.Id = 30;
            this.btnRemoveCustReport.ImageIndex = 8;
            this.btnRemoveCustReport.ImageIndexDisabled = 8;
            this.btnRemoveCustReport.Name = "btnRemoveCustReport";
            this.btnRemoveCustReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnReView);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "帮助";
            // 
            // btnReView
            // 
            this.btnReView.Caption = "预览";
            this.btnReView.Id = 67;
            this.btnReView.ImageIndex = 8;
            this.btnReView.ImageIndexDisabled = 8;
            this.btnReView.LargeGlyph = global::DXWindowsApplication1.Properties.Resources.NavBar_SouKeReport_32x32;
            this.btnReView.Name = "btnReView";
            this.btnReView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem28_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "退出";
            this.btnExit.Id = 64;
            this.btnExit.LargeGlyph = global::DXWindowsApplication1.Properties.Resources.Ribbon_Exit_32x32;
            this.btnExit.LargeGlyphDisabled = global::DXWindowsApplication1.Properties.Resources.Ribbon_Exit_16x16;
            this.btnExit.Name = "btnExit";
            this.btnExit.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)
                        | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnNewPivotTable
            // 
            this.btnNewPivotTable.Caption = "新建";
            this.btnNewPivotTable.Id = 46;
            this.btnNewPivotTable.Name = "btnNewPivotTable";
            this.btnNewPivotTable.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUpdatePivotTable
            // 
            this.btnUpdatePivotTable.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnUpdatePivotTable.Caption = "更新";
            this.btnUpdatePivotTable.Id = 47;
            this.btnUpdatePivotTable.Name = "btnUpdatePivotTable";
            this.btnUpdatePivotTable.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnRemovePivotTable
            // 
            this.btnRemovePivotTable.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnRemovePivotTable.Caption = "删除";
            this.btnRemovePivotTable.Id = 48;
            this.btnRemovePivotTable.Name = "btnRemovePivotTable";
            this.btnRemovePivotTable.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnPieChart
            // 
            this.btnPieChart.Caption = "饼状图";
            this.btnPieChart.Id = 61;
            this.btnPieChart.Name = "btnPieChart";
            this.btnPieChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnColumnChart
            // 
            this.btnColumnChart.Caption = "柱型图";
            this.btnColumnChart.Id = 62;
            this.btnColumnChart.Name = "btnColumnChart";
            this.btnColumnChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnLineChart
            // 
            this.btnLineChart.Caption = "线型图";
            this.btnLineChart.Id = 63;
            this.btnLineChart.Name = "btnLineChart";
            this.btnLineChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUpdatePivotChart
            // 
            this.btnUpdatePivotChart.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnUpdatePivotChart.Caption = "更新";
            this.btnUpdatePivotChart.Id = 50;
            this.btnUpdatePivotChart.Name = "btnUpdatePivotChart";
            this.btnUpdatePivotChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnRemovePivotChart
            // 
            this.btnRemovePivotChart.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnRemovePivotChart.Caption = "删除";
            this.btnRemovePivotChart.Id = 51;
            this.btnRemovePivotChart.Name = "btnRemovePivotChart";
            this.btnRemovePivotChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnNewCaColumn
            // 
            this.btnNewCaColumn.Caption = "新建";
            this.btnNewCaColumn.Id = 34;
            this.btnNewCaColumn.ImageIndex = 5;
            this.btnNewCaColumn.ImageIndexDisabled = 5;
            this.btnNewCaColumn.LargeImageIndex = 5;
            this.btnNewCaColumn.LargeImageIndexDisabled = 5;
            this.btnNewCaColumn.Name = "btnNewCaColumn";
            this.btnNewCaColumn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUpdateCaColumn
            // 
            this.btnUpdateCaColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnUpdateCaColumn.Caption = "更新";
            this.btnUpdateCaColumn.Id = 41;
            this.btnUpdateCaColumn.ImageIndex = 4;
            this.btnUpdateCaColumn.ImageIndexDisabled = 4;
            this.btnUpdateCaColumn.Name = "btnUpdateCaColumn";
            this.btnUpdateCaColumn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // btnRemoveCaColumn
            // 
            this.btnRemoveCaColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnRemoveCaColumn.Caption = "删除";
            this.btnRemoveCaColumn.Id = 42;
            this.btnRemoveCaColumn.ImageIndex = 3;
            this.btnRemoveCaColumn.ImageIndexDisabled = 3;
            this.btnRemoveCaColumn.LargeImageIndex = 9;
            this.btnRemoveCaColumn.LargeImageIndexDisabled = 9;
            this.btnRemoveCaColumn.Name = "btnRemoveCaColumn";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "在Excel中 预览";
            this.barButtonItem15.Id = 45;
            this.barButtonItem15.ImageIndex = 7;
            this.barButtonItem15.ImageIndexDisabled = 7;
            this.barButtonItem15.Name = "barButtonItem15";
            this.barButtonItem15.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "adas",
            "dsfdsf",
            "adsf",
            "f",
            "dds",
            "ds",
            "fasf",
            "adsf",
            "adsfadsfas",
            "fdfasfasdfds"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 0, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemComboBox2.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.repositoryItemComboBox2.HideSelection = false;
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemTextEdit7
            // 
            this.repositoryItemTextEdit7.AutoHeight = false;
            this.repositoryItemTextEdit7.Name = "repositoryItemTextEdit7";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 14;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 15;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 16;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 22;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 23;
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barLinkContainerItem1
            // 
            this.barLinkContainerItem1.Caption = "barLinkContainerItem1";
            this.barLinkContainerItem1.Id = 38;
            this.barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.ButtonGroupsVertAlign = DevExpress.Utils.VertAlignment.Top;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barEditItem1,
            this.btnNewCustReport,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem6,
            this.barSubItem1,
            this.btnUpdateCustReport,
            this.btnRemoveCustReport,
            this.btnNewCaColumn,
            this.barLinkContainerItem1,
            this.btnUpdateCaColumn,
            this.btnRemoveCaColumn,
            this.barButtonItem15,
            this.btnNewPivotTable,
            this.btnUpdatePivotTable,
            this.btnRemovePivotTable,
            this.btnUpdatePivotChart,
            this.btnRemovePivotChart,
            this.btnPieChart,
            this.btnColumnChart,
            this.btnLineChart,
            this.btnExit,
            this.barButtonItem26,
            this.barButtonItem27,
            this.btnReView,
            this.btnNewPTable,
            this.btnUpdatePTable,
            this.btnDeletePTable,
            this.btnPLineChart,
            this.btnPColumnChart,
            this.btnPPieChart,
            this.barButtonItem3,
            this.barButtonItem10});
            this.ribbonControl1.ItemsVertAlign = DevExpress.Utils.VertAlignment.Top;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 77;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemPictureEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit5,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit6,
            this.repositoryItemComboBox2,
            this.repositoryItemTextEdit7,
            this.repositoryItemSearchLookUpEdit1,
            this.repositoryItemLookUpEdit1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.SelectedPage = this.ribbonPage1;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(826, 151);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItem26
            // 
            this.barButtonItem26.Caption = "PreView";
            this.barButtonItem26.Id = 65;
            this.barButtonItem26.Name = "barButtonItem26";
            // 
            // barButtonItem27
            // 
            this.barButtonItem27.Caption = "barButtonItem27";
            this.barButtonItem27.Id = 66;
            this.barButtonItem27.Name = "barButtonItem27";
            this.barButtonItem27.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnNewPTable
            // 
            this.btnNewPTable.Caption = "新建";
            this.btnNewPTable.Id = 69;
            this.btnNewPTable.Name = "btnNewPTable";
            this.btnNewPTable.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUpdatePTable
            // 
            this.btnUpdatePTable.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnUpdatePTable.Caption = "更新";
            this.btnUpdatePTable.Id = 70;
            this.btnUpdatePTable.Name = "btnUpdatePTable";
            // 
            // btnDeletePTable
            // 
            this.btnDeletePTable.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnDeletePTable.Caption = "删除";
            this.btnDeletePTable.Id = 71;
            this.btnDeletePTable.Name = "btnDeletePTable";
            // 
            // btnPLineChart
            // 
            this.btnPLineChart.Caption = "拆线图";
            this.btnPLineChart.Id = 72;
            this.btnPLineChart.LargeGlyph = global::DXWindowsApplication1.Properties.Resources.Ribbon_Report_32x32;
            this.btnPLineChart.Name = "btnPLineChart";
            this.btnPLineChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPLineChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPLineChart_ItemClick);
            // 
            // btnPColumnChart
            // 
            this.btnPColumnChart.Caption = "柱型图";
            this.btnPColumnChart.Id = 73;
            this.btnPColumnChart.Name = "btnPColumnChart";
            this.btnPColumnChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnPPieChart
            // 
            this.btnPPieChart.Caption = "饼图";
            this.btnPPieChart.Id = 74;
            this.btnPPieChart.Name = "btnPPieChart";
            this.btnPPieChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "更新";
            this.barButtonItem3.Id = 75;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem10.Caption = "删除";
            this.barButtonItem10.Id = 76;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup7});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "插入";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNewPTable);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnUpdatePTable);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDeletePTable);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "透视表";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnPLineChart);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnPColumnChart);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnPPieChart);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem3, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "透视图";
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // barButtonItem19
            // 
            this.barButtonItem19.Caption = "barButtonItem19";
            this.barButtonItem19.Id = 52;
            this.barButtonItem19.Name = "barButtonItem19";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 157);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(802, 358);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.advBandedGridView1,
            this.bandedGridView2});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.SystemColors.HighlightText;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.glReportName,
            this.glReportMarks});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowPreviewLines = false;
            // 
            // glReportName
            // 
            this.glReportName.Caption = "报表名称";
            this.glReportName.FieldName = "Name";
            this.glReportName.Name = "glReportName";
            this.glReportName.Visible = true;
            this.glReportName.VisibleIndex = 0;
            // 
            // glReportMarks
            // 
            this.glReportMarks.Caption = "备注";
            this.glReportMarks.FieldName = "Remarks";
            this.glReportMarks.Name = "glReportMarks";
            this.glReportMarks.Visible = true;
            this.glReportMarks.VisibleIndex = 1;
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.advBandedGridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.SystemColors.HighlightText;
            this.advBandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.advBandedGridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.advBandedGridView1.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.advBandedGridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.advBandedGridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.advBandedGridView1.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.advBandedGridView1.OptionsCustomization.AllowFilter = false;
            this.advBandedGridView1.OptionsCustomization.AllowGroup = false;
            this.advBandedGridView1.OptionsCustomization.AllowRowSizing = true;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            this.advBandedGridView1.OptionsView.ShowPreviewLines = false;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand1";
            this.gridBand2.Columns.Add(this.bandedGridColumn1);
            this.gridBand2.Columns.Add(this.bandedGridColumn2);
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 150;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "报表名称";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "备注";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // bandedGridView2
            // 
            this.bandedGridView2.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bandedGridView2.Appearance.HeaderPanel.BackColor2 = System.Drawing.SystemColors.HighlightText;
            this.bandedGridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView2.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3});
            this.bandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn3,
            this.bandedGridColumn4});
            this.bandedGridView2.GridControl = this.gridControl1;
            this.bandedGridView2.Name = "bandedGridView2";
            this.bandedGridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.bandedGridView2.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.bandedGridView2.OptionsBehavior.AutoPopulateColumns = false;
            this.bandedGridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.bandedGridView2.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.bandedGridView2.OptionsCustomization.AllowFilter = false;
            this.bandedGridView2.OptionsCustomization.AllowGroup = false;
            this.bandedGridView2.OptionsCustomization.AllowRowSizing = true;
            this.bandedGridView2.OptionsView.ShowGroupPanel = false;
            this.bandedGridView2.OptionsView.ShowPreviewLines = false;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand1";
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 150;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "报表名称";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "备注";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 527);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNewCustReport;
        private DevExpress.XtraBars.BarButtonItem btnUpdateCustReport;
        private DevExpress.XtraBars.BarButtonItem btnRemoveCustReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem btnNewCaColumn;
        private DevExpress.XtraBars.BarButtonItem btnUpdateCaColumn;
        private DevExpress.XtraBars.BarButtonItem btnRemoveCaColumn;
        private DevExpress.XtraBars.BarButtonItem btnNewPivotTable;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePivotTable;
        private DevExpress.XtraBars.BarButtonItem btnRemovePivotTable;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePivotChart;
        private DevExpress.XtraBars.BarButtonItem btnRemovePivotChart;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        private DevExpress.XtraBars.BarButtonItem btnReView;
        private DevExpress.XtraBars.BarButtonItem btnPieChart;
        private DevExpress.XtraBars.BarButtonItem btnColumnChart;
        private DevExpress.XtraBars.BarButtonItem btnLineChart;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem26;
        private DevExpress.XtraBars.BarButtonItem barButtonItem27;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn glReportName;
        private DevExpress.XtraGrid.Columns.GridColumn glReportMarks;
        private DevExpress.XtraBars.BarButtonItem btnNewPTable;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePTable;
        private DevExpress.XtraBars.BarButtonItem btnDeletePTable;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnPLineChart;
        private DevExpress.XtraBars.BarButtonItem btnPColumnChart;
        private DevExpress.XtraBars.BarButtonItem btnPPieChart;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;


    }
}

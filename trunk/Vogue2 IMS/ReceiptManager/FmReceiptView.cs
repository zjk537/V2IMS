using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Vogue2_IMS.ReceiptManager
{
    public partial class FmReceiptView : DevExpress.XtraEditors.XtraForm
    {
        public FmReceiptView()
        {
           //reportViewer1.PrinterSettings.DefaultPageSettings.
            InitializeComponent();
        }

        public void InitializeReceiptView<T>(params List<T>[] tSources)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();

            bool isKnowType = false;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = string.Empty;
            if (typeof(T) == typeof(PurchaseJsGoodsOrderInfo))
            {
                isKnowType = true;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Vogue2_IMS.ReceiptManager.JsReceipt.rdlc";
            }
            if (typeof(T) == typeof(PurchaseJhGoodsOrderInfo))
            {
                isKnowType = true;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Vogue2_IMS.ReceiptManager.JhReceipt.rdlc";
            }
            if (typeof(T) == typeof(SaledGoodsOrderInfo))
            {
                isKnowType = true;
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Vogue2_IMS.ReceiptManager.CkReceipt.rdlc";
            }

            if (!isKnowType) return;
         
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("GoodsJsSource", tSources[0]));   
            this.reportViewer1.RefreshReport();  
    
            //this.reportViewer1.PrinterSettings.p
        }

        private void ReceiptView_Load(object sender, EventArgs e)
        {     
        }

        #region print

        public void PrintReceipt<T>(params List<T>[] tSources)
        {
            foreach (var source in tSources)
                LoadReceipt(source);

            Print();
        }

        private void LoadReceipt<T>(List<T> tSources)
        {
            string reportPath = string.Empty;
            if (typeof(T) == typeof(PurchaseJsGoodsOrderInfo))
            {
                reportPath = @".\ReceiptManager\JsReceipt.rdlc";
            }
            if (typeof(T) == typeof(PurchaseJhGoodsOrderInfo))
            {
                reportPath = @".\ReceiptManager\JhReceipt.rdlc";
            }

            if (string.IsNullOrEmpty(reportPath) || !File.Exists(reportPath))
            {
                return;
            }

            LocalReport report = new LocalReport();
            //设置需要打印的报表的文件名称。
            report.ReportPath = reportPath;
            //创建要打印的数据源
            ReportDataSource source = new ReportDataSource("GoodsJsSource", tSources);
            report.DataSources.Add(source);
            //刷新报表中的需要呈现的数据
            report.Refresh();
            //report.GetDefaultPageSettings().PaperSize);

            #region deviceInfo

//            string deviceInfo =
//           @"<DeviceInfo>
//                <OutputFormat>EMF</OutputFormat>
//                <PageWidth>8.5in</PageWidth>
//                <PageHeight>11in</PageHeight>
//                <MarginTop>0.25in</MarginTop>
//                <MarginLeft>0.25in</MarginLeft>
//                <MarginRight>0.25in</MarginRight>
//                <MarginBottom>0.25in</MarginBottom>
//            </DeviceInfo>";
//            Warning[] warnings;
//            m_streams = new List<Stream>();
//            report.Render("Image", deviceInfo, CreateStream,
//               out warnings);

//            foreach (Stream stream in m_streams)
//                stream.Position = 0;

            #endregion

            m_streams.Add(new MemoryStream(report.Render("Image")));           
        }

        //声明一个Stream对象的列表用来保存报表的输出数据
        //LocalReport对象的Render方法会将报表按页输出为多个Stream对象。
        private List<Stream> m_streams = new List<Stream>();
        //用来提供Stream对象的函数，用于LocalReport对象的Render方法的第三个参数。
        private Stream CreateStream(string name, string fileNameExtension,Encoding encoding, string mimeType, bool willSeek)
        {
            //如果需要将报表输出的数据保存为文件，请使用FileStream对象。
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private int m_currentPageIndex;

        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>14cm</PageWidth>
                <PageHeight>21cm</PageHeight>
                <MarginTop>0cm</MarginTop>
                <MarginLeft>0cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0cm</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);

            m_streams.Add(new MemoryStream(report.Render("Image")));
            //foreach (Stream stream in m_streams)
            //    stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            //// Adjust rectangular area with printer margins.
            //Rectangle adjustedRect = new Rectangle(
            //    ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
            //    ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
            //    ev.PageBounds.Width,
            //    ev.PageBounds.Height);

            // Draw a white background for the report
            //ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, 0, 0);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.DefaultPageSettings = new PageSettings() { PaperSize = new PaperSize() { Width = 39 * 14, Height = 39 * 21 } };
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        #endregion

    }
}
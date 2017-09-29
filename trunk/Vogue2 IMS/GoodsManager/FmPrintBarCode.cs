using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vogue2_IMS.Business;
using System.Drawing.Printing;
using Vogue2_IMS.Common;
using System.Threading;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmPrintBarCode : Form
    {
        Bitmap memoryImage = null; //定义一个图片
        public  PrintDocument printDocument = new PrintDocument(); //定义一个Print文档对象

        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            bool preview = false;
            RectangleF realMarginBounds = GetRealPageBounds(e, preview);

            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
  
        Rectangle GetRealPageBounds(PrintPageEventArgs e, bool preview)
        {
            if (preview) return e.MarginBounds;

            float cx = e.PageSettings.HardMarginX;
            float cy = e.PageSettings.HardMarginY;

            float dpix = e.Graphics.DpiX;
            float dpiy = e.Graphics.DpiY;
            Rectangle marginBounds = e.MarginBounds;
            marginBounds.Offset((int)(-cx * 100 / dpix), (int)(-cy * 100 / dpiy));
            return marginBounds;

        }

        public List<ProInfo> source = new List<ProInfo>();
        public List<ProInfo> Source
        {
            get { return source; }
            set
            {
                source = value == null ? new List<ProInfo>() : value;
                index = source.Count > 0 ? 1 : 0;
            }
        }
        public FmPrintBarCode()
        {
            InitializeComponent();
         

            printDocument.PrinterSettings.PrinterName = "Deli DL-888D";
            //labTextNow.Text = string.Format("{0}/{1}",0,Source.Count);
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
           // printDocument.EndPrint += PrintDocument_EndPrint;
        }

        int index = 1;
        public void Print()
        {
            source.ForEach(proInfo => {
                var price = proInfo.probjiage.ToString();
                price=price.PadLeft(8,'0');
                             
                var priceCode = string.Format("{0}{1}{2}B{3}", price.Substring(0,4), proInfo.procode.Substring(0, 2), proInfo.procode.Substring(10, 3),
                  price.Substring(4));


                var image = ImageBarCodeHelper.GetBarcode(50, 180, 90, BarcodeLib.TYPE.CODE128, proInfo.procode, new System.Drawing.Font("verdana", 9f));
                memoryImage = new Bitmap(image);

                ImageBarCodeHelper.GetViewText(memoryImage, proInfo.proname, 52, new System.Drawing.Font("verdana", 9f, FontStyle.Bold));
                ImageBarCodeHelper.GetViewText(memoryImage, priceCode, 70, new System.Drawing.Font("verdana", 9f));


                printDocument.Print();
            
            });

          
        }

        private void labTextNow_Click(object sender, EventArgs e)
        {

        }

        private void progessBar_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

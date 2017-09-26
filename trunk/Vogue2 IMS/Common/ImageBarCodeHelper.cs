using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Vogue2_IMS.Common
{
    class ImageBarCodeHelper
    {
        public static void GetViewText(Bitmap pBitmap, string showText, int startY, Font font)
        {
            if (pBitmap == null || string.IsNullOrEmpty(showText)) return;

            Graphics _Graphics = Graphics.FromImage(pBitmap);
            SizeF _DrawSize = _Graphics.MeasureString(showText, font);

            if (_DrawSize.Height > pBitmap.Height - 10 || _DrawSize.Width > pBitmap.Width)
            {
                _Graphics.Dispose(); return;
            }

            int starX = (pBitmap.Width - (int)_DrawSize.Width) / 2;
            _Graphics.FillRectangle(Brushes.White, new Rectangle(starX, startY, pBitmap.Width, (int)_DrawSize.Height));
            _Graphics.DrawString(showText, font, Brushes.Black, starX, startY);//文字在图片的中间位置
        }

        public static Image GetBarcode(int tHeight, int tWidth, int pHeight, BarcodeLib.TYPE type, string code, Font font)
        {
            Image image = null;

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.Black;
            b.IncludeLabel = true;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
            b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            b.LabelFont = font;
            b.Height = tHeight;
            b.Width = tWidth;

            image = b.Encode(type, code);
            Bitmap bmpOut = new Bitmap(tWidth, pHeight, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmpOut);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, tWidth, pHeight));
            g.DrawImage(new Bitmap(image), new Rectangle(0, 0, tWidth, pHeight), new Rectangle(0, 0, tWidth, pHeight), GraphicsUnit.Pixel);
            g.Dispose();

            return bmpOut;
        }
    }
}

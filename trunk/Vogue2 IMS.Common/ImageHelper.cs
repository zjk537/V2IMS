using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Vogue2_IMS.Common
{
    public class ImageHelper
    {
        public ImageHelper()
        {

        }

        public static ImageHelper Instance = new ImageHelper();

        #region imageCut
        //// <summary>
        /// 图片切割函数
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="xNum">在Ｘ轴上的切割数量</param>
        /// <param name="yNum">在Ｙ轴上的切割数量</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="outputFile">输出文件名，不带后缀</param>
        /// <returns>成功返回true，失败则返回false</returns>
        public bool ImageCut(String sourceFile, int xNum, int yNum, long quality, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width / xNum;
                float yWidth = sourceImage.Height / yNum;
                String outputImage = "";

                for (int countY = 0; countY < yNum; countY++)
                    for (int countX = 0; countX < xNum; countX++)
                    {

                        RectangleF cloneRect = new RectangleF(countX * xWidth, countY * yWidth, xWidth, yWidth);
                        Bitmap newImage = sourceImage.Clone(cloneRect, PixelFormat.Format24bppRgb);
                        outputImage = outputFile + countX + countY + ".jpg";
                        newImage.Save(outputImage, myImageCodecInfo, myEncoderParameters);

                    }
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion imageCut


        #region imageCompress
        /**/
        /// <summary>
        /// 图片压缩函数 
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="ouputFile">输出文件名,请用 .jpg 后缀 </param>
        /// <returns>成功返回true，失败则返回false</returns>
        public bool ImageCompress(String sourceFile, long quality, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;

                sourceImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;

            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 图片压缩函数 保真率50
        /// </summary>
        /// <param name="image">原始图</param>
        /// <param name="multiple">缩放比例</param>
        /// <returns>压缩后图片字节数组</returns>
        public byte[] ImageCompress(Image image, int multiple)
        {
            try
            {
                Bitmap sourceImage = (Bitmap)image;
                using (MemoryStream ms = new MemoryStream())
                {

                    long imageQuality = 50L;
                    float xWidth = sourceImage.Width / multiple;
                    float yWidth = sourceImage.Height / multiple;

                    Bitmap newImage = new Bitmap((int)xWidth, (int)yWidth);
                    using (Graphics g = GetGraphic(sourceImage, newImage))
                    {
                        g.DrawImage(sourceImage, 0, 0, xWidth, yWidth);
                        using (EncoderParameters myEncoderParameters = new EncoderParameters(1))
                        {
                            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                            myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, imageQuality);
                            newImage.Save(ms, myImageCodecInfo, myEncoderParameters);
                        }
                    }
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }

        }
        #endregion imageCompress


        #region ImageThum
        /**/
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceFile">原始图片文件</param>
        /// <param name="quality">质量压缩比</param>
        /// <param name="multiple">收缩倍数</param>
        /// <param name="outputFile">输出文件名</param>
        /// <returns>成功返回true,失败则返回false</returns>
        public bool ImageThum(String sourceFile, long quality, int multiple, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 生成缩略图 保真率50
        /// </summary>
        /// <param name="image">原始图片</param>
        /// <param name="multiple">收缩倍数</param>
        /// <returns></returns>
        public byte[] ImageThum(Image image, int multiple)
        {
            try
            {
                Bitmap sourceImage = (Bitmap)image;
                using (MemoryStream ms = new MemoryStream())
                {
                    long imageQuality = 50L;
                    float xWidth = sourceImage.Width / multiple;
                    float yWidth = sourceImage.Height / multiple;
                    Bitmap newImage = new Bitmap((int)xWidth, (int)yWidth);
                    using (Graphics g = GetGraphic(sourceImage, newImage))
                    {
                        g.DrawImage(sourceImage, 0, 0, xWidth, yWidth);
                        using (EncoderParameters myEncoderParameters = new EncoderParameters(1))
                        {
                            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                            myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, imageQuality);
                            newImage.Save(ms, myImageCodecInfo, myEncoderParameters);
                        }
                    }

                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        private Graphics GetGraphic(Image originImage, Bitmap newImage)
        {
            newImage.SetResolution(originImage.HorizontalResolution, originImage.VerticalResolution);
            var graphic = Graphics.FromImage(newImage);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            return graphic;
        }

        #endregion getThumImage

        #region ImageCodecInfo
        /// <summary>
        /// 获取图片编码信息
        /// </summary>
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion
    }
}

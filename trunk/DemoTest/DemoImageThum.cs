using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Common;
using Vogue2_IMS.Model.DataModel;

namespace DXWindowsApplication1
{
    public partial class DemoImageThum : Form
    {
        public DemoImageThum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharedVariables.Instance.LoginUser.User = new UserInfo()
            {
                Id = 1,
                RoleId = 1,
                Name = "admin"
            };
            int success = 0;
            int failed = 0;
            List<GoodsInfo> goodsList = GoodsBusiness.Instance.GetAllGoods();
            if (goodsList != null && goodsList.Count > 0)
            {
                foreach (var goodsInfo in goodsList)
                {
                    if (!string.IsNullOrEmpty(goodsInfo.Image) && string.IsNullOrEmpty(goodsInfo.ImageThum))
                    {
                        listBox1.Items.Insert(0, string.Format("开始更新：{0}__{1}", goodsInfo.Name, goodsInfo.Code));
                        Bitmap bitImg = null;
                        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(goodsInfo.Image)))
                        {
                            bitImg = (Bitmap)Image.FromStream(ms);
                        }
                        if (bitImg == null)
                            return;

                        int compressMultiple = bitImg.Width > 600 ? (int)bitImg.Width / 600 : 1;
                        int thumMultiple = bitImg.Width > 200 ? (int)bitImg.Width / 200 : 1;
                        goodsInfo.ImageThum = Convert.ToBase64String(ImageHelper.Instance.ImageThum(bitImg, thumMultiple));
                        goodsInfo.Image = Convert.ToBase64String(ImageHelper.Instance.ImageCompress(bitImg, compressMultiple));
                        goodsInfo.IdSpecify = true;

                        PurchaseGoodsBusiness.Instance.UpdatePurchaseGoods(new PurchaseGoodsInfo() { Goods = goodsInfo });
                        success++;
                        listBox1.Items.Insert(0, string.Format("更新成功！"));
                    }
                    else
                    {
                        failed++;
                        listBox1.Items.Insert(0, string.Format("无图或已更新：{0}__{1}", goodsInfo.Name, goodsInfo.Code));
                    }
                }
                listBox1.Items.Insert(0, string.Format("商品总数:{0}个,成功更新:{1}个,无更新:{2}个", goodsList.Count, success, failed));
            }
        }
    }
}

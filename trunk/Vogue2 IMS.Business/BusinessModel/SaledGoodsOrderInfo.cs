using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.Business.BusinessModel
{
    public class SaledGoodsOrderInfo
    {

        /// <summary>
        /// get SaledGoodsInfo
        /// </summary>
        public ProInfo SaledGoodsInfo { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsInfo"></param>
        /// <param name="orderType">1:第一联 顾客联 2：第二联 记账联</param>
        public SaledGoodsOrderInfo(ProInfo goodsInfo, int orderType)
        {
            this.SaledGoodsInfo = goodsInfo;

            OrderType = orderType == 1
                ? "第一联 顾客联" 
                : "第二联 记账联";
        }

        public string OrderType { get; private set; }

        public int Id { get { return SaledGoodsInfo.proid.Value; } }

      

        /// <summary>
        /// 商品编号 
        /// </summary>
        public string GoodsCode { get { return SaledGoodsInfo.procode; } }
        /// <summary>
        /// 商品名称 
        /// </summary>
        public string Name { get { return SaledGoodsInfo.proname; } }
        /// <summary>
        /// 商品原厂编号 
        /// </summary>
        public string OriginalCode { get { return SaledGoodsInfo.projcode; } }
        /// <summary>
        /// 商品图片 
        /// </summary>
        public byte[] GoodsImageBytes { get { return SaledGoodsInfo.imagebytes; } }
        /// <summary>
        /// 商品颜色 
        /// </summary>
        public string Color { get { return SaledGoodsInfo.procolor; } }
        /// <summary>
        /// 商品成色 
        /// </summary>
        public string Quality { get { return SaledGoodsInfo.prochengse; } }
        /// <summary>
        /// 商品配件 
        /// </summary>
        public string Parts { get { return SaledGoodsInfo.probujian; } }

        /// <summary>
        /// 商品标价
        /// </summary>
        public string MarkPrice
        {
            get
            {
                return SaledGoodsInfo.probjiage.HasValue ?
                    SaledGoodsInfo.probjiage.Value.ToString("F2") : string.Empty;
            }
        }
        /// <summary>
        /// 商品 实售价格
        /// </summary>
        public string SaledPrice
        {
            get
            {
                return SaledGoodsInfo.prosjiage.HasValue ?
                    SaledGoodsInfo.prosjiage.Value.ToString("F2") : string.Empty;
            }
        }
        ///// <summary>
        ///// 商品 实售价格
        ///// </summary>
        //public string Discount
        //{
        //    get
        //    {
        //        return SaledGoodsInfo..Discount.HasValue ?
        //            SaledGoodsInfo.Goods.Discount.Value.ToString("F2") : string.Empty;
        //    }
        //}
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDate
        {
            get
            {
                return SaledGoodsInfo.prostarttime.HasValue ? SaledGoodsInfo.prostarttime.Value.ToString("yyyy/MM/DD") : string.Empty; ;
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDate
        {
            get
            {
                return SaledGoodsInfo.proendtime.HasValue ? SaledGoodsInfo.proendtime.Value.ToString("yyyy/MM/DD") : string.Empty; ;
            }
        }

        ///// <summary>
        ///// 当前登录用户所在店面信息
        ///// </summary>
        //private ShopInfo mShop = null;
        //private ShopInfo CurShopInfo
        //{

        //    get
        //    {
        //        if (mShop == null)
        //        {
        //            //mShop = SharedVariables.Instance.ShopInfos.FirstOrDefault(shop => shop.Id == SharedVariables.Instance.LoginUser.User.ShopId);
        //        }
        //        mShop = mShop ?? new ShopInfo();
        //        return mShop;
        //    }
        //}
        /// <summary>
        /// 店面名
        /// </summary>
        public string ShopName { get { return SaledGoodsInfo.prodepname; } }
        /// <summary>
        /// 店面联系方式
        /// </summary>
        public string ShopPhone { get { return SaledGoodsInfo.prodepphone; } }
        /// <summary>
        /// 顾客姓名
        /// </summary>
        public string CustomerName { get { return SaledGoodsInfo.prooutcustname; } }
        /// <summary>
        /// 顾客联系方式
        /// </summary>
        public string CustomerPhone { get { return SaledGoodsInfo.prooutcustphone; } }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string Paytype { get { return SaledGoodsInfo.prooutpaytype; } }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalMarkPrice { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 合计金额 大写
        /// </summary>
        public string TotalPriceZH { get { return MoneyHelper.Instance.Convert(TotalPrice.ToString("F2")); } }
        /// <summary>
        /// 总折扣金额
        /// </summary>
        public decimal TotalDiscount { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public string PrintDate { get { return DateTime.Now.ToString("yyyy/MM/dd"); } }
        /// <summary>
        /// 经手人
        /// </summary>
        public string Operator { get { return SaledGoodsInfo.prooutjuname; } }
        /// <summary>
        /// 备注信息 
        /// </summary>
        public string Desc { get { return SaledGoodsInfo.proremark; } }

    }
}

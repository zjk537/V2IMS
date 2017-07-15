using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common;

namespace Vogue2_IMS.Business.BusinessModel
{
    public class PurchaseGoodsOrderInfoBase
    {
        /// <summary>
        /// get purchaseGoodsOrderInfo
        /// </summary>
        public ProInfo PurchaseGoodsInfo { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsInfo"></param>
        /// <param name="orderType">1:第一联 顾客联 2：第二联 记账联</param>
        public PurchaseGoodsOrderInfoBase(ProInfo goodsInfo, int orderType)
        {
            this.PurchaseGoodsInfo = goodsInfo;

            OrderType = orderType == 1
                ? goodsInfo.protype == ConfigManager.JiShou ? "第一联 顾客联" : "第一联 供应商联"
                : "第二联 记账联";
        }

        public string OrderType { get; private set; }

        public int Id { get { return PurchaseGoodsInfo.proid.Value; } }

        /// <summary>
        /// 店面名
        /// </summary>
        public string ShopName { get { return PurchaseGoodsInfo.prodepname; } }
        /// <summary>
        /// 店面联系方式
        /// </summary>
        public string ShopPhone
        {
            get
            {
                return PurchaseGoodsInfo.prodepphone; 
            }
        }

     

        /// <summary>
        /// 供应商
        /// </summary>
        public string SupplierName { get { return PurchaseGoodsInfo.custname; } }
        /// <summary>
        /// 供应商证件号
        /// </summary>
        public string SpplierIdCard { get { return PurchaseGoodsInfo.custidcard; } }
        /// <summary>
        /// 供应商联系方式
        /// </summary>
        public string SupplierPhone { get { return PurchaseGoodsInfo.custphone; } }
        /// <summary>
        /// 供应商开户行
        /// </summary>
        public string SpplierBankName { get { return PurchaseGoodsInfo.custyhname; } }
        /// <summary>
        /// 供应商卡号
        /// </summary>
        public string SpplierBankCard { get { return PurchaseGoodsInfo.custyhcard; } }

        /// <summary>
        /// 商品编号 
        /// </summary>
        public string GoodsCode { get { return PurchaseGoodsInfo.procode; } }
        /// <summary>
        /// 商品名称 
        /// </summary>
        public string Name { get { return PurchaseGoodsInfo.proname; } }
        /// <summary>
        /// 商品原厂编号 
        /// </summary>
        public string OriginalCode { get { return PurchaseGoodsInfo.projcode; } }
        /// <summary>
        /// 商品图片 
        /// </summary>
        public byte[] GoodsImageBytes { get { return PurchaseGoodsInfo.imagebytes; } }
        /// <summary>
        /// 商品颜色 
        /// </summary>
        public string Color { get { return PurchaseGoodsInfo.procolor; } }
        /// <summary>
        /// 商品成色 
        /// </summary>
        public string Quality { get { return PurchaseGoodsInfo.prochengse; } }
        /// <summary>
        /// 商品配件 
        /// </summary>
        public string Parts { get { return PurchaseGoodsInfo.probujian; } }

        /// <summary>
        /// 经手人
        /// </summary>
        public string Operator { get { return PurchaseGoodsInfo.proinjuname; } }


        /// <summary>
        /// 商品描述 
        /// </summary>
        public string Desc { get { return PurchaseGoodsInfo.proremark; } }
        /// <summary>
        /// 商品进货价格 
        /// </summary>
        public string PrimePrice
        {
            get
            {
                return PurchaseGoodsInfo.projiage.HasValue ?
                    PurchaseGoodsInfo.projiage.Value.ToString("F2") : string.Empty;
            }
        }

        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 合计金额 大写
        /// </summary>
        public string TotalPriceZH { get { return MoneyHelper.Instance.Convert(TotalPrice.ToString("F2")); } }

    }
    /// <summary>
    /// 寄售回单视图
    /// </summary>
    public class PurchaseJsGoodsOrderInfo : PurchaseGoodsOrderInfoBase
    {
        public PurchaseJsGoodsOrderInfo(ProInfo goodsInfo, int orderType)
            : base(goodsInfo, orderType)
        { }

        /// <summary>
        /// 商品开始时间 
        /// </summary>
        public string ConsignStartDate
        {
            get
            {
                return
                    PurchaseGoodsInfo.prostarttime.HasValue ?
                    PurchaseGoodsInfo.prostarttime.Value.ToString("yyy-MM-dd") : string.Empty;
            }
        }
        /// <summary>
        /// 商品结束时间 
        /// </summary>
        public string ConsignEndDate
        {
            get
            {
                return
                    PurchaseGoodsInfo.proendtime.HasValue ?
                    PurchaseGoodsInfo.proendtime.Value.ToString("yyy-MM-dd") : string.Empty;
            }
        }


    }
    /// <summary>
    /// 进货回单视图
    /// </summary>
    public class PurchaseJhGoodsOrderInfo : PurchaseGoodsOrderInfoBase
    {
        public PurchaseJhGoodsOrderInfo(ProInfo goodsInfo, int orderType)
            : base(goodsInfo, orderType)
        { }

        public string PayTypeName { get { return this.PurchaseGoodsInfo.proinpaytype; } }


    }
}

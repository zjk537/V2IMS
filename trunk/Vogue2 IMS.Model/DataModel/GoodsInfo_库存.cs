/* ==============================================================================
 * 功能描述：库存表
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:27
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;
using System.Collections.Generic;

namespace Vogue2_IMS.Model.DataModel
{
    public class GoodsInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("GoodsId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private int categoryId = 0;
        public bool CategoryIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 所属分类Id
        /// </summary>
        [DBFieldAttribute("GoodsCategoryId")]
        public int CategoryId { get { return categoryId; } set { categoryId = value; CategoryIdSpecify = true; } }


        private int supplierId = 0;
        public bool SupplierIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 供应商Id
        /// </summary>
        [DBFieldAttribute("GoodsSupplierId")]
        public int SupplierId { get { return supplierId; } set { supplierId = value; SupplierIdSpecify = true; } }


        private string code = string.Empty;
        public bool CodeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品编码
        /// </summary>
        [DBFieldAttribute("GoodsCode")]
        public string Code { get { return code; } set { code = value; CodeSpecify = true; } }


        private string originalCode = string.Empty;
        public bool OriginalCodeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 原厂编码
        /// </summary>
        [DBFieldAttribute("GoodsOriginalCode")]
        public string OriginalCode { get { return originalCode; } set { originalCode = value; OriginalCodeSpecify = true; } }


        private int sourceType = 0;
        public bool SourceTypeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 来源类型：寄售：1，进货自有：2
        /// </summary>
        [DBFieldAttribute("GoodsSourceType")]
        public int SourceType { get { return sourceType; } set { sourceType = value; SourceTypeSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品名称
        /// </summary>
        [DBFieldAttribute("GoodsName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private int status = 0;
        public bool StatusSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品状态：1、在库；2、预定；3、售出；4、取回；
        /// </summary>
        [DBFieldAttribute("GoodsStatus")]
        public int Status { get { return status; } set { status = value; StatusSpecify = true; } }


        private string image = string.Empty;
        public bool ImageSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品图片
        /// </summary>
        [DBFieldAttribute("GoodsImage")]
        public string Image { get { return image; } set { image = value; ImageSpecify = true; } }


        private string imageThum = string.Empty;
        public bool ImageThumSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品图片缩略图
        /// </summary>
        [DBFieldAttribute("GoodsImageThum")]
        public string ImageThum { get { return imageThum; } set { imageThum = value; ImageThumSpecify = true; } }

        //private byte[] mGoodsImageBytes = null;
        //public byte[] GoodsImageBytes
        //{
        //    get
        //    {
        //        if (mGoodsImageBytes == null && !string.IsNullOrEmpty(Image))
        //            mGoodsImageBytes = Convert.FromBase64String(Image);
        //        else
        //            mGoodsImageBytes = new List<byte>().ToArray();

        //        return mGoodsImageBytes;
        //    }
        //    set
        //    {
        //        Image = Convert.ToBase64String(value);
        //    }
        //}


        private string color = string.Empty;
        public bool ColorSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品颜色
        /// </summary>
        [DBFieldAttribute("GoodsColor")]
        public string Color { get { return color; } set { color = value; ColorSpecify = true; } }


        private string quality = string.Empty;
        public bool QualitySpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品成色
        /// </summary>
        [DBFieldAttribute("GoodsQuality")]
        public string Quality { get { return quality; } set { quality = value; QualitySpecify = true; } }


        private string parts = string.Empty;
        public bool PartsSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品配件
        /// </summary>
        [DBFieldAttribute("GoodsParts")]
        public string Parts { get { return parts; } set { parts = value; PartsSpecify = true; } }


        private decimal? markPrice = null;
        public bool MarkPriceSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品标价
        /// </summary>
        [DBFieldAttribute("GoodsMarkPrice")]
        public decimal? MarkPrice { get { return markPrice; } set { markPrice = value; MarkPriceSpecify = true; } }


        private decimal? primePrice = null;
        public bool PrimePriceSpecify { get; set; }
        /// <summary>
        /// 获取或设置 进货价格
        /// </summary>
        [DBFieldAttribute("GoodsPrimePrice")]
        public decimal? PrimePrice { get { return primePrice; } set { primePrice = value; PrimePriceSpecify = true; } }


        private decimal? salePrice = null;
        public bool SalePriceSpecify { get; set; }
        /// <summary>
        /// 获取或设置 售出价格
        /// </summary>
        [DBFieldAttribute("GoodsSalePrice")]
        public decimal? SalePrice { get { return salePrice; } set { salePrice = value; SalePriceSpecify = true; } }


        private decimal? prepay = null;
        public bool PrepaySpecify { get; set; }
        /// <summary>
        /// 获取或设置 预付款
        /// </summary>
        [DBFieldAttribute("GoodsPrepay")]
        public decimal? Prepay { get { return prepay; } set { prepay = value; PrepaySpecify = true; } }


        private decimal? discount = null;
        public bool DiscountSpecify { get; set; }
        /// <summary>
        /// 获取或设置 折扣金额
        /// </summary>
        [DBFieldAttribute("GoodsDiscount")]
        public decimal? Discount { get { return discount; } set { discount = value; DiscountSpecify = true; } }


        private int? paid = null;
        public bool PaidSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品是否已打款：1：已打款；2、未打款
        /// </summary>
        [DBFieldAttribute("GoodsPaid")]
        public int? Paid { get { return paid; } set { paid = value; PaidSpecify = true; } }


        private string desc = string.Empty;
        public bool DescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品描述
        /// </summary>
        [DBFieldAttribute("GoodsDesc")]
        public string Desc { get { return desc; } set { desc = value; DescSpecify = true; } }


        private DateTime createdDate = DateTime.Now;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("GoodsCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? saledDate = null;
        public bool SaledDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 售出时间
        /// </summary>
        [DBFieldAttribute("GoodsSaledDate")]
        public DateTime? SaledDate { get { return saledDate; } set { saledDate = value; SaledDateSpecify = true; } }


        private DateTime? consignStartDate = null;
        public bool ConsignStartDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 寄售开始时间
        /// </summary>
        [DBFieldAttribute("GoodsConsignStartDate")]
        public DateTime? ConsignStartDate { get { return consignStartDate; } set { consignStartDate = value; ConsignStartDateSpecify = true; } }


        private DateTime? consignEndDate = null;
        public bool ConsignEndDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 寄售结束时间
        /// </summary>
        [DBFieldAttribute("GoodsConsignEndDate")]
        public DateTime? ConsignEndDate { get { return consignEndDate; } set { consignEndDate = value; ConsignEndDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 最近一次更新时间，进出货记录的更新也算在这个字段里
        /// </summary>
        [DBFieldAttribute("GoodsUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

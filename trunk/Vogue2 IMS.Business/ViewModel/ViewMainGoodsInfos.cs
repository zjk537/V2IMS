using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.Business.BusinessModel;

namespace Vogue2_IMS.Business.ViewModel
{
    [Serializable]
    public class ViewMainGoodsInfos
    {
        public bool CheckEdit { get; set; }

        GoodsPaidInfo mGoodsPaid = null;
        public GoodsPaidInfo GoodsPaid
        {
            get
            {
                if (mGoodsPaid == null)
                    mGoodsPaid = SharedVariables.GoodsPaids.FirstOrDefault(payid => { return payid.Id == (Goods.Paid ?? 0); });

                return mGoodsPaid;
            }
            set
            {
                mGoodsPaid = value;
                if (value != null)
                    Goods.Paid = value.Id;
            }
        }

        ShopInfo mShop = null;
        /// <summary>
        /// Get ShopInfo 店面信息 
        /// </summary>
        public ShopInfo Shop
        {
            get
            {
                if (mShop == null)
                    mShop = SharedVariables.Instance.ShopInfos.First(shop =>
                {
                    return shop.Id.Equals(PurchaseUser.ShopId);
                });

                return mShop;
            }
        }

        public string ShopName
        {
            get { return Shop.Name; }
            set { Shop.Name = value; }
        }

        string mSourceName = null;
        /// <summary>
        /// Get SourceType 商品来源
        /// </summary>
        public string SourceName
        {
            get
            {
                if (string.IsNullOrEmpty(mSourceName))
                    mSourceName = SharedVariables.SourceTypeCNNames[((SourceType)Goods.SourceType)];

                return mSourceName;
            }
        }

        CategoryInfo mCategory = null;
        /// <summary>
        /// CateGoryInfo 商品分类
        /// </summary>
        public CategoryInfo Category
        {
            get
            {
                if (mCategory == null)
                    mCategory = SharedVariables.Instance.CategoryInfos.Find(category => { return category.Id.Equals(Goods.CategoryId); });

                return mCategory;
            }
        }

        /// <summary>
        /// GoodsInfo 商品信息
        /// </summary>
        GoodsInfo mGoods = new GoodsInfo();
        public GoodsInfo Goods
        {
            get
            {
                if (mGoods == null) mGoods = new GoodsInfo();

                return mGoods;
            }
            set { mGoods = value; }
        }


        public DateTime? SalesDate
        {
            get { return Goods.SaledDate; }
            set { Goods.SaledDate = value; }
        }

        /// <summary>
        /// readonly
        /// </summary>
        public int GoodsID
        {
            get { return Goods.Id; }            
        }

        /// <summary>
        /// readonly
        /// </summary>
        public decimal SalesPrice
        {
            get { return Goods.SalePrice.HasValue ? Goods.SalePrice.Value : 0; }
        }

        public string GoodsStatusName
        {
            get { return SharedVariables.GoodsStatusName[Goods == null ? 0 : Goods.Status]; }
        }

        public GoodsStatus GoodsStatus
        {
            get { if (Goods != null) return (GoodsStatus)Goods.Status; return GoodsStatus.In; }
        }
        SupplierInfo mSoupplier = null;
        /// <summary>
        /// Supplier 供应商信息  
        /// </summary>
        public SupplierInfo Supplier
        {
            get
            {
                if (mSoupplier == null)
                    mSoupplier = SharedVariables.Instance.SupplierInfos.Find(supplier => { return supplier.Id==(Goods.SupplierId); });

                return mSoupplier;
            }
        }

        public string SupplierSexName
        {
            get { return SharedVariables.SexName[(Supplier == null || !Supplier.Sex.HasValue) ? 0 : Supplier.Sex.Value]; }
        }

        PayTypeInfo mPurchasePayType = null;
        /// <summary>
        /// Get PayTypeInfo 付款类型
        /// </summary>
        public PayTypeInfo PurchasePayType
        {
            get
            {
                if (mPurchasePayType == null)
                    mPurchasePayType = SharedVariables.Instance.PayTypeInfos.Find(paytype => { return paytype.Id.Equals(PurchaseRecord.PayType); });

                return mPurchasePayType;
            }
        }

        PurchaseRecordInfo mPurchaseRecord = null;
        /// <summary>
        /// Get Or Set PurchaseRecordInfo 入库信息
        /// </summary>
        public PurchaseRecordInfo PurchaseRecord
        {
            get
            {
                if (mPurchaseRecord == null) mPurchaseRecord = new PurchaseRecordInfo();

                return mPurchaseRecord;
            }
            set { mPurchaseRecord = value; }
        }

        UserInfo mPurchaseUser = null;
        /// <summary>
        /// UserInfo 入库操作人
        /// </summary>
        public UserInfo PurchaseUser
        {
            get
            {
                if (mPurchaseUser == null)
                    mPurchaseUser = SharedVariables.Instance.UserInfos.Find(user =>
                         {
                             return user.Id.Equals(PurchaseRecord.UserId);
                         });

                return mPurchaseUser;
            }
        }

        SaledRecordInfo mSaledRecord = null;
        /// <summary>
        ///  Get Or Set SaledRecordInfo 出库信息
        /// </summary>
        public SaledRecordInfo SaledRecord
        {
            get
            {
                if (mSaledRecord == null) mSaledRecord = new SaledRecordInfo();

                return mSaledRecord;
            }
            set { mSaledRecord = value; }
        }


        PayTypeInfo mSaledPayType = null;
        /// <summary>
        /// Get PayTypeInfo 付款类型
        /// </summary>
        public PayTypeInfo SaledPayType
        {
            get
            {
                if (mSaledPayType == null)
                    mSaledPayType = SharedVariables.Instance.PayTypeInfos.Find(paytype => { return paytype.Id.Equals(SaledRecord.PayType); });

                return mSaledPayType;
            }
        }

        UserInfo mSaledUser = null;
        /// <summary>
        ///  UserInfo 出库操作人 
        /// </summary>
        public UserInfo SaledUser
        {
            get
            {
                if (mSaledUser == null)
                    mSaledUser = SharedVariables.Instance.UserInfos.Find(user =>
                         {
                             return user.Id.Equals(SaledRecord.UserId);
                         });

                return mSaledUser;
            }
        }

        /// <summary>
        /// 获取进货记录
        /// </summary>
        /// <returns></returns>
        public PurchaseGoodsInfo GetPurchaseRecordInfo()
        {
            return new PurchaseGoodsInfo()
            {
                Goods = Goods,
                PurchaseRecord = PurchaseRecord
            };
        }

        public SaledGoodsInfo GetSaledGoodsInfo()
        {
            return new SaledGoodsInfo()
            {
                Goods = Goods,
                SaledRecord = SaledRecord
            };
        }

        public byte[] GoodsImageBytes
        {
            get
            {
                if (!string.IsNullOrEmpty(mGoods.ImageThum))
                    return Convert.FromBase64String(mGoods.ImageThum);

                return new List<byte>().ToArray();
            }
            set
            {
                mGoods.Image = Convert.ToBase64String(value);
            }
        }
    }
}

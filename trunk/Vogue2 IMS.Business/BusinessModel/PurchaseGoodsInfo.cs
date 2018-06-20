using System;
using System.Collections.Generic;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Model.DataModel;
using System.Linq;
using System.IO;
using System.Drawing;
using Vogue2_IMS.Common;

namespace Vogue2_IMS.Business.BusinessModel
{
    public sealed class PurchaseGoodsInfo
    {
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
                //if (mShop == null)
                    //mShop = SharedVariables.Instance.ShopInfos.First(shop =>
                    //{
                    //    return shop.Id.Equals(LoginUser.ShopId);
                    //});

                return mShop;
            }
        }

        CategoryInfo mCategory = null;
        /// <summary>
        /// 商品分类
        /// </summary>
        public CategoryInfo Category
        {
            get
            {
                if (mCategory == null)
                {
                    mCategory = SharedVariables.Instance.CategoryInfos.FirstOrDefault(category =>
                    {
                        return category.Id == Goods.CategoryId;
                    });
                }

                return mCategory;
            }
            set
            {
                mCategory = value;
                Goods.CategoryId = mCategory.Id;
            }
        }

        PayTypeInfo mPayType = null;
        /// <summary>
        /// 付款类型
        /// </summary>
        public PayTypeInfo PayType
        {
            get
            {
                if (mPayType == null)
                    mPayType = SharedVariables.Instance.PayTypeInfos.FirstOrDefault(payType =>
                    {
                        return payType.Id == PurchaseRecord.PayType;
                    });

                return mPayType;
            }
            set
            {
                mPayType = value;
                PurchaseRecord.PayType = mPayType.Id;
            }
        }

        LoginUser mLoginUser = null;
        /// <summary>
        /// 当前(录入)用户
        /// </summary>
        public LoginUser LoginUser
        {
            get
            {
                if (mLoginUser == null)
                {
                    mLoginUser = ConfigManager.LoginUser;
                }

                return mLoginUser;
            }
            set
            {
                mLoginUser = value;
                this.PurchaseRecord.UserId = value.uid;
            }
        }

        GoodsInfo mGoods = new GoodsInfo();
        /// <summary>
        /// 商品信息
        /// </summary>
        public GoodsInfo Goods
        {
            get
            {
                if (mGoods == null) mGoods = new GoodsInfo();

                return mGoods;
            }
            set
            {
                mGoods = value;
            }
        }

        public string GoodsStatusName { get { return SharedVariables.GoodsStatusName[Goods == null ? 0 : Goods.Status]; } }

        SupplierInfo mSupplier = null;
        /// <summary>
        /// 供应商信息
        /// </summary>
        public SupplierInfo Supplier
        {
            get
            {
                if (mSupplier == null)
                {
                    mSupplier = SharedVariables.Instance.SupplierInfos.FirstOrDefault(supplier =>
                    {
                        return supplier.Id == Goods.SupplierId;
                    });
                }

                return mSupplier;
            }
            set
            {
                mSupplier = value;

                Goods.SupplierId = mSupplier.Id;
            }
        }

        public string SupplierSexName
        {
            get { return SharedVariables.SexName[(Supplier == null || !Supplier.Sex.HasValue) ? 0 : Supplier.Sex.Value]; }
        }

        PurchaseRecordInfo mPurchaseRecord = new PurchaseRecordInfo();
        /// <summary>
        /// 商品入库记录
        /// </summary>
        public PurchaseRecordInfo PurchaseRecord
        {
            get
            {
                if (mPurchaseRecord == null) mPurchaseRecord = new PurchaseRecordInfo();

                return mPurchaseRecord;
            }
            set
            {
                mPurchaseRecord = value;
            }
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
                Bitmap bitImg = null;
                using (MemoryStream ms = new MemoryStream(value))
                {
                    bitImg = (Bitmap)Image.FromStream(ms);
                }
                if (bitImg == null)
                    return;

                int compressMultiple = bitImg.Width > 600 ? (int)bitImg.Width / 600 : 1;
                int thumMultiple = bitImg.Width > 200 ? (int)bitImg.Width / 200 : 1;
                this.Goods.ImageThum = Convert.ToBase64String(ImageHelper.Instance.ImageThum(bitImg, thumMultiple));
                this.Goods.Image = Convert.ToBase64String(ImageHelper.Instance.ImageCompress(bitImg, compressMultiple));

            }
        }

        public PurchaseGoodsInfo Clone()
        {
            var tempGoods = new GoodsInfo();
            var tempPurchaseRecordInfo = new PurchaseRecordInfo();
            var tempCategory = new CategoryInfo();
            var tempPayInfo = new PayTypeInfo();
            var tempSupplier = new SupplierInfo();
            //var tempLoginUser = new LoginUser();

            DBModelBase.Clone<CategoryInfo>(Category, ref tempCategory);
            //DBModelBase.Clone<LoginUser>(LoginUser, ref tempLoginUser);
            DBModelBase.Clone<PayTypeInfo>(PayType, ref tempPayInfo);
            DBModelBase.Clone<SupplierInfo>(Supplier, ref tempSupplier);
            DBModelBase.Clone<GoodsInfo>(Goods, ref tempGoods);
            DBModelBase.Clone<PurchaseRecordInfo>(PurchaseRecord, ref tempPurchaseRecordInfo);

            PurchaseGoodsInfo newPurchaseGoodsInfo = new PurchaseGoodsInfo();
            newPurchaseGoodsInfo.Category = tempCategory;
            newPurchaseGoodsInfo.PayType = tempPayInfo;
            newPurchaseGoodsInfo.LoginUser = ConfigManager.LoginUser;

            newPurchaseGoodsInfo.PurchaseRecord = tempPurchaseRecordInfo;
            newPurchaseGoodsInfo.Supplier = tempSupplier;
            newPurchaseGoodsInfo.Goods = tempGoods;

            return newPurchaseGoodsInfo;
        }

        public override string ToString()
        {
            return Goods == null ? base.ToString() : Goods.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var tempThis = obj as PurchaseGoodsInfo;
            if (tempThis != null)
            {
                bool isEql = true;
                isEql = tempThis.Goods.Equals(Goods);
                isEql = isEql && tempThis.PurchaseRecord.Equals(PurchaseRecord);

                return isEql;
            }

            return base.Equals(obj);
        }
    }
}
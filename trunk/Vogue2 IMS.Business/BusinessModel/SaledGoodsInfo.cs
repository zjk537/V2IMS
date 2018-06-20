using System;
using System.Collections.Generic;
using System.Linq;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Business.BusinessModel
{
    public sealed class SaledGoodsInfo
    {
        CategoryInfo mCategory =new CategoryInfo();
        /// <summary>
        /// get 商品分类
        /// </summary>
        public CategoryInfo Category
        {
            get
            {
                if (mCategory == null || mCategory.Id <= 0)
                    mCategory = SharedVariables.Instance.CategoryInfos.FirstOrDefault(category => { return category.Id.Equals(Goods.CategoryId); });

                return mCategory ?? new CategoryInfo();
            }
        }

        PayTypeInfo mPayType = new PayTypeInfo();
        /// <summary>
        /// 付款类型
        /// </summary>
        public PayTypeInfo PayType
        {
            get
            {
                if (mPayType == null || mPayType.Id == 0)
                    mPayType = SharedVariables.Instance.PayTypeInfos.FirstOrDefault(paytype => { return paytype.Id.Equals(SaledRecord.PayType); });


                return mPayType ?? new PayTypeInfo();
            }
            set
            {
                mPayType = value;
                this.SaledRecord.PayType = mPayType.Id;
            }
        }

        LoginUser mLoginUser = new LoginUser();
        /// <summary>
        /// get 当前(录入)用户
        /// </summary>
        public LoginUser LoginUser
        {
            get
            {
                if (mLoginUser.uid <= 0)
                    mLoginUser = ConfigManager.LoginUser;

                return mLoginUser;
            }
            set
            {
                mLoginUser = value;

                if (value != null)
                    SaledRecord.UserId = value.uid;
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
                return mGoods;
            }
            set
            {
                mGoods = value;
            }
        }


        public string GoodsStatusName { get { return SharedVariables.GoodsStatusName[Goods == null ? 0 : Goods.Status]; } }


        SaledRecordInfo saledRecordInfo = new SaledRecordInfo();
        public SaledRecordInfo SaledRecord
        {
            get { return saledRecordInfo; }
            set { saledRecordInfo = value; }
        }

        public byte[] GoodsImageBytes
        {
            get
            {
                if (!string.IsNullOrEmpty(mGoods.ImageThum))
                    return Convert.FromBase64String(mGoods.ImageThum);

                return new List<byte>().ToArray();
            }
            //set
            //{
            //    mGoods.ImageThum = Convert.ToBase64String(value);
            //}
        }

        public SaledGoodsInfo Clone()
        {
            var tempGoods = new GoodsInfo();
            var tempSaledRecordInfo = new SaledRecordInfo();

            DBModelBase.Clone<GoodsInfo>(Goods, ref tempGoods);
            DBModelBase.Clone<SaledRecordInfo>(SaledRecord, ref tempSaledRecordInfo);

            return new SaledGoodsInfo()
            {
                Goods=tempGoods,
                SaledRecord=tempSaledRecordInfo
            };
        }

        public override bool Equals(object obj)
        {
            var tempThis = obj as SaledGoodsInfo;
            if (tempThis != null)
            {
                bool isEql = true;
                isEql = tempThis.Goods.Equals(Goods);
                isEql = isEql && tempThis.SaledRecord.Equals(SaledRecord);

                return isEql;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

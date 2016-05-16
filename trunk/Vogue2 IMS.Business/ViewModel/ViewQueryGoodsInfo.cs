using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.Business.ViewModel
{
    public class ViewQueryGoodsInfo : DBModelBase
    {
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

        private DateTime? startDate = null;
        public bool StartDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 起始时间
        /// </summary>
        [DBFieldAttribute("StartDate")]
        public DateTime? StartDate { get { return startDate; } set { startDate = value; StartDateSpecify = true; } }

        private DateTime? endDate = null;
        public bool EndDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 结束时间
        /// </summary>
        [DBFieldAttribute("EndDate")]
        public DateTime? EndDate { get { return endDate; } set { endDate = value; EndDateSpecify = true; } }


        //private DateTime? startPurchaseDate = null;
        //public bool StartPurchaseDateSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 进货起始时间
        ///// </summary>
        //[DBFieldAttribute("StartPurchaseDate")]
        //public DateTime? StartPurchaseDate { get { return startPurchaseDate; } set { startPurchaseDate = value; StartPurchaseDateSpecify = true; } }

        //private DateTime? endPurchaseDate = null;
        //public bool EndPurchaseDateSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 进货结束时间
        ///// </summary>
        //[DBFieldAttribute("EndPurchaseDate")]
        //public DateTime? EndPurchaseDate { get { return endPurchaseDate; } set { endPurchaseDate = value; EndPurchaseDateSpecify = true; } }

        //private DateTime? startSaledDate = null;
        //public bool StartSaledDateSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 售出起始时间
        ///// </summary>
        //[DBFieldAttribute("StartSaledDate")]
        //public DateTime? StartSaledDate { get { return startSaledDate; } set { startSaledDate = value; StartSaledDateSpecify = true; } }

        //private DateTime? endSaledDate = null;
        //public bool EndSaledDateSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 售出结束时间
        ///// </summary>
        //[DBFieldAttribute("EndSaledDate")]
        //public DateTime? EndSaledDate { get { return endSaledDate; } set { endSaledDate = value; EndSaledDateSpecify = true; } }

        private QueryDateRange dataRange=QueryDateRange.Customer;
        public QueryDateRange DateRange
        {
            get { return dataRange; }
            set { dataRange = value;  }
        }

        public override string ToString()
        {
            List<string> conditionSts = new List<string>();
            try
            {
                conditionSts.Add(string.Format("时间：[{0}]-[{1}]",
                    StartDate.HasValue ? StartDate.Value.ToString("yyyy/MM/dd") : "最早"
                    , EndDate.HasValue ? EndDate.Value.ToString("yyyy/MM/dd") : "现在"
                    ));
            }
            finally { }

            return string.Join(",", conditionSts);
        }
    }

    [Serializable]
    public enum QueryDateRange
    {
        ThisWeek,
        ThisMonth,
        ThisQuarter,
        ThisYear,
        AllYear10,
        Customer
    }
}

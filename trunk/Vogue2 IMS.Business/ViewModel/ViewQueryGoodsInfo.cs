﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.Business.ViewModel
{
    public class ViewQueryGoodsInfo : DBModelBase
    {  
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

        private DateTime? salesStartDate = null;
        public bool SalesStartDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 售出起始时间
        /// </summary>
        [DBFieldAttribute("SalesStartDate")]
        public DateTime? SalesStartDate { get { return salesStartDate; } set { salesStartDate = value; SalesStartDateSpecify = true; } }

        private DateTime? salesEndDate = null;
        public bool SalesEndDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 售出结束时间
        /// </summary>
        [DBFieldAttribute("SalesEndDate")]
        public DateTime? SalesEndDate { get { return salesEndDate; } set { salesEndDate = value; SalesEndDateSpecify = true; } }

        private QueryDateRange dateRange=QueryDateRange.Customer;
        public QueryDateRange DateRange
        {
            get { return dateRange; }
            set
            {
                dateRange = value;

                var dateNow = DateTime.Now;

                if (dateRange == QueryDateRange.ThisWeek)
                    StartDate = dateNow.AddDays(1 - Convert.ToInt32(dateNow.DayOfWeek.ToString("d")));

                if (dateRange == QueryDateRange.ThisMonth)
                    StartDate = dateNow.AddDays(1 - dateNow.Day);

                if (dateRange == QueryDateRange.ThisQuarter)
                    StartDate = dateNow.AddMonths(0 - (dateNow.Month - 1) % 3).AddDays(1 - dateNow.Day);

                if (dateRange == QueryDateRange.ThisYear)
                    StartDate = new DateTime(dateNow.Year, 1, 1);

                if (dateRange == QueryDateRange.AllYear10)
                    StartDate = new DateTime(dateNow.Year - 10, 1, 1);

                if (dateRange != QueryDateRange.Customer)
                    EndDate = DateTime.Now;
            }
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

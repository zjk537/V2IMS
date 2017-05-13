using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Business.ViewModel
{
    [Serializable]
    public class ViewDashboard : DBModelBase
    {
        private int jHWeiDaKuan = 0;
        public bool JHWeiDaKuanSpecify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DBFieldAttribute("JHWeiDaKuan")]
        public int JHWeiDaKuan { get { return jHWeiDaKuan; } set { jHWeiDaKuan = value; JHWeiDaKuanSpecify = true; } }

        private int jHChaoQi = 0;
        public bool JHChaoQiSpecify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DBFieldAttribute("JHChaoQi")]
        public int JHChaoQi { get { return jHChaoQi; } set { jHChaoQi = value; JHChaoQiSpecify = true; } }

        private int jHKuCun = 0;
        public bool JHKuCunSpecify { get; set; }
        /// <summary>
        ///
        /// </summary>
        [DBFieldAttribute("JHKuCun")]
        public int JHKuCun { get { return jHKuCun; } set { jHKuCun = value; JHKuCunSpecify = true; } }

        //**************************

        private int jSWeiDaKuan = 0;
        public bool JSWeiDaKuanSpecify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DBFieldAttribute("JSWeiDaKuan")]
        public int JSWeiDaKuan { get { return jSWeiDaKuan; } set { jSWeiDaKuan = value; JSWeiDaKuanSpecify = true; } }

        private int jSChaoQi = 0;
        public bool JSChaoQiSpecify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DBFieldAttribute("JSChaoQi")]
        public int JSChaoQi { get { return jSChaoQi; } set { jSChaoQi = value; JSChaoQiSpecify = true; } }

        private int jSKuCun = 0;
        public bool JSKuCunSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("JSKuCun")]
        public int JSKuCun { get { return jSKuCun; } set { jSKuCun = value; JSKuCunSpecify = true; } }

        private int jinHuoLiang = 0;
        public bool JinHuoLiangSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("JinHuoLiang")]
        public int JinHuoLiang { get { return jinHuoLiang; } set { jinHuoLiang = value; JinHuoLiangSpecify = true; } }

        private int xiaoShouLiang = 0;
        public bool XiaoShouLiangSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("XiaoShouLiang")]
        public int XiaoShouLiang { get { return xiaoShouLiang; } set { xiaoShouLiang = value; XiaoShouLiangSpecify = true; } }

    }

    [Serializable]
    public class ViewQuaryTotal : DBModelBase
     {
         private int? daySpan = null;
         public bool DaySpanSpecify { get; set; }
         /// <summary>
         /// 获取或设置 起始时间
         /// </summary>
         [DBFieldAttribute("DaySpan")]
         public int? DaySpan { get { return daySpan; } set { daySpan = value; DaySpanSpecify = true; } }

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
     }
}

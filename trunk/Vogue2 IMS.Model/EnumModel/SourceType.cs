using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vogue2_IMS.Model.EnumModel
{
    public enum SourceType
    {
        /// <summary>
        /// 寄售
        /// </summary>
        JiShou=1,
        /// <summary>
        /// 进货
        /// </summary>
        JinHuo=2
    }


    public enum GoodsStatus
    {
        /// <summary>
        /// 在库
        /// </summary>
        In = 1,
        /// <summary>
        /// 预定
        /// </summary>
        Catch = 2,
        /// <summary>
        /// 售出
        /// </summary>
        Saled = 3,
        /// <summary>
        /// 取回
        /// </summary>
        GetOut = 4,
    }

    public enum GoodsPaid
    {
        /// <summary>
        /// 已打款
        /// </summary>
        HasPaid = 1,
        /// <summary>
        /// 未打款
        /// </summary>
        NoPaid = 2
        
    }
}

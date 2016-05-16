/* ==============================================================================
 * 功能描述：进货记录表
 * 创 建 者：zjk
 * 创建日期：2013-12-02 22:04
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class PurchaseRecordInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 进货Id
        /// </summary>
        [DBFieldAttribute("PurchaseRecordId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private int userId = 0;
        public bool UserIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 当前用户Id
        /// </summary>
        [DBFieldAttribute("PurchaseRecordUserId")]
        public int UserId { get { return userId; } set { userId = value; UserIdSpecify = true; } }


        private int goodsId = 0;
        public bool GoodsIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("PurchaseRecordGoodsId")]
        public int GoodsId { get { return goodsId; } set { goodsId = value; GoodsIdSpecify = true; } }


        private int payType = 0;
        public bool PayTypeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
        /// </summary>
        [DBFieldAttribute("PurchaseRecordPayType")]
        public int PayType { get { return payType; } set { payType = value; PayTypeSpecify = true; } }


        private string remark = string.Empty;
        public bool RemarkSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("PurchaseRecordRemark")]
        public string Remark { get { return remark; } set { remark = value; RemarkSpecify = true; } }


        private string _operator = string.Empty;
        public bool OperatorSpecify { get; set; }
        /// <summary>
        /// 获取或设置 经手人
        /// </summary>
        [DBFieldAttribute("PurchaseRecordOperator")]
        public string Operator { get { return _operator; } set { _operator = value; OperatorSpecify = true; } }


        private DateTime createdDate = DateTime.Now;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 进货时间
        /// </summary>
        [DBFieldAttribute("PurchaseRecordCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        //public override string ToString()
        //{
        //    return "";
        //}

    }
}

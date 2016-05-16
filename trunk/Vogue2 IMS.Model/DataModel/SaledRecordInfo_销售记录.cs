/* ==============================================================================
 * 功能描述：销售记录
 * 创 建 者：zjk
 * 创建日期：2013-12-02 22:02
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class SaledRecordInfo: DBModelBase
    {
        
        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 销售记录Id
        /// </summary>
        [DBFieldAttribute("SaledRecordId")]
        public int Id {get { return id; } set { id = value; IdSpecify = true; } }
        
        
        private int userId = 0;
        public bool UserIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 当前登录用户名
        /// </summary>
        [DBFieldAttribute("SaledRecordUserId")]
        public int UserId {get { return userId; } set { userId = value; UserIdSpecify = true; } }
        
        
        private int goodsId = 0;
        public bool GoodsIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 货品Id
        /// </summary>
        [DBFieldAttribute("SaledRecordGoodsId")]
        public int GoodsId {get { return goodsId; } set { goodsId = value; GoodsIdSpecify = true; } }
        
        
        private int? payType = null;
        public bool PayTypeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 付款方式：1、现金；2、汇款；3、信用卡；4、网银转帐；
        /// </summary>
        [DBFieldAttribute("SaledRecordPayType")]
        public int? PayType {get { return payType; } set { payType = value; PayTypeSpecify = true; } }
        
        
        private string remark = string.Empty;
        public bool RemarkSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("SaledRecordRemark")]
        public string Remark {get { return remark; } set { remark = value; RemarkSpecify = true; } }


        private string customerName = string.Empty;
        public bool CustomerNameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 顾客姓名
        /// </summary>
        [DBFieldAttribute("SaledRecordCustomerName")]
        public string CustomerName { get { return customerName; } set { customerName = value; CustomerNameSpecify = true; } }


        private string customerPhone = string.Empty;
        public bool CustomerPhoneSpecify { get; set; }
        /// <summary>
        /// 获取或设置 顾客联系方式
        /// </summary>
        [DBFieldAttribute("SaledRecordCustomerPhone")]
        public string CustomerPhone { get { return customerPhone; } set { customerPhone = value; CustomerPhoneSpecify = true; } }
        

        private string _operator = string.Empty;
        public bool OperatorSpecify { get; set; }
        /// <summary>
        /// 获取或设置 经手人
        /// </summary>
        [DBFieldAttribute("SaledRecordOperator")]
        public string Operator {get { return _operator; } set { _operator = value; OperatorSpecify = true; } }


        private decimal? payCharge = null;
        public bool PayChargeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 银行手续费
        /// </summary>
        [DBFieldAttribute("SaledRecordPayCharge")]
        public decimal? PayCharge { get { return payCharge; } set { payCharge = value; PayChargeSpecify = true; } }

        private string batchId = string.Empty;
        public bool BatchIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 出库记录批次号
        /// </summary>
        [DBFieldAttribute("SaledRecordBatchId")]
        public string BatchId { get { return batchId; } set { batchId = value; BatchIdSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 售出时间
        /// </summary>
        [DBFieldAttribute("SaledRecordCreatedDate")]
        public DateTime CreatedDate {get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }
        
        
        //public override string ToString()
        //{
        //    return "";
        //}
        
    }
}

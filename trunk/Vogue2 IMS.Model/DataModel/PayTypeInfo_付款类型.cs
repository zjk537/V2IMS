/* ==============================================================================
 * 功能描述：付款类型表
 * 创 建 者：zjk
 * 创建日期：2013-12-09 17:57
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class PayTypeInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 Id
        /// </summary>
        [DBFieldAttribute("PayTypeId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 付款方式名称
        /// </summary>
        [DBFieldAttribute("PayTypeName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private decimal? bankCharge = null;
        public bool BankChargeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 银行手续费
        /// </summary>
        [DBFieldAttribute("PayTypeBankCharge")]
        public decimal? BankCharge { get { return bankCharge; } set { bankCharge = value; BankChargeSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("PayTypeCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("PayTypeUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }

        public override string ToString()
        {
            return Name;
        }

    }
}

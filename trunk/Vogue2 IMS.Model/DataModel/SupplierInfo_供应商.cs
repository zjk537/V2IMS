/* ==============================================================================
 * 功能描述：供应商
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:31
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class SupplierInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 供应商Id
        /// </summary>
        [DBFieldAttribute("SupplierId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 供应商名称
        /// </summary>
        [DBFieldAttribute("SupplierName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private int? sex = null;
        public bool SexSpecify { get; set; }
        /// <summary>
        /// 获取或设置 供应商性别：0、未知；1、男;2、女;
        /// </summary>
        [DBFieldAttribute("SupplierSex")]
        public int? Sex { get { return sex; } set { sex = value; SexSpecify = true; } }


        private string phone = string.Empty;
        public bool PhoneSpecify { get; set; }
        /// <summary>
        /// 获取或设置 联系电话
        /// </summary>
        [DBFieldAttribute("SupplierPhone")]
        public string Phone { get { return phone; } set { phone = value; PhoneSpecify = true; } }


        private string bankName = string.Empty;
        public bool BankNameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 开户行名称
        /// </summary>
        [DBFieldAttribute("SupplierBankName")]
        public string BankName { get { return bankName; } set { bankName = value; BankNameSpecify = true; } }


        private string bankCard = string.Empty;
        public bool BankCardSpecify { get; set; }
        /// <summary>
        /// 获取或设置 银行卡号
        /// </summary>
        [DBFieldAttribute("SupplierBankCard")]
        public string BankCard { get { return bankCard; } set { bankCard = value; BankCardSpecify = true; } }


        private string idCard = string.Empty;
        public bool IdCardSpecify { get; set; }
        /// <summary>
        /// 获取或设置 身份证号
        /// </summary>
        [DBFieldAttribute("SupplierIdCard")]
        public string IdCard { get { return idCard; } set { idCard = value; IdCardSpecify = true; } }


        private string address = string.Empty;
        public bool AddressSpecify { get; set; }
        /// <summary>
        /// 获取或设置 通信地址
        /// </summary>
        [DBFieldAttribute("SupplierAddress")]
        public string Address { get { return address; } set { address = value; AddressSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("SupplierCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("SupplierUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

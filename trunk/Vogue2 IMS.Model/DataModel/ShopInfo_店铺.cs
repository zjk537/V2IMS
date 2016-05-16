/* ==============================================================================
 * 功能描述：店铺表
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:31
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class ShopInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 店铺Id
        /// </summary>
        [DBFieldAttribute("ShopId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 店铺名称
        /// </summary>
        [DBFieldAttribute("ShopName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private string phone = string.Empty;
        public bool PhoneSpecify { get; set; }
        /// <summary>
        /// 获取或设置 联系电话
        /// </summary>
        [DBFieldAttribute("ShopPhone")]
        public string Phone { get { return phone; } set { phone = value; PhoneSpecify = true; } }


        private string address = string.Empty;
        public bool AddressSpecify { get; set; }
        /// <summary>
        /// 获取或设置 店铺地址
        /// </summary>
        [DBFieldAttribute("ShopAddress")]
        public string Address { get { return address; } set { address = value; AddressSpecify = true; } }


        private string desc = string.Empty;
        public bool DescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 店铺描述
        /// </summary>
        [DBFieldAttribute("ShopDesc")]
        public string Desc { get { return desc; } set { desc = value; DescSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("ShopCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("ShopUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

/* ==============================================================================
 * 功能描述：系统用户
 * 创 建 者：zjk
 * 创建日期：2013-12-09 17:20
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class UserInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 用户Id
        /// </summary>
        [DBFieldAttribute("UserId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private int roleId = 0;
        public bool RoleIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 角色Id
        /// </summary>
        [DBFieldAttribute("UserRoleId")]
        public int RoleId { get { return roleId; } set { roleId = value; RoleIdSpecify = true; } }


        private int shopId = 0;
        public bool ShopIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 所在商铺Id
        /// </summary>
        [DBFieldAttribute("UserShopId")]
        public int ShopId { get { return shopId; } set { shopId = value; ShopIdSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 用户登录名
        /// </summary>
        [DBFieldAttribute("UserName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private string realName = string.Empty;
        public bool RealNameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 用户真实姓名
        /// </summary>
        [DBFieldAttribute("UserRealName")]
        public string RealName { get { return realName; } set { realName = value; RealNameSpecify = true; } }


        private string pwd = string.Empty;
        public bool PwdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 登录密码
        /// </summary>
        [DBFieldAttribute("UserPwd")]
        public string Pwd { get { return pwd; } set { pwd = value; PwdSpecify = true; } }


        private int? sex = null;
        public bool SexSpecify { get; set; }
        /// <summary>
        /// 获取或设置 性别：1、男;2、女;
        /// </summary>
        [DBFieldAttribute("UserSex")]
        public int? Sex { get { return sex; } set { sex = value; SexSpecify = true; } }


        private string phone = string.Empty;
        public bool PhoneSpecify { get; set; }
        /// <summary>
        /// 获取或设置 联系电话
        /// </summary>
        [DBFieldAttribute("UserPhone")]
        public string Phone { get { return phone; } set { phone = value; PhoneSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("UserCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("UserUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

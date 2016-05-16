/* ==============================================================================
 * 功能描述：系统角色表
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:30
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class RoleInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 角色Id
        /// </summary>
        [DBFieldAttribute("RoleId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 角色名称
        /// </summary>
        [DBFieldAttribute("RoleName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private string roleColumnIds = string.Empty;
        public bool RoleColumnIdsSpecify { get; private set; }
        /// <summary>
        /// 获取或设置 角色名称
        /// </summary>
        [DBFieldAttribute("RoleColumnIds")]
        public string RoleColumnIds { get { return roleColumnIds; } set { roleColumnIds = value; RoleColumnIdsSpecify = false; } }


        private string desc = string.Empty;
        public bool DescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 角色描述
        /// </summary>
        [DBFieldAttribute("RoleDesc")]
        public string Desc { get { return desc; } set { desc = value; DescSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("RoleCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("RoleUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

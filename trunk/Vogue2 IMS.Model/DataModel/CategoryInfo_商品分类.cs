/* ==============================================================================
 * 功能描述：商品分类表
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:27
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class CategoryInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类Id
        /// </summary>
        [DBFieldAttribute("CategoryId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private int parentId = 0;
        public bool ParentIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类 父级Id
        /// </summary>
        [DBFieldAttribute("CategoryParentId")]
        public int ParentId { get { return parentId; } set { parentId = value; ParentIdSpecify = true; } }


        private int status = 0;
        public bool StatusSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类状态:1、可用 2、停用
        /// </summary>
        [DBFieldAttribute("CategoryStatus")]
        public int Status { get { return status; } set { status = value; StatusSpecify = true; } }


        private int? order = null;
        public bool OrderSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类排序
        /// </summary>
        [DBFieldAttribute("CategoryOrder")]
        public int? Order { get { return order; } set { order = value; OrderSpecify = true; } }


        private string name = string.Empty;
        public bool NameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类名称
        /// </summary>
        [DBFieldAttribute("CategoryName")]
        public string Name { get { return name; } set { name = value; NameSpecify = true; } }


        private string desc = string.Empty;
        public bool DescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 商品分类描述
        /// </summary>
        [DBFieldAttribute("CategoryDesc")]
        public string Desc { get { return desc; } set { desc = value; DescSpecify = true; } }


        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DBFieldAttribute("CategoryCreatedDate")]
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        private DateTime? updatedDate = null;
        public bool UpdatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DBFieldAttribute("CategoryUpdatedDate")]
        public DateTime? UpdatedDate { get { return updatedDate; } set { updatedDate = value; UpdatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.Name;
        }

    }
}

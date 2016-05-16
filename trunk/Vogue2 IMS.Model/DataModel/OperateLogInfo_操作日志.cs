/* ==============================================================================
 * 功能描述：操作日志表
 * 创 建 者：zjk
 * 创建日期：2013-12-01 23:27
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class OperateLogInfo: DBModelBase
    {
        
        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 日志Id
        /// </summary>
        [DBFieldAttribute("OperateLogId")]
        public int Id {get { return id; } set { id = value; IdSpecify = true; } }
        
        
        private int userId = 0;
        public bool UserIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 当前用户Id
        /// </summary>
        [DBFieldAttribute("OperateLogUserId")]
        public int UserId {get { return userId; } set { userId = value; UserIdSpecify = true; } }
        
        
        private int shopId = 0;
        public bool ShopIdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 用户所在店铺Id
        /// </summary>
        [DBFieldAttribute("OperateLogShopId")]
        public int ShopId {get { return shopId; } set { shopId = value; ShopIdSpecify = true; } }
        
        
        private int? type = null;
        public bool TypeSpecify { get; set; }
        /// <summary>
        /// 获取或设置 操作类型：1、新增；2、修改；3、删除
        /// </summary>
        [DBFieldAttribute("OperateLogType")]
        public int? Type {get { return type; } set { type = value; TypeSpecify = true; } }
        
        
        private string desc = string.Empty;
        public bool DescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 操作描述
        /// </summary>
        [DBFieldAttribute("OperateLogDesc")]
        public string Desc {get { return desc; } set { desc = value; DescSpecify = true; } }
        
        
        private string _operator = string.Empty;
        public bool OperatorSpecify { get; set; }
        /// <summary>
        /// 获取或设置 操作用户
        /// </summary>
        [DBFieldAttribute("OperateLogOperator")]
        public string Operator { get { return _operator; } set { _operator = value; OperatorSpecify = true; } }
        
        
        private DateTime createdDate = DateTime.MinValue;
        public bool CreatedDateSpecify { get; set; }
        /// <summary>
        /// 获取或设置 操作时间
        /// </summary>
        [DBFieldAttribute("OperateLogCreatedDate")]
        public DateTime CreatedDate {get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }
        
        
        //public override string ToString()
        //{
        //    return "";
        //}
        
    }
}

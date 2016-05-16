/* ==============================================================================
 * 功能描述：
 * 创 建 者：zjk
 * 创建日期：2013-12-26 23:18
 * 修改日期：
 * 修改详情：
 * ==============================================================================*/
using System;
using Vogue2_IMS.Common.ModelBase;

namespace Vogue2_IMS.Model.DataModel
{
    public class TableColumnInfo : DBModelBase
    {

        private int id = 0;
        public bool IdSpecify { get; set; }
        /// <summary>
        /// 获取或设置 列Id
        /// </summary>
        [DBFieldAttribute("TableColumnId")]
        public int Id { get { return id; } set { id = value; IdSpecify = true; } }


        private string tableName = string.Empty;
        public bool TableNameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 表名
        /// </summary>
        [DBFieldAttribute("TableColumnTableName")]
        public string TableName { get { return tableName; } set { tableName = value; TableNameSpecify = true; } }


        //private string tableDesc = string.Empty;
        //public bool TableDescSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 表描述
        ///// </summary>
        //[DBFieldAttribute("TableColumnTableDesc")]
        //public string TableDesc { get { return tableDesc; } set { tableDesc = value; TableDescSpecify = true; } }


        private string columnName = string.Empty;
        public bool ColumnNameSpecify { get; set; }
        /// <summary>
        /// 获取或设置 列名
        /// </summary>
        [DBFieldAttribute("TableColumnColumnName")]
        public string ColumnName { get { return columnName; } set { columnName = value; ColumnNameSpecify = true; } }


        private string columnCaption = string.Empty;
        public bool ColumnCaptionSpecify { get; set; }
        /// <summary>
        /// 获取或设置 列标题
        /// </summary>
        [DBFieldAttribute("TableColumnColumnCaption")]
        public string ColumnCaption { get { return columnCaption; } set { columnCaption = value; ColumnCaptionSpecify = true; } }


        private string columnDesc = string.Empty;
        public bool ColumnDescSpecify { get; set; }
        /// <summary>
        /// 获取或设置 列描述
        /// </summary>
        [DBFieldAttribute("TableColumnColumnDesc")]
        public string ColumnDesc { get { return columnDesc; } set { columnDesc = value; ColumnDescSpecify = true; } }


        //private string columnDataType = string.Empty;
        //public bool ColumnDataTypeSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 列数据类型
        ///// </summary>
        //[DBFieldAttribute("TableColumnColumnDataType")]
        //public string ColumnDataType { get { return columnDataType; } set { columnDataType = value; ColumnDataTypeSpecify = true; } }


        //private int columnType = 0;
        //public bool ColumnTypeSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 列类型：1、普通列；2、权限列
        ///// </summary>
        //[DBFieldAttribute("TableColumnColumnType")]
        //public int ColumnType { get { return columnType; } set { columnType = value; ColumnTypeSpecify = true; } }


        //private DateTime? createdDate = null;
        //public bool CreatedDateSpecify { get; set; }
        ///// <summary>
        ///// 获取或设置 列添加时间
        ///// </summary>
        //[DBFieldAttribute("TableColumnCreatedDate")]
        //public DateTime? CreatedDate { get { return createdDate; } set { createdDate = value; CreatedDateSpecify = true; } }


        public override string ToString()
        {
            return this.ColumnCaption;
        }

    }
}

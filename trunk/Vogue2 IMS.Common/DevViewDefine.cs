using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Vogue2_IMS.Common
{
    public class DevViewDefine
    {
        /// <summary>
        /// 重置为简单视图(绑定多选事件，行号事件)
        /// </summary>
        /// <typeparam name="T">Base View</typeparam>
        /// <param name="baseView">View</param>
        /// <param name="isMultiSelect">是否允许多选</param>
        /// <param name="isColumnAutoWidth">是否列自适应视图宽度</param>
        /// <param name="allowAddRows">是否允许添加列</param>
        /// <param name="alloweleteRows">是否允许删除列</param>
        public static void ResetToNormalView<T>(T baseView, bool showViewCaption, bool isMultiSelect = false, bool isColumnAutoWidth = false
            , DefaultBoolean allowAddRows = DefaultBoolean.False, DefaultBoolean alloweleteRows = DefaultBoolean.False) where T : BaseView
        {
            ResetToNormalColumnView(baseView as ColumnView, showViewCaption, isMultiSelect, isColumnAutoWidth, allowAddRows, alloweleteRows);

            ResetToNormalGridView(baseView as GridView,isColumnAutoWidth);
        }

        private static void ResetToNormalColumnView(ColumnView columnView,bool showViewCaption, bool isMultiSelect = false,bool isColumnAutoWidth=false
            , DefaultBoolean allowAddRows = DefaultBoolean.False, DefaultBoolean alloweleteRows = DefaultBoolean.False)
        {
            if (columnView == null) return;

            columnView.OptionsBehavior.EditorShowMode = EditorShowMode.Click;//单击整行选中
            columnView.OptionsBehavior.Editable = false; //是否可编辑
            columnView.OptionsView.ShowViewCaption = showViewCaption;//显示视图标题
            columnView.OptionsSelection.MultiSelect = isMultiSelect;//多选

            columnView.SelectionChanged += ColumnView_SelectionChanged;
            columnView.OptionsBehavior.AllowAddRows = allowAddRows;
            columnView.OptionsBehavior.AllowDeleteRows = alloweleteRows;
            columnView.OptionsPrint.ShowPrintExportProgress = true;
            //columnView.CustomUnboundColumnData+=Colu
        }

        private static void ResetToNormalGridView(GridView gridView,bool isColumnAutoWidth=false)
        {
            if (gridView == null) return;

            gridView.OptionsMenu.EnableColumnMenu = true;//列右键菜单
            gridView.OptionsMenu.EnableGroupPanelMenu = true;//右键菜单中分组面板
            gridView.OptionsMenu.EnableFooterMenu = true;//右键菜单中表尾面板

            gridView.OptionsCustomization.AllowFilter = true;//过滤
            gridView.OptionsCustomization.AllowGroup = true;//分组
            gridView.OptionsCustomization.AllowSort = true;//排序
            gridView.OptionsCustomization.AllowQuickHideColumns = true;//操作隐藏列

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;//焦点样式范围为行        
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;//不显示单元格选中样式
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;

            gridView.OptionsCustomization.AllowColumnMoving = true;//移动列
            gridView.OptionsCustomization.AllowColumnResizing = true;//改变列宽
            gridView.OptionsView.ColumnAutoWidth = isColumnAutoWidth;//列自适应视图宽度

            //gridView.IndicatorWidth = 40;
            //gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
        } 

        /// <summary>
        /// Grid数据为空时的显示信息
        /// </summary>
        public string DrawEmptyShowMsg { get; set; }
        /// <summary>
        /// Grid数据为空时输出空信息提示,相关属性：DrawEmptyShowMsg
        /// </summary>
        /// <param name="sender">ColumnView</param>
        /// <param name="e"></param>
        public void ColumnView_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            BindingSource bindingSource = columnView.DataSource as BindingSource;
            if (columnView.RowCount == 0)
            {
                string str = DrawEmptyShowMsg ?? "没有找到相关数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Top + 5, e.Bounds.Left + 5, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
        }

        /// <summary>
        /// 行号的列宽
        /// </summary>
        public const int IndicatorWidth = 40;
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        
        /// <summary>
        /// 拖动选中行（仅在允许多选时有效）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ColumnView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var columnValue = sender as ColumnView;
            var rowHandlers = columnValue.GetSelectedRows();

            if (rowHandlers != null && rowHandlers.Length > 0)
            {
                foreach (var rowHandle in rowHandlers)
                {
                    columnValue.SelectRow(rowHandle);
                }
            }
        }
    }
}

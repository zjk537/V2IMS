using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Vogue2_IMS.Common.FormBase
{
    public partial class RibbonFormSimpleGridDialogBase : RibbonFormSimpleDialogBase
    {
        public RibbonFormSimpleGridDialogBase()
        {
            InitializeComponent();

            //this.MainRibbonControl.Pages.Clear();
        }

        public RibbonFormSimpleGridDialogBase(Language language=Language.Chinese)
            : base(language)
        {
            InitializeComponent();

            //this.MainRibbonControl.Pages.Clear();
        }

        public GridControl MainGridControl { get { return this.gridControl1; } set { this.gridControl1 = value; } }
        public GridView MainGridView { get { return this.gridView1; } set { this.gridView1 = value; } }
    }
}
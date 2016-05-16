using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace Vogue2_IMS.Common.FormBase
{
    public partial class NavBarFormBase : DevExpress.XtraEditors.XtraForm
    {
        public NavBarFormBase()
        {
            InitializeComponent();

            InitializeNavBar();
        }

        private void InitializeNavBar()
        {
            navBarControl.AllowSelectedLink = true;
            navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            navBarControl.Location = new System.Drawing.Point(0, 0);
            //navBarControl.OptionsNavPane.ExpandedWidth = 195;
            navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            //navBarControl.Size = new System.Drawing.Size(197, 1600);
            //navBarControl.Groups[0].group
            navBarControl.Resize += navBarControl1_Resize;
        }       

        private void navBarControl1_Resize(object sender, EventArgs e)
        {
            var control = ((NavBarControl)sender);
            int width = control.Width + functionTypeGroupContainer.Padding.Left;
            functionTypeGroupContainer.Width = width;
        }
    }
}

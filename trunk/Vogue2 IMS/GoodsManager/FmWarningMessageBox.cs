using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vogue2_IMS.GoodsManager
{
    public partial class FmWarningMessageBox : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler linkViewInfo_Clicked;
        System.Windows.Forms.Timer startTime = new System.Windows.Forms.Timer();
        public const int NormalOpacity = 1;

        public FmWarningMessageBox(Form owner, string userName, int goodsCount, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            this.Owner = owner;

            labelUserName.Text = string.Format(labelUserName.Text, "," + userName);
            linkViewInfo.Text = string.Format(linkViewInfo.Text, goodsCount);
            lblStartDate.Text = startDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = endDate.ToString("dd/MM/yyyy");

            this.Load += new EventHandler(FmWarningMessageBox_Load);
        }

        public EventHandler FmWarningMessageBox_Load
        {
            get
            {
                return (object sender, EventArgs args) =>
                {
                    try
                    {
                        this.TopMost = true;
                        this.Opacity = 0;
                        this.Location = new Point(
                            this.Owner.Width + this.Owner.Location.X - this.Width - 10
                            , this.Owner.Height + this.Owner.Top - this.Height - 10);

                        startTime.Interval = 100;
                        startTime.Tick += new EventHandler((object sender2, EventArgs args2) =>
                        {
                            this.Opacity += 0.2;
                            if (this.Opacity >= 1) startTime.Enabled = false;

                            linkViewInfo.Focus();
                        });

                        startTime.Enabled = true;
                        startTime.Start();
                    }
                    finally { }
                };
            }
        }

        private void linkViewInfo_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (linkViewInfo_Clicked != null)
            {
                linkViewInfo_Clicked(this, new EventArgs());
            }

            this.Close();
        }
    }
}
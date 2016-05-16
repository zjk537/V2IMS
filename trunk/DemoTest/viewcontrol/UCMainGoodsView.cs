using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vogue2_IMS.Business.ViewModel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Base;

namespace Vogue2_IMS.ViewControls
{
    public partial class UCMainGoodsView : DevExpress.XtraEditors.XtraUserControl
    {
        //public UCMainGoodsView(List<ViewMainGoodsInfos> sources)
        //{
        //    InitializeComponent();
            
        //    Grid.DataSource = DataSource;

        //    DataSource = sources;
        //}

        public UCMainGoodsView()
        {
            InitializeComponent();
        }

        //List<ViewMainGoodsInfos> _DataSource = new List<ViewMainGoodsInfos>();
        //public List<ViewMainGoodsInfos> DataSource
        //{
        //    get { return _DataSource; }
        //    set
        //    {
        //        _DataSource = value;
        //        MainView.RefreshData();
        //    }
        //}

        #region GridViews

        public GridControl Grid
        {
            get { return this.gridViewControl; }
            set { this.gridViewControl = value; }
        }

        public GridView GridDefaultView
        {
            get { return this.gridDefaultView; }
            set { this.gridDefaultView = value; }
        }

        public AdvBandedGridView GridAdvBandedView
        {
            get { return this.gridAdvBandedView; }
            set { this.gridAdvBandedView = value; }
        }

        public CardView GridCardView
        {
            get { return this.gridCardView; }
            set { this.gridCardView = value; }
        }

        public BaseView MainView
        {
            get { return Grid.MainView; }
            set { Grid.MainView = value; }
        }

        #endregion

        public void RefreshData()
        {
            Grid.MainView.RefreshData();
        }     
    }
}

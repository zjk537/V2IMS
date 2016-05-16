using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXWindowsApplication1.FormBase;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Business.BusinessModel;
using System.Web;
using System.IO;
using Vogue2_IMS.Business.ViewModel;

namespace DXWindowsApplication1
{
    public partial class XtraForm1 : FormSimpleDialogBase
    {
        public XtraForm1()
        {
            InitializeComponent();
            this.gridViewInfo.DataSource = mListGoods;
            this.Btn_OK.Click += btnOk_Click;
            this.Btn_Cancel.DialogResult = DialogResult.Cancel;
        }

        int i = 0;
        List<PurchaseGoodsInfo> mListGoods = new List<PurchaseGoodsInfo>();
        private void btnOk_Click(object sender, EventArgs e)
        {
            //ViewMainGoodsInfos
            List<ViewMainGoodsInfos> lists = new List<ViewMainGoodsInfos>();
            var resutls = SerializeBinary(lists); ;

            //var oldStr = File.ReadAllText(@"D:\2.txt");
            //var encodeStr = HttpUtility.UrlEncode(File.ReadAllText(@"D:\7.txt"));
            //var newStr = HttpUtility.UrlDecode(File.ReadAllText(@"D:\5.txt"));


            ////GoodsCardView.Focus();
            //////SupplierNameTxt.fo
            ////var temp = new PurchaseGoodsInfo() { Goods = new GoodsInfo() { OriginalCode = i.ToString(),Name=null} };
            ////i++;
            ////mListGoods.Add(temp);
            ////GoodsCardView.RefreshData();
            ////gridView1.RefreshData();
            ////if (GoodsCardView.IsLastRow)
            ////{
            ////    GoodsCardView.MoveLast();
            ////}

            ////MessageBox.Show(GoodsCardView.HasColumnErrors.ToString());
        }

        public static byte[] SerializeBinary(object request)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer =
             new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            serializer.Serialize(memStream, request);
            return memStream.ToArray();
        }
    }
}
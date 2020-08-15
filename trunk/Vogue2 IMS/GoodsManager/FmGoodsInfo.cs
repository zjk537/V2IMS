using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.Business;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Common;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Vogue2_IMS.OrderManager
{
    public partial class FmGoodsInfo : DevExpress.XtraEditors.XtraForm
    {
        public ProInfo NewProInfo = new ProInfo();
        public bool IsPrint { get { return ckbprinted.Checked; } }
        string mRKType = ConfigManager.JiShou;

        private string formText = "";
        /// <summary>
        /// 编辑对象
        /// </summary>
        ProCustInfo newProCustInfo = new ProCustInfo();
        /// <summary>
        /// 原始对象（仅在处于编辑时有值）
        /// </summary>
        ProCustInfo mProBaseInfo = null;

        /// <summary>
        /// 编辑好的对象
        /// </summary>
        public ProCustInfo ProAddInfo
        {
            get
            {
                return newProCustInfo;
            }
        }

        List<WebUserInfo> users = new List<WebUserInfo>();

        public FmGoodsInfo(string rkType)
            : base()
        {
            InitializeComponent();
            mRKType = rkType;
            InitializeControls();
            newProCustInfo.type = mRKType;
            newProCustInfo.uid = ConfigManager.LoginUser.uid;
            newProCustInfo.uname = ConfigManager.LoginUser.username;
            newProCustInfo.uuid = ConfigManager.LoginUser.uid;
            newProCustInfo.uuname = ConfigManager.LoginUser.username; 
        }

        private int proIndex = 0;
        private List<ProInfo> proInfos = new List<ProInfo>();
        public FmGoodsInfo(List<ProInfo> proInfos)
            : base()
        {
            InitializeComponent();
            this.proInfos.AddRange(proInfos);

            InitializeControls(this.proInfos.Count > 0 ? proInfos[proIndex] : null);
        }

        private void InitializeControls(ProInfo proinfo = null)
        {
            users = UserWebBusiness.GetUserInfoList();
            if (proinfo != null)
            {
                btnNext.Visible = btnLast.Visible = true;
                btnNext.Enabled = this.proInfos.Count > proIndex + 1;
                btnLast.Enabled = proIndex != 0;

                var probaseinfo = GoodsWebBusiness.GetProBaseInfo(proinfo.proid.Value);
                newProCustInfo = probaseinfo as ProCustInfo;
                newProCustInfo.cust = proinfo.Cust;
                newProCustInfo.paytype = proinfo.proinpaytype;
                mProBaseInfo = newProCustInfo.Clone();
                newProCustInfo.JUser = users.Find(a => { return a.id == proinfo.proinjuid; });

                newProCustInfo.images = GoodsWebBusiness.GetProImages(proinfo.proid.Value);

                this.mRKType = mProBaseInfo.type;
            }
            else
                newProCustInfo.cust = GoodsWebBusiness.GetCustInfoList(string.Empty);
          

            this.custsex.Properties.Items.Clear();
            this.profenlei.Properties.Items.Clear();
            this.propaytype.Properties.Items.Clear();
            this.projuser.Properties.Items.Clear();
            this.propaystatus.Properties.Items.Clear();
            this.radioGroup1.Properties.Items.Clear();


            this.custsex.Properties.Items.AddRange(new List<string>() { "男", "女" });
            this.profenlei.Properties.Items.AddRange(GoodsWebBusiness.GetProFenLeis());
            this.propaytype.Properties.Items.AddRange(ConfigManager.ProPayType);
            this.projuser.Properties.Items.AddRange(users);
            this.propaystatus.Properties.Items.AddRange(ConfigManager.ProPayStatus);
            this.radioGroup1.Properties.Items.AddRange(ConfigManager.ProFenLei);

         

            ControlsBinding();
        }

        private void ControlsBinding()
        {
            #region form title 

            if (mProBaseInfo == null)
            {
                formText = "商品详情-添加";
            }
            else
            {
                formText = "商品详情";
                if (mProBaseInfo.status == ConfigManager.ZaiKu)
                {
                    formText += "-编辑";
                    SetControlStatus(true);
                }
                if (mProBaseInfo.status == ConfigManager.ShouChu)
                {
                    SetControlStatus(false);
                    formText = "[已售出] " + formText;                 
                }
                if (mProBaseInfo.status == ConfigManager.YuDing)
                {
                    SetControlStatus(false);
                    formText = "[已预定] " + formText; 
                }
                if (mProBaseInfo.status == ConfigManager.QuHui)
                {
                    SetControlStatus(false);
                    formText = "[已取回] " + formText;
                }           
            }
            #endregion

            this.Text = formText;
            labelControl9.Text = mRKType == ConfigManager.JinHuo ? "打款状态" : "结束时间";

            endtime.Visible = mRKType == ConfigManager.JiShou;
            propaystatus.Visible = mRKType == ConfigManager.JinHuo;

            BindCustMsg(true);

            profenlei.DataBindings.Clear();
            projcode.DataBindings.Clear();
            proname.DataBindings.Clear();
            procolor.DataBindings.Clear();
            prochengse.DataBindings.Clear();
            prochima.DataBindings.Clear();
            projiankuan.DataBindings.Clear();
            proyaowei.DataBindings.Clear();
            proxiongwei.DataBindings.Clear();
            protunwei.DataBindings.Clear();
            proyichang.DataBindings.Clear();
            proxiuchang.DataBindings.Clear();
            prokuchang.DataBindings.Clear();
            projuser.DataBindings.Clear();
            probujian.DataBindings.Clear();
            proremark.DataBindings.Clear();
            propaytype.DataBindings.Clear();
            radioGroup1.DataBindings.Clear();

            profenlei.DataBindings.Add("Text", newProCustInfo, "pinpai");
            projcode.DataBindings.Add("Text", newProCustInfo, "jcode");
            proname.DataBindings.Add("Text", newProCustInfo, "name");
            procolor.DataBindings.Add("Text", newProCustInfo, "color");
            prochengse.DataBindings.Add("Text", newProCustInfo, "chengse");
            prochima.DataBindings.Add("Text", newProCustInfo, "chima");
            projiankuan.DataBindings.Add("Text", newProCustInfo, "jiankuan");
            proyaowei.DataBindings.Add("Text", newProCustInfo, "yaowei");
            proxiongwei.DataBindings.Add("Text", newProCustInfo, "xiongwei");
            protunwei.DataBindings.Add("Text", newProCustInfo, "tunwei");
            proyichang.DataBindings.Add("Text", newProCustInfo, "yichang");
            proxiuchang.DataBindings.Add("Text", newProCustInfo, "xiuchang");
            prokuchang.DataBindings.Add("Text", newProCustInfo, "kuchang");

            projuser.DataBindings.Add("EditValue", newProCustInfo, "JUser");
            
            probujian.DataBindings.Add("Text", newProCustInfo, "bujian");
            proremark.DataBindings.Add("Text", newProCustInfo, "remark");

            proimage.EditValue = newProCustInfo.imagebytes;

            propaytype.DataBindings.Add("EditValue", newProCustInfo, "paytype");

            radioGroup1.DataBindings.Add("EditValue", newProCustInfo, "fenlei");


            if (this.mRKType == ConfigManager.JinHuo)
            {
                propaystatus.Text ="已打款";
                propaystatus.Enabled = false;
            }
            else
            {
                propaystatus.SelectedIndex = 1;
            }
            projiage.EditValue = newProCustInfo.jiage ?? 0;
            probjiage.EditValue = newProCustInfo.bjiage ?? 0;
            endtime.EditValue = newProCustInfo.endtime.HasValue ? newProCustInfo.endtime.Value.ToString("yyyy/MM/dd") : "";

            gcExtendInfo.Visible = radioGroup1.EditValue.ToString() == "衣服";
        }


        private void BindCustMsg(bool isRefresh=false)
        {
            if (!isRefresh)
            {
                custname.DataBindings.Add("Text", newProCustInfo.cust, "name");
                custphone.DataBindings.Add("Text", newProCustInfo.cust, "phone");
                custsex.DataBindings.Add("Text", newProCustInfo.cust, "sex");
                custidcard.DataBindings.Add("Text", newProCustInfo.cust, "idcard");
                custyhname.DataBindings.Add("Text", newProCustInfo.cust, "yhname");
                custyhcard.DataBindings.Add("Text", newProCustInfo.cust, "yhcard");
                custdizhi.DataBindings.Add("Text", newProCustInfo.cust, "dizhi");

            }
            else
            {
                custname.DataBindings.Clear();
                custphone.DataBindings.Clear();
                custsex.DataBindings.Clear();
                custidcard.DataBindings.Clear();
                custyhname.DataBindings.Clear();
                custyhcard.DataBindings.Clear();
                custdizhi.DataBindings.Clear();

                BindCustMsg();
            }
          
        }

        private byte[] GetGoodsLargeImage()
        {
            var imgStr = string.Empty;
            if (newProCustInfo.id.HasValue && newProCustInfo.id.Value > 0 )
            {
                imgStr = GoodsBusiness.Instance.GetGoodsImage(newProCustInfo.id.Value);
            }


            if (!string.IsNullOrEmpty(imgStr))
            {
                newProCustInfo.images = newProCustInfo.images == null ? new List<string>() : newProCustInfo.images;
                newProCustInfo.images.Add(imgStr);

                return Convert.FromBase64String(imgStr);
            }

            return new List<byte>().ToArray();
        }

        private void SetControlStatus(bool status)
        {
            //this.status = status;// && SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.AdminRoleId;
            this.propaytype.Enabled =
            this.propaystatus.Enabled =
            this.projuser.Enabled =
            this.profenlei.Enabled =
            this.procolor.Enabled =
            this.proremark.Enabled =
            this.probjiage.Enabled =
            this.proname.Enabled =
            this.projcode.Enabled =
            this.probujian.Enabled =
            this.projiage.Enabled =
                this.proimage.Enabled =
            this.prochengse.Enabled =
            this.endtime.Enabled =
            this.gcExtendInfo.Enabled=
            this.groupControl6.Enabled=
            this.probujian.Enabled =
            this.proremark.Enabled = status;// || SharedVariables.Instance.LoginUser.User.RoleId == SharedVariables.PMRoleId;
        }

        private bool ValidatFail()
        {
            mErrorProvider.ClearErrors();
            decimal validationTryDecimal = 0;

            #region cust

            if (string.IsNullOrEmpty(this.custname.Text))
            {
                mErrorProvider.SetError(this.custname, "供应商名称不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.custphone.Text))
            {
                mErrorProvider.SetError(this.custphone, "联系方式不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.custyhname.Text))
            {
                mErrorProvider.SetError(this.custyhname, "开户行不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.custyhcard.Text))
            {
                mErrorProvider.SetError(this.custyhcard, "银行卡号不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.custidcard.Text))
            {
                mErrorProvider.SetError(this.custidcard, "证件号码不能为空", ErrorType.Warning);
            }

            if (custsex.SelectedIndex < 0)
            {
                custsex.SelectedIndex = 0;
            }

            this.newProCustInfo.cust.sex = custsex.Text;

            #endregion

            if (string.IsNullOrEmpty(this.profenlei.Text))
            {
                mErrorProvider.SetError(this.profenlei, "请选择或者输入类别", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.projcode.Text.Trim()))
            {
                mErrorProvider.SetError(this.projcode, "不能为空", ErrorType.Warning);
            }
            if (string.IsNullOrEmpty(this.proname.Text.Trim()))
            {
                mErrorProvider.SetError(this.proname, "不能为空", ErrorType.Warning);
            }
            //商品颜色默认：未知          
            //商品成色默认：未知           
            if (string.IsNullOrEmpty(this.propaytype.Text))
            {
                mErrorProvider.SetError(this.propaytype, "请选择付款方式", ErrorType.Warning);
            }

            if (projiage.EditValue == null || !decimal.TryParse(projiage.EditValue.ToString().Trim(), out validationTryDecimal))
            {
                mErrorProvider.SetError(this.projiage, "请输入正确的价格", ErrorType.Warning);
            }
            else newProCustInfo.jiage = validationTryDecimal;

            if (probjiage.EditValue == null || !decimal.TryParse(probjiage.EditValue.ToString(), out validationTryDecimal))
            {
                mErrorProvider.SetError(this.probjiage, "请输入正确的价格", ErrorType.Warning);
            }
            else newProCustInfo.bjiage = validationTryDecimal;

            //if (string.IsNullOrEmpty(this.projuser.Text.Trim()))
            if (this.projuser.EditValue == null || string.IsNullOrEmpty(this.projuser.Text.Trim()))
            {
                mErrorProvider.SetError(this.projuser, "请选择经手人", ErrorType.Warning);
            }
            else
            {
                newProCustInfo.JUser = this.projuser.SelectedItem as WebUserInfo;
            }

            if (mRKType == ConfigManager.JiShou && (this.endtime.EditValue == null || this.endtime.EditValue.Equals("")))
            {
                mErrorProvider.SetError(this.endtime, "请输入寄售结束时间", ErrorType.Warning);
            }


            return mErrorProvider.HasErrors;
        }

        private void GoodsPictureImage_DoubleClick(object sender, EventArgs e)
        {
            proimage.LoadImage();

            var imgguid = proimage.Image.RawFormat.Guid;
            var type = string.Empty;
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
            {
                if (codec.FormatID == imgguid)
                    type= codec.MimeType;
            }

            //var imgStrFormat = string.Format("data:{0};base64,", type);
            newProCustInfo.ImgStrFormat = type;

            newProCustInfo.imagebytes = (byte[])proimage.EditValue;
        }

        private void ComboxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidatFail();
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            if (((Control)sender) == proname)
            {
                this.Text = formText + (string.IsNullOrEmpty(proname.Text) ? "" : "-" + proname.Text);
            }

            ValidatFail();
        }

        private void TextEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(custphone.Text.Trim())){
                return;
            }
            newProCustInfo.cust = GoodsWebBusiness.GetCustInfoList(custphone.Text.Trim());
            BindCustMsg(true);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ConfigManager.LoginUser.posname.Trim() == "店员")
            {
                XtraMessageBox.Show("请联系店长,修改商品信息.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidatFail())
            {
                if (string.IsNullOrEmpty(endtime.EditValue.ToString()))
                {
                    newProCustInfo.endtime = null;
                }
                else
                {
                    newProCustInfo.endtime = (this.endtime.EditValue == null || this.endtime.EditValue.Equals(""))
                        ? new Nullable<DateTime>()
                        : Convert.ToDateTime(endtime.EditValue);
                }

                //进货为已打款1，寄售为未打款2
                newProCustInfo.paystatus = propaystatus.Text;

                if (mProBaseInfo != null)
                {
                    this.NewProInfo = GoodsWebBusiness.ProEdit(newProCustInfo);
                }
                else
                {
                    this.NewProInfo = GoodsWebBusiness.ProAdd(newProCustInfo);
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gcExtendInfo.Visible = radioGroup1.EditValue.ToString() == "衣服";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            proIndex++;
            InitializeControls(this.proInfos[proIndex]);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            proIndex--;
            InitializeControls(this.proInfos[proIndex]);
        }
    }
}
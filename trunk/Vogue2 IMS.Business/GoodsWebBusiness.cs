using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.ViewModel;

namespace Vogue2_IMS.Business
{
    public class GoodsWebBusiness
    {
        private static string _urlProList = " http://120.27.21.93:8080/api.php/pc/pro/lists";
        private static string _urlProDetail = " http://120.27.21.93:8080/api.php/pc/pro/detail";
        private static string _urlProAdd = " http://120.27.21.93:8080/api.php/pc/pro/add";
        private static string _urlProEdit = " http://120.27.21.93:8080/api.php/pc/pro/edit";
        private static string _urlCustList = " http://120.27.21.93:8080/api.php/pc/cust/lists";
        private static string _urlProOut = " http://120.27.21.93:8080/api.php/pc/proout/add";
        private static string _urlProTongJi = " http://120.27.21.93:8080/api.php/pc/pro/tongji";

        private static string _urlProQuHui = " http://120.27.21.93:8080/api.php/pc/pro/quhui";
        private static string _urlProTuiHuo = " http://120.27.21.93:8080/api.php/pc/pro/tuihuo";
        private static string _urlProDaKuan = " http://120.27.21.93:8080/api.php/pc/pro/dakuan";

        private static string _urlProGetImages = " http://120.27.21.93:8080/api.php/pc/pro/getimages";
        private static string _urlProgettypes = "http://120.27.21.93:8080/api.php/pc/pro/gettypes";

        public static List<string> GetProImages(int proid)
        {
            var result = new List<string>();
            var repsone = WebServiceHelper.HttpPost<object, string[]>(_urlProGetImages, new { attid = proid });

            if (repsone != null && repsone.Length > 0)
                result.AddRange(repsone);

            return result;
        }

        public static DashBoard GetProTongJi(DashBoardRequest request)
        {
            return WebServiceHelper.HttpPost<DashBoardRequest, DashBoard>(_urlProTongJi, request);
        }

        public static List<ProInfo> GetProInfoList(ProListRequest request)
        {
            var result = new List<ProInfo>();
            bool theEnd = false;

            while (!theEnd)
            {
                var data = WebServiceHelper.HttpPost<ProListRequest, ProListRepsone>(_urlProList, request);

                if (data != null && data.list != null && data.list.Length > 0)
                {
                    result.AddRange(data.list);
                    theEnd = data.IsEnd;

                    request.pageIndex += theEnd ? 0 : 1;
                }
                else
                {
                    theEnd = true;
                }
            }

            return result;
        }

        public static ProCustInfo GetProBaseInfo(int proId)
        {
            return WebServiceHelper.HttpPost<object, ProCustInfo>(_urlProDetail, new { id = proId });
        }

        public static CustInfo GetCustInfoList(string phone)
        {
            var repsone = WebServiceHelper.HttpPost<object, CustListRepsone>(_urlCustList, new { keys = phone });

            if (repsone != null && repsone.list != null && repsone.list.Count() > 0)
                return repsone.list.First();

            return new CustInfo();
        }

        public static List<string> GetProFenLeis()
        {
            var result = new List<string>();
            var repsone = WebServiceHelper.HttpPost<string, string[]>(_urlProgettypes, null);

            if (repsone != null && repsone.Length > 0)
                result.AddRange(repsone);

            return result;
        }

        public static void ProAdd(ProCustInfo proCustInfo)
        {
            WebServiceHelper.HttpPost<ProCustInfo, string>(_urlProAdd, proCustInfo);
        }

        public static void ProEdit(ProCustInfo proCustInfo)
        {
            WebServiceHelper.HttpPost<ProCustInfo, string>(_urlProEdit, proCustInfo);
        }

        public static void ProOut(ProSalesInfo proSalesInfo)
        {
            WebServiceHelper.HttpPost<ProSalesInfo, string>(_urlProOut, proSalesInfo);
        }

        public static void ProQuHui(List<int> ids)
        {
            WebServiceHelper.HttpPost<object, string>(_urlProQuHui, new { ids = ids });
        }

        public static void ProTuiHuo(List<int> ids)
        {
            WebServiceHelper.HttpPost<object, string>(_urlProTuiHuo, new { ids = ids });
        }

        public static void ProDaKuan(List<int> ids)
        {
            WebServiceHelper.HttpPost<object, string>(_urlProDaKuan, new { ids = ids });
        }

        public static List<string>  ProDaKuan(int attid)
        {
           var data=  WebServiceHelper.HttpPost<object, string[]>(_urlProDaKuan, new { attid = attid });
           var result = new List<string>();

           result.AddRange(data);

           return result;
        }

        //通过更新时间查询产品
        //通过手机号查询供应商
        //通过产品ID查询商品包括图片信息
        //批量修改商品

    }

    #region

    public class ProListRequest
    {
        private string _order = "proid";
        public string order { get { return _order; } set { _order = value; } }
        public string sort { get; set; }
        public string keys { get; set; }
        public DateTime? stime { get; set; }
        public DateTime? etime { get; set; }
        public DateTime? ostime { get; set; }
        public DateTime? oetime { get; set; }
        private int _pageIndex = 1;
        public int pageIndex { get { return _pageIndex; } set { _pageIndex = value; } }

        public ProListRequest Clone()
        {
            return new ProListRequest()
            {
                sort = this.sort,
                keys = this.keys,
                stime = this.stime,
                etime = this.etime,
                ostime = this.ostime,
                oetime = this.oetime,
                pageIndex = this.pageIndex

            };
        }


        private QueryDateRange dateRange = QueryDateRange.Customer;
        public QueryDateRange DateRange
        {
            get { return dateRange; }
            set
            {
                dateRange = value;

                var dateNow = DateTime.Now;

                if (dateRange == QueryDateRange.ThisWeek)
                {
                    var weekday = Convert.ToInt32(dateNow.DayOfWeek.ToString("d"));
                    stime = dateNow.AddDays(1 - (weekday == 0 ? 7 : weekday));
                }

                if (dateRange == QueryDateRange.ThisMonth)
                    stime = dateNow.AddDays(1 - dateNow.Day);

                if (dateRange == QueryDateRange.ThisQuarter)
                    stime = dateNow.AddMonths(0 - (dateNow.Month - 1) % 3).AddDays(1 - dateNow.Day);

                if (dateRange == QueryDateRange.ThisYear)
                    stime = new DateTime(dateNow.Year, 1, 1);

                if (dateRange == QueryDateRange.AllYear10)
                    stime = new DateTime(dateNow.Year - 10, 1, 1);

                if (dateRange != QueryDateRange.Customer)
                    etime = DateTime.Now;
            }
        }

        public override string ToString()
        {
            List<string> conditionSts = new List<string>();
            try
            {
                conditionSts.Add(string.Format("时间：[{0}]-[{1}]",
                    stime.HasValue ? stime.Value.ToString("yyyy/MM/dd") : "最早"
                    , etime.HasValue ? etime.Value.ToString("yyyy/MM/dd") : "现在"
                    ));
            }
            finally { }

            return string.Join(",", conditionSts);
        }
    }
    public class ProListRepsone
    {
        public ProInfo[] list { get; set; }

        public int totalCount { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public bool IsEnd
        {
            get
            {
                return pageIndex * pageSize >= totalCount;
            }
        }

       // public int NextPageIndex { get { retun 1; } }
    }
    public class ProInfo
    {
        public bool CheckEdit { get; set; }  

        public int? proid { get; set; }
        public int? prodepid { get; set; }
        public string prodepname { get; set; }
        public string prodepphone { get; set; }
        public string proname { get; set; }
        public string profenlei { get; set; }
        public string propinpai { get; set; }
        public string procode { get; set; }
        public string projcode { get; set; }
        public int? projcustid { get; set; }
        public string projcustname { get; set; }
        public string protype { get; set; }
        public string procolor { get; set; }
        public string prochengse { get; set; }
        public string probujian { get; set; }
        public string prochima { get; set; }
        public string projiankuan { get; set; }
        public string proyaowei { get; set; }
        public string proxiongwei { get; set; }
        public string protunwei { get; set; }
        public string proyichang { get; set; }
        public string prokuchang { get; set; }
        public string proxiuchang { get; set; }
        public decimal? projiage { get; set; }
        public decimal? probjiage { get; set; }
        public decimal? prosjiage { get; set; }
        public decimal? proyufu { get; set; }
        public decimal? prozhekou { get; set; }
        public string prostatus { get; set; }
        public string propaystatus { get; set; }
        public string proremark { get; set; }
        public DateTime? prostarttime { get; set; }
        public DateTime? proendtime { get; set; }
        public int? prouid { get; set; }
        public string prouname { get; set; }
        public DateTime? proaddtime { get; set; }
        public int? prouuid { get; set; }
        public string prouuname { get; set; }
        public DateTime? proupdatetime { get; set; }
        public int? proinid { get; set; }
        public int? proinjpid { get; set; }
        public string proinjpname { get; set; }
        public string proinjpjiage { get; set; }
        public string proinremark { get; set; }
        public string proinpaytype { get; set; }
        public int? proinjuid { get; set; }
        public string proinjuname { get; set; }
        public int? proinuid { get; set; }
        public string proinuname { get; set; }
        public DateTime? proinaddtime { get; set; }
        public int? proinuuid { get; set; }
        public string proinuuname { get; set; }
        public DateTime? proinupdatetime { get; set; }
        public int? prooutid { get; set; }
        public int? prooutjpid { get; set; }
        public string prooutjpname { get; set; }
        public decimal? prooutjpsjiage { get; set; }
        public string prooutpaytype { get; set; }
        public string prooutcustname { get; set; }
        public string prooutcustphone { get; set; }
        public string prooutbeizhu { get; set; }
        public int? prooutjuid { get; set; }
        public string prooutjuname { get; set; }
        public int? prooutuid { get; set; }
        public string prooutuname { get; set; }
        public DateTime? prooutaddtime { get; set; }
        public int? prooutuuid { get; set; }
        public string prooutuuname { get; set; }
        public DateTime? prooutupdatetime { get; set; }
        public int? custid { get; set; }
        public string custname { get; set; }
        public string custphone { get; set; }
        public int? custstatus { get; set; }
        public string custremark { get; set; }
        public string custdizhi { get; set; }
        public string custsex { get; set; }
        public string custyhname { get; set; }
        public string custyhcard { get; set; }
        public string custidcard { get; set; }
        public string custtype { get; set; }
        public int? custjuid { get; set; }
        public string custjuname { get; set; }
        public int? custuid { get; set; }
        public string custuname { get; set; }
        public DateTime? custaddtime { get; set; }
        public int? custuuid { get; set; }
        public string custuuname { get; set; }
        public DateTime? custupdatetime { get; set; }

        public CustInfo Cust
        {
            get{
                return new CustInfo()
                {
                    id = custid,
                    addtime = custaddtime,
                    dizhi = custdizhi,
                    idcard = custidcard,
                    juid = custjuid,
                    juname = custjuname,
                    name = custname,
                    phone = custphone,
                    remark = custremark,
                    sex = custsex,
                    status = custstatus,
                    type = custtype,
                    uid = custuid,
                    uname = custuname,
                    updatetime = custupdatetime,
                    uuid = custuuid,
                    uuname = custuuname,
                    yhcard = custyhcard,
                    yhname = custyhname
                };
            
            } 
        }

        public List<string> images { get; set; }

        public byte[] imagebytes
        {
            get
            {
                if (images != null && images.Count() > 0)
                {
                    var imageStr = images.FirstOrDefault();
                    var imageStrs = imageStr.Split(',');
                    if (imageStrs.Length > 1)
                    {
                        return Convert.FromBase64String(imageStrs[1]);
                    }
                }

                return new List<byte>().ToArray();
            }          
        }

        public ProSalesInfo ProSalesInfo
        {
            get {
                return new ProSalesInfo()
                {
                    fenlei=profenlei,
                    pinpai = propinpai,
                    bjiage = probjiage,
                    jpid = proid,
                    jpname = proname,
                    jpsjiage = prosjiage,
                    yufu = proyufu,
                    zhekou = prozhekou,
                    custname = prooutcustname,
                    custphone = prooutcustphone,
                    juname = prooutjuname,
                    juid = prooutjuid,
                    status=prostatus
                };
            }
        }
    }

    public class ProBaseInfo
    {
        public ProBaseInfo() { }

        public int? id { get; set; }
        public string name { get; set; }
        public string fenlei { get; set; }
        public string pinpai { get; set; }
        public string code { get; set; }
        public string jcode { get; set; }     
        public string type { get; set; }
        public string color { get; set; }
        public string chengse { get; set; }
        public string bujian { get; set; }
        public string chima { get; set; }
        public string jiankuan { get; set; }
        public string yaowei { get; set; }
        public string xiongwei { get; set; }
        public string tunwei { get; set; }
        public string yichang { get; set; }
        public string kuchang { get; set; }
        public string xiuchang { get; set; }
        public decimal? jiage { get; set; }
        public decimal? bjiage { get; set; }
        public decimal? sjiage { get; set; }
        public decimal? yufu { get; set; }
        public decimal? zhekou { get; set; }
        public string status { get; set; }
        public string paystatus { get; set; }
        public string paytype { get; set; }
        public string remark { get; set; }
        public DateTime? starttime { get; set; }
        public DateTime? endtime { get; set; }
        public int uid { get; set; }
        public string uname { get; set; }
        public int juid { get; set; }
        public string juname { get; set; }
        public DateTime? addtime { get; set; }
        public int? uuid { get; set; }
        public string uuname { get; set; }
        public DateTime? updatetime { get; set; }
        public List<string> images { get; set; }

        public T Clone<T>() where T : ProBaseInfo,new()
        {
            return new T()
            {
                id = id,
                name = name,
                fenlei = fenlei,
                code = code,
                jcode = jcode,
                type = type,
                color = color,
                chengse = chengse,
                bujian = bujian,
                chima = chima,
                jiankuan = jiankuan,
                yaowei = yaowei,
                xiongwei = xiongwei,
                tunwei = tunwei,
                yichang = yichang,
                kuchang = kuchang,
                xiuchang = xiuchang,
                jiage = jiage,
                bjiage = bjiage,
                sjiage = sjiage,
                yufu = yufu,
                zhekou = zhekou,
                status = status,
                paystatus = paystatus,
                remark = remark,
                starttime = starttime,
                endtime = endtime,
                uid = uid,
                uname = uname,
                addtime = addtime,
                uuid = uuid,
                uuname = uuname,
                updatetime = updatetime,
                images = images
            };
        }

        private string imgStrFormat = string.Empty;
        private string imageType = string.Empty;
        public string ImgStrFormat
        {
            get
            {
                return imageType;
            }
            set
            {
                imageType = value;
            }
        }
        public byte[] imagebytes
        {
            get
            {
                if(images!=null &&images.Count()>0)
                {
                    var imageStr = images.FirstOrDefault();
                    var imageStrs = imageStr.Split(',');
                    if (imageStrs.Length > 1)
                    {
                        return Convert.FromBase64String(imageStrs[1]);
                    }
                }

                return new List<byte>().ToArray();
            }
            set
            {
                images = new List<string>();

                images.Add(string.Format("data:{0};base64,{1}", ImgStrFormat, Convert.ToBase64String(value)));
            }
        }
    }
    public class ProBaseRequest
    {
        public int id { get; set; }
    }

    public class ProCustInfo : ProBaseInfo
    {
        //public WebUserInfo juser { get; set; }       

        private WebUserInfo mJuser = null;
        public WebUserInfo JUser
        {
            get { return mJuser; }
            set
            {
                mJuser = value;
                if (mJuser != null)
                {
                    this.juid = mJuser.id;
                    this.juname = mJuser.truename;
                }
            }
        }

        private CustInfo _cust = new CustInfo();
        public CustInfo cust { get { return _cust; } set { _cust = value; } }

        public ProCustInfo Clone()
        {
            var result = base.Clone<ProCustInfo>();
            result.cust = cust.Clone();

            return result;
        }
    }

    public class CustInfo
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int? status { get; set; }
        public string remark { get; set; }
        public string dizhi { get; set; }
        public string sex { get; set; }
        public string yhname { get; set; }
        public string yhcard { get; set; }
        public string idcard { get; set; }
        public string type { get; set; }
        public int? juid { get; set; }
        public string juname { get; set; }
        public int? uid { get; set; }
        public string uname { get; set; }
        public DateTime? addtime { get; set; }
        public int? uuid { get; set; }
        public string uuname { get; set; }
        public DateTime? updatetime { get; set; }

        public CustInfo Clone()
        {
            return new CustInfo()
            {
                id = id,
                name = name,
                phone = phone,
                status = status,
                remark = remark,
                dizhi = dizhi,
                sex = sex,
                yhname = yhname,
                yhcard = yhcard,
                idcard = idcard,
                type = type,
                juid = juid,
                juname = juname,
                uid = uid,
                uname = uname,
                addtime = addtime,
                uuid = uuid,
                uuname = uuname,
                updatetime = updatetime
            };
        }
    }

    public class CustListRepsone
    {
        public CustInfo[] list { get; set; }

        public int totalCount { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public bool IsEnd
        {
            get
            {
                return pageIndex * pageSize >= totalCount;
            }
        }

        public int NextPageIndex { get { return pageSize++; } }
    }

    public class ProSalesInfo
    {
        private WebUserInfo mJuser = null;
        public WebUserInfo JUser
        {
            get { return mJuser; }
            set
            {
                mJuser = value;
                if (mJuser != null)
                {
                    this.juid = mJuser.id;
                    this.juname = mJuser.truename;
                }
            }
        }


        public string fenlei { get; set; }
        public string pinpai { get; set; }

        public decimal? bjiage { get; set; }
        public int? jpid { get; set; }
        public string jpname { get; set; }
        public decimal? jpsjiage { get; set; }
        public decimal? yufu { get; set; }
        public decimal? zhekou { get; set; }
        public string custname { get; set; }
        public string custphone { get; set; }
        public string beizhu { get; set; }
        public string status { get; set; }
        public string juname { get; set; }
        public int? juid { get; set; }

        public List<string> images { get; set; }

        private string imgStrFormat = string.Empty;
        private string imageType = string.Empty;
        public string ImgStrFormat
        {
            get
            {
                return imageType;
            }
            set
            {
                imageType = value;
            }
        }
        public byte[] imagebytes
        {
            get
            {
                if (images != null && images.Count() > 0)
                {
                    var imageStr = images.FirstOrDefault();
                    var imageStrs = imageStr.Split(',');
                    if (imageStrs.Length > 1)
                    {
                        return Convert.FromBase64String(imageStrs[1]);
                    }
                }

                return new List<byte>().ToArray();
            }
            set
            {
                images = new List<string>();

                images.Add(string.Format("data:{0};base64,{1}", ImgStrFormat, Convert.ToBase64String(value)));
            }
        }

    }

    public class DashBoardRequest
    {
        public int dayspan { get; set; }
        public DateTime? stime { get; set; }
        public DateTime? etime { get; set; }
    }
    public class DashBoard
    {
        public int jsweidakuan { get; set; }
        public int jschaoqi { get; set; }
        public int jskucun { get; set; }
        public int jhweidakuan { get; set; }
        public int jhchaoqi { get; set; }
        public int jhkucun { get; set; }
        public int jinhuoliang { get; set; }
        public int xiaoshouliang { get; set; }
    }
    
    #endregion
}


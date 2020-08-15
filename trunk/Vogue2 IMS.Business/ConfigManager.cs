using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vogue2_IMS.Business
{
    public static class ConfigManager
    {
        public static string JinHuo = "进货";
        public static string JiShou = "寄售";
        public static string ZaiKu = "在库";
        public static string YuDing = "预定";
        public static string ShouChu = "售出";
        public static string QuHui = "取回";
        public static string YiDaKuan = "已打款";

        private static string _urlLogin = "/public/login";
        private static string _urlConifgs = "/config/lists";
        private static string _urlLogLists = "/log/lists";
    
        public static void Login(string username,string password)
        {
            var user=new LoginUser() { username = username, password = password };

            var loginRes = WebServiceHelper.HttpPost<LoginUser, LoginUser>(_urlLogin, user);
            WebServiceHelper.Token = loginRes.token;
            LoginUser = loginRes;

            var res = WebServiceHelper.HttpPost<LoginUser, List<RepsonseConfigMsg>>(_urlConifgs, null);

            ProPayStatus = res.First(a => a.name == RepsonseConfigMsg.PRO_PAY_STATUS).Values;
            ProPayType = res.First(a => a.name == RepsonseConfigMsg.PRO_PAY_TYPE).Values;
            ProStatus = res.First(a => a.name == RepsonseConfigMsg.PRO_STATUS).Values;
            ProType = res.First(a => a.name == RepsonseConfigMsg.PRO_TYPE).Values;
            BaseSex = res.First(a => a.name == RepsonseConfigMsg.BASE_SEX).Values;

            ProFenLei = res.First(a => a.name == RepsonseConfigMsg.PRO_FENLEI).Values;
        }

        public static LoginUser LoginUser { get; private set; }

        public static List<RepsonseConfigMsg> ConfigMsgs { get; private set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public static List<string> ProPayStatus { get; private set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public static List<string> ProStatus { get; private set; }
        /// <summary>
        /// 付款类型
        /// </summary>
        public static List<string> ProPayType { get; private set; }
        /// <summary>
        /// 商品分类
        /// </summary>
        public static List<string> ProType { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public static List<string> BaseSex { get; private set; }

        /// <summary>
        /// 性别
        /// </summary>
        public static List<string> ProFenLei { get; private set; }
    }

    public class RepsonseConfigMsg
    {
        /// <summary>
        /// 商品状态
        /// </summary>
        public static string PRO_STATUS = "PRO_STATUS";
        /// <summary>
        /// 付款类型
        /// </summary>
        public static string PRO_PAY_TYPE = "PRO_PAY_TYPE";
        /// <summary>
        /// 付款状态
        /// </summary>
        public static string PRO_PAY_STATUS = "PRO_PAY_STATUS";
        /// <summary>
        /// 商品类型
        /// </summary>
        public static string PRO_TYPE = "PRO_TYPE";
        /// <summary>
        /// 性别 
        /// </summary>
        public static string BASE_SEX = "BASE_SEX";

        /// <summary>
        /// 性别 
        /// </summary>
        public static string PRO_FENLEI = "PRO_FENLEI";

        public string type { get; set; }
        public string name { get; set; }

        private string _value = string.Empty;
        public string value
        {
            get { return _value; }
            set
            {
                _value = value;

                Values = Values == null ? new List<string>() : Values;
                Values.Clear();
                if (!string.IsNullOrEmpty(_value))
                {
                    Values.AddRange(_value.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }

        public List<string> Values { get; set; }
    }

}

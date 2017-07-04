using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.ViewModel;

namespace Vogue2_IMS.Business
{
    public class UserListRequest
    {
        //public int? depid { get; set; }
    }
    public class UserListRepsone
    {
        public WebUserInfo[] list { get; set; }

    }

    public class WebUserInfo
    {       
        public int id{ get; set; }
        public string username{ get; set; }
        public string password{ get; set; }
        public string memo{ get; set; }
        public string depname{ get; set; }
        public string posname{ get; set; }
        public string truename{ get; set; }
        public string sex{ get; set; }
        public string tel{ get; set; }
        public string phone{ get; set; }
        public string neixian{ get; set; }
        public string email{ get; set; }
        public string qq{ get; set; }
        public DateTime? logintime{ get; set; }
        public string loginip{ get; set; }
        public string logins{ get; set; }
        public int status{ get; set; }
        //public DateTime? update_time{ get; set; }
        public string bian { get; set; }

        public override string ToString()
        {
            return username.ToString();
        }
    }

    
  
    public class UserWebBusiness
    {
        private static string _urlUserList = " http://120.27.21.93:8080/api.php/pc//user/lists";

        public static List<WebUserInfo> GetUserInfoList()
        {
            var result = new List<WebUserInfo>();

            var repsone = WebServiceHelper.HttpPost<UserListRequest, UserListRepsone>(_urlUserList, null);

            if (repsone.list != null)
            {
                result.AddRange(repsone.list);
            }

            return result;
        }
    }

}


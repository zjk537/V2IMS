using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vogue2_IMS.Business
{
    public class LoginUser
    {
        //  "uid": "1",
        //"username": "admin",
        //"truename": "zjk537",
        //"depname": "系统运维",
        //"posname": "管理员",
        //"token": "goV0u8e_L-bjpdDnUCl6dO6-Nvasz_I4"

        public int uid { get; set; }

        public string username { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string truename { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int depid { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string depname { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string posname { get; set; }

        public string password
        {
            get;
            set;
        }

        public string token { get; set; }
    }
}

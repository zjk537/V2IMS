using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.Business.BusinessModel
{
    public class UserShopRoleInfo
    {
        private UserInfo mUserInfo = new UserInfo();
        public UserInfo User
        {
            get { return mUserInfo; }
            set
            {
                mUserInfo = value;
                OwnerShop = null;
                Role = null;
            }
        }

        private ShopInfo mOwnerShop = null;
        public ShopInfo OwnerShop
        {
            get
            {
                if (mOwnerShop == null && User != null)
                {
                    mOwnerShop = SharedVariables.Instance.ShopInfos.Find(shop => { return shop.Id == User.ShopId; });
                }

                return mOwnerShop;
            }
            set
            {

                mOwnerShop = value;
                if (User != null && value != null)
                {
                    User.ShopId = value.Id;
                }
            }
        }

        private RoleInfo mRole = null;
        public RoleInfo Role
        {
            get
            {
                if (mRole == null && User != null)
                {
                    mRole = SharedVariables.Instance.RoleInfos.Find(role => { return role.Id == User.RoleId; });
                }

                return mRole;
            }
            set
            {
                mRole = value;
                if (User != null && value != null)
                {
                    User.RoleId = value.Id;
                }
            }
        }

        public string SexName
        {
            get { return SharedVariables.SexName[(User == null || !User.Sex.HasValue) ? 0 : User.Sex.Value]; }
        }
    }
}

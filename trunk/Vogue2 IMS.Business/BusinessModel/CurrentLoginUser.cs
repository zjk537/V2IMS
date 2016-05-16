using System;
using System.Collections.Generic;
using System.Linq;
using Vogue2_IMS.Model.DataModel;

namespace Vogue2_IMS.Business.BusinessModel
{
    public class CurrentLoginUserInfo
    {
        private UserInfo currentUser = null;
        public UserInfo User
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                this.mRoleColumns = null;
            }
        }

        private List<TableColumnInfo> mRoleColumns = null;
        public List<TableColumnInfo> RoleColumns
        {
            get
            {
                if (mRoleColumns == null)
                {
                    mRoleColumns = RoleBusiness.Instance.GetRoleColumns(this.User.RoleId, true);
                }
                return mRoleColumns;
            }
        }

        public void ResetRoleColumns()
        {
            mRoleColumns = null;
        }
        
        private string sessionId = string.Empty;
        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
    }
}

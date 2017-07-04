using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.Service;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public class UserBusiness : BusinessBase<UserBusiness>
    {
        public event EventHandler<CusEventArgs> OnUserUpdated;

        /// <summary>
        /// 验证用户名是否可用 true 可用  false 已被占用
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidateUserName(int userId, string userName)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspValidateUserName";
                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@UserId", userId);
                functionParms.Pams.Add("@UserName", userName);

                return ServiceManager.Instance.DataService.FuncGetResults(functionParms);
            }, null, "ValidateUserName.uspValidateUserName", false);

            var dbUserId = 0;
            if (result.ResultTable.Rows.Count() > 0)
            {
                dbUserId = Convert.ToInt32(result.ResultTable.Rows[0][0]);
            }

            return dbUserId == 0;
            
        }

        public void AddUser(UserInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddUser";
                functionParms.Pams = info.GetPams();

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddUser.uspAddUser",false);

            if (!result.Faild && OnUserUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnUserUpdated, "AddUser", true);
            }
        }

        public IList<UserInfo> GetUsers()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetUsers";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetUsers.uspGetUsers", true);

            return DoFunctionWithLog<List<UserInfo>>(() =>
            {
                return ConvertToList<UserInfo>(result);

            }, null, "GetUsers.ConvertToList", true);
        }

        public IList<UserShopRoleInfo> GetUserShopRoleInfos()
        {
            var listUserInfo = GetUsers();

            List<UserShopRoleInfo> results = new List<UserShopRoleInfo>();
            foreach (var user in listUserInfo)
            {
                results.Add(new UserShopRoleInfo() { User = user });
            }

            return results;
        }

        public UserInfo GetUserByName(string name, string pwd)
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetUserByName";
                funcParms.Pams = new Dictionary<string, object>();
                funcParms.Pams.Add("@UserName", name);
                funcParms.Pams.Add("@UserPwd", pwd);

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetUserByName.uspGetUserByName", true);


            var user = DoFunctionWithLog<UserInfo>(() =>
            {
                return ConvertToList<UserInfo>(result).FirstOrDefault();

            }, null, "GetUserByName.ConvertToList", true);

            return user;
        }

        public void UpdateUser(UserInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateUser";
                functionParms.Pams = info.GetPams();

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateUser.uspUpdateUser", true);

            if (!result.Faild && OnUserUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnUserUpdated, "UpdateUser", true);
            }
        }

        public void UpdateUserPwd(int userId,string oldPwd,string newPwd)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateUserPwd";
                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@UserId", userId);
                functionParms.Pams.Add("@UserOldPwd", oldPwd);
                functionParms.Pams.Add("@UserNewPwd", newPwd);

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateUserPwd.uspUpdateUserPwd", true);

            if (!result.Faild && OnUserUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnUserUpdated, "UpdateUserPwd", true);
            }
        }

    }
}

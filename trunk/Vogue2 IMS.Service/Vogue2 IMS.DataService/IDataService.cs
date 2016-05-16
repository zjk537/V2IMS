using System.ServiceModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;
using System.Collections.Generic;
using System;
using System.Data;

namespace Vogue2_IMS.DataService
{
    [ServiceContract]
    [ServiceKnownType("GetKnownTypes", typeof(ServiceKnownTypes))]
    public interface IDataService
    {
        /// <summary>
        /// 验证用户是否存在 
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="pwd">登录密码</param>
        /// <returns>返回验证结果信息</returns>
        [OperationContract]
        ResultValue UserValidator(string userName, string pwd);

        /// <summary>
        /// 保存数据入数据库
        /// </summary>
        /// <param name="functionParms">方法的参数</param>
        /// <returns>保存数据入库</returns>
        [OperationContract]
        ResultValue FuncSaveData(FunctionParms functionParms);


        /// <summary>
        /// 批量保存数据入数据库
        /// </summary>
        /// <param name="functionParms">方法的参数</param>
        /// <returns>保存数据入库</returns>
        [OperationContract]
        ResultValue[] FuncBatchSaveData(FunctionParms[] functionParms);

        /// <summary>
        /// 获取查询结果集合
        /// </summary>
        /// <param name="functionParms">查询条件</param>
        /// <returns>返回结果集合</returns>
        [OperationContract]
        ResultValue FuncGetResults(FunctionParms functionParms);

        ///// <summary>
        ///// 批量入库
        ///// </summary>
        ///// <param name="typeName">类型名称，对应AppSetting中的配置</param>
        ///// <param name="resource">结果集</param>
        //[OperationContract]
        //void BulkInsert(string typeName, DataTable resource);
    }

    public static class ServiceKnownTypes
    {
        public static IEnumerable<Type> GetKnownTypes(System.Reflection.ICustomAttributeProvider provider)
        {
            return new List<Type>() { typeof(int[]), typeof(string[]), 
                typeof(ResultValue), typeof(IDictionary<string, object>),typeof(IList<FunctionParms>),typeof(DataTable)};
        }
    }
}

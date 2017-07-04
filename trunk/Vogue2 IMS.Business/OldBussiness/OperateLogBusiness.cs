using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.Service;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public class OperateLogBusiness : BusinessBase<OperateLogBusiness>
    {

        public void AddOperateLog(OperateLogInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddOperateLog";
                functionParms.Pams = info.GetPams();

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddOperateLog.uspAddOperateLog", true);
        }


        public IList<OperateLogInfo> GetOperateLogs(OperateLogInfo info)
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetOperateLogs";
                funcParms.Pams = info.GetPams();
                

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetOperateLogs.uspGetOperateLogs", true);

            return DoFunctionWithLog<List<OperateLogInfo>>(() =>
            {
                return ConvertToList<OperateLogInfo>(result);

            }, null, "GetOperateLogs.ConvertToList", true);
        }

        
    }
}

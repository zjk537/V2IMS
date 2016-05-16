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
    public class PayTypeBusiness : BusinessBase<PayTypeBusiness>
    {
        public  EventHandler<CusEventArgs> OnPayTypeUpdated;

        public void AddPayType(PayTypeInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddPayType";
                functionParms.Pams = info.GetPams();

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddPayType.uspAddPayType", true);

            if (!result.Faild && OnPayTypeUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnPayTypeUpdated, "AddPayType", true);
            }
        }


        public IList<PayTypeInfo> GetPayTypes()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetPayTypes";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetPayTypes.uspGetPayTypes", true);

            return DoFunctionWithLog<List<PayTypeInfo>>(() =>
            {
                return ConvertToList<PayTypeInfo>(result);

            }, null, "GetPayTypes.ConvertToList", true);
        }

        public void UpdatePayType(PayTypeInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdatePayType";
                functionParms.Pams = info.GetPams();

                return ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdatePayType.uspUpdatePayType", true);

            if (!result.Faild && OnPayTypeUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnPayTypeUpdated, "UpdatePayType", true);
            }
        }
    
    }
}

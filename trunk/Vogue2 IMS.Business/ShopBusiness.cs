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
    public class ShopBusiness : BusinessBase<ShopBusiness>
    {
        public event EventHandler<CusEventArgs> OnShopUpdated;

        public void AddShop(ShopInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddShop";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddShop.uspAddShop", true);

            if (!result.Faild && OnShopUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnShopUpdated, "AddShop", true);
            }
        }


        public IList<ShopInfo> GetShops()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetShops";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetShops.uspGetShops", true);

            return DoFunctionWithLog<List<ShopInfo>>(() =>
            {
                return ConvertToList<ShopInfo>(result);

            }, null, "GetShops.ConvertToList", true);
        }

        public void UpdateShop(ShopInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateShop";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateShop.uspUpdateShop", true);

            if (!result.Faild && OnShopUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnShopUpdated, "UpdateShop", true);
            }
        }
    }
}

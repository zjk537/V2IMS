using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public class SupplierBusiness : BusinessBase<SupplierBusiness>
    {
        public EventHandler<CusEventArgs> OnSupplierUpdated;

        public void AddSupplier(SupplierInfo info)
        {
            if (info == null) return;

            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddSupplier";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddSupplier.uspAddSupplier", true);

            if (!result.Faild && OnSupplierUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnSupplierUpdated, "AddSupplier", true);
            }
        }

        /// <summary>
        /// 查找Supplier
        /// </summary>
        /// <param name="supplier">查找条件</param>
        /// <returns>供应商列表</returns>
        public List<SupplierInfo> GetSuppliers(SupplierInfo info)
        {
            if (info == null) info = new SupplierInfo();

            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetSuppliers";
                functionParms.Pams = info.GetPams();

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetSupplier.uspGetSuppliers", false);

            return DoFunctionWithLog<List<SupplierInfo>>(() =>
            {
                return ConvertToList<SupplierInfo>(result);
            }, null, "GetCateGoryInfos.Convert", true);
        }


        public SupplierInfo GetSupplier(SupplierInfo info)
        {
            List<SupplierInfo> suppliers = GetSuppliers(info);
            if (suppliers.Count == 0)
            {
                return null;
            }

            return suppliers.First();
        }

        public void UpdateSupplier(SupplierInfo info)
        {
            if (info == null || !info.IsUpdated())
                return;

            info.IdSpecify = true;
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateSupplier";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateSupplier.uspUpdateSupplier", true);

            if (!result.Faild && OnSupplierUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnSupplierUpdated, "UpdateSupplier", true);
            }
        }

        
    }
}

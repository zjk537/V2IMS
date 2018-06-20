using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Business.Service;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public sealed class CategoryBusiness : BusinessBase<CategoryBusiness>
    {
        public  EventHandler<CusEventArgs> OnCategoryUpdated;

        public void AddCategory(CategoryInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspAddCategory";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "AddCategory.uspAddCategory", true);

            if (!result.Faild && OnCategoryUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnCategoryUpdated, "AddCategory", true);
            }
        }


        public IList<CategoryInfo> GetCategories()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetCategories";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetCategories.uspGetCategories", true);

            return DoFunctionWithLog<List<CategoryInfo>>(() =>
            {
                return ConvertToList<CategoryInfo>(result);

            }, null, "GetCategories.ConvertToList", true);
        }

        public void UpdateCategory(CategoryInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdateCategory";
                functionParms.Pams = info.GetPams();

                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdateCategory.uspUpdateCategory", true);

            if (!result.Faild && OnCategoryUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnCategoryUpdated, "UpdateCategory", true);
            }
        }
    }
}
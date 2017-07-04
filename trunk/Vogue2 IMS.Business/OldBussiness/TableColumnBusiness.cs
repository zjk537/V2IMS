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
    public class TableColumnBusiness : BusinessBase<TableColumnBusiness>
    {

        public IList<TableColumnInfo> GetTableColumns()
        {
            var result = DoFunctionWithLog<ResultValue>(() =>
            {
                var funcParms = new FunctionParms();
                funcParms.FunctionName = "uspGetTableColumns";

                return ServiceManager.Instance.DataService.FuncGetResults(funcParms);
            }, new ResultValue(), "GetTableColumns.uspGetTableColumns", true);

            return DoFunctionWithLog<List<TableColumnInfo>>(() =>
            {
                return ConvertToList<TableColumnInfo>(result);

            }, null, "GetTableColumns.ConvertToList", true);
        }

    }
}

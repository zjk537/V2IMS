using System.Collections.Generic;
using System.Linq;
using Vogue2_IMS.Business.ViewModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Model.EnumModel;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.Business
{
    public class GoodsBusiness : BusinessBase<GoodsBusiness>
    {
        public List<GoodsInfo> GetGoodsInfos(GoodsInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetGoodsInfos";
                functionParms.Pams = info.GetPams();

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetGoodsInfos.uspGetGoodsInfos", false);

            return DoFunctionWithLog<List<GoodsInfo>>(() =>
            {
                return ConvertToList<GoodsInfo>(result);

            }, null, "GetGoodsInfos.Convert", true);
        }

        public List<GoodsInfo> GetAllGoods()
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetAllGoodsInfos";

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetAllGoods.uspGetAllGoodsInfos", false);

            return DoFunctionWithLog<List<GoodsInfo>>(() =>
            {
                return ConvertToList<GoodsInfo>(result);

            }, null, "GetAllGoods.Convert", true);
        }

        public List<ViewMainGoodsInfos> GetGoodses(ViewQueryGoodsInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetGoodses";
                functionParms.Pams = info.GetPams();

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetGoodses.uspGetGoodses", false);

            return DoFunctionWithLog<List<ViewMainGoodsInfos>>(() =>
            {
                return ConvertMainGoodsToList(result);

            }, null, "GetGoodses.Convert", true);
        }

        /// <summary>
        /// 获取需要预警的商品信息
        /// </summary>
        /// <param name="warningType">
        /// WarningType.JSWarning:寄售商品，未售出且到了提示 warningDays 的时间，给预警提示(默认)
        /// WarningType.SCWarning:售出商品，未付款且售出后 warningDays 的时间，给预警提示
        /// </param>
        /// <param name="warningDays">提示时间(默认7天)</param>
        /// <returns></returns>
        public List<ViewMainGoodsInfos> GetWarningGoods(WarningType warningType, int warningDays)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetWarningGoods";
                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@WarningType", (int)warningType);
                functionParms.Pams.Add("@WarningDays", warningDays);

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetWarningGoods.uspGetWarningGoods", false);

            return DoFunctionWithLog<List<ViewMainGoodsInfos>>(() =>
            {
                return ConvertMainGoodsToList(result);

            }, null, "GetWarningGoods.Convert", true);
        }

        /// <summary>
        /// 获取需要预警的商品信息
        /// </summary>
        /// <param name="warningType">
        /// WarningType.JSWarning:寄售商品，未售出且到了提示 warningDays 的时间，给预警提示(默认)
        /// WarningType.SCWarning:售出商品，未付款且售出后 warningDays 的时间，给预警提示
        /// </param>
        /// <param name="warningDays">提示时间(默认7天)</param>
        /// <returns></returns>
        public Dictionary<string, object> GetWarningGoodsMsg(WarningType warningType, int warningDays)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetWarningGoodsMsg";
                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@WarningType", (int)warningType);
                functionParms.Pams.Add("@WarningDays", warningDays);

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetWarningGoodsMsg.uspGetWarningGoodsMsg", false);

            return DoFunctionWithLog<Dictionary<string, object>>(() =>
            {
                Dictionary<string, object> warningMsgDict = new Dictionary<string, object>();
                if (result != null && result.ResultTable != null)
                {
                    foreach (var row in result.ResultTable.Rows)
                    {
                        for (int i = 0; i < result.ResultTable.Columns.Length; i++)
                        {
                            string column = result.ResultTable.Columns[i];
                            warningMsgDict.Add(column, row[i]);
                        }
                    }
                }
                return warningMsgDict;

            }, null, "GetWarningGoods.Convert", true);
        }

        private List<ViewMainGoodsInfos> ConvertMainGoodsToList(ResultValue result)
        {
            var itemList = new List<ViewMainGoodsInfos>();
            if (result != null && result.ResultTable != null)
            {
                foreach (var row in result.ResultTable.Rows)
                {
                    var item = new ViewMainGoodsInfos();
                    Dictionary<string, object> goodsDict = new Dictionary<string, object>();
                    Dictionary<string, object> purchaseDict = new Dictionary<string, object>();
                    Dictionary<string, object> saledDict = new Dictionary<string, object>();
                    for (int i = 0; i < result.ResultTable.Columns.Length; i++)
                    {
                        string column = result.ResultTable.Columns[i];
                        var isPrivacyColumn = SharedVariables.Instance.TableColumnInfos.Where(e => (e.TableName + e.ColumnName) == column).Count() > 0;
                        if (isPrivacyColumn)
                        {
                            var loginUserColumns = SharedVariables.Instance.LoginUser.RoleColumns;
                            if (loginUserColumns == null) continue;
                            var hasAuthor = loginUserColumns.Where(e => (e.TableName + e.ColumnName) == column).Count() > 0;
                            if (!hasAuthor) continue;
                        }

                        object cellValue = row[i];
                        if (column.StartsWith("Goods"))
                        {
                            goodsDict.Add(column, cellValue);
                            continue;
                        }
                        if (column.StartsWith("PurchaseRecord"))
                        {
                            purchaseDict.Add(column, cellValue);
                            continue;
                        }
                        if (column.StartsWith("SaledRecord"))
                        {
                            saledDict.Add(column, cellValue);
                            continue;
                        }
                    }
                    item.Goods.SetValues(goodsDict);
                    item.PurchaseRecord.SetValues(purchaseDict);
                    item.SaledRecord.SetValues(saledDict);

                    itemList.Add(item);
                }
            }

            return itemList;
        }


        public string GetGoodsImage(int goodsId)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspGetGoodsImage";
                functionParms.Pams = new Dictionary<string, object>();
                functionParms.Pams.Add("@GoodsId", goodsId);

                var results = Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
                return results;
            }, new ResultValue(), "GetGoodsImage.uspGetGoodsImage", false);

            if (result != null && result.ResultTable != null)
            {
                var imgObj = result.ResultTable.Rows[0][0];
                return imgObj == null ? string.Empty : imgObj.ToString();
            }
            return string.Empty;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Common.ModelBase;
using Vogue2_IMS.Business.Service;
using System.IO;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;
using System.Data;

namespace Vogue2_IMS.Business
{
    public class PurchaseGoodsBusiness : BusinessBase<PurchaseGoodsBusiness>
    {
        public EventHandler<CusEventArgs> OnPurchaseGoodsUpdated;

        public PurchaseGoodsInfo AddPurchaseGoods(PurchaseGoodsInfo purchaseGoodsInfo)
        {
            var purchaseGoods = BatchAddPurchaseGoods(new List<PurchaseGoodsInfo> { purchaseGoodsInfo });
            if (purchaseGoods == null || purchaseGoods.Count == 0)
            {
                return null;
            }
            return purchaseGoods.FirstOrDefault();
        }

        public List<PurchaseGoodsInfo> BatchAddPurchaseGoods(IList<PurchaseGoodsInfo> infos)
        {
            if (infos == null || infos.Count == 0) return null;


            ResultValue[] results = DoFunctionWithLog<ResultValue[]>(() =>
            {
                List<FunctionParms> functions = new List<FunctionParms>();
                foreach (var info in infos)
                {
                    var functionParms = new FunctionParms();
                    functionParms.FunctionName = "uspAddPurchaseGoods";
                    var goodsPams = info.Goods.GetPams();
                    var purchasePams = info.PurchaseRecord.GetPams();
                    functionParms.Pams = goodsPams.Concat(purchasePams).ToDictionary(k => k.Key, v => v.Value);
                    functions.Add(functionParms);
                }

                return ServiceManager.Instance.DataService.FuncBatchSaveData(functions.ToArray());

            }, null, "BatchAddGoods.uspAddPurchaseGoods", true);

            if (results.Where(e => e.Faild).Count() > 0)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, null, "BatchAddPurchaseGoods", true);

                return null;
            }
            else
            {
                if (OnPurchaseGoodsUpdated != null)
                    OnPurchaseGoodsUpdated(this, null);
            }

            return DoFunctionWithLog<List<PurchaseGoodsInfo>>(() =>
            {
                List<PurchaseGoodsInfo> purchaseGoodsInfos = new List<PurchaseGoodsInfo>();
                foreach (var result in results)
                {
                    purchaseGoodsInfos.AddRange(ConvertPurchaseGoodsToList(result));
                }
                return purchaseGoodsInfos;

            }, null, "BatchAddPurchaseGoods.Convert", true);
        }

        public void UpdatePurchaseGoods(PurchaseGoodsInfo info)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                info.Goods.IdSpecify = true;
                var functionParms = new FunctionParms();
                functionParms.FunctionName = "uspUpdatePurchaseGoods";
                functionParms.Pams = info.Goods.GetPams().Concat(info.PurchaseRecord.GetPams()).ToDictionary(k => k.Key, v => v.Value);
                return Service.ServiceManager.Instance.DataService.FuncSaveData(functionParms);
            }, null, "UpdatePurchaseGoods.uspUpdatePurchaseGoods", true);

            if (!result.Faild && OnPurchaseGoodsUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnPurchaseGoodsUpdated, "UpdatePurchaseGoods", true);
            }
        }

        public void BatchUpdatePurchaseGoods(List<PurchaseGoodsInfo> infos)
        {
            if (infos == null || infos.Count == 0) return;

            ResultValue[] results = DoFunctionWithLog<ResultValue[]>(() =>
            {
                List<FunctionParms> functions = new List<FunctionParms>();
                foreach (var info in infos)
                {
                    info.Goods.IdSpecify = true;
                    var functionParms = new FunctionParms();
                    functionParms.FunctionName = "uspUpdatePurchaseGoods";
                    functionParms.Pams = info.Goods.GetPams().Concat(info.PurchaseRecord.GetPams()).ToDictionary(k => k.Key, v => v.Value);
                    functions.Add(functionParms);
                }

                return ServiceManager.Instance.DataService.FuncBatchSaveData(functions.ToArray());

            }, null, "BatchUpdatePurchaseGoods.uspUpdatePurchaseGoods", true);
            if (results.Where(e => e.Faild).Count() > 0)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, null, "BatchAddPurchaseGoods", true);

                return;
            }
            if (OnPurchaseGoodsUpdated != null)
                OnPurchaseGoodsUpdated(this, null);
        }


        public PurchaseGoodsInfo GetPurchaseGoods(string code)
        {
            var listResult = GetPurchaseGoods(new PurchaseGoodsInfo() { Goods = new Model.DataModel.GoodsInfo() { Code = code } });

            return listResult == null ? null : listResult.First();
        }

        public List<PurchaseGoodsInfo> GetPurchaseGoods(PurchaseGoodsInfo info)
        {
            throw new NotImplementedException();
            //ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            //{
            //    var functionParms = new FunctionParms();
            //    functionParms.FunctionName = "uspSelectPurchaseGoods";
            //    functionParms.Pams = condationInfo.Goods.GetPams();
            //    functionParms.Pams.Concat(condationInfo.PurchaseRecord.GetPams());

            //    return Service.ServiceManager.Instance.DataService.FuncGetResults(functionParms);
            //}, null, "UpdatePurchaseGoods.uspUpdatePurchaseGoods", true);

            //return DoFunctionWithLog<List<PurchaseGoodsInfo>>(() =>
            //{
            //    return ConvertToList<PurchaseGoodsInfo>(result);
            //}, null, "GetCateGoryInfos.Convert", true);
        }

        public void BulkInsertPurchaseGoods(DataTable resource)
        {
            ResultValue result = DoFunctionWithLog<ResultValue>(() =>
            {
                resource.TableName = string.IsNullOrEmpty(resource.TableName) ? "tempTab" : resource.TableName;
                FunctionParms pams = new FunctionParms();
                pams.FunctionName = "ufcBulkInsert";
                pams.Pams = new Dictionary<string, object>();
                pams.Pams.Add("typeName", "BulkInsertPurchaseGoods");
                pams.Pams.Add("resource", resource);

                return ServiceManager.Instance.DataService.FuncSaveData(pams);

            }, null, "BulkInsertPurchaseGoods.ufcBulkInsert", true);

            //if (!result.Faild && OnPurchaseGoodsUpdated != null)
            //{
            //    DoUpdateFunctionWithLog<CusEventArgs>(() =>
            //    {
            //        return new CusEventArgs();
            //    }, new CusEventArgs(), this, OnPurchaseGoodsUpdated, "BulkInsertPurchaseGoods", true);
            //}
        }

        private List<PurchaseGoodsInfo> ConvertPurchaseGoodsToList(ResultValue result)
        {
            var itemList = new List<PurchaseGoodsInfo>();
            if (result != null && result.ResultTable != null)
            {
                foreach (var row in result.ResultTable.Rows)
                {
                    var item = new PurchaseGoodsInfo();
                    Dictionary<string, object> goodsDict = new Dictionary<string, object>();
                    Dictionary<string, object> purchaseDict = new Dictionary<string, object>();
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
                    }
                    item.Goods.SetValues(goodsDict);
                    item.PurchaseRecord.SetValues(purchaseDict);

                    itemList.Add(item);
                }
            }

            return itemList;
        }
    }
}

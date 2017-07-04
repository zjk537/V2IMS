using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Business.Service;


using Vogue2_IMS.DataService.Model;
using Vogue2_IMS.Service.Business.Model;
namespace Vogue2_IMS.Business
{
    public class SaleGoodsBusiness : BusinessBase<SaleGoodsBusiness>
    {
        public EventHandler<CusEventArgs> OnSaledGoodsUpdated;

        public void AddSaledGoods(SaledGoodsInfo saleGoodsInfo)
        {
            BatchAddSaledGoods(new List<SaledGoodsInfo> { saleGoodsInfo });
        }

        public void BatchAddSaledGoods(IList<SaledGoodsInfo> infos)
        {
            if (infos == null || infos.Count == 0) return;

            string batchId = DateTime.Now.ToString("yyyyMMddhhmmss");
            ResultValue[] results = DoFunctionWithLog<ResultValue[]>(() =>
            {
                List<FunctionParms> functions = new List<FunctionParms>();
                foreach (var info in infos)
                {
                    info.Goods.IdSpecify = true;
                    // 扣手续费
                    //info.Goods.SalePrice -= info.PayType.BankCharge.HasValue ? info.PayType.BankCharge : 0;
                    info.SaledRecord.PayType = info.PayType.Id;
                    //info.SaledRecord.PayCharge = info.PayType.BankCharge;
                    info.SaledRecord.BatchId = batchId;
                    var functionParms = new FunctionParms();
                    functionParms.FunctionName = "uspAddSaledGoods";
                    var goodsPams = info.Goods.GetPams();
                    var salePams = info.SaledRecord.GetPams();
                    functionParms.Pams = goodsPams.Concat(salePams).ToDictionary(k => k.Key, v => v.Value);
                    functions.Add(functionParms);
                }

                return ServiceManager.Instance.DataService.FuncBatchSaveData(functions.ToArray());

            }, null, "BatchAddSaleGoods.uspAddSaledGoods", true);

            if (results.Where(e => !e.Faild).Count() > 0 && OnSaledGoodsUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnSaledGoodsUpdated, "BatchAddSaleGoods", true);
            }

        }

        public void UpdateSaledGoods(SaledGoodsInfo info)
        {
            BatchUpdateSaledGoods(new List<SaledGoodsInfo> { info });
        }

        public void BatchUpdateSaledGoods(IList<SaledGoodsInfo> infos)
        {
            if (infos == null || infos.Count == 0) return;

            string batchId =  DateTime.Now.ToString("yyyyMMddhhmmss");
            ResultValue[] results = DoFunctionWithLog<ResultValue[]>(() =>
            {
                List<FunctionParms> functions = new List<FunctionParms>();
                foreach (var info in infos)
                {
                    info.Goods.IdSpecify = true;
                    // 扣手续费
                    //info.Goods.SalePrice -= info.PayType.BankCharge.HasValue ? info.PayType.BankCharge : 0;
                    info.SaledRecord.PayType = info.PayType.Id;
                    //info.SaledRecord.PayCharge = info.PayType.BankCharge;
                    info.SaledRecord.BatchId = batchId;
                    var functionParms = new FunctionParms();
                    functionParms.FunctionName = "uspUpdateSaledGoods";
                    var goodsPams = info.Goods.GetPams();
                    var salePams = info.SaledRecord.GetPams();
                    functionParms.Pams = goodsPams.Concat(salePams).ToDictionary(k => k.Key, v => v.Value);
                    functions.Add(functionParms);
                }

                return ServiceManager.Instance.DataService.FuncBatchSaveData(functions.ToArray());

            }, null, "BatchUpdateSaledGoods.uspUpdateSaledGoods", true);

            if (results.Where(e => !e.Faild).Count() > 0 && OnSaledGoodsUpdated != null)
            {
                DoUpdateFunctionWithLog<CusEventArgs>(() =>
                {
                    return new CusEventArgs();
                }, new CusEventArgs(), this, OnSaledGoodsUpdated, "BatchUpdateSaledGoods", true);
            }
        }

    }
}

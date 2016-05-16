using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Vogue2_IMS.Business;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Business.ViewModel;
using Vogue2_IMS.Model.DataModel;
using Newtonsoft.Json;

namespace Vogue2_IMS.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UserTest();

            Console.ReadLine();
        }

        static void SupplierTest()
        {
            //SupplierInfo supplier = new SupplierInfo();
            //supplier.Address = "北京";
            //supplier.BankCard = "123123123123";
            //supplier.BankName = "招商银行";
            //supplier.Name = "张三";
            //supplier.Phone = "12121212";
            //supplier.Sex = 2;
            //supplier.IdCard = "22222";

            //SupplierBusiness.Instance.AddSupplier(supplier);
            //Console.WriteLine("add success");
            var result = SupplierBusiness.Instance.GetSuppliers(null);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        // 未测试分页
        static void PurchaseGoodsTest()
        {
            //PurchaseGoodsInfo purchaseGoods = new PurchaseGoodsInfo();
            //purchaseGoods.Goods.CategoryId = 1;
            //purchaseGoods.Goods.Code = "Code_test";
            //purchaseGoods.Goods.OriginalCode = "originalCode_test";
            //purchaseGoods.Goods.SourceType = 1;
            //purchaseGoods.Goods.Name = "测试商品名";
            //purchaseGoods.Goods.Status = 1;
            //purchaseGoods.Goods.Desc = "测试数据,只能不能为空的字段赋值";
            //purchaseGoods.Goods.SupplierId = 1;

            //purchaseGoods.PurchaseRecord.UserId = 1;
            //purchaseGoods.PurchaseRecord.PayType = 1;

            //PurchaseGoodsBusiness.Instance.AddPurchaseGoods(purchaseGoods);
            //Console.WriteLine("add success");

            ViewQueryGoodsInfo info = new ViewQueryGoodsInfo();
            info.Goods.CategoryId = 1;
            info.StartPurchaseDate = DateTime.Now.AddMonths(-1);
            info.EndPurchaseDate = DateTime.Now;
            var result = GoodsBusiness.Instance.GetGoodses(info);
            Console.WriteLine(JsonConvert.SerializeObject(result));

        }

        static void CategoryTest()
        {
            CategoryInfo info = new CategoryInfo();
            info.Id = 3;
            info.Name = "包包2_update";
            //info.ParentId = 0;
            info.Status = 1;
            info.Desc = "包包测试2_update";
            CategoryBusiness.Instance.AddCategory(info);
            //CategoryBusiness.Instance.UpdateCategory(info);
            Console.WriteLine("Add Success");

            //var result = CategoryBusiness.Instance.GetCategories();
            //Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        static void ShopTest()
        {
            ShopInfo info = new ShopInfo();
            info.Id = 2;
            info.Name = "北京店2";
            info.Phone = "12312";
            info.Address = "北京_up";
            info.Desc = "北店主店_up";
            ShopBusiness.Instance.UpdateShop(info);
            Console.WriteLine("Add Success");

            //var result = ShopBusiness.Instance.GetShops();
            //Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        static void RoleTest()
        {
            //RoleInfo info = new RoleInfo();
            //info.Id = 1;
            //info.Name = "系统管理员";
            //info.Desc = "系统管理员，全部权限_update";
            ////RoleBusiness.Instance.AddRole(info);
            //RoleBusiness.Instance.UpdateRole(info);
            //Console.WriteLine("add success");

            var result = RoleBusiness.Instance.GetRoles();
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        static void UserTest()
        {
            UserInfo info = new UserInfo();
            //info.Id = 1;
            info.Name = "admin";
            info.RoleId = 1;
            info.Phone = "";
            info.Pwd = "admin";
            info.RealName = "系统管理员";
            info.Sex = 2;
            info.ShopId = 0;
            UserBusiness.Instance.AddUser(info);
            //UserBusiness.Instance.UpdateUser(info);
            //UserBusiness.Instance.UpdateUserPwd(1, "admin", "123");
            Console.WriteLine("add success");

            //var result = UserBusiness.Instance.GetUserByName("admin", "123");
            //var result = UserBusiness.Instance.GetUsers();
            //Console.WriteLine(JsonConvert.SerializeObject(result));

        }

        static void PayTypeTest()
        {
            PayTypeInfo info = new PayTypeInfo();
            info.Id = 2;
            info.Name = "信用卡_add";
            PayTypeBusiness.Instance.UpdatePayType(info);
            //PayTypeBusiness.Instance.AddPayType(info);
            Console.WriteLine("add success");

            //var result = PayTypeBusiness.Instance.GetPayTypes();
            //Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        static void OperateLogTest()
        {
            OperateLogInfo info = new OperateLogInfo();
            info.UserId = 1;
            info.ShopId = 1;
            info.Type = 1;
            info.Desc = "用户 admin 在店面 shop1 新增员工 memeber1";
            info.Operator = "admin";
            OperateLogBusiness.Instance.AddOperateLog(info);
            Console.WriteLine("add success");

            var result = OperateLogBusiness.Instance.GetOperateLogs(info);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}

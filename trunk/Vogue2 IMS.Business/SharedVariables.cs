using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Model.DataModel;
using Vogue2_IMS.Business.BusinessModel;
using Vogue2_IMS.Model.EnumModel;
using System.IO;

namespace Vogue2_IMS.Business
{
    public class SharedVariables
    {
        const string mLayoutXmlPath = @".\Config\ViewLayout\";
        public string LayoutXmlPath
        {
            get
            {
                if (!Directory.Exists(mLayoutXmlPath))
                {
                    Directory.CreateDirectory(mLayoutXmlPath);
                }

                return mLayoutXmlPath;
            }
        }

        /// <summary>
        /// 数据仓储超时时间
        /// </summary>
        const int mSourceCacheTimeOutMin = 5;
        /// <summary>
        /// 数据仓储最后一次刷新时间列表
        /// </summary>
        Dictionary<string, DateTime> CacheLastUpdatedTimes = new Dictionary<string, DateTime>();

        #region 单例 Instance
        static object lockObj = new object();

        public SharedVariables()
        {
            //相关初始化工作
            CategoryBusiness.Instance.OnCategoryUpdated += new EventHandler<CusEventArgs>(OnCategoryUpdatedCompleted);
            SupplierBusiness.Instance.OnSupplierUpdated += new EventHandler<CusEventArgs>(OnSupplierUpdatedCompleted);
            RoleBusiness.Instance.OnRoleColumnsUpdated += new EventHandler<CusEventArgs>(OnRoleColumnsUpdatedCompleted);
            PayTypeBusiness.Instance.OnPayTypeUpdated += new EventHandler<CusEventArgs>(OnPayTypeUpdatedCompleted);
            //Pa.Instance.OnCategoryUpdated += new EventHandler<CusEventArgs>(OnCategoryUpdatedCompleted);
            //CategoryBusiness.Instance.OnCategoryUpdated += new EventHandler<CusEventArgs>(OnCategoryUpdatedCompleted);
        }

        

        private static SharedVariables mInstance = null;
        public static SharedVariables Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new SharedVariables();

                return mInstance;
            }
            set
            {
                mInstance = value;
            }
        }

        #endregion

        CurrentLoginUserInfo mCurrentLoginUser = null;
        public CurrentLoginUserInfo LoginUser
        {
            get
            {
                lock (lockObj)
                {
                    if (mCurrentLoginUser == null)
                    {
                        mCurrentLoginUser = new CurrentLoginUserInfo();

                    }

                    return mCurrentLoginUser;
                }
            }
            set { mCurrentLoginUser = value; }
        }

        #region Data Cache

        List<CategoryInfo> mCategoryInfos = null;
        const string mCategoryInfosCacheKey = "CategoryInfos";
        /// <summary>
        /// 商品分类仓储
        /// </summary>
        public List<CategoryInfo> CategoryInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mCategoryInfosCacheKey))
                    {
                        if (mCategoryInfos != null)
                        {
                            mCategoryInfos.Clear();
                        }
                        else
                        {
                            mCategoryInfos = new List<CategoryInfo>();
                        }

                        //mCategoryInfos = new List<CategoryInfo>() { new CategoryInfo() { Name = "箱包" } };
                        mCategoryInfos.AddRange(CategoryBusiness.Instance.GetCategories());

                        if (mCategoryInfos == null || mCategoryInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mCategoryInfosCacheKey);
                        }
                    }

                    return mCategoryInfos;
                }
            }
        }

        List<PayTypeInfo> mPayTypeInfos = null;
        const string mPayTypeInfosCacheKey = "PayTypeInfos";
        /// <summary>
        /// 付款类型仓储
        /// </summary>
        public List<PayTypeInfo> PayTypeInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mPayTypeInfosCacheKey))
                    {
                        if (mPayTypeInfos != null)
                        {
                            mPayTypeInfos.Clear();
                        }
                        else { mPayTypeInfos = new List<PayTypeInfo>(); }

                        //mPayTypeInfos = new List<PayTypeInfo>() { new PayTypeInfo() { Name = "现金" } };
                        mPayTypeInfos.AddRange(PayTypeBusiness.Instance.GetPayTypes());

                        if (mPayTypeInfos == null || mPayTypeInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mPayTypeInfosCacheKey);
                        }
                    }

                    return mPayTypeInfos;
                }
            }
        }

        List<UserInfo> mUserInfos = null;
        const string mUserInfosCacheKey = "UserInfos";
        /// <summary>
        /// 商品分类仓储
        /// </summary>
        public List<UserInfo> UserInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mUserInfosCacheKey))
                    {
                        if (mUserInfos != null)
                        {
                            mUserInfos.Clear();
                        }
                        else mUserInfos = new List<UserInfo>();

                        // mUserInfos = new List<UserInfo>() { new UserInfo() { Name = "测试员1", Id = -88888 } };
                        mUserInfos.AddRange(UserBusiness.Instance.GetUsers());

                        if (mUserInfos == null || mUserInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mUserInfosCacheKey);
                        }
                    }

                    return mUserInfos;
                }
            }
        }

        List<ShopInfo> mShopInfos = null;
        const string mShopInfosCacheKey = "ShopInfos";
        /// <summary>
        /// 商品分类仓储
        /// </summary>
        public List<ShopInfo> ShopInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mShopInfosCacheKey))
                    {
                        if (mShopInfos != null)
                        {
                            mShopInfos.Clear();
                        }
                        else
                            mShopInfos = new List<ShopInfo>();

                        mShopInfos.AddRange(ShopBusiness.Instance.GetShops());

                        if (mShopInfos == null || mShopInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mShopInfosCacheKey);
                        }
                    }

                    return mShopInfos;
                }
            }
        }

        List<SupplierInfo> mSupplierInfos = null;
        const string mSupplierInfosCacheKey = "SupplierInfos";
        /// <summary>
        /// 商品分类仓储
        /// </summary>
        public List<SupplierInfo> SupplierInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mSupplierInfosCacheKey))
                    {
                        if (mSupplierInfos != null)
                        {
                            mSupplierInfos.Clear();
                        }
                        else
                            mSupplierInfos = new List<SupplierInfo>();

                        mSupplierInfos.AddRange(SupplierBusiness.Instance.GetSuppliers(new SupplierInfo()));

                        if (mSupplierInfos == null || mSupplierInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mSupplierInfosCacheKey);
                        }
                    }

                    return mSupplierInfos;
                }
            }
        }

        List<RoleInfo> mRoleInfos = null;
        const string mRolesInfoCacheKey = "RoleInfos";

        public List<RoleInfo> RoleInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mRolesInfoCacheKey))
                    {
                        if (mRoleInfos != null)
                        {
                            mRoleInfos.Clear();
                        }
                        else
                            mRoleInfos = new List<RoleInfo>();

                        mRoleInfos.AddRange(RoleBusiness.Instance.GetRoles());

                        if (mRoleInfos == null || mRoleInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mRolesInfoCacheKey);
                        }
                    }

                    return mRoleInfos;
                }
            }
        }

        List<TableColumnInfo> mTableColumnInfos = null;
        const string mTableColumnInfoCacheKey = "TableColumnInfos";

        public List<TableColumnInfo> TableColumnInfos
        {
            get
            {
                lock (lockObj)
                {
                    if (NeedRefrenceCache(mTableColumnInfoCacheKey))
                    {
                        if (mTableColumnInfos != null)
                        {
                            mTableColumnInfos.Clear();
                        }
                        else
                            mTableColumnInfos = new List<TableColumnInfo>();

                        mTableColumnInfos.AddRange(TableColumnBusiness.Instance.GetTableColumns());

                        if (mTableColumnInfos == null || mTableColumnInfos.Count <= 0)
                        {
                            this.CacheLastUpdatedTimes.Remove(mTableColumnInfoCacheKey);
                        }
                    }

                    return mTableColumnInfos;
                }
            }
        }

        #region Private Method

        /// <summary>
        /// 是否需要刷新缓存
        /// </summary>
        /// <param name="cacheKey">缓存ID</param>
        /// <returns>true | false</returns>
        private bool NeedRefrenceCache(string cacheKey)
        {
            if (!CacheLastUpdatedTimes.ContainsKey(cacheKey)
                || (DateTime.Now - CacheLastUpdatedTimes[cacheKey]).Minutes >= mSourceCacheTimeOutMin)
            {
                CacheLastUpdatedTimes[cacheKey] = DateTime.Now;
                return true;
            }

            return false;
        }

        #endregion

        #endregion

        #region Key Names

        public static int AdminRoleId = 1;
        public static int PMRoleId = 2;

        public static List<string> SexName = new List<string>() { "未知", "男", "女" };
        public static List<string> GoodsStatusName = new List<string>() { "未知", "在库", "预定", "售出", "取回" };

        public static Dictionary<SourceType, string> SourceTypeRKCNNames = new Dictionary<SourceType, string>()
        {
            {SourceType.JinHuo,"进货入库"}
            ,{SourceType.JiShou,"寄售入库"}
        };

        public static Dictionary<SourceType, string> SourceTypeCNNames = new Dictionary<SourceType, string>()
        {
            {SourceType.JinHuo,"进货"}
            ,{SourceType.JiShou,"寄售"}
        };

        public static Dictionary<SourceType, string> SupplierCNNames = new Dictionary<SourceType, string>()
        {
            {SourceType.JinHuo,"供应商"}
            ,{SourceType.JiShou,"寄售人"}
        };

        public static Dictionary<SourceType, int> SupplierIconIndexs = new Dictionary<SourceType, int>()
        {
            {SourceType.JinHuo,24}
            ,{SourceType.JiShou,26}
        };

        public static List<GoodsPaidInfo> GoodsPaids = new List<GoodsPaidInfo>()
        {
           new GoodsPaidInfo(){ Id = (int)GoodsPaid.HasPaid, Name = "已打款" },
           new GoodsPaidInfo(){ Id = (int)GoodsPaid.NoPaid, Name = "未打款" }
        };

        #endregion

        #region Updated Event

        public void OnCategoryUpdatedCompleted(object sender, CusEventArgs args)
        {
            this.CacheLastUpdatedTimes.Remove(mCategoryInfosCacheKey);
        }

        public void OnSupplierUpdatedCompleted(object sender, CusEventArgs args)
        {
            this.CacheLastUpdatedTimes.Remove(mSupplierInfosCacheKey);
        }

        public void OnRoleColumnsUpdatedCompleted(object sender, CusEventArgs args)
        {
            this.CacheLastUpdatedTimes.Remove(mSupplierInfosCacheKey);
            this.CacheLastUpdatedTimes.Remove(mRolesInfoCacheKey);
        }

        public void OnPayTypeUpdatedCompleted(object sender, CusEventArgs e)
        {
            this.CacheLastUpdatedTimes.Remove(mPayTypeInfosCacheKey);
        }

        #endregion

        #region



        #endregion
    }
}
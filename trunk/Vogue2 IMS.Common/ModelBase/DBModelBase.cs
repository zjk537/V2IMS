using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Vogue2_IMS.Common.ModelBase
{
    [Serializable]
    public class DBFieldAttribute : Attribute
    {
        public DBFieldAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }

        public string ColumnName { get; set; }

        private string pamName = string.Empty;
        public string PamName
        {
            get
            {
                if (string.IsNullOrEmpty(pamName))
                    pamName = string.Format("@{0}", ColumnName);

                return pamName;
            }
        }
    }

   
    [Serializable]
    /// <summary>
    /// 继承DBModelBase的类需要在属性上添加属性DBFieldAttribute以指定属性对应列名称
    /// </summary>
    public class DBModelBase
    {
        public DBModelBase() { }

        /// <summary>
        /// 获取模型参数
        /// </summary>
        /// <returns>返回值List,类型为：@+为模型属性DBFieldAttribute的值</returns>
        public Dictionary<string, object> GetPams()
        {
            Type selfType = this.GetType();
            Dictionary<string, object> pams = new Dictionary<string, object>();
            foreach (PropertyInfo proInfo in selfType.GetProperties())
            {
                if (proInfo.PropertyType.IsAssignableFrom(typeof(DBModelBase)))
                {
                    var pamsTemp = ((DBModelBase)(proInfo.GetValue(this, null))).GetPams();
                    foreach (var key in pamsTemp.Keys)
                    {
                        pams.Add(key, pamsTemp[key]);
                    }
                }
                else
                {
                    if (proInfo.Name.EndsWith("Specify"))
                        continue;

                    object[] attrs = proInfo.GetCustomAttributes(typeof(DBFieldAttribute), true);
                    if (attrs != null && attrs.Length == 1)
                    {
                        var dbField = attrs[0] as DBFieldAttribute;
                        bool ifSpecify = (bool)selfType.GetProperty(string.Format("{0}Specify", proInfo.Name)).GetValue(this, null);

                        if (ifSpecify)
                            pams.Add(dbField.PamName, proInfo.GetValue(this, null));
                    }
                }
            }

            return pams;
        }

        /// <summary>
        /// 给值参数模型
        /// </summary>
        /// <param name="dataDic">源数据集合</param>
        public void SetValues(IDictionary<string, object> dataDic)
        {
            Type tType = this.GetType();

            Dictionary<string, object> pams = new Dictionary<string, object>();
            foreach (PropertyInfo proInfo in tType.GetProperties())
            {
                if (proInfo.PropertyType.IsAssignableFrom(typeof(DBModelBase)))
                {
                    var proInfoInstance = Assembly.GetAssembly(proInfo.PropertyType).CreateInstance(proInfo.PropertyType.Name) as DBModelBase;
                    proInfoInstance.SetValues(dataDic);

                    proInfo.SetValue(this, proInfoInstance, null);
                }
                else
                {
                    if (proInfo.Name.EndsWith("Specify")) continue;

                    object[] attrs = proInfo.GetCustomAttributes(typeof(DBFieldAttribute), true);
                    if (attrs != null && attrs.Length == 1)
                    {
                        var dbField = attrs[0] as DBFieldAttribute;

                        if (!dataDic.ContainsKey(dbField.ColumnName)) continue;

                        proInfo.SetValue(this, ConvertTo(dataDic[dbField.ColumnName], proInfo.Name, proInfo.PropertyType), null);
                       
                        //proInfo.SetValue(this, ConvertTo(false, proInfo.Name + "Specify", typeof(bool)), null);
                        var proInfoSpecify = tType.GetProperty(proInfo.Name + "Specify");
                        if (proInfoSpecify != null)
                            proInfoSpecify.SetValue(this, false, null);
                    }
                }
            }
        }

        /// <summary>
        /// 给值参数模型
        /// </summary>
        /// <param name="dataRecord">源数据集合</param>
        public void SetValues(IDataRecord dataRecord)
        {
            Type tType = this.GetType();

            Dictionary<string, object> pams = new Dictionary<string, object>();
            foreach (PropertyInfo proInfo in tType.GetProperties())
            {
                if (proInfo.PropertyType.IsAssignableFrom(typeof(DBModelBase)))
                {
                    var proInfoInstance = Assembly.GetAssembly(proInfo.PropertyType).CreateInstance(proInfo.PropertyType.Name) as DBModelBase;
                    proInfoInstance.SetValues(dataRecord);

                    proInfo.SetValue(this, proInfoInstance, null);
                }
                else
                {
                    if (proInfo.Name.EndsWith("Specify"))
                        continue;

                    object[] attrs = proInfo.GetCustomAttributes(typeof(DBFieldAttribute), true);
                    if (attrs != null && attrs.Length == 1)
                    {
                        var dbField = attrs[0] as DBFieldAttribute;
                        if (dataRecord.GetOrdinal(dbField.ColumnName) > 0)
                        {
                            proInfo.SetValue(this, ConvertTo(dataRecord[dbField.ColumnName], proInfo.Name, proInfo.PropertyType), null);
                        }
                    }
                }
            }

            foreach (PropertyInfo proInfo in tType.GetProperties())
            {
                if (proInfo.Name.EndsWith("Specify"))
                {
                    proInfo.SetValue(this, false, null);
                }
            }
        }

        /// <summary>
        /// 给值参数模型
        /// </summary>
        /// <param name="columns">名称集合</param>
        /// <param name="cellValues">对应值集合</param>
        public void SetValues(string[] columns, object[] cellValues)
        {
            Type tType = this.GetType();

            Dictionary<string, object> pams = new Dictionary<string, object>();
            foreach (PropertyInfo proInfo in tType.GetProperties())
            {
                if (proInfo.PropertyType.IsAssignableFrom(typeof(DBModelBase)))
                {
                    var proInfoInstance = Assembly.GetAssembly(proInfo.PropertyType).CreateInstance(proInfo.PropertyType.Name) as DBModelBase;
                    proInfoInstance.SetValues(columns, cellValues);

                    proInfo.SetValue(this, proInfoInstance, null);
                }
                else
                {
                    if (proInfo.Name.EndsWith("Specify"))
                        continue;

                    object[] attrs = proInfo.GetCustomAttributes(typeof(DBFieldAttribute), true);
                    if (attrs != null && attrs.Length == 1)
                    {
                        var dbField = attrs[0] as DBFieldAttribute;
                        for (int i = 0; i < columns.Length; i++)
                        {
                            if (dbField.ColumnName == columns[i])
                            {
                                proInfo.SetValue(this, ConvertTo(cellValues[i], proInfo.Name, proInfo.PropertyType), null);

                                var proInfoSpecify = tType.GetProperty(proInfo.Name + "Specify");
                                if (proInfoSpecify != null)
                                    proInfoSpecify.SetValue(this, false, null);

                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void Clone<T>(T oldT, ref T newT) where T : DBModelBase
        {
            Dictionary<string, object> pams = new Dictionary<string, object>();
            foreach (PropertyInfo proInfo in typeof(T).GetProperties())
            {
                if (!proInfo.Name.EndsWith("Specify"))
                {
                    proInfo.SetValue(newT, proInfo.GetValue(oldT, null), null);
                }
            }

            foreach (PropertyInfo proInfo in typeof(T).GetProperties())
            {
                if (proInfo.Name.EndsWith("Specify"))
                {
                    proInfo.SetValue(newT, proInfo.GetValue(oldT, null), null);
                }
            }
        }

        public bool IsUpdated()
        {
            foreach (PropertyInfo proInfo in this.GetType().GetProperties())
            {
                if (proInfo.Name.EndsWith("Specify"))
                {
                    if (Convert.ToBoolean(proInfo.GetValue(this, null)))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }

            if (obj.GetType().Equals(this.GetType()))
            {
                bool equals = true;

                foreach (PropertyInfo proInfo in this.GetType().GetProperties())
                {
                    var tempOld = proInfo.GetValue(this, null);
                    var tempNew = proInfo.GetValue(obj, null);
                    if (tempOld == (object)null)
                    {
                        equals = tempNew == (object)null;
                    }
                    else
                    {
                        equals = tempOld.Equals(tempNew);
                    }

                    if (!equals)
                        break;
                }

                return equals;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region Convert To

        public object ConvertTo(object value, string propertyName, Type toType)
        {
            bool success = false;
            object returnObject = null;
            returnObject = ConvertToExtend(value, toType, out success);

            if (!success)
                returnObject = ConvertToBase(value, toType, out success);

            if (success)
                return returnObject;
            else
                throw new FormatException(string.Format("类型转换失败，属性[{0}] 类型[{1}] 原始值[{2}]", propertyName, toType, value));
        }

        private object ConvertToBase(object value, Type toType, out bool success)
        {
            string valueString = value == null ? string.Empty : value.ToString();
            if (toType.Equals(typeof(string)))
            {
                success = true;
                return valueString;
            }
            if (toType.Equals(typeof(int)))
            {
                int result = 0;
                success = int.TryParse(valueString, out result);
                return result;
            }
            if (toType.Equals(typeof(DateTime)))
            {
                DateTime result = DateTime.MinValue;
                success = DateTime.TryParse(valueString, out result);
                return result;
            }
            if (toType.Equals(typeof(decimal)))
            {
                decimal result = 0;
                success = decimal.TryParse(valueString, out result);
                return result;
            }
            if (toType.Equals(typeof(double)))
            {
                double result = 0;
                success = double.TryParse(valueString, out result);
                return result;
            }
            if (toType.Equals(typeof(float)))
            {
                float result = 0;
                success = float.TryParse(valueString, out result);
                return result;
            }
            if (toType.Equals(typeof(bool)))
            {
                bool result = false;
                success = bool.TryParse(valueString, out result);
                return result;
            }

            success = false;
            return null;
        }

        public virtual object ConvertToExtend(object value, Type toType, out bool success)
        {
            if (toType.Equals(typeof(Nullable<DateTime>)))
            {
                success = true;
                return (DateTime?)value;
            }
            if (toType.Equals(typeof(Nullable<decimal>)))
            {
                success = true;
                return (decimal?)value;
            }
            if (toType.Equals(typeof(Nullable<int>)))
            {
                success = true;
                return (int?)value;
            }
            success = false;
            return null;
        }

        #endregion
    }
}
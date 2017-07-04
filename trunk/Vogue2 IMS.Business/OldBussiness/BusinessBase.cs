using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Vogue2_IMS.Common.ModelBase;
using System.Reflection;
using Vogue2_IMS.DataService.Model;

namespace Vogue2_IMS.Business
{
    [Serializable]
    public class BusinessBase<TBusiness> where TBusiness : new()
    {
        private static TBusiness mInstance = default(TBusiness);
        public static TBusiness Instance
        {
            get
            {
                if (mInstance == null) mInstance = new TBusiness();

                return mInstance;
            }
        }

        string _LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
        public string mLogPath
        {
            get
            {
                if (Directory.Exists(_LogPath))
                {
                    Directory.CreateDirectory(_LogPath);
                }

                return _LogPath;
            }
        }

        private void LogSourceFail(ResultValue result, string functionName, bool isThrow = false)
        {
            if (result.Faild)
            {
                File.AppendAllText(mLogPath, string.Format("{0} Error:{1}\r\n{2}", functionName, result.Message, result.StackTrace));

                if (isThrow) throw new Exception(result.Message);
            }
        }

        private void LogRunFail(Exception ex, string functionName, bool isThrow = false)
        {
            File.AppendAllText(mLogPath, string.Format("{0} Error:{1}\r\n{2}", functionName, ex.Message, ex.StackTrace));

            if (isThrow) throw ex;
        }

        protected void DoUpdateFunctionWithLog(Action action, EventHandler<EventArgs> CallBack, string functionName, bool isThrow = false)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogRunFail(ex, functionName, isThrow);
            }
        }

        protected T DoUpdateFunctionWithLog<T>(Func<T> action, T defaultT, object sender, EventHandler<T> CallBack, string functionName, bool isThrow = false) where T : CusEventArgs
        {
            try
            {
                var eventArgs = action();

                if (CallBack != null)
                {
                    CallBack(sender, eventArgs);
                }
            }
            catch (Exception ex)
            {
                LogRunFail(ex, functionName, isThrow);

                if (CallBack != null)
                {
                    if (defaultT != null)
                    {
                        defaultT.EventException = ex;
                    }

                    CallBack(sender, defaultT);
                }
            }

            return defaultT;
        }

        protected T DoFunctionWithLog<T>(Func<T> action, T defaultT, string functionName, bool isThrow = false)
        {
            try
            {
                var resultValue = action();
                if (typeof(T) == typeof(ResultValue))
                {
                    LogSourceFail(resultValue as ResultValue, functionName, isThrow);
                }

                return resultValue;
            }
            catch (Exception ex)
            {
                LogRunFail(ex, functionName, isThrow);
            }

            return defaultT;
        }

        protected List<T> ConvertToList<T>(ResultValue result) where T : DBModelBase, new()
        {
            var itemList = new List<T>();

            if (result != null && result.ResultTable != null)
            {
                foreach (var row in result.ResultTable.Rows)
                {
                    var item = new T();
                   
                    Dictionary<string, object> itemDict = new Dictionary<string, object>();
                    var resultColumns = result.ResultTable.Columns;
                    for (int i = 0; i < resultColumns.Length; i++)
                    {
                        var columnName = resultColumns[i];
                        var isPrivacyColumn = SharedVariables.Instance.TableColumnInfos.Where(e => (e.TableName + e.ColumnName) == columnName).Count() > 0;
                        if (isPrivacyColumn)
                        {
                            //var loginUserColumns = null;//;SharedVariables.Instance.LoginUser.RoleColumns;
                            //if (loginUserColumns == null) continue;
                            //var hasAuthor = loginUserColumns.Where(e => (e.TableName + e.ColumnName) == columnName).Count() > 0;
                            //if (!hasAuthor) continue;
                        }
                        itemDict.Add(columnName, row[i]);
                    }

                    item.SetValues(itemDict);
                    itemList.Add(item);
                }
            }

            return itemList;
        }


    }

    public class CusEventArgs : EventArgs
    {
        public Exception EventException { get; set; }

        public CusEventArgs(Exception ex = null)
        {
            EventException = ex;
        }
    }
}

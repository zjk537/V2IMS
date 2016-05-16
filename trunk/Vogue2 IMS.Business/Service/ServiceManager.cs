using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vogue2_IMS.Business.DataServiceReference;
using System.Configuration;

namespace Vogue2_IMS.Business.Service
{
    class ServiceManager : IDisposable
    {
        private static ServiceManager instance;
        public static ServiceManager Instance
        {
            get
            {
                if (instance == null) instance = new ServiceManager();

                return instance;
            }
        }

        private DataServiceClient dataService = new DataServiceClient();
        private IDataService dataServiceLocal;
        public IDataService DataService
        {
            get
            {
                if (ConfigurationManager.AppSettings["LocalService"] == "0")
                {
                    if (dataService == null
                        || dataService.State.Equals(System.ServiceModel.CommunicationState.Closed)
                        || dataService.State.Equals(System.ServiceModel.CommunicationState.Faulted))
                    {
                        //补充HeaderMessage（HeaerMessage用于验证用户与通道安全性）
                        //currentUser.SessionId
                        //currentUser.CurrentUser.UserId
                        dataService = new DataServiceClient();
                    }

                    return dataService;
                }
                else
                {
                    if (dataServiceLocal == null)
                    {
                        dataServiceLocal = new DataLocalService();
                    }

                    return dataServiceLocal;
                }
                //return new DataService.DataService() as IDataService;
            }
        }

        public void Dispose()
        {
            try
            {
                if (dataService != null
                    && dataService.State.Equals(System.ServiceModel.CommunicationState.Opened))
                {
                    dataService.Close();
                }
            }
            finally
            {
                dataService = null;
            }
        }
    }

    class DataLocalService : IDataService
    {
        DataService.DataService localDataService = new DataService.DataService();

        public DataService.Model.ResultValue UserValidator(string userName, string pwd)
        {
            return localDataService.UserValidator(userName, pwd);
        }

        public DataService.Model.ResultValue FuncSaveData(Vogue2_IMS.Service.Business.Model.FunctionParms functionParms)
        {
            return localDataService.FuncSaveData(functionParms);
        }

        public DataService.Model.ResultValue[] FuncBatchSaveData(Vogue2_IMS.Service.Business.Model.FunctionParms[] functionParms)
        {
            return localDataService.FuncBatchSaveData(functionParms);
        }

        public DataService.Model.ResultValue FuncGetResults(Vogue2_IMS.Service.Business.Model.FunctionParms functionParms)
        {
            return localDataService.FuncGetResults(functionParms);
        }
    }

}

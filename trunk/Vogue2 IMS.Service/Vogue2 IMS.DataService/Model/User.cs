using System;

namespace Vogue2_IMS.Service.Business.Model
{
    internal class User : IDisposable
    {
        public string SessionID { get; set; }

        public DateTime LastRequestTime { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

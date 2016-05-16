using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Vogue2_IMS.Service.Business.Model
{
    [DataContract]
    [Serializable]
    public class FunctionParms
    {
        [DataMember]
        public string FunctionName { get; set; }

        [DataMember]
        public IDictionary<string, object> Pams { get; set; }
    }
}

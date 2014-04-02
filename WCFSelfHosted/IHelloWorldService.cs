using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFSelfHosted
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string Hello(string request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFSelfHosted
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RealHelloService : IHelloWorldService
    {
        public virtual string Hello(string request)
        {
            return "Hello World";
        }
    }
}

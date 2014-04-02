using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFSelfHosted
{
    public class HelloClient : ClientBase<IHelloWorldService>, IHelloWorldService
    {
        public HelloClient(string address) : base(new BasicHttpBinding(), new EndpointAddress(address))
        {

        }

        public string Hello(string request)
        {
            return this.Channel.Hello(request);
        }
    }
}

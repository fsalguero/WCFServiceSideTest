using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Moq;
using System.ServiceModel.Description;

namespace WCFSelfHosted
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelfHostedTest()
        {
            Uri baseAddress = new Uri("http://localhost:8001/HelloWorld");

            var mock = new Mock<RealHelloService>();
            mock.Setup(m => m.Hello(It.IsAny<string>())).Returns("mock world");

            var serviceHost = new ServiceHost(mock.Object, baseAddress);

            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            serviceHost.Description.Behaviors.Add(smb);

            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            serviceHost.AddServiceEndpoint(typeof(IHelloWorldService), new BasicHttpBinding(), "");
            serviceHost.Open();


            var client = new HelloClient(baseAddress.ToString());
            Console.WriteLine(client.Hello("hello"));

            serviceHost.Close();

        }
    }
}

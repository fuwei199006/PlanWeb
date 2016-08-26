using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;

namespace Framework.Utility
{
    /// <summary>
    /// wcf帮助类
    /// </summary>
    public class WcfServiceProxy
    {
        public static T CreateServiceProxy<T>(string uri)
        {
            var key = string.Format("{0} - {1}", typeof (T), uri);

            if (Caching.Get(key) == null)
            {
                var binding = new BasicHttpBinding();
                binding.MaxBufferPoolSize = MaxReceivedMessageSize;
                binding.ReaderQuotas=new XmlDictionaryReaderQuotas();
                binding.ReaderQuotas.MaxStringContentLength = MaxReceivedMessageSize;
                binding.ReaderQuotas.MaxArrayLength = MaxReceivedMessageSize;
                binding.ReaderQuotas.MaxBytesPerRead = MaxReceivedMessageSize;
                binding.OpenTimeout = Timeout;
                binding.ReceiveTimeout = Timeout;
                binding.SendTimeout = Timeout;
                var channel=new ChannelFactory<T>(binding,new EndpointAddress(uri));

                foreach (var operation in channel.Endpoint.Contract.Operations)
                {
                    var dataContractBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    if(dataContractBehavior!=null)
                        dataContractBehavior.MaxItemsInObjectGraph=Int32.MaxValue;
                }
                channel.Open();
                var service = channel.CreateChannel();
                Caching.Set(key,service);
                return service;

            }
            return (T) Caching.Get(key);
        }

        private const int MaxReceivedMessageSize = 2147483647;
        private static readonly TimeSpan Timeout = TimeSpan.FromMinutes(10);
    }
}
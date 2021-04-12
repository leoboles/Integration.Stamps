using Integration.Stamps.Soap.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Stamps.Soap
{
    public static class Rates
    {
        public static RateV26[] Get (RateV26 request)
        {
            var endpoint = ConfigurationManager.AppSettings["Environment"] == "Production"
                ? "https://swsim.stamps.com/swsim/swsimv71.asmx"
                : "https://swsim.testing.stamps.com/swsim/swsimv71.asmx";

            var client = new SwsimV71SoapClient(
                new BasicHttpsBinding(BasicHttpsSecurityMode.Transport)
                {
                    MaxReceivedMessageSize = int.MaxValue,
                },
                new EndpointAddress(endpoint));

            var credential = new Credentials()
            {
                IntegrationID = new Guid(ConfigurationManager.AppSettings["IntegrationID"]),
                Username = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"]
            };

            var result = new RateV26[0];

            var resturnedValue = client.GetRates(credential, request, out result);

            return result;
        }
    }
}

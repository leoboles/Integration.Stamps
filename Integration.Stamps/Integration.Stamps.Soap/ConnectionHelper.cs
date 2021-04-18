using Integration.Stamps.Soap.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Stamps.Soap
{
    internal class ConnectionHelper
    {
        internal static (SwsimV111Soap Client, Credentials Credentials, bool IsProduction) GetConnection()
        {
            bool isProduction = ConfigurationManager.AppSettings["Environment"] == "Production";

            var endpoint = isProduction
                ? "https://swsim.stamps.com/swsim/swsimv111.asmx"
                : "https://swsim.testing.stamps.com/swsim/swsimv111.asmx";

            var client = new SwsimV111SoapClient(
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

            return (client, credential, isProduction);
        }
    }
}

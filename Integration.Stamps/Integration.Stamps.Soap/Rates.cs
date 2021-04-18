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
        public static RateV40[] Get (RateV40 request)
        {
            var connection = ConnectionHelper.GetConnection();

            var response = connection.Client.GetRates( 
                new GetRatesRequest
                {
                    Item = connection.Credentials,
                    Rate = request,
                    Carrier = Carrier.All
                });

            return response.Rates;
        }
    }
}

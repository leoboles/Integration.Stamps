using Integration.Stamps.Soap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Stamps.Soap
{
    public static class Labels
    {
        public static CreateIndiciumResponse Create (RateV40 rate, string integratorTxID, string trackingNumber)
        {
            var connection = ConnectionHelper.GetConnection();

            var response = connection.Client.CreateIndicium(
                new CreateIndiciumRequest
                {
                    Rate = rate,
                    Item = connection.Credentials, 
                    IntegratorTxID = integratorTxID,
                    TrackingNumber = trackingNumber,
                    SampleOnly = !connection.IsProduction,
                });

            return response;
        }
    }
}

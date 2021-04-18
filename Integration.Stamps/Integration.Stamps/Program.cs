using Integration.Stamps.Soap;
using Integration.Stamps.Soap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Stamps
{
    class Program
    {
        static void Main(string[] args)
        {
            var rate = new RateV40()
            {
                ShipDate = DateTime.Today.AddDays (5),
                From = new Address()
                {
                    State = "CA",
                    ZIPCode = "92128"
                },
                To = new Address()
                {
                    State = "CA",
                    ZIPCode = "90245"
                },
                WeightLb = 1,
            };

            var returnedRates = Rates.Get(rate);

            foreach(var returnedRate in returnedRates)
            {
                Console.WriteLine($"Service: {returnedRate.ServiceDescription} = ${returnedRate.Amount}");
            }

            var labelRate = new RateV40()
            {
                ShipDate = DateTime.Today.AddDays(5),
                From = new Address()
                {
                    FirstName = "Wade",
                    LastName = "Wilson",
                    Address1 = "3420 Ocean Park Bl",
                    Address2 = "Ste 1000",
                    City = "Santa Monica",
                    State = "CA",
                    ZIPCode = "92128"
                },
                To = new Address()
                {
                    FirstName = "Charles",
                    LastName = "Xavier",
                    Address1 = "1900 E Grand Ave",
                    City = "El Segundo",
                    State = "CA",
                    ZIPCode = "90245"
                },
                Amount = 5,
                WeightLb = 2,
                WeightOz = 0,
                PackageType = PackageTypeV11.Package,
                Length = 5,
                Width = 5,
                Height = 5,
                ServiceType = ServiceType.USPM,
            };

            var labelResponse = Labels.Create(labelRate, Guid.NewGuid().ToString(), "99999");

            Console.WriteLine($"Label URL: {labelResponse.URL}");
        }
    }
}

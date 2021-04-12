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
            var rate = new RateV26()
            {
                ShipDate = DateTime.Today.AddDays (5),
            };

            var result = Rates.Get(rate);

        }
    }
}

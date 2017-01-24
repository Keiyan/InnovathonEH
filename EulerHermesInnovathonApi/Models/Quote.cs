using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models
{
    public class Quote
    {
        public Quote() { }
        public Quote(string partnerName, int hourlyPrice, string contract)
        {
            this.PartnerName = partnerName;
            this.HourlyPrice = hourlyPrice;
            this.Contract = contract;
        }

        public string PartnerName { get; set; }
        public int HourlyPrice { get; set; }
        public string Contract { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class PartnerQuote
    {
        private static int nextId = 0;
        public PartnerQuote() { }
        public PartnerQuote(string partnerName, int hourlyPrice, string contract = null)
        {
            this.PartnerQuoteId = nextId++;
            this.PartnerName = partnerName;
            this.HourlyPrice = hourlyPrice;
            this.Contract = contract ?? LoremIpsum.Text3;
        }

        public string PartnerName { get; set; }
        public int HourlyPrice { get; set; }
        public string Contract { get; set; }
        public int PartnerQuoteId { get; private set; }
    }
}
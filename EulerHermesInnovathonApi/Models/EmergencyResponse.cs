using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models
{
    public class EmergencyResponse
    {
        public Category Qualification { get; set; }

        public Guaranty Guaranty { get; set; }

        public IEnumerable<Quote> Quotes { get; set; }
    }
}
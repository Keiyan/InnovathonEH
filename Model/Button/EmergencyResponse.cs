using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class EmergencyResponse : BaseEntity
    {
        public static IEnumerable<EmergencyResponse> ResponseList { get; private set; }

        static EmergencyResponse()
        {
            ResponseList = new List<EmergencyResponse>()
            {
                new EmergencyResponse(
                    new Category(""),
                    new Warranty(0,0),
                    new List<PartnerQuote>()
                    {
                        new PartnerQuote("",0),
                    }),
                new EmergencyResponse(
                    new Category(""),
                    new Warranty(1,0),
                    new List<PartnerQuote>()
                    {
                        new PartnerQuote("",0),
                    }),
                new EmergencyResponse(
                    new Category(""),
                    new Warranty(2,0),
                    new List<PartnerQuote>()
                    {
                        new PartnerQuote("",0),
                    }),
            };
        }

        public EmergencyResponse() { }

        public EmergencyResponse(Category category, Warranty guaranty, IEnumerable<PartnerQuote> quoteList)
        {
            this.SetId();
            this.Category = category;
            this.Warranty = guaranty;
            this.QuoteList = quoteList;
        }

        public Category Category { get; set; }

        public Warranty Warranty { get; set; }

        public IEnumerable<PartnerQuote> QuoteList { get; set; }
    }
}
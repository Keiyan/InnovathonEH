using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models.Button
{
    public class EmergencyResponse
    {
        public static IEnumerable<EmergencyResponse> ResponseList { get; private set; }

        static EmergencyResponse()
        {
            ResponseList = new List<EmergencyResponse>()
            {
                new EmergencyResponse(
                    new Category("", ""),
                    new Guaranty(0,0,""),
                    new List<Quote>()
                    {
                        new Quote("",0,""),
                    }),
                new EmergencyResponse(
                    new Category("", ""),
                    new Guaranty(1,0,""),
                    new List<Quote>()
                    {
                        new Quote("",0,""),
                    }),
                new EmergencyResponse(
                    new Category("", ""),
                    new Guaranty(2,0,""),
                    new List<Quote>()
                    {
                        new Quote("",0,""),
                    }),
            };
        }

        public EmergencyResponse() { }

        public EmergencyResponse(Category category, Guaranty guaranty, IEnumerable<Quote> quoteList)
        {
            this.Category = category;
            this.Guaranty = guaranty;
            this.QuoteList = quoteList;
        }

        public Category Category { get; set; }

        public Guaranty Guaranty { get; set; }

        public IEnumerable<Quote> QuoteList { get; set; }
    }
}
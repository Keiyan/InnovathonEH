using EulerHermesInnovathon.Models.Button;
using EulerHermesInnovathon.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Repositories
{
    public class DataRepository
    {
        private static object __sync = new object();
        private static DataRepository __Instance;

        public static DataRepository Instance
        {
            get
            {
                if (__Instance == null)
                    lock (__sync)
                        if (__Instance == null)
                            __Instance = new DataRepository();
                return __Instance;
            }
        }

        private IEnumerable<EmergencyResponse> _responseList = new List<EmergencyResponse>()
        {
            new EmergencyResponse(
                new Category("CA"),
                new Warranty(0,0),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("QA",0),
                }),
            new EmergencyResponse(
                new Category("CB"),
                new Warranty(1,0),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("QB",0),
                }),
            new EmergencyResponse(
                new Category("CC"),
                new Warranty(2,0),
                new List<PartnerQuote>()
                {
                    new PartnerQuote("QC",0),
                }),
        };

        private IEnumerable<Package> _packageList = new List<Package>()
        {
            new Package("A", 0),
            new Package("B", 1),
            new Package("C", 2),
            new Package("D", 3),
        };

        private IEnumerable<Enterprise> _enterpriseList = new List<Enterprise>()
        {
            new Enterprise("678502444", "ROHL", 6700000, 30, "2740Z", false, "Fabrication d'éclairage", null),
        };

        public IEnumerable<T> GetAll<T>()
        {
            var targetType = typeof(T);
            if (targetType == typeof(EmergencyResponse)) return (IEnumerable<T>)this._responseList;
            if (targetType == typeof(Package)) return (IEnumerable<T>)this._packageList;
            if (targetType == typeof(Enterprise)) return (IEnumerable<T>)this._enterpriseList;

            return null;
        }
    }
}
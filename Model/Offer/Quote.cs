using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Offer
{
    public class Quote : BaseEntity
    {
        public Quote() { }
        public Quote(IEnumerable<Package> packageList)
        {
            this.SetId();
            this.PackageList = packageList;
        }

        public IEnumerable<Package> PackageList { get; set; }
        public int AnnualPrice { get { return this.PackageList.Sum(p => p.AnnualPrice); } }
        public string Contract { get { return string.Join("\n", this.PackageList.Select(p => p.Contract)); } }
    }
}

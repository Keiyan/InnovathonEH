﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models.Offer
{
    public class Package
    {
        public static readonly IEnumerable<Package> PackageList = new List<Package>()
        {
            new Package("", 0, ""),
            new Package("", 1, ""),
            new Package("", 2, ""),
            new Package("", 3, ""),
        };

        private static int nextId = 0;

        public Package() { this.PackageId = nextId++; }
        public Package(string name, int annualPrice, string description, string contract = null)
        {
            this.PackageId = nextId++;
            this.Name = name;
            this.AnnualPrice = annualPrice;
            this.Description = description;
            this.Contract = contract ?? this.Name + " : " + LoremIpsum.Text;
        }

        public int PackageId { get; set; }
        public int AnnualPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Contract { get; internal set; }
    }
}
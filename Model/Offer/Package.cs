﻿using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Offer
{
    public class Package : BaseEntity
    {
        public Package() { }
        public Package(string name, int annualPrice, string description = null, string contract = null)
        {
            this.SetId();
            this.Name = name;
            this.AnnualPrice = annualPrice;
            this.Description = description ?? LoremIpsum.Text;
            this.Contract = contract ?? this.Name + " : " + LoremIpsum.Text2;
        }

        public int AnnualPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Contract { get; internal set; }
    }
}
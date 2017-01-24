using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Offer
{
    public class Enterprise : BaseEntity
    {
        public Enterprise() { }

        public Enterprise(
            string SIREN
            , string name
            , long totalRevenue
            , int peopleCount
            , string NAF
            , bool isGroup
            , string activitySector
            , string CSEP)
        {
            this.SetId();
            this.SIREN = SIREN;
            this.Name = name;
            this.TotalRevenue = totalRevenue;
            this.PeopleCount = peopleCount;
            this.NAF = NAF;
            this.IsGroup = isGroup;
            this.ActivitySector = activitySector;
            this.CSEP = CSEP;
        }

        public string SIREN { get; set; }

        public string Name { get; set; }

        public long TotalRevenue { get; set; }

        public int PeopleCount { get; set; }

        public string NAF { get; set; }

        public bool IsGroup { get; set; }

        public string ActivitySector { get; set; }

        public string CSEP { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models.Button
{
    public class Guaranty
    {
        public Guaranty() { }

        public Guaranty(int coverage, int excess, string description)
        {
            this.Coverage = coverage;
            this.Excess = excess;
            this.Description = description;
        }

        public int Coverage { get; set; }
        public int Excess { get; set; }
        public string Description { get; set; }
    }
}
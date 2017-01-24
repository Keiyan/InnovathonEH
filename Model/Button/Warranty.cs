using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class Warranty : BaseEntity
    {
        public Warranty() { }

        public Warranty(string name, int coverage, int excess, string description = null)
        {
            this.SetId();
            this.Name = name;
            this.Coverage = coverage;
            this.Excess = excess;
            this.Description = description ?? LoremIpsum.Text;
        }

        public string Name { get; set; }
        public int Coverage { get; set; }
        public int Excess { get; set; }
        public string Description { get; set; }
    }
}
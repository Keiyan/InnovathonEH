﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class Warranty
    {
        public Warranty() { }

        public Warranty(int coverage, int excess, string description = null)
        {
            this.Coverage = coverage;
            this.Excess = excess;
            this.Description = description ?? LoremIpsum.Text;
        }

        public int Coverage { get; set; }
        public int Excess { get; set; }
        public string Description { get; set; }
    }
}
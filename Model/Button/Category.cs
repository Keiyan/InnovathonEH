using EulerHermesInnovathon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class Category : BaseEntity
    {

        public Category() { }
        public Category(string name, string description = null)
        {
            this.SetId();
            this.Name = name;
            this.Description = description ?? LoremIpsum.Text;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
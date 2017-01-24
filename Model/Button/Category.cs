using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathon.Models.Button
{
    public class Category
    {
        private static int nextId = 0;

        public Category() { this.CategoryId = nextId++; }
        public Category(string name, string description = null)
        {
            this.CategoryId = nextId++;
            this.Name = name;
            this.Description = description ?? LoremIpsum.Text;
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
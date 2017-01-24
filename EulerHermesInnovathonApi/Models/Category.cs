using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EulerHermesInnovathonApi.Models
{
    public class Category
    {
        private static int nextId = 0;
        private static readonly IEnumerable<Category> _CategoryList = new List<Category>()
        {
            new Category("", ""),
        };

        public static IEnumerable<Category> GetCategoryList()
        {
            return _CategoryList;
        }

        public Category() { this.CategoryId = nextId++; }
        public Category(string name, string description)
        {
            this.CategoryId = nextId++;
            this.Name = name;
            this.Description = description;
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
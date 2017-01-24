using EulerHermesInnovathon.Models.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EulerHermesInnovathonApi.Controllers
{
    public class ButtonController : ApiController
    {
        [HttpGet]
        [Route("category/all")]
        public IEnumerable<Category> GetEmergencyCategories()
        {
            return EmergencyResponse.ResponseList.Select(e => e.Category);
        }

        [HttpGet]
        [Route("category/{id}")]
        public EmergencyResponse GetCategory(int id)
        {
            return EmergencyResponse.ResponseList.FirstOrDefault(e => e.Category.CategoryId == id);
        }

    }
}

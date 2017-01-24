using EulerHermesInnovathon.Models.Button;
using EulerHermesInnovathonApi.Services;
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
            return EmergencyResponse.ResponseList.FirstOrDefault(e => e.Category.Id == id);
        }

        [HttpPost]
        [Route("accept")]
        public IHttpActionResult AcceptQuote(int quoteId)
        {
            ClientActionService.Instance.PerformClientActions(EmergencyResponse.ResponseList.SelectMany(e => e.QuoteList).FirstOrDefault(l => l.Id == quoteId));

            return Ok();
        }
    }
}

using EulerHermesInnovathon.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EulerHermesInnovathonApi.Controllers
{
    public class OfferController : ApiController
    {
        [HttpGet]
        [Route("package/all")]
        public IEnumerable<Package> GetAllPackages()
        {
            return Package.PackageList;
        }

        [HttpGet]
        [Route("quote")]
        public Quote GetQuote([FromUri(Name ="package")] IEnumerable<int> packageList)
        {
            return new Quote(Package.PackageList.Where(p => packageList.Contains(p.PackageId)));
        }

        [HttpPost]
        [Route("quote")]
        public IHttpActionResult AcceptQuote([FromUri(Name = "package")] IEnumerable<int> packageList)
        {
            return Ok();
        }

        [HttpGet]
        [Route("enterprise/{siren}")]
        public Enterprise GetEnterpriseDetails(string SIREN)
        {
            throw new NotImplementedException();
        }
    }
}

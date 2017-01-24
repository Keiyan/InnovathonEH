using EulerHermesInnovathonApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EulerHermesInnovathonApi.Controllers
{
    public class ClientController : ApiController
    {
        [HttpPost]
        [Route("register/sms/{phoneNumber}")]
        public IHttpActionResult RegisterForSms(string phoneNumber)
        {
            ClientActionService.Instance.RegisterForSms(phoneNumber);

            return Ok();
        }

        [HttpPost]
        [Route("register/email/{emailAddress}")]
        public IHttpActionResult RegisterForEmail(string emailAddress)
        {
            ClientActionService.Instance.RegisterForEmail(emailAddress);

            return Ok();
        }

        [HttpPost]
        [Route("register/callback/{uri}")]
        public IHttpActionResult RegisterForCallback(string uri)
        {
            ClientActionService.Instance.RegisterForCallback(uri);

            return Ok();
        }
    }
}

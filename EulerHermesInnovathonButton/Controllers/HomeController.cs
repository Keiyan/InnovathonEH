using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using EulerHermesInnovathon.Models.Button;

namespace EulerHermesInnovathonButton.Controllers
{
    public class HomeController : Controller
    {
        private static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        private static HttpClient client = new HttpClient();

        static HomeController()
        {
            client.BaseAddress = new Uri(ApiBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            //if (catId.HasValue)
            //{
            //    // save or remove choice
            //    if (Session["categories"] == null)
            //        Session["categories"] = new List<int>();

            //    var choices = Session["categories"] as List<int>;
            //    if (choices.Exists(catid => catid == catId.Value))
            //        choices.Remove(catId.Value);
            //    else
            //        choices.Add(catId.Value);

            //    Session["categories"] = choices;
            //}

            var response = await client.GetAsync(ApiBaseUrl + "/category/all");
            var categories = new List<Category>();
            if (response.IsSuccessStatusCode)
                categories = await response.Content.ReadAsAsync<List<Category>>();

            return View(categories);
        }

        public async Task<ActionResult> Props(int catId)
        {
            var response = await client.GetAsync(ApiBaseUrl + $"/category/{catId}");
            var emergency = new EmergencyResponse();
            if (response.IsSuccessStatusCode)
                emergency = await response.Content.ReadAsAsync<EmergencyResponse>();

            return View(emergency);
        }

        public async Task<ActionResult> Accept(int quoteId)
        {
            var response = await client.PostAsync<int>(ApiBaseUrl + $"/accept?quoteId={quoteId}", quoteId, new JsonMediaTypeFormatter());
            return View(response.IsSuccessStatusCode);
        }
    }
}
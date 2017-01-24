using EulerHermesInnovathon.Models.Offer;
using EulerHermesInnovathonOffer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EulerHermesInnovathonOffer.Controllers
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

        public async Task<ActionResult> Index(int[] packageIds)
        {
            var model = new IndexViewModel
            {
                Packages = await GetPackages(),
            };
            return View(model);
        }

        public ActionResult PageN(int page = 1)
        {
            return View(page);
        }

        private async Task<List<Package>> GetPackages()
        {
            var response = await client.GetAsync(ApiBaseUrl + "/package/all");
            var packages = new List<Package>();
            if (response.IsSuccessStatusCode)
                packages = await response.Content.ReadAsAsync<List<Package>>();
            return packages;
        }

        //private async Task<List<Quote>> GetQuotes()
        //{

        //    var response = await client.GetAsync(ApiBaseUrl + "/quote?" + );
        //    var quotes = new List<Quote>();
        //    if (response.IsSuccessStatusCode)
        //        quotes = await response.Content.ReadAsAsync<List<Quote>>();
        //    return quotes;
        //}
    }
}
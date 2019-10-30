using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnthroCloud.UI.Web.Controllers
{
    public class ChartController : Controller
    {
        static HttpClient client = new HttpClient();
        
        //https://anthrocloudapi.azurewebsites.net/
        [HttpGet]
        public JsonResult GetGreeting(string path)
        {
            client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
            //HttpResponseMessage response = await client.GetAsync(path);
            path = "chart/WFL/2";
            //HTTP GET
            var responseTask = client.GetAsync(path);
            responseTask.Wait();

            var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
            //    readTask.Wait();

            //    students = readTask.Result;
            //}
            //var populationList = PopulationDataAccessLayer.GetCityPopulationList();
            //var populationList = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            //return Json(populationList);
           // string output = "Welcome to the Admin User";

            return Json(responseTask);
        }

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Chart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
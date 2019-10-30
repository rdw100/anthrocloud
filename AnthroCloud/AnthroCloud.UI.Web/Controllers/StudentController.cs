using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnthroCloud.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        // https://www.tutorialsteacher.com/webapi/consume-web-api-get-method-in-aspnet-mvc
        // GET: Student
        //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
        //public ActionResult Index()
        //{
        //    IEnumerable<StudentViewModel> students = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64189/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync("student");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
        //            readTask.Wait();

        //            students = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            students = Enumerable.Empty<StudentViewModel>();

        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return View(students);
        //}

    }
}
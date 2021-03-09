using AnthroCloud.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AnthroCloud.UI.Web.Controllers
{
    public class LineChartController : Controller
    {
        private static IConfiguration _configuration;
        private static string baseAddressPath;

        public LineChartController(IConfiguration iConfig)
        {
            _configuration = iConfig;
            baseAddressPath = _configuration.GetValue<string>("ConfigurationSettings:baseApiAddressPath");
        }

        // GET: /<controller>/  
        [Route("{id}")]
        [Route("LineChart/{id}")]
        public IActionResult Index()
        {            
            return View();
        }

        [Route("LineChart/BFA_P")]
        public IActionResult BFA_P()
        {            
            return View();
        }

        [Route("LineChart/HCA_P")]
        public IActionResult HCA_P()
        {
            return View();
        }

        [Route("LineChart/LHFA_P")]
        public IActionResult LHFA_P()
        {
            return View();
        }

        [Route("LineChart/MUAC_P")]
        public IActionResult MUAC_P()
        {
            return View();
        }

        [Route("LineChart/SSF_P")]
        public IActionResult SSF_P()
        {
            return View();
        }

        [Route("LineChart/TSF_P")]
        public IActionResult TSF_P()
        {
            return View();
        }

        [Route("LineChart/WFA_P")]
        public IActionResult WFA_P()
        {
            return View();
        }

        [Route("LineChart/WFH_P")]
        public IActionResult WFH_P()
        {
            return View();
        }

        [Route("LineChart/WFL_P")]
        public IActionResult WFL_P()
        {
            return View();
        }

        [Route("LineChart/BFA_Z")]
        public IActionResult BFA_Z()
        {
            return View();
        }

        [Route("LineChart/HCA_Z")]
        public IActionResult HCA_Z()
        {
            return View();
        }

        [Route("LineChart/LHFA_Z")]
        public IActionResult LHFA_Z()
        {
            return View();
        }

        [Route("LineChart/MUAC_Z")]
        public IActionResult MUAC_Z()
        {
            return View();
        }

        [Route("LineChart/SSF_Z")]
        public IActionResult SSF_Z()
        {
            return View();
        }

        [Route("LineChart/TSF_Z")]
        public IActionResult TSF_Z()
        {
            return View();
        }

        [Route("LineChart/WFA_Z")]
        public IActionResult WFA_Z()
        {
            return View();
        }

        [Route("LineChart/WFH_Z")]
        public IActionResult WFH_Z()
        {
            return View();
        }

        [Route("LineChart/WFL_Z")]
        public IActionResult WFL_Z()
        {
            return View();
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetWeightForLengthJson(byte id, double x, double y)
        {
            var populationList = GetWeightForLengthData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetBMIForAgeJson(byte id, double x, double y)
        {
            var populationList = GetBMIForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetHCForAgeJson(byte id, double x, double y)
        {
            var populationList = GetHCForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetLengthHeightForAgeJson(byte id, double x, double y)
        {
            var populationList = GetLengthHeightForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetMUACForAgeJson(byte id, double x, double y)
        {
            var populationList = GetMUACForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetSSFForAgeJson(byte id, double x, double y)
        {
            var populationList = GetSSFForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetTSFForAgeJson(byte id, double x, double y)
        {
            var populationList = GetTSFForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetWeightForAgeJson(byte id, double x, double y)
        {
            var populationList = GetWeightForAgeData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        [Route("{controller}/{action}/{id}/{x}/{y}")]
        public JsonResult GetWeightForHeightJson(byte id, double x, double y)
        {
            var populationList = GetWeightForHeightData(id, x, y);
            var result = Json(populationList);

            return result;
        }

        public static List<BmiforAge> GetBMIForAgeData(byte id, double x, double y)
        {
            List<BmiforAge> bfaList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathBFA = "chart/BFA/" + id + "/" + x + "/" + y; 
                var response = client.GetAsync(pathBFA);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<BmiforAge>>();
                    readTask.Wait();

                    bfaList = readTask.Result;
                }
            }

            return bfaList;
        }

        public static List<HcForAge> GetHCForAgeData(byte id, double x, double y)
        {
            List<HcForAge> hcaList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathHCA = "chart/HCFA/" + id + "/" + x + "/" + y; 
                var response = client.GetAsync(pathHCA);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<HcForAge>>();
                    readTask.Wait();

                    hcaList = readTask.Result;
                }
            }

            return hcaList;
        }

        public static List<LengthHeightForAge> GetLengthHeightForAgeData(byte id, double x, double y)
        {
            List<LengthHeightForAge> lhfaList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathLHFA = "chart/LHFA/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathLHFA);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<LengthHeightForAge>>();
                    readTask.Wait();

                    lhfaList = readTask.Result;
                }
            }

            return lhfaList;
        }

        public static List<MuacforAge> GetMUACForAgeData(byte id, double x, double y)
        {
            List<MuacforAge> muacList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathMUAC = "chart/MUAC/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathMUAC);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<MuacforAge>>();
                    readTask.Wait();

                    muacList = readTask.Result;
                }
            }

            return muacList;
        }

        public static List<SsfforAge> GetSSFForAgeData(byte id, double x, double y)
        {
            List<SsfforAge> ssfList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathSSF = "chart/SSFA/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathSSF);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<SsfforAge>>();
                    readTask.Wait();

                    ssfList = readTask.Result;
                }
            }

            return ssfList;
        }

        public static List<TsfforAge> GetTSFForAgeData(byte id, double x, double y)
        {
            List<TsfforAge> tsfList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathTSF = "chart/TSFA/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathTSF);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TsfforAge>>();
                    readTask.Wait();

                    tsfList = readTask.Result;
                }
            }

            return tsfList;
        }

        public static List<WeightForAge> GetWeightForAgeData(byte id, double x, double y)
        {
            List<WeightForAge> hcaList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathWFA = "chart/WFA/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathWFA);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<WeightForAge>>();
                    readTask.Wait();

                    hcaList = readTask.Result;
                }
            }

            return hcaList;
        }        

        public static List<WeightForLength> GetWeightForLengthData(byte id, double x, double y)
        {
            List<WeightForLength> wflList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathWFL = "chart/WFL/" + id + "/" + x + "/" + y; //"chart/WFL/2"
                var response = client.GetAsync(pathWFL);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<WeightForLength>>();
                    readTask.Wait();

                    wflList = readTask.Result;
                }
            }

            return wflList;
        }

        public static List<WeightForHeight> GetWeightForHeightData(byte id, double x, double y)
        {
            List<WeightForHeight> wfhList = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddressPath);
                //HTTP GET
                string pathWFH = "chart/WFH/" + id + "/" + x + "/" + y;
                var response = client.GetAsync(pathWFH);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<WeightForHeight>>();
                    readTask.Wait();

                    wfhList = readTask.Result;
                }
            }

            return wfhList;
        }
    }
}
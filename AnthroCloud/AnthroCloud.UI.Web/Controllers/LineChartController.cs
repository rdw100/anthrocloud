using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AnthroCloud.Entities;
using AnthroCloud.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace AnthroCloud.UI.Web.Controllers
{
    public class LineChartController : Controller
    {
        private const string baseAddressPath = "http://www.dustywright.me/anthrocloudapi/api/";
 
        // GET: /<controller>/  
        [Route("{id}")]
        [Route("LineChart/{id}")]
        //[Route("LineChart/sex")]
        //[Route("LineChart")]
        public IActionResult Index()
        {
            //RouteValueDictionary rvd = new RouteValueDictionary();
            //rvd.Add("sex", (Models.Sexes)id);
            //string url = "/LineChart/Index?sex" + (Models.Sexes)id;
            //return Redirect(url);
            //return RedirectToAction("Index", new { sex = (Models.Sexes)id });
            return View();
        }
        
        public IActionResult BFA_P()
        {            
            return View();
        }

        public IActionResult HCA_P()
        {
            return View();
        }

        public IActionResult LHFA_P()
        {
            return View();
        }

        public IActionResult MUAC_P()
        {
            return View();
        }

        public IActionResult SSF_P()
        {
            return View();
        }

        public IActionResult TSF_P()
        {
            return View();
        }

        public IActionResult WFA_P()
        {
            return View();
        }

        public IActionResult WFH_P()
        {
            return View();
        }

        public IActionResult WFL_P()
        {
            return View();
        }

        public IActionResult BFA_Z()
        {
            return View();
        }

        public IActionResult HCA_Z()
        {
            return View();
        }

        public IActionResult LHFA_Z()
        {
            return View();
        }

        public IActionResult MUAC_Z()
        {
            return View();
        }

        public IActionResult SSF_Z()
        {
            return View();
        }

        public IActionResult TSF_Z()
        {
            return View();
        }

        public IActionResult WFA_Z()
        {
            return View();
        }

        public IActionResult WFH_Z()
        {
            return View();
        }

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
                List<BmiforAge> bfaList = new List<BmiforAge>();
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
            List<HcForAge> hcaList = new List<HcForAge>();
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
            List<LengthHeightForAge> lhfaList = new List<LengthHeightForAge>();
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
            List<MuacforAge> muacList = new List<MuacforAge>();
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
            List<SsfforAge> ssfList = new List<SsfforAge>();
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
            List<TsfforAge> tsfList = new List<TsfforAge>();
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
            List<WeightForAge> hcaList = new List<WeightForAge>();
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
            List<WeightForLength> wflList = new List<WeightForLength>();
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
            List<WeightForHeight> wfhList = new List<WeightForHeight>();
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

        ////[HttpGet("{id}")]
        ////[Route("{id}")]
        ////[Route("GetWFLJson/{id}")]
        //public JsonResult GetWFLJson(byte id)
        //{
        //    var populationList = GetWFLData(id);
        //    return Json(populationList);
        //}

        //public static List<WeightForLength> GetWFLData(byte id)
        //{
        //    var list = new List<WeightForLength>();
        //    if (id == 1)
        //    {
        //        list.Add(new WeightForLength { Lengthincm = 45.0M, Score = null, P3 = 2.100M, P15 = 2.200M, P50 = 2.400M, P85 = 2.700M, P97 = 2.900M, Sd3neg = 1.900M, Sd2neg = 2.000M, Sd1neg = 2.200M, Sd0 = 2.400M, Sd1 = 2.700M, Sd2 = 3.000M, Sd3 = 3.300M });
        //        list.Add(new WeightForLength { Lengthincm = 50.0M, Score = null, P3 = 2.100M, P15 = 2.300M, P50 = 2.500M, P85 = 2.800M, P97 = 3.000M, Sd3neg = 1.900M, Sd2neg = 2.100M, Sd1neg = 2.300M, Sd0 = 2.500M, Sd1 = 2.800M, Sd2 = 3.100M, Sd3 = 3.400M });
        //        list.Add(new WeightForLength { Lengthincm = 55.0M, Score = null, P3 = 2.200M, P15 = 2.400M, P50 = 2.600M, P85 = 2.900M, P97 = 3.100M, Sd3neg = 2.000M, Sd2neg = 2.200M, Sd1neg = 2.400M, Sd0 = 2.600M, Sd1 = 2.900M, Sd2 = 3.100M, Sd3 = 3.500M });
        //        list.Add(new WeightForLength { Lengthincm = 60.0M, Score = null, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
        //        list.Add(new WeightForLength { Lengthincm = 72.5M, Score = 2.85M, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
        //        //list.Add(new WeightForLength { Lengthincm = 62.4M, Score = 2.85M, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
        //        //list.Add(new WeightForLength { Lengthincm = 62.4M, Score = 2.85M, P3 = null, P15 = null, P50 = null, P85 = null, P97 = null, Sd3neg = null, Sd2neg = null, Sd1neg = null, Sd0 = null, Sd1 = null, Sd2 = null, Sd3 = null });
        //        list.Add(new WeightForLength { Lengthincm = 65.0M, Score = null, P3 = 2.400M, P15 = 2.500M, P50 = 2.800M, P85 = 3.100M, P97 = 3.300M, Sd3neg = 2.300M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.800M, Sd1 = 3.000M, Sd2 = 3.300M, Sd3 = 3.700M });
        //    }
        //    else if (id == 2)
        //    {
        //        list.Add(new WeightForLength { Lengthincm = 70.0M, Score = null, P3 = 2.100M, P15 = 2.200M, P50 = 2.400M, P85 = 2.700M, P97 = 2.900M, Sd3neg = 1.900M, Sd2neg = 2.000M, Sd1neg = 2.200M, Sd0 = 2.400M, Sd1 = 2.700M, Sd2 = 3.000M, Sd3 = 3.300M });
        //        list.Add(new WeightForLength { Lengthincm = 75.0M, Score = null, P3 = 2.100M, P15 = 2.300M, P50 = 2.500M, P85 = 2.800M, P97 = 3.000M, Sd3neg = 1.900M, Sd2neg = 2.100M, Sd1neg = 2.300M, Sd0 = 2.500M, Sd1 = 2.800M, Sd2 = 3.100M, Sd3 = 3.400M });
        //        list.Add(new WeightForLength { Lengthincm = 80.0M, Score = null, P3 = 2.200M, P15 = 2.400M, P50 = 2.600M, P85 = 2.900M, P97 = 3.100M, Sd3neg = 2.000M, Sd2neg = 2.200M, Sd1neg = 2.400M, Sd0 = 2.600M, Sd1 = 2.900M, Sd2 = 3.100M, Sd3 = 3.500M });
        //        list.Add(new WeightForLength { Lengthincm = 83.7M, Score = 2.85M, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
        //        //list.Add(new WeightForLength { Lengthincm = 83.7M, Score = 2.85M});
        //        list.Add(new WeightForLength { Lengthincm = 85.0M, Score = null, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
        //        list.Add(new WeightForLength { Lengthincm = 90.0M, Score = null, P3 = 2.400M, P15 = 2.500M, P50 = 2.800M, P85 = 3.100M, P97 = 3.300M, Sd3neg = 2.300M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.800M, Sd1 = 3.000M, Sd2 = 3.300M, Sd3 = 3.700M });
        //    }
        //    return list;
        //}

        //[HttpGet]
        //public async Task<JsonResult> PopulationMyChartAsync()
        //{
        //    List<WeightForLength> wflList = new List<WeightForLength>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://anthrocloudapi.azurewebsites.net/api/chart/WFL/2"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            wflList = JsonConvert.DeserializeObject<List<WeightForLength>>(apiResponse);
        //        }
        //    }

        //    //return View(wflList);
        //    return Json(wflList);
        //}

        //[HttpGet]
        //public JsonResult PopulationMyChart()
        //{
        //    HttpClient client = new HttpClient();

        //    client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
        //    //HttpResponseMessage response = await client.GetAsync(path);
        //    string path = "chart/WFL/2";
        //    //HTTP GET
        //    var responseTask = client.GetAsync(path);
        //    responseTask.Wait();
        //    var result = responseTask.Result;

        //    return Json(result);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AnthroCloud.Entities;
using AnthroCloud.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AnthroCloud.UI.Web.Controllers
{
    public class LineChartController : Controller
    {
        // GET: /<controller>/  
        public IActionResult Index()
        {
            return View();
        }
        
        //[Route("LineChart")]
        //[Route("LineChart/Index")]
        //[Route("LineChart/Index/{ID}")]
        //[Route("LineChart/{ID}")]
        //public IActionResult Index(int id)
        //{
        //    return View(id);
        //}

 

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

        [HttpGet]
        public JsonResult GetWFLJson()
        {
            var populationList = GetWFLData();// GetWeightForLength();//PopulateChartData(); 
            return Json(populationList);
        }

        public static List<WeightForLength> GetWFLData()
        {
            var list = new List<WeightForLength>();
            list.Add(new WeightForLength { Lengthincm = 45.0M, Score = null, P3 = 2.100M, P15 = 2.200M, P50 = 2.400M, P85 = 2.700M, P97 = 2.900M, Sd3neg = 1.900M, Sd2neg = 2.000M, Sd1neg = 2.200M, Sd0 = 2.400M, Sd1 = 2.700M, Sd2 = 3.000M, Sd3 = 3.300M });
            list.Add(new WeightForLength { Lengthincm = 50.0M, Score = null, P3 = 2.100M, P15 = 2.300M, P50 = 2.500M, P85 = 2.800M, P97 = 3.000M, Sd3neg = 1.900M, Sd2neg = 2.100M, Sd1neg = 2.300M, Sd0 = 2.500M, Sd1 = 2.800M, Sd2 = 3.100M, Sd3 = 3.400M });
            list.Add(new WeightForLength { Lengthincm = 55.0M, Score = null, P3 = 2.200M, P15 = 2.400M, P50 = 2.600M, P85 = 2.900M, P97 = 3.100M, Sd3neg = 2.000M, Sd2neg = 2.200M, Sd1neg = 2.400M, Sd0 = 2.600M, Sd1 = 2.900M, Sd2 = 3.100M, Sd3 = 3.500M });
            list.Add(new WeightForLength { Lengthincm = 60.0M, Score = 2.85M, P3 = 2.300M, P15 = 2.500M, P50 = 2.700M, P85 = 3.000M, P97 = 3.200M, Sd3neg = 2.100M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.700M, Sd1 = 3.000M, Sd2 = 3.200M, Sd3 = 3.600M });
            list.Add(new WeightForLength { Lengthincm = 65.0M, Score = null, P3 = 2.400M, P15 = 2.500M, P50 = 2.800M, P85 = 3.100M, P97 = 3.300M, Sd3neg = 2.300M, Sd2neg = 2.300M, Sd1neg = 2.500M, Sd0 = 2.800M, Sd1 = 3.000M, Sd2 = 3.300M, Sd3 = 3.700M });
            return list;
        }
         
        public JsonResult GetWeightForLengthJson()
        {
            var populationList = GetWeightForLengthData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetBMIForAgeJson()
        {
            var populationList = GetBMIForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetHCForAgeJson()
        {
            var populationList = GetHCForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetLengthHeightForAgeJson()
        {
            var populationList = GetLengthHeightForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetMUACForAgeJson()
        {
            var populationList = GetMUACForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetSSFForAgeJson()
        {
            var populationList = GetSSFForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetTSFForAgeJson()
        {
            var populationList = GetTSFForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetWeightForAgeJson()
        {
            var populationList = GetWeightForAgeData();
            var result = Json(populationList);

            return result;
        }

        public JsonResult GetWeightForHeightJson()
        {
            var populationList = GetWeightForHeightData();
            var result = Json(populationList);

            return result;
        }

        public static List<BmiforAge> GetBMIForAgeData()
            {
                List<BmiforAge> bfaList = new List<BmiforAge>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                    //HTTP GET
                    string pathBFA = "chart/BFA/2";
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

        public static List<HcForAge> GetHCForAgeData()
        {
            List<HcForAge> hcaList = new List<HcForAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathHCA = "chart/HCFA/2";
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

        public static List<LengthHeightForAge> GetLengthHeightForAgeData()
        {
            List<LengthHeightForAge> lhfaList = new List<LengthHeightForAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathLHFA = "chart/LHFA/2";
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

        public static List<MuacforAge> GetMUACForAgeData()
        {
            List<MuacforAge> muacList = new List<MuacforAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathMUAC = "chart/MUAC/2";
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

        public static List<SsfforAge> GetSSFForAgeData()
        {
            List<SsfforAge> ssfList = new List<SsfforAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathSSF = "chart/SSFA/2";
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

        public static List<TsfforAge> GetTSFForAgeData()
        {
            List<TsfforAge> tsfList = new List<TsfforAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathTSF = "chart/TSFA/2";
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

        public static List<WeightForAge> GetWeightForAgeData()
        {
            List<WeightForAge> hcaList = new List<WeightForAge>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathWFA = "chart/WFA/2";
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

        public static List<WeightForLength> GetWeightForLengthData()
        {
            List<WeightForLength> wflList = new List<WeightForLength>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathWFL = "chart/WFL/2";
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

        public static List<WeightForHeight> GetWeightForHeightData()
        {
            List<WeightForHeight> wfhList = new List<WeightForHeight>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://anthrocloudapi.azurewebsites.net/api/");
                //HTTP GET
                string pathWFH = "chart/WFL/2";
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
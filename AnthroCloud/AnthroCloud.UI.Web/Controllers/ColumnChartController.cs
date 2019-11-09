using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnthroCloud.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnthroCloud.UI.Web.Controllers
{
    public class ColumnChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PopulationChart()
        {
            //var popList = PopulationMyChart();
            var populationList = GetCityPopulationList();
            return Json(populationList);
        }

        public static List<PopulationModel> GetCityPopulationList()
        {
            var list = new List<PopulationModel>();
            list.Add(new PopulationModel { CityName = "PURINA", PopulationYear2020 = 28000, PopulationYear2010 = 45000, PopulationYear2000 = 22000, PopulationYear1990 = 50000 });
            list.Add(new PopulationModel { CityName = "Bhubaneswar", PopulationYear2020 = 30000, PopulationYear2010 = 49000, PopulationYear2000 = 24000, PopulationYear1990 = 39000 });
            list.Add(new PopulationModel { CityName = "Cuttack", PopulationYear2020 = 35000, PopulationYear2010 = 56000, PopulationYear2000 = 26000, PopulationYear1990 = 41000 });
            list.Add(new PopulationModel { CityName = "Berhampur", PopulationYear2020 = 37000, PopulationYear2010 = 44000, PopulationYear2000 = 28000, PopulationYear1990 = 48000 });
            list.Add(new PopulationModel { CityName = "Odisha", PopulationYear2020 = 40000, PopulationYear2010 = 38000, PopulationYear2000 = 30000, PopulationYear1990 = 54000 });

            return list;
        }
    }
}
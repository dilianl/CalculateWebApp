using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculateWebApp.Models;
using CalculateWebApp.Services.Calculate;
using Microsoft.Extensions.Configuration;

namespace CalculateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        CalculateClient _client;
        List<string> result;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            string url = config.GetSection("AppSettings").GetSection("CalculateServiceUrl").Value;
            _client = new CalculateClient(url);
            result = new List<string>();
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CalculateResult(TowIntNumbersModel param)
        {
            try
            {
                result = await _client.Combination(param);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

            return View(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }   
}

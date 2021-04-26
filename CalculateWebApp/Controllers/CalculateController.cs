using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculateWebApp.Models;
using Newtonsoft.Json;
using CalculateWebApp.Services.Calculate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Numerics;

namespace CalculateWebApp.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;
        CalculateClient _client;
        List<string> result;
        public CalculateController(IConfiguration config, ILogger<CalculateController> logger)
        {
            _logger = logger;
            _client = new CalculateClient(config.GetSection("AppSettings").GetSection("CalculateServiceUrl").Value);
            result = new List<string>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SumResult(TowIntNumbersModel param)
        {
            if (!TryValidateModel(param))
            {
                result.Add(param.GetNoValidationMesage);

                return View("~/Views/Calculate/CalculateResult.cshtml", result);
            }

            try
            {
                string sum = await _client.Sum(param);
                result.Add(param.Display(sum));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

            return View("~/Views/Calculate/CalculateResult.cshtml", result);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateResult(TowIntNumbersModel param)
        {
            if (!TryValidateModel(param))
            {
                result.Add(param.GetNoValidationMesage);

                return View("~/Views/Calculate/CalculateResult.cshtml", result);
            }

            try
            {
                result = await _client.Combination(param);


                if (result.Count > 0 && !string.IsNullOrEmpty(result[0]))
                    return View(result);
                else
                {
                    result.Add(param.GetNoCombinationMessage);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

            return View("~/Views/Calculate/CalculateResult.cshtml", result);
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

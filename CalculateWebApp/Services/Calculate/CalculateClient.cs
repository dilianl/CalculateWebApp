using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Calculate.Api.Client;
using Calculate.Api.Client.Interfaces;
using Calculate.Api.Dto.Api;
using Calculate.Api.Dto.Interfaces;
using CalculateWebApp.Models;

namespace CalculateWebApp.Services.Calculate
{
    public class CalculateClient
    {
        private ICalculateApiClient _client;
        public CalculateClient(string serviceUrl)
        {
            var setting = new CalculateApiClientSettings();
            setting.BaseUrl = serviceUrl;
            _client = new CalculateApiClient(setting);
        }

        ITwoIntNumbersDTO Transform(TowIntNumbersModel data)
        {
            TwoIntNumbersDTO result = new TwoIntNumbersDTO();
            result.FirstNumber = data.FirstNumber;
            result.SecondNumber = data.SecondNumber;

            return result;
        }

        public Task<List<string>> Combination(TowIntNumbersModel data)
        {

            return _client.Combination(Transform(data));
        }

        public Task<string> Multiply(TowIntNumbersModel data)
        {
            return _client.Multiply(Transform(data));
        }

        public Task<string> Subtract(TowIntNumbersModel data)
        {
            return _client.Subtract(Transform(data));
        }

        public Task<string> Sum(TowIntNumbersModel data)
        {
            return _client.Sum(Transform(data));
        }
        public Task<string> GetApiStatus()
        {
            return _client.GetApiStatus();
        }

        public Task<string> GetApiStatusExtended()
        {
            return _client.GetApiStatusExtended();
        }
    }
}

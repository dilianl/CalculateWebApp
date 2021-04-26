using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateWebApp
{
    public class AppSettings
    {
        private readonly IConfiguration config;
        public AppSettings(IConfiguration config)
        {
            this.config = config;
        }

        public string CalculateServiceUrl
        { 
            get { 
                return this.config.GetSection("AppSettings")
                    .GetSection("CalculateServiceUrl").Value; 
            }
        }
    }
}

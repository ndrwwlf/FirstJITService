using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace JITWeatherService.Scheduled
{
    public class AerisJobParams 
    {
        public string AerisClientId { get; set; }
        public string AerisClientSecret { get; set; }
        public string JitWeatherConnectionString { get; set; }
        public string JitWebData3ConnectionString { get; set; }
    }
}

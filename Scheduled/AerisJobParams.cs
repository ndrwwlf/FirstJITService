using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace JITWeatherService.Scheduled
{
    public class AerisJobParams 
    {
        //public string AerisClientId { get; set; }
        //public string AerisClientSecret { get; set; }
        //public string JitWeatherConnectionString { get; set; }
        //public string JitWebData3ConnectionString { get; set; }

        public string AerisClientId = "vgayNZkz1o2JK6VRhOTBZ";
        public string AerisClientSecret = "8YK1bmJlOPJCIO2darWs48qmXPKzGxQHdWWzWmNg";

        public string JitWeatherConnectionString 
            = "Data Source=.\\SQLEXPRESS;Initial Catalog=Weather;User ID=WorkWeeksql;Password=Jon23505#sql; MultipleActiveResultSets=true";
        public string JitWebData3ConnectionString 
            = "Data Source = .\\SQLEXPRESS; Initial Catalog = JitWebData3; User ID = WorkWeeksql; Password = Jon23505#sql; MultipleActiveResultSets=true";
    }
}
using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITWeatherService.Scheduled
{
    class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var log = new LoggerConfiguration()
            .WriteTo.File(@"c:\Users\User\test.txt")
            .CreateLogger())
            {
                log.Information("Hello, Andy!");
                log.Warning("Goodbye, Serilog.");
            }
        }
    }
}

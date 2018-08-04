using JITWeatherService.Scheduled;
using Quartz;
using Quartz.Impl;
using Serilog;
using Serilog.Events;
using System.ServiceProcess;

namespace JITWeatherService
{
    public partial class JITWeatherService : ServiceBase
    {
        public JITWeatherService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string userDir = "C:\\Users\\workweek";
            //string userDir = "C:\\Users\\User";

            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Information()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //.MinimumLevel.Override("System", LogEventLevel.Information)
            //.Enrich.FromLogContext()
            ////to outsite of project
            //.WriteTo.RollingFile(userDir + "/Logs/log-{Date}.log", retainedFileCountLimit: null)
            //.CreateLogger();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)
            .MinimumLevel.Override("Quartz", LogEventLevel.Error)
            .Enrich.FromLogContext()
            //to outsite of project
            .WriteTo.File(userDir + "/Logs/MasterLogJIT.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollOnFileSizeLimit: true)
            .WriteTo.RollingFile(userDir + "/Logs/log-{Date}.txt", retainedFileCountLimit: null)
            .WriteTo.Console()
            .CreateLogger();

            AerisJobParams aerisJobParams = new AerisJobParams();

            IScheduler scheduler;
            var schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
            scheduler.Context.Put("aerisJobParams", aerisJobParams);
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<AerisJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(7, 11))
                   //.WithSimpleSchedule(a => a.WithIntervalInMinutes(15).RepeatForever())
                   .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        protected override void OnStop()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Shutdown();
        }
    }
}

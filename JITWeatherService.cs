using JITWeatherService.Scheduled;
using Quartz;
using Quartz.Impl;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information)
            .Enrich.FromLogContext()
            //to outsite of project
            .WriteTo.RollingFile(userDir + "/Logs/log-{Date}.log", retainedFileCountLimit: null)
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

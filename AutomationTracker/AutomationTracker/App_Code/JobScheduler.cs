using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.App_Code
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<AutomationJobs>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInMinutes(30)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(19, 18,30))
                  )
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
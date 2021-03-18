using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    static class QuartzManager
    {

        public static async Task RunAsync()
        {
            // construct a scheduler factory
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" },
                { "quartz.scheduler.instanceName", "testLiteDbScheduler" },
                { "quartz.threadPool.threadCount", $"3" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            // get a scheduler
            var scheduler = await factory.GetScheduler();

            //Insert 1
            IJobDetail insertJob = JobBuilder.Create<QuartzInsertJob>()
                   .WithIdentity("Insert", "Insert")
                   .Build();
            //
            ITrigger insert1Trigger = TriggerBuilder.Create()
                .WithIdentity("Insert_Trigger1", "Insert")
                .StartAt(DateTimeOffset.Now.AddSeconds(1)) //start after 1 second
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1) //Every 1 seconds
                    .RepeatForever())
                .Build();
            // Planification
            await scheduler.ScheduleJob(insertJob, insert1Trigger);
            Console.WriteLine("Insert job scheduled");

            //Insert 2
            /*IJobDetail insertJob2 = JobBuilder.Create<QuartzInsertJob>()
                   .WithIdentity("Insert2", "Insert")
                   .Build();
            //
            ITrigger insert1Trigger2 = TriggerBuilder.Create()
                .WithIdentity("Insert_Trigger2", "Insert")
                .StartAt(DateTimeOffset.Now.AddSeconds(1)) //start after 1 second
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1) //Every 1 seconds
                    .RepeatForever())
                .Build();
            // Planification
            await scheduler.ScheduleJob(insertJob2, insert1Trigger2);
            Console.WriteLine("Insert job2 scheduled");*/

            //Rebuild
            IJobDetail rebuildJob = JobBuilder.Create<QuartzRebuildJob>()
                   .WithIdentity("Rebuild", "Maintenance")
                   .Build();
            //
            ITrigger rebuildTrigger = TriggerBuilder.Create()
                .WithIdentity("Rebuild_trigger", "Maintenance")
                .WithPriority(9999)
                .StartAt(DateTimeOffset.Now.AddSeconds(30)) //start after 30 seconds
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(5) //Every 5 minutes
                    .RepeatForever())
                .Build();
            // Planification
            await scheduler.ScheduleJob(rebuildJob, rebuildTrigger);
            Console.WriteLine("Rebuild job scheduled");

            await scheduler.Start();

        }
    }
}

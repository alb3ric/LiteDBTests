using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    [DisallowConcurrentExecution]
    internal class QuartzRebuildJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    Console.WriteLine($"Starting scheduled rebuild...");
                    var sw = Stopwatch.StartNew();
                    TestDB.Repository.Database.Rebuild();
                    sw.Stop();
                    Console.WriteLine($"Rebuild finished in {sw.ElapsedMilliseconds / 1000}s...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR REBUILDING : {ex.Message}");
                }
            });
        }
    }
}
 
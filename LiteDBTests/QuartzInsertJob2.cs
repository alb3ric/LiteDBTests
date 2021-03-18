using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    //[DisallowConcurrentExecution]
    internal class QuartzInsertJob2 : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    Console.Write($"Inserting2...");
                    TestDB.Repository.Insert<Entity>(Entity.CreateRandomEntity());
                    Console.Write($" OK2!");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR INSERTING2 : {ex.Message}");
                }
            });
        }
    }
}

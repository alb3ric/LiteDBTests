using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    //[DisallowConcurrentExecution]
    internal class QuartzInsertJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    Console.Write($"Inserting...");
                    TestDB.Repository.Insert<Entity>(Entity.CreateRandomEntity());
                    Console.Write($" OK!");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR INSERTING : {ex.Message}");
                }
            });
        }
    }
}

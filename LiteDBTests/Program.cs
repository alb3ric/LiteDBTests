using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiteDBTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");

            await QuartzManager.RunAsync();
            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}

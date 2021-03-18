using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    public class Entity
    {

        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public static Entity CreateRandomEntity()
        {
            return new Entity()
            {
                Name = RandomString(20),
                FirstName = RandomString(20),
                Age = random.Next(0, 80),
                LongString = RandomString(1000000)
            };
        }

        public string LongString { get; set; }

        private static Random random = new Random();
        public static string RandomString(int length)
        {

            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }


}

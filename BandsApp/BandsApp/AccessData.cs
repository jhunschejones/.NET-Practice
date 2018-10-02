using NewRelic.Api.Agent;
using System;
using System.Linq;

namespace BandsApp
{
    class AccessData
    {
        public void Read()
        {
            using (var db = new BandsContext())
            {
                Console.WriteLine();
                Console.WriteLine("All bands in database:");
                foreach (var band in db.Bands)
                {
                    Console.WriteLine(" - {0}", band.Name);
                }
                // pause
                Console.ReadLine();
            }
        }
    }
}

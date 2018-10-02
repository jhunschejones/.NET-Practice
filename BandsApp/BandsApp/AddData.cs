using NewRelic.Api.Agent;
using System;
using System.Linq;

namespace BandsApp
{
    class AddData
    {
        public void NewBand()
        {
            using (var db = new BandsContext())
            {
                Console.WriteLine();
                Console.WriteLine("Add a band to the database:");
                string newBand = Console.ReadLine();

                if (newBand != "")
                {
                    db.Bands.Add(new Band { Name = newBand });
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);
                }
                // pause
                Console.ReadLine();
            }
        }
    }
}

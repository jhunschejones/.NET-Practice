using NewRelic.Api.Agent;
using System;
using System.Linq;

namespace BandsApp
{
    class DeleteData
    {
        public void DeleteBand()
        {
            using (var db = new BandsContext())
            {
                Console.WriteLine();
                Console.WriteLine("Enter the band's name to delete");
                string userInput = Console.ReadLine();
                var bandToDelete = db.Bands.Where(b => b.Name.ToUpper() == userInput.ToUpper()).FirstOrDefault();
                if (bandToDelete != null)
                {
                    Console.WriteLine("Deleting {0} from the database", bandToDelete.Name);
                    db.Remove(bandToDelete);
                    db.SaveChanges();
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Could not find band: {0}", userInput);
                    Console.ReadLine();
                }
            }
        }
    }
}

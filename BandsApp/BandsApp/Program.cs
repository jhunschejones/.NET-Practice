using System;
using System.Linq;

namespace BandsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BandsContext())
            {
                string loop = "go";
                while (loop != "done")
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. See all bands in the database");
                    Console.WriteLine("2. Add a band to the database");
                    Console.WriteLine("3. Delete a band from the database");
                    Console.WriteLine("4. Exit");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
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
                    else if (choice == 2)
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
                    else if (choice == 3)
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
                    else if (choice == 4)
                    {
                        loop = "done";
                    }
                }
            }
        }
    }
}
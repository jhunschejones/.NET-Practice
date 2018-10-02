using NewRelic.Api.Agent;
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

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        AccessData data = new AccessData();
                        data.Read();
                    }
                    else if (choice == "2")
                    {
                        AddData add = new AddData();
                        add.NewBand();
                    }
                    else if (choice == "3")
                    {
                        DeleteData ex = new DeleteData();
                        ex.DeleteBand();
                    }
                    else if (choice == "4")
                    {
                        loop = "done";
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized user input");
                    }
                }
            }
        }
    }
}
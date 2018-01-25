using ConsoleApp9.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            Region region = new Region()
            {
                RegionDescription = "Olala",
            };

            dbContext.Region.Add(region);
            dbContext.SaveChanges();
            Console.ReadLine();
        }
    }
}

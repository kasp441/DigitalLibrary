using System;
using System.Linq;
using System.Threading;
using HealthScanner;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHealthScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsDown = 0;
            using var context = new HealtchContext();
            while (true)
            {
                try
                {
                    var appliedMigrations = context.Database.GetAppliedMigrations().ToList();
                    Console.WriteLine("Database is up");
                    Console.WriteLine("Number of Applied Migrations: " + appliedMigrations.Count);
                    foreach (var migration in appliedMigrations)
                    {
                        Console.WriteLine(migration);
                    }
                }
                catch (Exception ex)
                {
                    secondsDown++;
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                    Console.WriteLine($"Database has been down for {secondsDown} seconds");
                }
                Thread.Sleep(1000);
            }
        }
    }
}

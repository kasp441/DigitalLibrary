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
                    Console.Clear();
                    Console.WriteLine("Database is up");
                    Console.WriteLine("Number of Applied Migrations: " + appliedMigrations.Count);
                    foreach (var migration in appliedMigrations)
                    {
                        Console.WriteLine(migration);
                    }
                    if (secondsDown > 0)
                    {
                        Console.WriteLine($"Database was down for {secondsDown} seconds");
                        secondsDown = 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    secondsDown++;
                    Console.WriteLine("Error connecting to database: " + ex.Message);
                    Console.WriteLine($"Database has been down for {secondsDown} seconds");
                }
                Thread.Sleep(100);
            }
        }
    }
}

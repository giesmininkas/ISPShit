using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            //ISPContext context = new ISPContext();
            //context.Add(new Manufacturers() {Country = "Japan", Name = "Sony"});
            //context.SaveChanges();
            
            BuildWebHost(args).Run();
            
            
            
            
            
            Console.WriteLine("Hello World!");
        }
        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
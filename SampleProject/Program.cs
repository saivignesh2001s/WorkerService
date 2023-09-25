using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SampleProject.DatabaseContext;
using SampleProject.Model;
using SampleProject.Services;
using System.Text.Json.Serialization;

namespace SampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {



            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                   
                    services.TryAddTransient<IService,Service>();
                    services.AddHostedService<Worker>();
                    

                   




                })
                .Build();

            host.Run();
        }
    }
}
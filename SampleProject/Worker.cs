using Microsoft.Extensions.Options;
using SampleProject.Model;
using SampleProject.Services;
using System.Diagnostics;

namespace SampleProject
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(5);
        private readonly IService _service;
        public Worker(ILogger<Worker> logger,IService service)
        {
            _logger = logger;
            _service = service;
           
        }
        //public override async Task StartAsync(CancellationToken cancellationToken)
        //{
        //    string p = "C:\\Sample\\";
        //    DirectoryInfo directoryInfo = new DirectoryInfo(p);
            
        //    if (directoryInfo.Exists)
        //    {
        //        List<FileInfo> f=new List<FileInfo>();
        //        foreach( var fileInfo in  directoryInfo.GetFiles())
        //        {
        //            if ((DateTime.Now - fileInfo.CreationTime).TotalMinutes>=90)
        //            {
        //                f.Add(fileInfo);
                       
        //            }
        //        }
        //        foreach(var fileInfo in f)
        //        {
        //            string extension=fileInfo.Extension;
        //            File.Delete(fileInfo.FullName);
        //        }

        //        string p1 = DateTime.Today.ToShortDateString() + ".txt";
        //        p1=p1.Replace('/', '-');
                
        //        string p2 = p+p1;
        //            if (File.Exists(p2))
        //            {
        //                File.AppendAllLines(p2, new string[] { "Welcome Again" });
        //            }
        //            else
        //            {
        //                File.AppendAllLines(p2, new string[] { "Welcome" });
        //            }
                
                
        //    }
        //    else
        //    {
        //        directoryInfo.Create();
        //        string p1 = DateTime.Today.ToShortDateString() + ".txt";
        //        p1=p1.Replace('/', '-');
        //        string p2 = p + p1;
        //        File.AppendAllLines(p2, new string[] { "Welcome" });
                
        //    }
            
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_timeout);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                Data ps = new Data()
                {
                    Id=Guid.NewGuid().ToString(),
                    CreatedDate=DateTime.Today.ToShortDateString(),
                    CreatedTime=DateTime.Now.ToLongTimeString(),

                };
                bool k = _service.AddData(ps);
                if (k)
                {
                    _logger.LogInformation("Data Inserted");

                }
                else
                {
                    _logger.LogInformation("Data Not Inserted");


                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    public class AppSettings
    {
        public Logging? Logging { get; set; }
        public ConnectionStrings? ConnectionStrings { get; set; }


    }
    public class Logging
    {
       public LogLevel? LogLevel1 { get; set; }

    }
    public class LogLevel
    {
        public string? Default{ get;set; }
        public string? Lifetime { get;set; }
    }
    
    public class ConnectionStrings
    {
        public string?  ConnString1{ get; set; }    
    }
}

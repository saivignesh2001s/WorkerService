using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model
{
    public class Data
    {
        [Key]
        [Required]
       
        public string Id { get; set; }
        public string? CreatedDate{ get; set; }
        public string? CreatedTime { get; set; }
      
    }
}

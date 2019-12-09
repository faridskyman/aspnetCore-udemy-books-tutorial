using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_web_project_01.Model
{
    public class Config
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        public string cKey { get; set; }
        
        [MaxLength(50)]
        public string cValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_web_project_01.Model
{
    public class Book
    {
        
        [Key] // indicate this is identity column
        public int id { get; set; }
        [Required] // this means name cant be null as its required
        [MaxLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters")]
        public string Author { get; set; }
        [StringLength(20,ErrorMessage = "The {0} value cannot exceed {1} characters")]
        public string ISBN { get; set; }



    }
}

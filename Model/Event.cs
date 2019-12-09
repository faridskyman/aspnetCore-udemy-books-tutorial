using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_web_project_01.Model
{
    public class Event
    {
        [Key]
        public int id { get; set; }

        [MaxLength(30)]
        [Display(Name = "Event")]
        public string evtName { get; set; }

        [MaxLength(120)]
        [Display(Name = "Event description")]
        public string description { get; set; }

        [Display(Name = "Date of event")]
        public DateTime startDate { get; set; }
        
        [Display(Name = "Day 1")]
        public bool day1 { get; set; }

        [Display(Name = "Day 2")]
        public bool day2 { get; set; }

        [Display(Name = "Day 3")]
        public bool day3 { get; set; }

    }
}

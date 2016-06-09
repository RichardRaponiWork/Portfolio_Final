using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class AboutMe
    {
        [Key]
        public int AmoutMeID { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }

    }
}
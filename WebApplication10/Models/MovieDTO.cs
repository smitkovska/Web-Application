using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class MovieDTO
    {
        
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string DownloadURL { get; set; }
        public string ImageURL { get; set; }

        public float Rating { get; set; }
        public string Genre { get; set; }

    }
}
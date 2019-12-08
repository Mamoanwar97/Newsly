using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace news.Models
{
    public class Newsletter
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Img_link { get; set; }
        public DateTime? Date { get; set; }


    }
}
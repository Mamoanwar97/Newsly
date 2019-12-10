using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace news.Models
{
    public class Subscriber
    {
        public int? Id { get; set; }
        [Required]
        public string email { get; set; }
        public Subscriber()
        {
            Id = 0;
        }
    }
}
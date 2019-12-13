using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace newsly.Models
{
    public class Newsletter
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter valid name")]
        [StringLength(255)]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Img_link { get; set; }
        public DateTime? Date { get; set; }
    }
}
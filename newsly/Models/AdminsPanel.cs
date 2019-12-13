using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newsly.Models;

namespace newsly.Models
{
    public class AdminsPanel
    {
        public int Current { get; set; }
        public List<ApplicationUser> Panel { get; set; }
    }
}
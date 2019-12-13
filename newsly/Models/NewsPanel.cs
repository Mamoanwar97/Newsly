using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newsly.Models
{
    public class NewsPanel
    {
        public int Current { get; set; }
        public IEnumerable<Newsletter> News { get; set; }
    }
}
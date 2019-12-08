using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using news.Models;

namespace news.Models
{
    public class newsPage
    {
        public int current { get; set; }
        public IEnumerable<Newsletter> letters  { get; set; }
    }
}
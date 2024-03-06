using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppDevelopment.Models
{    
    public class Movie
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }       
        public string Genre { get; set; }
        public string Plot { get; set; }
        public float Ratings { get; set; }

        public string Watched { get; set; }

    }
}

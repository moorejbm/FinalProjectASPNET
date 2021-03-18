using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Product
    {
        public Product()
        {
        }

            public int driverID { get; set; }
            public string Name { get; set; }
            public string StrokesGained { get; set; }
            public string TotalDistanceRank { get; set; }
            public string ForgivenessRank{ get; set; }
            public int Price { get; set; }
            //public IEnumerable<Category> Categories { get; set; }
            public string Image { get; set; }
            public string URL { get; set; }
    }

    }       


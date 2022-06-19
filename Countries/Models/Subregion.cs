using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Models
{
    public class Subregion
    {
        public string SubregionName { get; set; }
        public int TotalPopulation { get; set; }
        public Region Region { get; set; }
        public IEnumerable<Country> Countries { get; set; }

    }
}

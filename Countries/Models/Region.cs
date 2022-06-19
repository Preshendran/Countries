using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTCountries.Models;

namespace Countries.Models
{
    public class Region
    {
        public string RegionName {get; set;}
        public int TotalPopulation { get; set; }
        public IEnumerable<Country> CountriesInRegion { get; set; }
        public IEnumerable<Subregion> Subregions { get; set; }

    }
}

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
        public IEnumerable<RESTCountries.Models.Country> CountriesInRegion { get; set; }
        public IEnumerable<string> Subregions { get; set; }

    }
}

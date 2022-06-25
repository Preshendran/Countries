using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Countries.Models;

namespace Countries.Interfaces
{
    public interface ICountry
    {
        Task<IEnumerable<RESTCountries.Models.Country>> GetAllCountriesAsync();

        Task<RESTCountries.Models.Country> GetCountryAync(string countryCode);

        Task<Region> GetRegionAsync(string regionName);

        Task<Subregion> GetSubregionAsync(string subregionName);


    }
}

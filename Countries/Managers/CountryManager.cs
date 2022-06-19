using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countries.Interfaces;
using Countries.Models;
using RESTCountries.Services;
namespace Countries.Managers
{
    public class CountryManager : ICountry
    {
        public async Task<IEnumerable<RESTCountries.Models.Country>> GetAllCountriesAsync()
        {
            List<RESTCountries.Models.Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
            return countries;
        }

        public Task<Country> GetCountryAync(string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetRegionAsync(string regionName)
        {
            throw new NotImplementedException();
        }

        public Task<Subregion> GetSubregionAsync(string subregionName)
        {
            throw new NotImplementedException();
        }
    }
}

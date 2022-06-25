using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countries.Helpers;
using Countries.Interfaces;
using Countries.Models;
using Microsoft.Extensions.Caching.Memory;
using RESTCountries.Services;
namespace Countries.Managers
{
    public class CountryManager : ICountry
    {
        private readonly IMemoryCache _memoryCache;


        public CountryManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<RESTCountries.Models.Country>> GetAllCountriesAsync()
        {
            var cacheKey = CacheHelper.GetCacheKey("Countires");
            if (!_memoryCache.TryGetValue(cacheKey, out List<RESTCountries.Models.Country> countries))
            {
                countries = await RESTCountriesAPI.GetAllCountriesAsync();
                _memoryCache.Set(cacheKey, countries, CacheEntryOptions());
            }

            return countries;
        }

        public async Task<RESTCountries.Models.Country> GetCountryAync(string countryCode)
        {
            var cacheKey = CacheHelper.GetCacheKey("Country", countryCode);
            if (!_memoryCache.TryGetValue(cacheKey, out RESTCountries.Models.Country country))
            {
                country = await RESTCountriesAPI.GetCountryByCodeAsync(countryCode);
                _memoryCache.Set(cacheKey, country, CacheEntryOptions());
            }

            return country;
        }

        public async Task<Region> GetRegionAsync(string regionName)
        {
            var countries = await GetAllCountriesAsync();
            
            var region = countries.Where(x => x.Region == regionName);
            var totalRegionPopulation = region.Sum(x => x.Population);
            
            IEnumerable<RESTCountries.Models.Country> countriesinRegion = new List<RESTCountries.Models.Country>();
            countriesinRegion = countries.Where(x => x.Region == regionName).ToList();
            
            IEnumerable<Subregion> subregions = new List<Subregion>();
            subregions = (IEnumerable<Subregion>)region.Select(x => x.Subregion).ToList();


            var newRegion = new Region
            {
                RegionName = region.Select(x => x.Region).ToString(),
                TotalPopulation = totalRegionPopulation,
                CountriesInRegion = (IEnumerable<Country>)countriesinRegion,
                Subregions = subregions
            };

            return newRegion;
        }

        public Task<Subregion> GetSubregionAsync(string subregionName)
        {
            throw new NotImplementedException();
        }

        public MemoryCacheEntryOptions CacheEntryOptions()
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
        }

    }
}

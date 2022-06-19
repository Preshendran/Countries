using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTCountries.Services;
using Countries.Interfaces;

namespace Countries.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountry _countryManager;

        public CountryController(ICountry country)
        {
            _countryManager = country;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _countryManager.GetAllCountriesAsync();
            return View(countries);
        }
    }
}

using Countries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Controllers
{
    public class RegionController : Controller
    {
        private readonly ICountry _countryManager;

        public RegionController(ICountry countryManager)
        {
            _countryManager = countryManager;
        }

        [Route("Region/{regionName}")]
        public async Task<IActionResult> Index(string regionName)
        {
            var region = await _countryManager.GetRegionAsync(regionName);
            return View(region);
        }
    }
}

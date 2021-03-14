using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Controllers;
using AbpCompanyName.AbpProjectName.Locations;
using AbpCompanyName.AbpProjectName.Locations.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Countries)]
    public class CountriesController : AbpProjectNameControllerBase
    {
        private readonly CountriesAppService countriesAppService;

        public CountriesController(CountriesAppService countriesAppService)
        {
            this.countriesAppService = countriesAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int countryId)
        {
            var output = await countriesAppService.GetAsync(new EntityDto(countryId));
            var model = ObjectMapper.Map<CountryDto>(output);
            return PartialView("_EditModal", model);
        }

    }
}

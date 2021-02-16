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
    [AbpMvcAuthorize(PermissionNames.Pages_Cities)]
    public class CitiesController : AbpProjectNameControllerBase
    {
        private readonly CitiesAppService citiesAppService;

        public CitiesController(CitiesAppService citiesAppService)
        {
            this.citiesAppService = citiesAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int cityId)
        {
            var output = await citiesAppService.GetAsync(new EntityDto(cityId));
            var model = ObjectMapper.Map<CityDto>(output);
            return PartialView("_EditModal", model);
        }

    }
}

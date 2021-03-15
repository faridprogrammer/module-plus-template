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
    [AbpMvcAuthorize(PermissionNames.Pages_StateProvinces)]
    public class StateProvincesController : AbpProjectNameControllerBase
    {
        private readonly StateProvincesAppService stateProvincesAppService;

        public StateProvincesController(StateProvincesAppService stateProvincesAppService)
        {
            this.stateProvincesAppService = stateProvincesAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int stateProvinceId)
        {
            var output = await stateProvincesAppService.GetAsync(new EntityDto(stateProvinceId));
            var model = ObjectMapper.Map<StateProvinceDto>(output);
            return PartialView("_EditModal", model);
        }

    }
}

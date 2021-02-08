using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Cities)]
    public class CitiesController : AbpProjectNameControllerBase
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

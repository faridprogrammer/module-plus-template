using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Controllers;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Logs)]
    public class LogsController : AbpProjectNameControllerBase
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Controllers;
using AbpCompanyName.AbpProjectName.Faqs;
using AbpCompanyName.AbpProjectName.Faqs.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Faqs)]
    public class FaqsController : AbpProjectNameControllerBase
    {
        private readonly FaqsAppService faqsAppService;

        public FaqsController(FaqsAppService faqsAppService)
        {
            this.faqsAppService = faqsAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int faqId)
        {
            var output = await faqsAppService.GetAsync(new EntityDto(faqId));
            var model = ObjectMapper.Map<FaqDto>(output);
            return PartialView("_EditModal", model);
        }

    }
}

using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Controllers;
using AbpCompanyName.AbpProjectName.Ticketing;
using AbpCompanyName.AbpProjectName.Ticketing.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AbpCompanyName.AbpProjectName.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tickets)]
    public class TicketsController : AbpProjectNameControllerBase
    {
        private readonly TicketsAppService _ticketsAppService;

        public TicketsController(TicketsAppService ticketsAppService)
        {
            this._ticketsAppService = ticketsAppService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int ticketId)
        {
            var output = await _ticketsAppService.GetAsync(new EntityDto(ticketId));
            var model = ObjectMapper.Map<TicketDto>(output);
            return PartialView("_EditModal", model);
        }

    }
}

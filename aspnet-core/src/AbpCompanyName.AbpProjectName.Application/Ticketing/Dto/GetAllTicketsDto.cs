using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Ticketing.Dto
{
    public class GetAllTicketsDto : PagedAndSortedResultRequestDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public TicketState? State { get; set; }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Ticketing.Dto
{
    public class GetAllTickeRepliesDto : PagedAndSortedResultRequestDto
    {
        public int? TicketId { get; set; }
    }
}

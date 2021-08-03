using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AbpCompanyName.AbpProjectName.Ticketing.Dto
{
    [AutoMap(typeof(Ticket))]
    public class TicketDto : FullAuditedEntityDto
    {
        [Required]
        [MaxLength(1000)]
        public string Title { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }
        public TicketState State { get; set; }
        public string Creator { get; set; }
        public string StateTitle => State.ToString();
    }
}

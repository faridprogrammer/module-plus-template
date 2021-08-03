using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Ticketing.Dto
{
    [AutoMap(typeof(TicketReply))]
    public class TicketReplyDto : FullAuditedEntityDto
    {
        [Required]
        public int TickedId { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }
    }
}

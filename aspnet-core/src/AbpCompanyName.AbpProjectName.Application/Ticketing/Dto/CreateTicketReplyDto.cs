using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Ticketing.Dto
{
    [AutoMap(typeof(TicketReply))]
    public class CreateTicketReplyDto : FullAuditedEntityDto
    {
        [Required]
        public int TickedId { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }

        public bool? MarkAsResolved { get; set; }
    }
}

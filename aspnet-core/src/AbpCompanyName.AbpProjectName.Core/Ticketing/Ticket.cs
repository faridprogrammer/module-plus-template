using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpCompanyName.AbpProjectName.Ticketing
{
    [Table("MpTickets")]
    public class Ticket : FullAuditedEntity
    {
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public TicketState State { get; set; }
    }
}

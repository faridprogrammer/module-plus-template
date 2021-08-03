using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbpCompanyName.AbpProjectName.Ticketing
{
    [Table("MpTicketReplies")]
    public class TicketReply : FullAuditedEntity
    {
        public int TickedId { get; set; }
        public string Body { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace AbpCompanyName.AbpProjectName.Faqs
{
    [Table("MpFaqs")]
    public class Faq : FullAuditedEntity
    {
        [Required]
        [MaxLength(1000)]
        public string Question
        {
            get;
            set;
        }

        [Required]
        [MaxLength(4000)]
        public string Answer
        {
            get;
            set;
        }

        public int SortOrder
        {
            get;
            set;
        }
    }
}

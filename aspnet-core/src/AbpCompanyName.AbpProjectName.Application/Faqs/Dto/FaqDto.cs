using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Faqs.Dto
{
    [AutoMap(typeof(Faq))]
    public class FaqDto : FullAuditedEntityDto
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

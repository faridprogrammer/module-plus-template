using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Faqs.Dto
{
    public class GetAllFaqsDto : PagedAndSortedResultRequestDto
    {
        public string Question { get; set; }
    }
}

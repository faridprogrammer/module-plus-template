using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Logs.Dto
{
    public class GetAllLogsDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public string Level
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}

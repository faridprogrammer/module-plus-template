using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Locations.Dto
{

    public class GetAllStateProvincesDto : PagedAndSortedResultRequestDto
    {
        public string Name
        {
            get;
            set;
        }

        public int? CountryId
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Locations.Dto
{
    public class GetAllCitiesDto : PagedAndSortedResultRequestDto
    {
        public string Name
        {
            get;
            set;
        }

        public int? StateProvinceId
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

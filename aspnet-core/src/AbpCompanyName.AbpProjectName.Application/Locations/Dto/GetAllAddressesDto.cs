using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Locations.Dto
{
    public class GetAllAddressesDto: PagedAndSortedResultRequestDto
    {
        public int? CityId
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

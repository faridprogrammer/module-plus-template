using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class CitiesAppService : AsyncCrudAppService<City, CityDto, int, GetAllCitiesDto>
    {
        public CitiesAppService(IRepository<City, int> repository) : base(repository)
        {
        }

        protected override IQueryable<City> CreateFilteredQuery(GetAllCitiesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.CountryId != null, city => city.CountryId == input.CountryId)
                    .WhereIf(input.StateProvinceId != null, city => city.StateProvinceId == input.StateProvinceId)
                    .WhereIf(!input.Name.IsNullOrEmpty(), city => city.Name.Contains(input.Name))

                ;
        }
    }
}

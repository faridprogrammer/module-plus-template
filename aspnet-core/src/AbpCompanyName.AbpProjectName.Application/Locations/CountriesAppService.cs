using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class CountriesAppService : AsyncCrudAppService<Country, CountryDto, int, GetAllCountriesDto>
    {
        public CountriesAppService(IRepository<Country, int> repository) : base(repository)
        {
            GetAllPermissionName = PermissionNames.Pages_Countries;
            CreatePermissionName = PermissionNames.Pages_Countries_Create;
            UpdatePermissionName = PermissionNames.Pages_Countries_Edit;
            DeletePermissionName = PermissionNames.Pages_Countries_Delete;
        }

        protected override IQueryable<Country> CreateFilteredQuery(GetAllCountriesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(!input.Name.IsNullOrEmpty(), country => country.Name.Contains(input.Name))
                ;
        }
    }
}

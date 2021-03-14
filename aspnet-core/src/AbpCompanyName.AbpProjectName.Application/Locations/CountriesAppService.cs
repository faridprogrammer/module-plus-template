using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class CountriesAppService : AsyncCrudAppService<Country, CountryDto, int, GetAllCountriesDto>
    {
        private readonly IRepository<City> cityRepo;
        private readonly IRepository<StateProvince> provinceRepo;

        public CountriesAppService(IRepository<City> cityRepo, IRepository<StateProvince> provinceRepo, IRepository<Country, int> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            GetAllPermissionName = PermissionNames.Pages_Countries;
            CreatePermissionName = PermissionNames.Pages_Countries_Create;
            UpdatePermissionName = PermissionNames.Pages_Countries_Edit;
            DeletePermissionName = PermissionNames.Pages_Countries_Delete;
            this.cityRepo = cityRepo;
            this.provinceRepo = provinceRepo;
            
        }

        protected override IQueryable<Country> CreateFilteredQuery(GetAllCountriesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(!input.Name.IsNullOrEmpty(), country => country.Name.Contains(input.Name));
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            if (await cityRepo.CountAsync(ff => ff.CountryId == input.Id) > 0 
                || await provinceRepo.CountAsync(ff => ff.CountryId == input.Id) > 0)

                throw new UserFriendlyException(L("CountryIsInUse"));

            await base.DeleteAsync(input);
        }
    }
}

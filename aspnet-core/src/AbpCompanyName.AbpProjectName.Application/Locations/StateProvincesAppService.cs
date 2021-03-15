using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Locations.Dto;
using Microsoft.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class StateProvincesAppService : AsyncCrudAppService<StateProvince, StateProvinceDto, int, GetAllStateProvincesDto>
    {
        private readonly IRepository<City> cityRepo;

        public StateProvincesAppService(IRepository<City> cityRepo, IRepository<StateProvince, int> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            GetAllPermissionName = PermissionNames.Pages_StateProvinces;
            CreatePermissionName = PermissionNames.Pages_StateProvinces_Create;
            UpdatePermissionName = PermissionNames.Pages_StateProvinces_Edit;
            DeletePermissionName = PermissionNames.Pages_StateProvinces_Delete;
            this.cityRepo = cityRepo;
        }

        protected override IQueryable<StateProvince> CreateFilteredQuery(GetAllStateProvincesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .Include(city => city.Country)

                    .WhereIf(input.CountryId != null, province => province.CountryId == input.CountryId)
                    .WhereIf(!input.Name.IsNullOrEmpty(), province => province.Name.Contains(input.Name))
                ;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            if (await cityRepo.CountAsync(ff => ff.CountryId == input.Id) > 0)
                throw new UserFriendlyException(L("StateProvinceIsInUse"));

            await base.DeleteAsync(input);
        }
    }
}

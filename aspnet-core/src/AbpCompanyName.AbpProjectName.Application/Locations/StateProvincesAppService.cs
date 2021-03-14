using System.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    public class StateProvincesAppService : AsyncCrudAppService<StateProvince, StateProvinceDto, int, GetAllStateProvincesDto>
    {
        public StateProvincesAppService(IRepository<StateProvince, int> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            GetAllPermissionName = PermissionNames.Pages_StateProvinces;
            CreatePermissionName = PermissionNames.Pages_StateProvinces_Create;
            UpdatePermissionName = PermissionNames.Pages_StateProvinces_Edit;
            DeletePermissionName = PermissionNames.Pages_StateProvinces_Delete;
        }

        protected override IQueryable<StateProvince> CreateFilteredQuery(GetAllStateProvincesDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.CountryId != null, province => province.CountryId == input.CountryId)
                    .WhereIf(!input.Name.IsNullOrEmpty(), province => province.Name.Contains(input.Name))
                ;
        }
    }
}

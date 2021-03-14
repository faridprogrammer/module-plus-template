using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.AuditLogs.Dto;
using AbpCompanyName.AbpProjectName.Authorization;

namespace AbpCompanyName.AbpProjectName.AuditLogs
{
    [AbpAuthorize]
    public class AuditLogsAppService : AsyncCrudAppService<AuditLog, AuditLogDto, long, GetAllAuditLogsDto>
    {
        public AuditLogsAppService(IRepository<AuditLog, long> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            GetAllPermissionName = PermissionNames.Pages_AuditLogs;
        }

        protected override IQueryable<AuditLog> CreateFilteredQuery(GetAllAuditLogsDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.TenantId != null, log => log.TenantId == input.TenantId.Value)
                .WhereIf(input.UserId != null, log => log.UserId == input.UserId.Value)
                .WhereIf(!input.ClientIpAddress.IsNullOrEmpty(), log => log.ClientIpAddress == input.ClientIpAddress)
                .WhereIf(!input.MethodName.IsNullOrEmpty(), log => log.MethodName.ToLower().Contains(input.MethodName))
                .WhereIf(!input.ServiceName.IsNullOrEmpty(), log => log.ServiceName.ToLower().Contains(input.ServiceName))
                .OrderByDescending(log => log.Id);
        }

        public override Task<AuditLogDto> CreateAsync(AuditLogDto input)
        {
            throw new NotSupportedException();
        }

        public override Task<AuditLogDto> UpdateAsync(AuditLogDto input)
        {
            throw new NotSupportedException();
        }

        public override Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotSupportedException();
        }
    }
}

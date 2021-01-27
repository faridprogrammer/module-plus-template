using System;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.AuditLogs.Dto
{
    [AutoMap(typeof(AuditLog))]
    public class AuditLogDto : EntityDto<long>
    {
        public virtual int? TenantId { get; set; }

        public virtual long? UserId { get; set; }

        public virtual string ServiceName { get; set; }

        public virtual string MethodName { get; set; }

        public virtual string Parameters { get; set; }

        public virtual string ReturnValue { get; set; }

        public virtual DateTime ExecutionTime { get; set; }

        public virtual int ExecutionDuration { get; set; }

        public virtual string ClientIpAddress { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string BrowserInfo { get; set; }

        public virtual string Exception { get; set; }

        public virtual long? ImpersonatorUserId { get; set; }

        public virtual int? ImpersonatorTenantId { get; set; }

        public virtual string CustomData { get; set; }

    }
}

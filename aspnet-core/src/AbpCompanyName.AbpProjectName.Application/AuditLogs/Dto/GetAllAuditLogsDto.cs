using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.AuditLogs.Dto
{
    public class GetAllAuditLogsDto : PagedAndSortedResultRequestDto
    {
        public string ServiceName
        {
            get;
            set;
        }

        public string MethodName
        {
            get;
            set;
        }

        public string ClientIpAddress
        {
            get;
            set;
        }

        public long? UserId
        {
            get;
            set;
        }

        public long? TenantId
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Accounting.Dto
{
    public class GetAllTransactionsDto : PagedAndSortedResultRequestDto
    {
        public long? OwnerId
        {
            get;
            set;
        }

        public string ReferenceEntityId
        {
            get;
            set;
        }

        public TransactionReason? Reason
        {
            get;
            set;
        }
    }
}

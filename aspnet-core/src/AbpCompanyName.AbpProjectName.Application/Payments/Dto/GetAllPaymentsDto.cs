using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Payments.Dto
{
    public class GetAllPaymentsDto: PagedAndSortedResultRequestDto
    {
        public long? OwnerId
        {
            get;
            set;
        }

        public PaymentType? PaymentType
        {
            get;
            set;
        }

        public DateTime? FromDate
        {
            get;
            set;
        }
        public DateTime? ToDate
        {
            get;
            set;
        }
    }
}

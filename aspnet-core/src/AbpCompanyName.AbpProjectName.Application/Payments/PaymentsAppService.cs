using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Payments.Dto;

namespace AbpCompanyName.AbpProjectName.Payments
{
    public class PaymentsAppService : AsyncCrudAppService<Payment, PaymentDto, Guid, GetAllPaymentsDto>
    {
        public PaymentsAppService(IRepository<Payment, Guid> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
        }

        protected override IQueryable<Payment> CreateFilteredQuery(GetAllPaymentsDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.OwnerId != null, payment => payment.OwnerId == input.OwnerId)
                    .WhereIf(input.PaymentType != null, payment => payment.Type == input.PaymentType)
                    .WhereIf(input.FromDate != null, payment => payment.Date >= input.FromDate)
                    .WhereIf(input.ToDate != null, payment => payment.Date <= input.ToDate)
                ;
        }
    }
}

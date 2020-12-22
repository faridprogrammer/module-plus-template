using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Invoices.Dto;
using AbpCompanyName.AbpProjectName.Payments.Dto;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Payments
{
    public class PaymentsAppService : AsyncCrudAppService<Payment, PaymentDto, Guid, GetAllPaymentsDto>
    {
        public PaymentsAppService(IRepository<Payment, Guid> repository) : base(repository)
        {
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

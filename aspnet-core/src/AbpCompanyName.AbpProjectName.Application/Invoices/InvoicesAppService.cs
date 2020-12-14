using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Invoices.Dto;

namespace AbpCompanyName.AbpProjectName.Invoices
{
    [AbpAuthorize]
    public class InvoicesAppService : AsyncCrudAppService<Invoice, InvoiceDto, int, GetAllInvoiceDto>
    {
        public InvoicesAppService(IRepository<Invoice, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Invoice> CreateFilteredQuery(GetAllInvoiceDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.CustomerId != null, ff => ff.CustomerId == input.CustomerId)
                    .WhereIf(!input.Number.IsNullOrEmpty(), ff => ff.Number.Contains(input.Number))
                    .WhereIf(input.DueDate != null, ff => ff.DueDate == input.DueDate)
                ;
        }
    }
}

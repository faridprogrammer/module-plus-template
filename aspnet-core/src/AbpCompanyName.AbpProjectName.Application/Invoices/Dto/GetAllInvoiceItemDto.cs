using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Invoices.Dto
{
    public class GetAllInvoiceItemDto: PagedAndSortedResultRequestDto
    {
        public Guid? InvoiceId { get; set; }
    }
}

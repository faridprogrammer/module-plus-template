using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Invoices.Dto
{
    public class GetAllInvoiceDto : PagedAndSortedResultRequestDto
    {
        public DateTime? DueDate { get; set; }
        public string Number { get; set; }
        public long? CustomerId { get; set; }
    }
}

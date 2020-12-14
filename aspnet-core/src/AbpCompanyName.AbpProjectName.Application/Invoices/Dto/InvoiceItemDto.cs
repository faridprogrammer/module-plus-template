using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Invoices.Dto
{
    [AutoMap(typeof(InvoiceItem))]
    public class InvoiceItemDto : EntityDto<Guid>
    {
        public Guid InvoiceId
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        [MaxLength(500)]
        public string Description
        {
            get;
            set;
        }
    }
}

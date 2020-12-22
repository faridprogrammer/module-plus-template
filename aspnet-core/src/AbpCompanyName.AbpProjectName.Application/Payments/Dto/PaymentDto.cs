using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Invoices.Dto;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Payments.Dto
{
    public class PaymentDto: EntityDto<Guid>
    {
        public PaymentType Type
        {
            get;
            set;
        }

        public PaymentState State
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public long CustomerId
        {
            get; 
            set;
        }
        
        public UserDto Customer
        {
            get;
            set;
        }

        public Guid ReferenceId
        {
            get;
            set;
        }

        public Guid? InvoiceId
        {
            get;
            set;
        }

        public InvoiceDto Invoice
        {
            get;
            set;
        }
    }
}

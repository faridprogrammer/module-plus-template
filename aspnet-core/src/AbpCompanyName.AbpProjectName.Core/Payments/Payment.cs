using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Invoices;

namespace AbpCompanyName.AbpProjectName.Payments
{
    [Table("MpPayments")]
    public class Payment : Entity<Guid>
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

        public long OwnerId
        {
            get; 
            set;
        }
        
        public User Owner
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

        public Invoice Invoice
        {
            get;
            set;
        }
    }
}

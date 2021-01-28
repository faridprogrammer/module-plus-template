using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Values;

namespace AbpCompanyName.AbpProjectName.Invoices
{
    [Table("MpInvoiceItems")]
    public class InvoiceItem : Entity<Guid>
    {
        public Guid InvoiceId
        {
            get;
            set;
        }

        public Invoice Invoice
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

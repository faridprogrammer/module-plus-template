using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using AbpCompanyName.AbpProjectName.Authorization.Users;

namespace AbpCompanyName.AbpProjectName.Accounting
{
    [Table("MpTransactions")]
    public class Transaction : FullAuditedEntity
    {
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

        public decimal CreditAmount
        {
            get;
            set;
        }

        public decimal DebitAmount
        {
            get;
            set;
        }

        public TransactionReason Reason
        {
            get;
            set;
        }

        [MaxLength(200)]
        public string Description
        {
            get;
            set;
        }

        public string ReferenceEntityId
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Accounting.Dto
{
    public class TransactionDto : FullAuditedEntityDto
    {
        public long OwnerId
        {
            get;
            set;
        }

        public UserDto Owner
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

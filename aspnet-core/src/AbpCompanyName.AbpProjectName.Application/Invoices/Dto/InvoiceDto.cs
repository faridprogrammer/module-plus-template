using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCompanyName.AbpProjectName.Addresses;
using AbpCompanyName.AbpProjectName.Locations;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Invoices.Dto
{
    [AutoMap(typeof(Invoice))]
    public class InvoiceDto : EntityDto
    {
        public string Number
        {
            get;
            set;
        }
        public DateTime DueDate
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

        public int? AddressId
        {
            get;
            set;
        }

        public AddressDto Address
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}

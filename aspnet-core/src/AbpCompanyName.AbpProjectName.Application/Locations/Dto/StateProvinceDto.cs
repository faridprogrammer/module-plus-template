using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Locations.Dto
{
    [AutoMap(typeof(StateProvince))]
    public class StateProvinceDto: EntityDto
    {
        [MaxLength(50)]
        public string Name
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string PhoneCode
        {
            get;
            set;
        }

        public int? CountryId
        {
            get;
            set;
        }

        public CountryDto Country
        {
            get;
            set;
        }
    }
}

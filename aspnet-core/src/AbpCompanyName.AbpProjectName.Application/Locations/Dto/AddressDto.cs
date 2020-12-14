using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpCompanyName.AbpProjectName.Addresses;
using AbpCompanyName.AbpProjectName.Locations.Dto;

namespace AbpCompanyName.AbpProjectName.Locations
{
    [AutoMap(typeof(Address))]
    public class AddressDto : EntityDto
    {
        public int? CityId
        {
            get;
            set;
        }

        public CityDto City
        {
            get;
            set;
        }

        public string StateProvince
        {
            get;
            set;
        }

        public int? CountryId
        {
            get;
            set;
        }

        public Country Country
        {
            get;
            set;
        }
        [MaxLength(100)]
        public string AddressLine1
        {
            get;
            set;
        }

        [MaxLength(100)]
        public string AddressLine2
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string PostalZipCode
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string Phone1
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string Phone2
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string Phone3
        {
            get;
            set;
        }

        public long? Latitude
        {
            get;
            set;
        }

        public long? Longitude
        {
            get;
            set;
        }
    }
}

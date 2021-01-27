using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Logs.Dto
{
    [AutoMap(typeof(Log))]
    public class LogDto : EntityDto
    {
        public DateTime Date
        {
            get;
            set;
        }
        [MaxLength(255)]
        public string Thread
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string Level
        {
            get;
            set;
        }

        [MaxLength(255)]
        public string Logger
        {
            get;
            set;
        }

        [MaxLength(4000)]
        public string Message
        {
            get;
            set;
        }

        [MaxLength(2000)]
        public string Exception
        {
            get;
            set;
        }
    }
}

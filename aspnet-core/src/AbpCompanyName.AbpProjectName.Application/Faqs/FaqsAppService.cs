using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Faqs.Dto;

namespace AbpCompanyName.AbpProjectName.Faqs
{

    public class FaqsAppService : AsyncCrudAppService<Faq, FaqDto>
    {
        public FaqsAppService(IRepository<Faq> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_Faqs_Create;
            UpdatePermissionName = PermissionNames.Pages_Faqs_Update;
            DeletePermissionName = PermissionNames.Pages_Faqs_Delete;
        }

        protected override IQueryable<Faq> ApplySorting(IQueryable<Faq> query, PagedAndSortedResultRequestDto input)
        {
            return base.ApplySorting(query, input).OrderBy(faq => faq.SortOrder).ThenBy(faq => faq.CreationTime);
        }
    }
}

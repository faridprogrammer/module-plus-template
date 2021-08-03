using System.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.Faqs.Dto;

namespace AbpCompanyName.AbpProjectName.Faqs
{
    public class FaqsAppService : AsyncCrudAppService<Faq, FaqDto, int, GetAllFaqsDto>
    {
        public FaqsAppService(IRepository<Faq> repository) : base(repository)
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
            CreatePermissionName = PermissionNames.Pages_Faqs_Create;
            UpdatePermissionName = PermissionNames.Pages_Faqs_Update;
            DeletePermissionName = PermissionNames.Pages_Faqs_Delete;
        }

        protected override IQueryable<Faq> ApplySorting(IQueryable<Faq> query, GetAllFaqsDto input)
        {
            return base.ApplySorting(query, input).OrderBy(faq => faq.SortOrder).ThenBy(faq => faq.CreationTime);
        }

        protected override IQueryable<Faq> CreateFilteredQuery(GetAllFaqsDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(!string.IsNullOrEmpty(input.Question), ff => ff.Question.Contains(input.Question));
        }
    }
}

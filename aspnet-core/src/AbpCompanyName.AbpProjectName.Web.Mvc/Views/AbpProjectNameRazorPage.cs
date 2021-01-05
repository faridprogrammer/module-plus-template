﻿using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AbpCompanyName.AbpProjectName.Web.Views
{
    public abstract class AbpProjectNameRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpProjectNameRazorPage()
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
        }
    }
}

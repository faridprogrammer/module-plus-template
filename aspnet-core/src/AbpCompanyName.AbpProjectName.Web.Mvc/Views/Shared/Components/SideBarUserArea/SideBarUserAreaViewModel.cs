﻿using AbpCompanyName.AbpProjectName.Sessions.Dto;

namespace AbpCompanyName.AbpProjectName.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            var userName = LoginInformations.User.UserName;

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.Tenant == null
                ? ".\\" + userName
                : LoginInformations.Tenant.TenancyName + "\\" + userName;
        }
    }
}

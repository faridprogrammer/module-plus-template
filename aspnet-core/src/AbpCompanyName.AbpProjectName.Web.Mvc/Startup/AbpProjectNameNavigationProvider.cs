using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using AbpCompanyName.AbpProjectName.Authorization;

namespace AbpCompanyName.AbpProjectName.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class AbpProjectNameNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true,
                        order: 1
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants),
                        order: 2
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users),
                        order: 3
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles),
                        order: 4
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Logs,
                        L("Logs"),
                        url: "Logs",
                        icon: "fas fa-history",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Logs),
                        order: 5
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.AuditLogs,
                        L("AuditLogs"),
                        url: "AuditLogs",
                        icon: "fas fa-history",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_AuditLogs),
                        order: 6
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Countries,
                        L("Countries"),
                        url: "Countries",
                        icon: "fas fa-globe",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Countries),
                        order: 7
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.StateProvinces,
                        L("StateProvinces"),
                        url: "StateProvinces",
                        icon: "fas fa-globe",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_StateProvinces),
                        order: 8
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Cities,
                        L("Cities"),
                        url: "Cities",
                        icon: "fas fa-globe",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Cities),
                        order: 9
                    ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpProjectNameConsts.LocalizationSourceName);
        }
    }
}

using System.Collections.Generic;
using Abp.Configuration;

namespace AbpCompanyName.AbpProjectName.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.DocumentsMaxSizeMb, "1", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.DocumentsRootPath, "c:\\", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true)
            };
        }
    }
}

using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.Authorization
{
    public class AbpProjectNameAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_TenantSettings, L("TenantSettings"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_Countries, L("Countries"));
            context.CreatePermission(PermissionNames.Pages_Countries_Create, L("CreateCountries"));
            context.CreatePermission(PermissionNames.Pages_Countries_Edit, L("EditCountries"));
            context.CreatePermission(PermissionNames.Pages_Countries_Delete, L("DeleteCountries"));
            
            context.CreatePermission(PermissionNames.Pages_StateProvinces, L("StateProvinces"));
            context.CreatePermission(PermissionNames.Pages_StateProvinces_Create, L("CreateStateProvinces"));
            context.CreatePermission(PermissionNames.Pages_StateProvinces_Edit, L("EditStateProvinces"));
            context.CreatePermission(PermissionNames.Pages_StateProvinces_Delete, L("DeleteStateProvinces"));
            
            context.CreatePermission(PermissionNames.Pages_Cities, L("Cities"));
            context.CreatePermission(PermissionNames.Pages_Cities_Create, L("CreateCities"));
            context.CreatePermission(PermissionNames.Pages_Cities_Edit, L("EditCities"));
            context.CreatePermission(PermissionNames.Pages_Cities_Delete, L("DeleteCities"));
            
            context.CreatePermission(PermissionNames.Pages_Addresses, L("Addresses"));
            context.CreatePermission(PermissionNames.Pages_Addresses_Create, L("CreateAddresses"));
            context.CreatePermission(PermissionNames.Pages_Addresses_Edit, L("EditAddresses"));
            context.CreatePermission(PermissionNames.Pages_Addresses_Delete, L("DeleteAddresses"));

            context.CreatePermission(PermissionNames.Pages_Invoices, L("Invoices"));
            context.CreatePermission(PermissionNames.Pages_Invoices_Create, L("CreateInvoices"));
            context.CreatePermission(PermissionNames.Pages_Invoices_Edit, L("EditInvoices"));
            context.CreatePermission(PermissionNames.Pages_Invoices_Delete, L("DeleteInvoices"));
            
            context.CreatePermission(PermissionNames.Pages_Payments, L("Payments"));
            context.CreatePermission(PermissionNames.Pages_Payments_Create, L("CreatePayments"));
            context.CreatePermission(PermissionNames.Pages_Payments_Edit, L("EditPayments"));
            context.CreatePermission(PermissionNames.Pages_Payments_Delete, L("DeletePayments"));
            
            context.CreatePermission(PermissionNames.Pages_Transactions, L("Transactions"));
            context.CreatePermission(PermissionNames.Pages_Transactions_Create, L("CreateTransactions"));
            context.CreatePermission(PermissionNames.Pages_Transactions_Edit, L("EditTransactions"));
            context.CreatePermission(PermissionNames.Pages_Transactions_Delete, L("DeleteTransactions"));

            context.CreatePermission(PermissionNames.Pages_Faqs, L("Faqs"));
            context.CreatePermission(PermissionNames.Pages_Faqs_Create, L("CreateFaqs"));
            context.CreatePermission(PermissionNames.Pages_Faqs_Update, L("EditFaqs"));
            context.CreatePermission(PermissionNames.Pages_Faqs_Delete, L("DeleteFaqs"));
            
            context.CreatePermission(PermissionNames.Pages_Tickets, L("Tickets"));
            context.CreatePermission(PermissionNames.Pages_Tickets_Create, L("CreateTickets"));
            context.CreatePermission(PermissionNames.Pages_Tickets_Update, L("EditTickets"));
            context.CreatePermission(PermissionNames.Pages_Tickets_Delete, L("DeleteTickets"));

            context.CreatePermission(PermissionNames.Pages_Logs, L("Logs"));
            context.CreatePermission(PermissionNames.Pages_AuditLogs, L("AuditLogs"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpProjectNameConsts.LocalizationSourceName);
        }
    }
}

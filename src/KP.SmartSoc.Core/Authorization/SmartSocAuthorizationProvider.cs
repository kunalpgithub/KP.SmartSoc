using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace KP.SmartSoc.Authorization
{
    public class SmartSocAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            var TenantPermission = context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            TenantPermission.CreateChildPermission(PermissionNames.Pages_View_Tenant, L("View Tenant"), multiTenancySides: MultiTenancySides.Tenant);
            TenantPermission.CreateChildPermission(PermissionNames.Pages_Edit_Tenant, L("Edit Tenant"), multiTenancySides: MultiTenancySides.Tenant);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SmartSocConsts.LocalizationSourceName);
        }
    }
}

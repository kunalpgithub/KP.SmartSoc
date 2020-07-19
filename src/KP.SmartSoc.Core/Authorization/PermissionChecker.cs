using Abp.Authorization;
using KP.SmartSoc.Authorization.Roles;
using KP.SmartSoc.Authorization.Users;

namespace KP.SmartSoc.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

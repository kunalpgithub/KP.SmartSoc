using Abp.MultiTenancy;
using KP.SmartSoc.Authorization.Users;

namespace KP.SmartSoc.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

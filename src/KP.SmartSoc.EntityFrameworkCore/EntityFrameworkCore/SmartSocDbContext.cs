using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using KP.SmartSoc.Authorization.Roles;
using KP.SmartSoc.Authorization.Users;
using KP.SmartSoc.MultiTenancy;
using System.Security.Policy;
using KP.SmartSoc.Society;

namespace KP.SmartSoc.EntityFrameworkCore
{
    public class SmartSocDbContext : AbpZeroDbContext<Tenant, Role, User, SmartSocDbContext>
    {
        /* Define a DbSet for each entity of the application */

        
        public virtual DbSet<KP.SmartSoc.Society.Society> Societies { get; set; }
        public SmartSocDbContext(DbContextOptions<SmartSocDbContext> options)
            : base(options)
        {
        }
    }
}

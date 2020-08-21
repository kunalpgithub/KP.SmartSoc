using Abp.MultiTenancy;
using KP.SmartSoc.Authorization.Users;
using KP.SmartSoc.Society;
using System.Collections.Generic;

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

        //public string FullName { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Zipcode { get; protected set; }
        public string Country { get; protected set; }

        public string RegistrationNumber { get; protected set; }

        public virtual List<BankDetail> BankDetails { get; set; }
        public virtual List<Parking> Parkings { get; set; }
    }
}

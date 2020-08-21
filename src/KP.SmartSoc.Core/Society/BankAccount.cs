using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society
{
    public class BankDetail : FullAuditedEntity<Guid>,IMustHaveTenant
    {
        public string Name { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNumber { get; set; }
        public string UpiId { get; set; }
        public int TenantId { get; set; }
    }
}

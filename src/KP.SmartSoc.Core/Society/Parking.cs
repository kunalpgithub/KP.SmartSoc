using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using KP.SmartSoc.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society
{
    public class Parking: FullAuditedEntity<Guid>,IPassivable,IMustHaveTenant
    {
        public string ParkingNo { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get ; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KP.SmartSoc.Society.Dtos
{
    [AutoMapFrom(typeof(Society))]
    public class SocietyDto: FullAuditedEntityDto<Guid>
    {
        //public virtual int TenantId { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; protected set; }
    }
}

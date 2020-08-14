using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society.Dtos
{
    [AutoMapFrom(typeof(Society))]
    public class SocietyListDto: FullAuditedEntityDto<Guid>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; protected set; }
    }
}

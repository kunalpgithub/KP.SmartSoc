using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society.Dtos
{
    [AutoMapTo(typeof(Society))]
    public class CreateScoietyDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; set; }

    }
}

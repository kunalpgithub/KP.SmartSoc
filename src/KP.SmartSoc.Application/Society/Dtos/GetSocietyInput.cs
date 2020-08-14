using System;
using System.Collections.Generic;
using System.Text;

namespace KP.SmartSoc.Society.Dtos
{
    public class GetSocietyInput
    {
        public Guid SocietyId { get; set; }
    }
    public class CreateSocietyInput {
        public string FullName { get;  set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; set; }

    }
    public class AddSocietyMemberInput { 
        public Guid SocietyId { get; set; }
        public string HouseNo { get; set; }
    }
    public class GetSocietyMemberInput { }
}

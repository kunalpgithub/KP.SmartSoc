using System;
using System.Collections.Generic;
using System.Text;

namespace KP.SmartSoc.Society.Dtos
{
    public class GetSocietyInput
    {
        public Guid SocietyId { get; set; }
    }
    
    public class AddSocietyMemberInput { 
        public Guid SocietyId { get; set; }
        public string HouseNo { get; set; }
    }
    public class GetSocietyMemberInput { }
}

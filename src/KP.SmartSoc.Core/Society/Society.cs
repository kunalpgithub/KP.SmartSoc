using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KP.SmartSoc.Society
{
    [Table("Society")]
    public class Society : FullAuditedEntity<Guid>
    {
        public string FullName { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Zipcode { get; protected set; }
        public string Country { get; protected set; }
        
        public string RegistrationNumber { get; protected set; }


        protected Society() { }

        public static Society Create( string fullName, string address, string city, string state, string zipcode, string country, string registrationNumber) {

            var @society = new Society
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Address = address,
                City = city,
                State = state,
                Zipcode = zipcode,
                Country = country,
                RegistrationNumber = registrationNumber,
            };

            return @society;
        }

    }
}

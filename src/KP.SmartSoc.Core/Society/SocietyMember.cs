using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.UI;
using KP.SmartSoc.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace KP.SmartSoc.Society
{
    [Table("SocietyMember")]
    public class SocietyMember : CreationAuditedEntity, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public string HouseNo { get; set; }

        public virtual Society Society { get; protected set; }
        public virtual Guid SocietyId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }
        public virtual long UserId { get; protected set; }

        protected SocietyMember() { }

        public static SocietyMember CreateAsync(Society @society, string HouseNo, User user, ISocietyMemberAddPolicy addPolicy)
        {
            addPolicy.CheckAddPolicy(@society, user);

            return new SocietyMember
            {
                //Id = Guid.NewGuid(),
                HouseNo = HouseNo,
                Society = @society,
                SocietyId = @society.Id,
                User = user,
                UserId = user.Id
            };
        }
    }

    public interface ISocietyMemberAddPolicy
    {

        public void CheckAddPolicy(Society @society, User user);
    }

    public class SocietyMemberAddPolicy : ISocietyMemberAddPolicy
    {
        public void CheckAddPolicy(Society society, User user)
        {
            if (string.IsNullOrEmpty(society.RegistrationNumber))
            {
                throw new UserFriendlyException("Registration nummber can not be empty.");
            }
        }
    }
}

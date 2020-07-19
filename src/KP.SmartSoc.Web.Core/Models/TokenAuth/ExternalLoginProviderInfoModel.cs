using Abp.AutoMapper;
using KP.SmartSoc.Authentication.External;

namespace KP.SmartSoc.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

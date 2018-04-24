using Abp.AutoMapper;
using vcoresrobotics.website.Authentication.External;

namespace vcoresrobotics.website.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

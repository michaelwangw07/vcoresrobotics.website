using System.Collections.Generic;

namespace vcoresrobotics.website.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}

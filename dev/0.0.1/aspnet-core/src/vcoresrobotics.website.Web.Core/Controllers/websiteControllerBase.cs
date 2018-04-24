using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace vcoresrobotics.website.Controllers
{
    public abstract class websiteControllerBase: AbpController
    {
        protected websiteControllerBase()
        {
            LocalizationSourceName = websiteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

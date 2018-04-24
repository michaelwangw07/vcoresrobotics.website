using Abp.MultiTenancy;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

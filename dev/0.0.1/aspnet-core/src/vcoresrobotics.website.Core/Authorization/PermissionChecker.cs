using Abp.Authorization;
using vcoresrobotics.website.Authorization.Roles;
using vcoresrobotics.website.Authorization.Users;

namespace vcoresrobotics.website.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

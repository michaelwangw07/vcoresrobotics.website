using System;
using Microsoft.AspNetCore.Http;

namespace vcoresrobotics.website.Utility.FroalaEditor
{
    public class FroalaEditor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FroalaEditor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}

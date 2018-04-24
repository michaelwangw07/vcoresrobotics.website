using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace vcoresrobotics.website.FileUpload
{
    public interface IImageUploadAppService : IApplicationService
    {
        Task Post(List<IFormFile> files);
    }
}

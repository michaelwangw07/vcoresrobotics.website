using Microsoft.AspNetCore.Hosting;
using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net;

namespace vcoresrobotics.website.FileUpload
{
    public class ImageUploadAppService:websiteAppServiceBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageUploadAppService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<HttpRequestMessage> Post(List<IFormFile> files)
        {
            var theFile = Requset.Form.FIles.GetFile("file");

            string webRootPath = _hostingEnvironment.WebRootPath;

            var fileRoute = Path.Combine(webRootPath, "uploads");

            var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

            string extension = System.IO.Path.GetExtension(theFile.FileName);

            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

            string link = Path.Combine(fileRoute, name);

            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
            string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

            try
            {
                if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
                {
                    // Copy contents to memory stream.
                    Stream stream;
                    stream = new MemoryStream();
                    theFile.CopyTo(stream);
                    stream.Position = 0;
                    String serverPath = link;

                    // Save the file
                    using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                    {
                        await stream.CopyToAsync(writerFileStream);
                        writerFileStream.Dispose();
                    }

                    // Return the file path as json
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("link", "/uploads/" + name);

                    return Json(imageUrl);
                }
                throw new ArgumentException("The image did not pass the validation");
            }
            catch (ArgumentException ex)
            {
                return Json(ex.Message);
            }



        }
    }
}

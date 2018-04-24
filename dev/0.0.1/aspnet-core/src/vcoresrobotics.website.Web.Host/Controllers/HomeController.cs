using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vcoresrobotics.website.Controllers;
using Microsoft.AspNetCore.Http;
<<<<<<< HEAD
using vcoresrobotics.website.Utility.FroalaEditor;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
=======
>>>>>>> d530ee20498a8b11bec436f022e78efad8da5d85

namespace vcoresrobotics.website.Web.Host.Controllers
{
    public class HomeController : websiteControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(INotificationPublisher notificationPublisher, IHostingEnvironment hostingEnvironment)
        {
            _notificationPublisher = notificationPublisher;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }

<<<<<<< HEAD
        
        [Microsoft.AspNetCore.Mvc.HttpPost("UploadFiles")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            // Get the server path, wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Building the path to the uploads directory
            var fileRoute = Path.Combine(webRootPath, "uploads/images/");

            try
            {
                return Json(Utility.FroalaEditor.Image.Upload(HttpContext, fileRoute));
=======
        [HttpPost("UploadFiles")]
        public ActionResult UploadImage()
        {
            string uploadPath = "/Public/";


            try
            {
                return Json(vcoresrobotics.website.Utility.FroalaEditor.Image.Upload(HttpContext, uploadPath));
>>>>>>> d530ee20498a8b11bec436f022e78efad8da5d85
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
<<<<<<< HEAD
        
/*
        [Microsoft.AspNetCore.Mvc.HttpPost("UploadFiles")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImage(IFormFile file)
=======

        /*

        [EnableCors("localhost")]
        [HttpPost("UploadFiles")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(List<IFormFile> files)
>>>>>>> d530ee20498a8b11bec436f022e78efad8da5d85
        {
            // Get the file from the POST request
            var theFile = HttpContext.Request.Form.Files.GetFile("file");

            // Get the server path, wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;

            // Building the path to the uploads directory
            var fileRoute = Path.Combine(webRootPath, "uploads");

            // Get the mime type
            var mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;

            // Get File Extension
            string extension = System.IO.Path.GetExtension(theFile.FileName);

            // Generate Random name.
            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;

            // Build the full path inclunding the file name
            string link = Path.Combine(fileRoute, name);

            // Create directory if it does not exist.
            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            // Basic validation on mime types and file extension
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

<<<<<<< HEAD
                    /*
                    // Return the file path as json
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("link", "/uploads/" + name);
 

                    return Json(new { link = link.Replace("wwwroot/", "") });
=======
                    // Return the file path as json
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("link", "/uploads/" + name);

                    return Json(imageUrl);
>>>>>>> d530ee20498a8b11bec436f022e78efad8da5d85
                }
                throw new ArgumentException("The image did not pass the validation");
            }

            catch (ArgumentException ex)
            {
                return Json(ex.Message);
            }
        }
<<<<<<< HEAD
       */
        /*
        [Microsoft.AspNetCore.Mvc.HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
         */
=======
        */
>>>>>>> d530ee20498a8b11bec436f022e78efad8da5d85
    }
}

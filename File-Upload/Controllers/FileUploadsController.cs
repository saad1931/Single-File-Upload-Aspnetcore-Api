using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using File_Upload.Models;
using System.Collections;
using System.IO;

namespace File_Upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public FileUploadsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public string Post([FromForm] FileUpload objectfile)
        {
            try
            {
                if(objectfile.Files.Length > 0 )
                {
                    String path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using(FileStream fileStream=System.IO.File.Create(path + objectfile.Files.FileName))
                    {
                        objectfile.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded.";

                    }
                }
                else
                {
                    return "Not Uploaded.";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}

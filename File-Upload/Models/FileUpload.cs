using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Upload.Models
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}

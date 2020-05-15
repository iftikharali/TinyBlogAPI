using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TinyBlog.Helper
{
    public static class Utility
    {
        public static string SaveProfile(IFormFile formFile, string folderName)
        {
            Directory.CreateDirectory(folderName);
            var file = formFile;
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(folderName, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                bool IsFileExists = true;
                int counterToAdd = 1;
                while (IsFileExists)
                {
                    if (File.Exists(fullPath))
                    {
                        string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                        string FileExtension = Path.GetExtension(fileName);
                        fullPath = Path.Combine(folderName, FileNameWithoutExtension + "(" + (counterToAdd++) + ")" + FileExtension);

                    }
                    else
                    {
                        IsFileExists = false;
                    }
                }
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Path.GetFileName(fullPath);
            }
            else
            {
                return null;
            }
        }

    }
}

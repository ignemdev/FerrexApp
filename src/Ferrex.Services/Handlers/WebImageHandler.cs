using Ferrex.Core.Handlers;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Ferrex.Services.Handlers
{
    public class WebImageHandler : IImageHandler
    {
        public string ImageName { get; private set; } = Guid.NewGuid().ToString();
        public string ImageExtension { get; set; } = "jpeg";
        public IFormFile FormFile { private get; set; }

        public void CopyImage(params string[] pathParts)
        {
            if (pathParts is null || FormFile is null)
                throw new ArgumentNullException();

            var path = Path.Combine(pathParts) + $"{ImageName}.{ImageExtension}"; ;

            using var fileStreams = new FileStream(path, FileMode.Create);
            FormFile.CopyTo(fileStreams);
        }
        public void CopyImage(string name, bool withGuid, params string[] pathParts)
        {
            if (string.IsNullOrWhiteSpace(name) || pathParts is null || FormFile is null)
                throw new ArgumentNullException();

            ImageName = (withGuid) ? string.Concat(ImageName, name) : name;
            var path = Path.Combine(pathParts) + $"{ImageName}.{ImageExtension}";
            using var fileStreams = new FileStream(path, FileMode.Create);
            FormFile.CopyTo(fileStreams);
        }

        public void DeleteImage(params string[] pathParts)
        {
            if (pathParts is null) throw new ArgumentNullException();

            var path = Path.Combine(pathParts);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}

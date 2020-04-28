using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MusicStore.Web.Services
{
    public class HostFileProvider : IFileProvider
    {
        private readonly IWebHostEnvironment _environment;

        public HostFileProvider(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public byte[] GetBytes(string relativePath)
        {
            var fullPath = Path.Combine(_environment.ContentRootPath, relativePath);
            return File.ReadAllBytes(fullPath);
        }
    }
}

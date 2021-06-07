using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Services.Interfaces
{
    public interface IOFXFileService
    {
        Task ProcessFile(List<IFormFile> files);
        Task<string> ReadAsStringAsync(IFormFile file);
    }
}

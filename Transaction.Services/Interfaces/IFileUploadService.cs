using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Services.Interfaces
{
    public interface IFileUploadService
    {
        FileUploadResponse UploadFile(IFormFile _ufile);
        bool UploadXMLData();

    }
}

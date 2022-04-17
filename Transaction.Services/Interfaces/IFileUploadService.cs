using System;
using System.Collections.Generic;
using System.Text;

namespace Transaction.Services.Interfaces
{
    public interface IFileUploadService
    {
        bool UploadCSVData();
        bool UploadXMLData();

    }
}

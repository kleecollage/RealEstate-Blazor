using Microsoft.AspNetCore.Components.Forms;

namespace PropertiesServer.Services;

public interface IUploadFile
{
    Task<string> UploadFiles(IBrowserFile file);
    bool DeleteFile(string fileName);
}
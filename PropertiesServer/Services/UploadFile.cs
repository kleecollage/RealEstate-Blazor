using Microsoft.AspNetCore.Components.Forms;

namespace PropertiesServer.Services;

public class UploadFile(IWebHostEnvironment webHostEnvironment, IConfiguration configuration): IUploadFile
{
    public async Task<string> UploadFiles(IBrowserFile file)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            var fileName = Guid.NewGuid() + fileInfo.Extension;
            var folderDirectory = Path.Combine(webHostEnvironment.WebRootPath, "EstateImages");
            var path = Path.Combine(folderDirectory, fileName);
            
            if (!Directory.Exists(folderDirectory))
                Directory.CreateDirectory(folderDirectory);
            
            await using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // 10 MB
            await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fileStream);
            
            var url = $"{configuration.GetValue<string>("ServerUrl")}";
            var fullPath = $"{url}EstateImages/{fileName}";
            
            return fullPath;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }        
    }

    public bool DeleteFile(string fileName)
    {
        try
        {
            var path = $"{webHostEnvironment.WebRootPath}\\EstateImages\\{fileName}";
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
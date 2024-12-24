using Microsoft.AspNetCore.Components.Forms;

namespace PropertiesServer.Services;

public class UploadFile(IWebHostEnvironment webHostEnvironment, IConfiguration configuration): IUploadFile
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    private readonly IConfiguration _configuration = configuration;
    
    public async Task<string> UploadFiles(IBrowserFile file)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(file.Name);
            var fileName = Guid.NewGuid() + fileInfo.Extension;
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\EstateImages";
            var path = Path.Combine(folderDirectory, fileName);
            var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            
            if (!Directory.Exists(folderDirectory))
                Directory.CreateDirectory(folderDirectory);

            await using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            };
            
            var url = $"{_configuration.GetValue<string>("ServerUrl")}";
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
            var path = $"{_webHostEnvironment.WebRootPath}\\EstateImages\\{fileName}";
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
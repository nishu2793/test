namespace DotNetCore_AWS_Demo.Interface
{
    public interface IAws3Services
    {
        Task<byte[]> DownloadFileAsync(string file);
        Task<bool> UploadFileAsync(IFormFile file);
    }
}

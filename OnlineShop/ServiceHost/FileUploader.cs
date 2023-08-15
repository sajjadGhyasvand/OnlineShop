using _0_FrameWork.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment=webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {

            if (file == null) return string.Empty;
             var directoryPath = $"{_webHostEnvironment.WebRootPath }//UploadedFiles//{path}";
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var  filePath  = $"{directoryPath}//{fileName}";
            using var output = System.IO.File.Create(filePath);
            file.CopyToAsync(output).Wait();
            return $"{path}/{fileName}";
        }
    }
}

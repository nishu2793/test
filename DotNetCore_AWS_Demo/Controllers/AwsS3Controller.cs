using DotNetCore_AWS_Demo.Interface;
using DotNetCore_AWS_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNetCore_AWS_Demo.Controllers
{

    [ApiController]
    [Route("documents")]
    public class AwsS3Controller : ControllerBase
    {
        private  IAppConfiguration _appConfiguration;
        private IAws3Services _aws3Services;


        public AwsS3Controller(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }
        [HttpGet("{documentName}")]
        public IActionResult GetDocumentFromS3(string documentName)
        {
            try
            {
                if (string.IsNullOrEmpty(documentName))
                    return ReturnMessage("The 'documentName' parameter is required", (int)HttpStatusCode.BadRequest);

                _aws3Services = new Aws3Services(_appConfiguration.AwsAccessKey, _appConfiguration.AwsSecretAccessKey  , _appConfiguration.Region, _appConfiguration.BucketName);

                var document = _aws3Services.DownloadFileAsync(documentName).Result;

                return File(document, "application/octet-stream", documentName);
            }
            catch (Exception ex)
            {
                return ReturnMessage(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult UploadDocumentToS3(IFormFile file)
        {
            try
            {
                if (file is null || file.Length <= 0)
                    return ReturnMessage("file is required to upload", (int)HttpStatusCode.BadRequest);
                _aws3Services = new Aws3Services(_appConfiguration.AwsAccessKey, _appConfiguration.AwsSecretAccessKey,  _appConfiguration.Region, _appConfiguration.BucketName);
                var result = _aws3Services.UploadFileAsync(file);
                return ReturnMessage(string.Empty, (int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return ReturnMessage(ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        private IActionResult ReturnMessage(string message, int? statusCode = null)
        {
            return new ContentResult()
            {
                Content = message,
                ContentType = "application/json",
                StatusCode = statusCode
            };
        }

    }
}

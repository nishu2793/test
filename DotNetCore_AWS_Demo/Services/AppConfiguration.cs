using DotNetCore_AWS_Demo.Interface;

namespace DotNetCore_AWS_Demo.Services
{
    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration()
        {
            BucketName = "acemicapp";
            Region = "ap-south-1";
            AwsAccessKey = "AKIARX2TT245HFVST2M4";
            AwsSecretAccessKey = "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";
            AwsSessionToken = "";
        }

        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }

    }
}

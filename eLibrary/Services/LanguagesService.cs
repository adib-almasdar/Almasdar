using Azure.Storage.Files.DataLake;
using CommonLib.Services;
using eLibrary.Models;
using eLibrary.Services.Interface;
using Microsoft.Extensions.Options;

namespace eLibrary.Services
{
    public class LanguagesService : ILanguagesService
    {
        private readonly DataLakeHandler _dataLakeHandler;
        private readonly DataLakeServiceClient dataLakeServiceClient;
        private readonly DataLakeFileSystemClient fileSystemClient;
        public LanguagesService(DataLakeHandler dataLakeHandler, IOptions<DataLakeOptions> dataLakeOptions)
        {
            _dataLakeHandler = dataLakeHandler;
            this.dataLakeServiceClient = new DataLakeServiceClient(dataLakeOptions.Value.DatalakeConnection);
            fileSystemClient = dataLakeServiceClient.GetFileSystemClient(dataLakeOptions.Value.Container);

        }
        public async Task<string> StartDocumentUploadProcess(IFormCollection filesCollection, LanguageModel languageModel)
        {
            if (filesCollection.Files.Count != 0)
            {
                //Upload file to blob storage
                string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();

                string blobFolderName = "/Languages/" + uniqueFolderName;

                string absoluteUri = await UploadFiletoBlob(filesCollection.Files[0], blobFolderName);
                return absoluteUri;
            }
            else
            {
                return "";
            }

        }
        public async Task<string> UploadFiletoBlob(IFormFile item, string blobFolderName)
        {
            Stream myBlob = new MemoryStream();
            myBlob = item.OpenReadStream();
            FileInfo fi = new FileInfo(item.FileName);
            string extn = fi.Extension;

            string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();
            string uniqueFileName = uniqueFolderName + extn;

            var data = await _dataLakeHandler.UploadFile(myBlob, blobFolderName, uniqueFileName, item.ContentType);

            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(blobFolderName);
            DataLakeFileClient fileClient = directoryClient.GetFileClient(uniqueFileName);

            //string saasUrl = Convert.ToString(fileClient.GenerateSasUri(Azure.Storage.Sas.DataLakeSasPermissions.Read, DateTime.UtcNow.AddMonths(6)));
            //return saasUrl;

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration

            string appServiceUrl = configuration["AppServiceUrl"];
            string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient.Uri.OriginalString;
            return url;
        }
    }
}

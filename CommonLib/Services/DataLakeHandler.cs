using Azure.Storage.Blobs;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using CommonLib.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CommonLib.Services
{
    public class DataLakeHandler
    {
        private readonly DataLakeServiceClient dataLakeServiceClient;
        private readonly DataLakeFileSystemClient fileSystemClient;

        public DataLakeHandler(IOptions<DataLakeOptions> dataLakeOptions)
        {
            this.dataLakeServiceClient = new DataLakeServiceClient(dataLakeOptions.Value.DatalakeConnection);
            fileSystemClient = dataLakeServiceClient.GetFileSystemClient(dataLakeOptions.Value.Container);
        }
        public DataLakeServiceClient GetDataLakeClient()
        {
            return dataLakeServiceClient;
        }
        public async Task<bool> CheckIfDirectoryExists(string folderName)
        {
            var directoryClient = fileSystemClient.GetDirectoryClient(folderName);
            return await directoryClient.ExistsAsync();
        }
        public async Task<DataLakeDirectoryClient> CreateDirectory(string folderName)
        {
            return await fileSystemClient.CreateDirectoryAsync(folderName);
        }
        public async Task DeleteDirectory(string folderName)
        {
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(folderName);

            await directoryClient.DeleteAsync();
        }

        public async Task<List<string>> GetFilesAsync(string folderName)
        {
            List<string> directories = new List<string>();

            IAsyncEnumerator<PathItem> enumerator = fileSystemClient.GetPathsAsync(folderName).GetAsyncEnumerator();

            await enumerator.MoveNextAsync();
            PathItem item = enumerator.Current;

            while (item != null)
            {
                if (item.IsDirectory is false)
                {
                    directories.Add(item.Name);
                }

                if (!await enumerator.MoveNextAsync())
                {
                    break;
                }

                item = enumerator.Current;
            }
            return directories;
        }
        public async Task<List<string>> GetDirectoriesAsync(string path = null)
        {
            List<string> directories = new List<string>();

            IAsyncEnumerator<PathItem> enumerator = fileSystemClient.GetPathsAsync(path).GetAsyncEnumerator();

            await enumerator.MoveNextAsync();
            PathItem item = enumerator.Current;

            while (item != null)
            {
                if (item.IsDirectory is true)
                {
                    directories.Add(item.Name);
                }

                if (!await enumerator.MoveNextAsync())
                {
                    break;
                }

                item = enumerator.Current;
            }
            return directories;
        }
        public async Task<Uri> UploadFile(Stream fileStream, string folderName, string fileName, string contentType)
        {
            if (!await CheckIfDirectoryExists(folderName))
            {
                await CreateDirectory(folderName);
            }
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(folderName);
            var headers = new PathHttpHeaders()
            {
                ContentType = contentType
            };
            DataLakeFileClient fileClient = await directoryClient.CreateFileAsync(fileName);
            long fileSize = fileStream.Length;
            await fileClient.AppendAsync(fileStream, offset: 0);
            await fileClient.FlushAsync(position: fileSize);
            return fileClient.Uri;
        }
        public Uri GenerateSasUri(string fileName, string folderName = null)
        {
            if (folderName is null)
            {
                DataLakeFileClient fileClient = fileSystemClient.GetFileClient(fileName);
                return fileClient.GenerateSasUri(Azure.Storage.Sas.DataLakeSasPermissions.Read, DateTime.UtcNow.AddMinutes(30));
            }
            else
            {
                DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(folderName);
                DataLakeFileClient fileClient = directoryClient.GetFileClient(fileName);
                return fileClient.GenerateSasUri(Azure.Storage.Sas.DataLakeSasPermissions.Read, DateTime.UtcNow.AddMinutes(30));
            }
        }
        public async Task<FileInfo> DownloadFile(string fileName, string folderName = null)
        {
            try
            {
                if (folderName is null)
                {
                    DataLakeFileClient fileClient = fileSystemClient.GetFileClient(fileName);
                    var downloadResponse = await fileClient.OpenReadAsync();
                    FileInfo fileInfo = new FileInfo() { Stream = downloadResponse, Properties = fileClient.GetProperties(), Name = fileClient.Name };
                    return fileInfo;
                }
                else
                {
                    DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(folderName);

                    DataLakeFileClient fileClient = directoryClient.GetFileClient(fileName);

                    var downloadResponse = await fileClient.OpenReadAsync();
                    FileInfo fileInfo = new FileInfo() { Stream = downloadResponse, Properties = fileClient.GetProperties() };
                    return fileInfo;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task RenameAsync(string fileName, string newName, string folderName = null)
        {
            try
            {
                if (folderName is null)
                {
                    DataLakeFileClient fileClient = fileSystemClient.GetFileClient(fileName);
                    await fileClient.RenameAsync(newName);

                }
                else
                {
                    DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(folderName);

                    DataLakeFileClient fileClient = directoryClient.GetFileClient(fileName);

                    await fileClient.RenameAsync(newName);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<DataLakeFileClient> MoveDirectory(string tempfilename, string filename)
        {
            DataLakeFileClient sourceDataLakeFileClient = fileSystemClient.GetFileClient(tempfilename);

            // Check if the source file exists
            if (!await sourceDataLakeFileClient.ExistsAsync())
            {
                // Handle the case where the source file doesn't exist.
                // You can log an error or throw an exception as needed.
                return null;
            }

            // Extract the directory path from the destination filename
            string destinationDirectory = Path.GetDirectoryName(filename);

            // Check if the destination directory exists, create it if not
            await CreateDirectorys(destinationDirectory);

            // Move the file to the destination
            return await sourceDataLakeFileClient.RenameAsync(filename);
        }

        private async Task CreateDirectorys(string directoryPath)
        {
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(directoryPath);

            // Check if the directory exists, create it if not
            if (!await directoryClient.ExistsAsync())
            {
                await directoryClient.CreateAsync();
            }
        }

        //public async Task<DataLakeFileClient> MoveDirectory(string tempfilename, string filename)
        //{
        //    //DataLakeFileClient sourceDataLakeFileClient = fileSystemClient.GetFileClient(tempfilename);
        //    //return await sourceDataLakeFileClient.RenameAsync(filename);
        //    DataLakeFileClient sourceDataLakeFileClient = fileSystemClient.GetFileClient(tempfilename);

        //    //Check if the source file exists
        //    if (!await sourceDataLakeFileClient.ExistsAsync())
        //    {
        //        //Console.WriteLine($"Source file '{tempfilename}' does not exist.");
        //        return null;  // or handle the error as needed
        //    }
        //    await CreateDirectory(filename);
        //    return await sourceDataLakeFileClient.RenameAsync(filename);

        //    //string accountName = "your_account_name";
        //    //string accountKey = "your_account_key";
        //    //string fileSystemName = "your_file_system_name"; // File System within the Data Lake
        //    //string sourceFolderName = "source_folder"; // Source folder
        //    //string destinationFolderName = "destination_folder"; // Destination folder
        //    //string sourceFileName = "file.txt"; // Source file name
        //    //string destinationFileName = "file.txt"; // Destination file name

        //    //DataLakeServiceClient serviceClient = new DataLakeServiceClient(
        //    //    new Uri($"https://{accountName}.dfs.core.windows.net"),
        //    //    new DataLakeSharedKeyCredential(accountName, accountKey)
        //    //);

        //    //DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);

        //    //DataLakeDirectoryClient sourceDirectoryClient = fileSystemClient.GetDirectoryClient(sourceFolderName);
        //    //DataLakeDirectoryClient destinationDirectoryClient = fileSystemClient.GetDirectoryClient(destinationFolderName);

        //    //DataLakeFileClient sourceFileClient = sourceDirectoryClient.GetFileClient(sourceFileName);
        //    //DataLakeFileClient destinationFileClient = destinationDirectoryClient.GetFileClient(destinationFileName);

        //    //try
        //    //{
        //    //    // Copy the source file to the destination folder
        //    //    await destinationFileClient.(sourceFileClient.Uri);

        //    //    // Delete the source file after successful copy
        //    //    await sourceFileClient.DeleteIfExistsAsync();

        //    //    Console.WriteLine("File moved successfully!");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine($"Error: {ex.Message}");
        //    //}

        //}

        public class FileInfo
        {
            public PathProperties Properties { get; set; }
            public Stream Stream { get; set; }
            public long Length { get; set; }
            public string Name { get; set; }
        }
    }
}

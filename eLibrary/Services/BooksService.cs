using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.Identity;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using CommonLib;
using CommonLib.Data;
using CommonLib.Data.Interface;
using CommonLib.Services;
using eLibrary.Models;
using eLibrary.Services.Interface;
using iText.Kernel.Pdf.Canvas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.DependencyResolver;
using NuGet.ProjectModel;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using static iTextSharp.text.pdf.AcroFields;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace eLibrary.Services
{
    public class BooksService : IBooksService
    {
        private readonly DataLakeHandler _dataLakeHandler;
        private readonly DataLakeServiceClient dataLakeServiceClient;
        private readonly DataLakeFileSystemClient fileSystemClient;
        private readonly ApplicationDbContext _context;
        // Inject IWebHostEnvironment into your controller or service
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<BooksService> _logger;

        public BooksService(ApplicationDbContext context, DataLakeHandler dataLakeHandler, IOptions<DataLakeOptions> dataLakeOptions, IWebHostEnvironment webHostEnvironment, ILogger<BooksService> logger)
        {
            _dataLakeHandler = dataLakeHandler;
            this.dataLakeServiceClient = new DataLakeServiceClient(dataLakeOptions.Value.DatalakeConnection);
            fileSystemClient = dataLakeServiceClient.GetFileSystemClient(dataLakeOptions.Value.Container);
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public async Task<string[]> StartBookUploadProcess(IFormCollection files, BookModel bookModel)
        {
            string[] BlobUrls = new string[3];
            //IFormFile bookFile = files.Files.SingleOrDefault(item => item.Name == "bookfile");
            //IFormFile bookThumbnailFile = files.Files.SingleOrDefault(item => item.Name == "thumbnailfile");
            //IFormFile bookApproverAttachmentFile = files.Files.SingleOrDefault(item => item.Name == "approverattachmentfile");

            //Upload file to blob storage
            string folderNameForBookFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/BookFile";
            string folderNameForBookThumbnailFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/Thumbnail";
            string folderNameForApproverAttachmentFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/ApproverAttachment";

            string bookFileBlobUrl = String.Empty;
            string thumbnailFileBlobUrl = String.Empty;
            string approverAttachmentFileBlobUrl = String.Empty;
            if (bookModel.bookfile != null)
            {
                bookFileBlobUrl = await UploadFiletoBlob(bookModel.bookfile, folderNameForBookFile, bookModel);
            }

            if (bookModel.thumbnailfile != null)
            {
                thumbnailFileBlobUrl = await UploadFiletoBlob(bookModel.thumbnailfile, folderNameForBookThumbnailFile, bookModel);
            }

            if (bookModel.approverattachmentfile != null)
            {
                approverAttachmentFileBlobUrl = await UploadFiletoBlob(bookModel.approverattachmentfile, folderNameForApproverAttachmentFile, bookModel);
            }
            //Parallel.Invoke(
            //   () => bookFileBlobUrl = UploadFiletoBlob(bookFile, folderNameForBookFile, bookModel).Result,
            //   () => thumbnailFileBlobUrl = UploadFiletoBlob(bookThumbnailFile, folderNameForBookThumbnailFile, bookModel).Result,
            //   () => approverAttachmentFileBlobUrl = UploadFiletoBlob(bookApproverAttachmentFile, folderNameForApproverAttachmentFile, bookModel).Result

            //);

            BlobUrls[0] = bookFileBlobUrl;
            BlobUrls[1] = thumbnailFileBlobUrl;
            BlobUrls[2] = approverAttachmentFileBlobUrl;

            return BlobUrls;
        }
        public async Task<string> UploadFile1toBlob(IFormFile item, string blobFolderName, BookModel bookModel)
        {
            if (item == null) return string.Empty;

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read uploaded file once
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await item.CopyToAsync(ms).ConfigureAwait(false);
                fileBytes = ms.ToArray();
            }

            FileInfo fi = new FileInfo(item.FileName);
            string extn = fi.Extension;
            string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();
            string uniqueFileName = uniqueFolderName + extn;

            string newblobFolderName = blobFolderName.Substring(1);
            var fileClient = fileSystemClient.GetFileClient(newblobFolderName + "/" + uniqueFileName);
            var fileClient2 = fileSystemClient.GetFileClient(newblobFolderName.Replace("/BooksOriginal/", "/Books/") + "/ocr_" + uniqueFileName);

            // Upload original file to data lake
            using (var sourceStream = new MemoryStream(fileBytes))
            {
                var transferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 4 * 1024 * 1024,
                    InitialTransferSize = 4 * 1024 * 1024
                };
                var uploadOptions = new DataLakeFileUploadOptions
                {
                    TransferOptions = transferOptions,
                    ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes"))
                };
                await fileClient.UploadAsync(sourceStream, uploadOptions).ConfigureAwait(false);
            }

            var propertiesNew = await fileClient.GetPropertiesAsync().ConfigureAwait(false);
            var fileUrl = fileClient.Uri.ToString();

            if (!blobFolderName.Contains("/BookFile"))
            {
                string appServiceUrl = configuration["AppServiceUrl"];
                string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient.Uri.OriginalString;
                return url;
            }

            // Book file -> run OCR and create searchable PDF
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding utf16 = Encoding.Unicode; // This is little endian

                // Specify the relative path to the font file
                string fontRelativePath = Path.Combine("Font", "Scheherazade-Regular.ttf");
               
                // Combine with the root path to get the full font file path
                string fontFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, fontRelativePath);
                BaseFont arabicBaseFont = BaseFont.CreateFont(fontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                using (var pdfReaderStream = new MemoryStream(fileBytes))
                using (var pdfReader = new iTextSharp.text.pdf.PdfReader(pdfReaderStream))
                using (var outputStream = new MemoryStream())
                {
                    var pdfStamper = new PdfStamper(pdfReader, outputStream);

                    string YourFormRecognizerEndpoint = configuration["YourFormRecognizerEndpoint"];
                   
                    // Use DefaultCredential(recommended for RBAC)
                    var credential = new DefaultAzureCredential();

                    // Create client using RBAC
                    var client = new DocumentAnalysisClient(new Uri(YourFormRecognizerEndpoint), credential);

                    int totalPages = pdfReader.NumberOfPages;
                    _logger.LogInformation("PDF has {TotalPages} pages for file {FileName}", totalPages, item.FileName);

                    // Dictionary to store all recognized pages across all chunks
                    var allRecognizedpages = new Dictionary<int, DocumentPage>();

                    // Process PDF in chunks (Form Recognizer S1 limit is _660 pages per call)
                    const int chunkSize = 600; // Stay under 660 limit with safety margin
                    int totalChunks = (int)Math.Ceiling((double)totalPages / chunkSize);

                    for (int chunkIndex=0;chunkIndex < totalChunks; chunkIndex++)
                    {
                        int chunkStartPage = chunkIndex * chunkSize + 1;
                        int chunkEndPage = Math.Min((chunkIndex + 1) * chunkSize, totalPages);
                        int chunkPageCount = chunkEndPage = chunkStartPage + 1;

                        _logger.LogInformation("Processing chunk {ChunkIndex}/{TotalChunks}:Pages {StartPage}-{EndPage} ({PageCount} pages)",
                            chunkIndex + 1, totalChunks, chunkStartPage, chunkEndPage, chunkPageCount);

                        // Extract pages for this chunk
                        byte[] chunkBytes = ExtractPdfPages(fileBytes, chunkStartPage, chunkEndPage);
                        using (var formrecogInputStream = new MemoryStream(chunkBytes))
                        {
                            formrecogInputStream.Position = 0;
                            var sw = Stopwatch.StartNew();
                            _logger.LogInformation("Sending entire PDF ({TotalPages} pages) to Form Recognizer...", totalPages);

                            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-read", formrecogInputStream).ConfigureAwait(false);
                            var result = operation.Value;

                            _logger.LogInformation("Chunk {ChunkIndex} Form Recognizer completed in {Elapaes} ms.Operation ID: {OperationalId},",
                                chunkIndex + 1, sw.ElapsedMilliseconds, operation.Id);

                            if (!operation.HasCompleted)
                            {
                                _logger.LogWarning("Form Recognizer operation did not complete for chunk {ChunkIndex} of file {FileName}",
                                    chunkIndex + 1, item.FileName);
                            }

                            var recognizedPages = result?.Pages ?? new List<DocumentPage>();

                            // store recognizedpage with their original page number
                            for(int i = 0; i < recognizedPages.Count; i++)
                            {
                                int originalPageNum = chunkStartPage + 1;
                                allRecognizedpages[originalPageNum] = recognizedPages[i];
                            }

                            _logger.LogInformation("Chuk {ChunkIndex}: Recognized {RecognizedCount}/{ChukpageCount} pages",
                                chunkIndex + 1, recognizedPages.Count, chunkPageCount);

                            if(recognizedPages.Count < chunkPageCount)
                            {
                                _logger.LogWarning("Chunk {ChunkIndex}: Incomplete OCR - Form Recognizer returned only {Returned}/{Expected} pages."
                                   + "Pages {Start}-{End} in the chunk will not have OCR overlays",
                                   chunkIndex + 1, recognizedPages.Count, chunkPageCount,
                                   chunkStartPage + recognizedPages.Count, chunkEndPage);
                            }
                        }

                    }
                    // Use a fresh stream for Form Recognizer and ensure position = 0
                    using (var formrecogInputStream = new MemoryStream(fileBytes))
                    {
                        formrecogInputStream.Position = 0;
                        var sw = Stopwatch.StartNew();
                        _logger.LogInformation("Sending entire PDF ({TotalPages} pages) to Form Recognizer...", totalPages);

                        AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-read", formrecogInputStream).ConfigureAwait(false);
                        var result = operation.Value;

                        _logger.LogInformation("Form Recognizer completed in {Elapsed} ms. Operation ID: {OperationId}, Status: {Status}",
                            sw.ElapsedMilliseconds, operation.Id, operation.Id);

                        if (!operation.HasCompleted)
                        {
                            _logger.LogWarning("Form Recognizer operation did not complete for file {FileName}", item.FileName);
                        }

                        var recognizedPages = result?.Pages ?? new List<DocumentPage>();
                        _logger.LogInformation("Form Recognizer returned {RecognizedCount} pages (PDF has {TotalPages} pages)",
                            recognizedPages.Count, totalPages);

                        if (recognizedPages.Count < totalPages)
                        {
                            _logger.LogWarning("INCOMPLETE OCR: Form Recognizer returned only {Returned}/{Total} pages. "
                                + "Pages {Start}-{End} will NOT have OCR overlays. "
                                + "P1v3 tier may have a page limit (~660 pages per call). "
                                + "Consider upgrading to S1/S2 or implementing page-range chunking.",
                                recognizedPages.Count, totalPages, recognizedPages.Count + 1, totalPages);
                        }

                        var sw2 = Stopwatch.StartNew();
                        // Loop through ONLY the pages that Form Recognizer returned
                        for (int page = 1; page <= recognizedPages.Count; page++)
                        {
                            var pageInfo = recognizedPages[page - 1];
                            int rotation = pdfReader.GetPageRotation(page);
                            iTextSharp.text.Rectangle originalPageSize = pdfReader.GetPageSize(page);
                            iTextSharp.text.Rectangle adjustedPageSize = (rotation == 90 || rotation == 270)
                                ? new iTextSharp.text.Rectangle(originalPageSize.Height, originalPageSize.Width)
                                : new iTextSharp.text.Rectangle(originalPageSize);

                            PdfContentByte pdfContentByte = pdfStamper.GetOverContent(page);

                            int lineCount = 0;
                            foreach (var line in pageInfo.Lines)
                            {
                                try
                                {
                                    float xMultiplicationFactor = (float)adjustedPageSize.Width / (float)pageInfo.Width;
                                    float yMultiplicationFactor = (float)adjustedPageSize.Height / (float)pageInfo.Height;

                                    var boundingPolygon = line.BoundingPolygon;
                                    float x1 = (float)(boundingPolygon[0].X * xMultiplicationFactor);
                                    float y1 = adjustedPageSize.Height - (float)(boundingPolygon[0].Y * yMultiplicationFactor);
                                    float x2 = (float)(boundingPolygon[2].X * xMultiplicationFactor);
                                    float y2 = adjustedPageSize.Height - (float)(boundingPolygon[2].Y * yMultiplicationFactor);

                                    float width2 = x2 - x1;
                                    float height2 = Math.Abs(y2 - y1);

                                    float fontSize2 = CalculateMaxFontSize(line.Content, width2, height2, fontFilePath);
                                    DrawTextWithinRectangle(pdfContentByte, line.Content, x1, y1, width2, height2, fontSize2, arabicBaseFont);
                                    lineCount++;
                                }
                                catch (Exception innerEx)
                                {
                                    _logger.LogDebug(innerEx, "Line drawing failed on page {Page} for file {FileName}", page, item.FileName);
                                }
                            }

                            if (page % 100 == 0 || page == recognizedPages.Count)
                            {
                                _logger.LogInformation("Processed page {Page}/{Total} ({Lines} lines) in {Elapsed} ms",
                                    page, recognizedPages.Count, lineCount, sw2.ElapsedMilliseconds);
                                sw2.Restart();
                            }
                        }

                        _logger.LogInformation("OCR overlay complete for {Pages} pages", recognizedPages.Count);
                    }

                    // finalize PDF
                    pdfStamper.Close();
                    pdfReader.Close();

                    byte[] modifiedPdfBytes = outputStream.ToArray();

                    // Upload OCR file
                    string newblobFolderNameForOCR = newblobFolderName.Replace("BooksOriginal", "Books");
                    fileClient2 = fileSystemClient.GetFileClient(newblobFolderNameForOCR + "/ocr_" + uniqueFileName);

                    using (Stream stream = new MemoryStream(modifiedPdfBytes))
                    {
                        var transferOptions = new StorageTransferOptions
                        {
                            MaximumTransferSize = 4 * 1024 * 1024,
                            InitialTransferSize = 4 * 1024 * 1024
                        };

                        var uploadOptions = new DataLakeFileUploadOptions
                        {
                            TransferOptions = transferOptions,
                            ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes"))
                        };

                        await fileClient2.UploadAsync(stream, uploadOptions).ConfigureAwait(false);
                    }

                    var propertiesNew2 = await fileClient2.GetPropertiesAsync().ConfigureAwait(false);

                    // Build and set metadata
                    string[] allTitle = GetTitlesbyId(bookModel.Category, bookModel.SubCategory, bookModel.Country, bookModel.Language, bookModel.BookType);
                    Dictionary<string, string> myDict = new Dictionary<string, string>();
                    PropertyInfo[] properties = typeof(BookModel).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        object value = property.GetValue(bookModel);
                        if (value != null)
                        {
                            if (property.Name == "Category")
                            {
                                string propertyValue = allTitle[0].Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else if (property.Name == "SubCategory")
                            {
                                string propertyValue = allTitle[1].Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else if (property.Name == "BookType")
                            {
                                string propertyValue = allTitle[4].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "Language")
                            {
                                string propertyValue = allTitle[3].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "Country")
                            {
                                string propertyValue = allTitle[2].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "ArabicKeywords" || property.Name == "BookTitleArabic" || property.Name == "Description" || property.Name == "Author" || property.Name == "Version" || property.Name == "VolumeNumber" || property.Name == "Publication")
                            {
                                string propertyValue = value.ToString().Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else
                            {
                                string propertyValue = value.ToString().Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                        }
                    }

                    await fileClient2.SetMetadataAsync(myDict).ConfigureAwait(false);

                    string appServiceUrl = configuration["AppServiceUrl"];
                    string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient2.Uri.OriginalString.Replace("ocr_", "");
                    return url;
                }
            }
            catch (RequestFailedException rfe)
            {
                _logger.LogError(rfe, "Azure RequestFailedException uploading/processing file {FileName}. Status: {Status}, ErrorCode: {ErrorCode}, Message: {Message}",
                    item?.FileName, rfe.Status, rfe.ErrorCode, rfe.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error uploading/processing file {FileName}", item?.FileName);
                throw;
            }
        }
        // 2nd 
        public async Task<string> UploadFiletoBlob(IFormFile item, string blobFolderName, BookModel bookModel)
        {
            if (item == null) return string.Empty;

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();

            // Read uploaded file once
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await item.CopyToAsync(ms).ConfigureAwait(false);
                fileBytes = ms.ToArray();
            }

            FileInfo fi = new FileInfo(item.FileName);
            string extn = fi.Extension;
            string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();
            string uniqueFileName = uniqueFolderName + extn;

            string newblobFolderName = blobFolderName.Substring(1);
            var fileClient = fileSystemClient.GetFileClient(newblobFolderName + "/" + uniqueFileName);
            var fileClient2 = fileSystemClient.GetFileClient(newblobFolderName.Replace("/BooksOriginal/", "/Books/") + "/ocr_" + uniqueFileName);

            // Upload original file to data lake
            using (var sourceStream = new MemoryStream(fileBytes))
            {
                var transferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 4 * 1024 * 1024,
                    InitialTransferSize = 4 * 1024 * 1024
                };
                var uploadOptions = new DataLakeFileUploadOptions
                {
                    TransferOptions = transferOptions,
                    ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes"))
                };
                await fileClient.UploadAsync(sourceStream, uploadOptions).ConfigureAwait(false);
            }

            var propertiesNew = await fileClient.GetPropertiesAsync().ConfigureAwait(false);
            var fileUrl = fileClient.Uri.ToString();

            if (!blobFolderName.Contains("/BookFile"))
            {
                string appServiceUrl = configuration["AppServiceUrl"];
                string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient.Uri.OriginalString;
                return url;
            }

            // Book file -> run OCR and create searchable PDF
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                string fontRelativePath = Path.Combine("Font", "Scheherazade-Regular.ttf");
                string fontFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, fontRelativePath);
                BaseFont arabicBaseFont = BaseFont.CreateFont(fontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                using (var pdfReaderStream = new MemoryStream(fileBytes))
                using (var pdfReader = new iTextSharp.text.pdf.PdfReader(pdfReaderStream))
                using (var outputStream = new MemoryStream())
                {
                    var pdfStamper = new PdfStamper(pdfReader, outputStream);

                    string YourFormRecognizerApiKey = configuration["YourFormRecognizerApiKey"];
                    string YourFormRecognizerEndpoint = configuration["YourFormRecognizerEndpoint"];
                    AzureKeyCredential credential = new AzureKeyCredential(YourFormRecognizerApiKey);
                    DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(YourFormRecognizerEndpoint), credential);

                    int totalPages = pdfReader.NumberOfPages;
                    _logger.LogInformation("PDF has {TotalPages} pages for file {FileName}", totalPages, item.FileName);

                    // Dictionary to store all recognized pages across all chunks
                    var allRecognizedPages = new Dictionary<int, DocumentPage>();

                    // Process PDF in chunks (Form Recognizer P1v3 limit is ~660 pages per call)
                    const int chunkSize = 600; // Stay under 660 limit with safety margin
                    int totalChunks = (int)Math.Ceiling((double)totalPages / chunkSize);

                    for (int chunkIndex = 0; chunkIndex < totalChunks; chunkIndex++)
                    {
                        int chunkStartPage = chunkIndex * chunkSize + 1;
                        int chunkEndPage = Math.Min((chunkIndex + 1) * chunkSize, totalPages);
                        int chunkPageCount = chunkEndPage - chunkStartPage + 1;

                        _logger.LogInformation(
                            "Processing chunk {ChunkIndex}/{TotalChunks}: Pages {StartPage}-{EndPage} ({PageCount} pages)",
                            chunkIndex + 1, totalChunks, chunkStartPage, chunkEndPage, chunkPageCount);

                        // Extract pages for this chunk
                        byte[] chunkBytes = ExtractPdfPages(fileBytes, chunkStartPage, chunkEndPage);

                        using (var formrecogInputStream = new MemoryStream(chunkBytes))
                        {
                            formrecogInputStream.Position = 0;
                            var sw = Stopwatch.StartNew();

                            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(
                                WaitUntil.Completed, "prebuilt-read", formrecogInputStream).ConfigureAwait(false);
                            var result = operation.Value;

                            _logger.LogInformation(
                                "Chunk {ChunkIndex} Form Recognizer completed in {Elapsed} ms. Operation ID: {OperationId}",
                                chunkIndex + 1, sw.ElapsedMilliseconds, operation.Id);

                            if (!operation.HasCompleted)
                            {
                                _logger.LogWarning(
                                    "Form Recognizer operation did not complete for chunk {ChunkIndex} of file {FileName}",
                                    chunkIndex + 1, item.FileName);
                            }

                            var recognizedPages = result?.Pages ?? new List<DocumentPage>();

                            // Store recognized pages with their original page numbers
                            for (int i = 0; i < recognizedPages.Count; i++)
                            {
                                int originalPageNum = chunkStartPage + i;
                                allRecognizedPages[originalPageNum] = recognizedPages[i];
                            }

                            _logger.LogInformation(
                                "Chunk {ChunkIndex}: Recognized {RecognizedCount}/{ChunkPageCount} pages",
                                chunkIndex + 1, recognizedPages.Count, chunkPageCount);

                            if (recognizedPages.Count < chunkPageCount)
                            {
                                _logger.LogWarning(
                                    "Chunk {ChunkIndex}: Incomplete OCR - Form Recognizer returned only {Returned}/{Expected} pages. "
                                    + "Pages {Start}-{End} in this chunk will NOT have OCR overlays.",
                                    chunkIndex + 1, recognizedPages.Count, chunkPageCount,
                                    chunkStartPage + recognizedPages.Count, chunkEndPage);
                            }
                        }
                    }

                    _logger.LogInformation("All chunks processed. Total recognized pages: {RecognizedCount}/{TotalPages}",
                        allRecognizedPages.Count, totalPages);

                    // Now apply OCR overlays to all recognized pages with batching and memory management
                    var sw2 = Stopwatch.StartNew();
                    int overlaysApplied = 0;
                    const int logInterval = 50;
                    const int batchSize = 100; // Process pages in batches to manage memory

                    try
                    {
                        // Process pages in batches
                        var pagesList = allRecognizedPages.OrderBy(x => x.Key).ToList();

                        for (int batchStart = 0; batchStart < pagesList.Count; batchStart += batchSize)
                        {
                            int batchEnd = Math.Min(batchStart + batchSize, pagesList.Count);
                            var currentBatch = pagesList.Skip(batchStart).Take(batchEnd - batchStart).ToList();

                            _logger.LogInformation("Processing batch of pages {BatchStart}-{BatchEnd}", batchStart + 1, batchEnd);

                            foreach (var pageEntry in currentBatch)
                            {
                                int pageNum = pageEntry.Key;
                                var pageInfo = pageEntry.Value;

                                try
                                {
                                    int rotation = pdfReader.GetPageRotation(pageNum);
                                    iTextSharp.text.Rectangle originalPageSize = pdfReader.GetPageSize(pageNum);
                                    iTextSharp.text.Rectangle adjustedPageSize = (rotation == 90 || rotation == 270)
                                        ? new iTextSharp.text.Rectangle(originalPageSize.Height, originalPageSize.Width)
                                        : new iTextSharp.text.Rectangle(originalPageSize);

                                    PdfContentByte pdfContentByte = pdfStamper.GetOverContent(pageNum);

                                    int lineCount = 0;
                                    foreach (var line in pageInfo.Lines)
                                    {
                                        try
                                        {
                                            // Skip if text is empty
                                            if (string.IsNullOrWhiteSpace(line.Content))
                                                continue;

                                            float xMultiplicationFactor = (float)adjustedPageSize.Width / (float)pageInfo.Width;
                                            float yMultiplicationFactor = (float)adjustedPageSize.Height / (float)pageInfo.Height;

                                            var boundingPolygon = line.BoundingPolygon;

                                            // Validate bounding polygon has required points
                                            if (boundingPolygon == null || boundingPolygon.Count < 3)
                                                continue;

                                            float x1 = (float)(boundingPolygon[0].X * xMultiplicationFactor);
                                            float y1 = adjustedPageSize.Height - (float)(boundingPolygon[0].Y * yMultiplicationFactor);
                                            float x2 = (float)(boundingPolygon[2].X * xMultiplicationFactor);
                                            float y2 = adjustedPageSize.Height - (float)(boundingPolygon[2].Y * yMultiplicationFactor);

                                            float width2 = x2 - x1;
                                            float height2 = Math.Abs(y2 - y1);

                                            // Skip if dimensions are invalid
                                            if (width2 <= 0 || height2 <= 0)
                                                continue;

                                            float fontSize2 = CalculateMaxFontSize(line.Content, width2, height2, fontFilePath);

                                            // Only draw if font size is valid
                                            if (fontSize2 > 0.5f)
                                            {
                                                DrawTextWithinRectangle(pdfContentByte, line.Content, x1, y1, width2, height2, fontSize2, arabicBaseFont);
                                                lineCount++;
                                            }
                                        }
                                        catch (Exception innerEx)
                                        {
                                            _logger.LogDebug(innerEx, "Line drawing failed on page {Page}", pageNum);
                                        }
                                    }

                                    overlaysApplied++;

                                    if (overlaysApplied % logInterval == 0 || overlaysApplied == pagesList.Count)
                                    {
                                        double memoryMB = GC.GetTotalMemory(false) / (1024 * 1024);
                                        double avgTimeMs = sw2.ElapsedMilliseconds / (double)logInterval;

                                        _logger.LogInformation(
                                            "Progress: {Applied}/{Total} pages ({Percent}%) | " +
                                            "Time: {AvgTime:F1}ms/batch | Memory: {Memory}MB | " +
                                            "Elapsed: {Total}s",
                                            overlaysApplied, pagesList.Count,
                                            (overlaysApplied * 100) / pagesList.Count,
                                            avgTimeMs,
                                            memoryMB,
                                            sw2.Elapsed.TotalSeconds);
                                        sw2.Restart();
                                    }
                                }
                                catch (Exception pageEx)
                                {
                                    _logger.LogError(pageEx, "Error processing page {Page}", pageNum);
                                }
                            }

                            // Force garbage collection after each batch to free memory
                            if (batchEnd % (batchSize * 5) == 0)
                            {
                                _logger.LogInformation("Running garbage collection after batch {Batch}", batchEnd / batchSize);
                                GC.Collect(2);
                                GC.WaitForPendingFinalizers();
                            }
                        }

                        _logger.LogInformation("OCR overlay complete. Applied overlays to {Applied}/{Total} pages",
                            overlaysApplied, pagesList.Count);
                    }
                    catch (OutOfMemoryException oomEx)
                    {
                        _logger.LogError(oomEx, "Out of memory while processing overlays. Processed {Applied} pages", overlaysApplied);
                        // Close and clean up what we have
                        pdfStamper.Close();
                        pdfReader.Close();
                        throw;
                    }

                    // finalize PDF
                    pdfStamper.Close();
                    pdfReader.Close();

                    byte[] modifiedPdfBytes = outputStream.ToArray();

                    // Upload OCR file
                    string newblobFolderNameForOCR = newblobFolderName.Replace("BooksOriginal", "Books");
                    fileClient2 = fileSystemClient.GetFileClient(newblobFolderNameForOCR + "/ocr_" + uniqueFileName);

                    using (Stream stream = new MemoryStream(modifiedPdfBytes))
                    {
                        var transferOptions = new StorageTransferOptions
                        {
                            MaximumTransferSize = 4 * 1024 * 1024,
                            InitialTransferSize = 4 * 1024 * 1024
                        };

                        var uploadOptions = new DataLakeFileUploadOptions
                        {
                            TransferOptions = transferOptions,
                            ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes"))
                        };

                        await fileClient2.UploadAsync(stream, uploadOptions).ConfigureAwait(false);
                    }

                    var propertiesNew2 = await fileClient2.GetPropertiesAsync().ConfigureAwait(false);

                    // Build and set metadata
                    string[] allTitle = GetTitlesbyId(bookModel.Category, bookModel.SubCategory, bookModel.Country, bookModel.Language, bookModel.BookType);
                    Dictionary<string, string> myDict = new Dictionary<string, string>();
                    PropertyInfo[] properties = typeof(BookModel).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        object value = property.GetValue(bookModel);
                        if (value != null)
                        {
                            if (property.Name == "Category")
                            {
                                string propertyValue = allTitle[0].Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else if (property.Name == "SubCategory")
                            {
                                string propertyValue = allTitle[1].Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else if (property.Name == "BookType")
                            {
                                string propertyValue = allTitle[4].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "Language")
                            {
                                string propertyValue = allTitle[3].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "Country")
                            {
                                string propertyValue = allTitle[2].Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                            else if (property.Name == "ArabicKeywords" || property.Name == "BookTitleArabic" || property.Name == "Description" || property.Name == "Author" || property.Name == "Version" || property.Name == "VolumeNumber" || property.Name == "Publication")
                            {
                                string propertyValue = value.ToString().Trim();
                                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                                string base64String = System.Convert.ToBase64String(plainTextBytes);
                                myDict.Add(property.Name, base64String);
                            }
                            else
                            {
                                string propertyValue = value.ToString().Trim();
                                propertyValue = RemoveSpecialCharacters(propertyValue);
                                myDict.Add(property.Name, propertyValue);
                            }
                        }
                    }

                    await fileClient2.SetMetadataAsync(myDict).ConfigureAwait(false);

                    string appServiceUrl = configuration["AppServiceUrl"];
                    string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient2.Uri.OriginalString.Replace("ocr_", "");
                    return url;
                }
            }
            catch (RequestFailedException rfe)
            {
                _logger.LogError(rfe, "Azure RequestFailedException uploading/processing file {FileName}. Status: {Status}, ErrorCode: {ErrorCode}, Message: {Message}",
                    item?.FileName, rfe.Status, rfe.ErrorCode, rfe.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error uploading/processing file {FileName}", item?.FileName);
                throw;
            }
        }

        /// <summary>
        /// Extracts specified pages from a PDF and returns them as a byte array
        /// </summary>
        private byte[] ExtractPdfPages(byte[] pdfBytes, int startPage, int endPage)
        {
            using (var pdfReaderStream = new MemoryStream(pdfBytes))
            using (var pdfReader = new iTextSharp.text.pdf.PdfReader(pdfReaderStream))
            using (var outputStream = new MemoryStream())
            {
                var pdfDocument = new iTextSharp.text.Document();
                var pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, outputStream);
                pdfDocument.Open();

                for (int page = startPage; page <= Math.Min(endPage, pdfReader.NumberOfPages); page++)
                {
                    var importedPage = pdfWriter.GetImportedPage(pdfReader, page);
                    pdfDocument.Add(iTextSharp.text.Image.GetInstance(importedPage));
                }

                pdfDocument.Close();
                return outputStream.ToArray();
            }
        }

        private void DrawTextWithinRectangle_Original(PdfContentByte pdfContentByte, string text, float x, float y, float width, float height, float fontSize, BaseFont baseFont)
        {
            try
            {
                // Set font and size
                //BaseFont baseFont = BaseFont.CreateFont(fontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                // Calculate text width and height using BaseFont
                float textWidth = baseFont.GetWidthPoint(text, fontSize);
                float textHeight = baseFont.GetAscentPoint(text, fontSize) - baseFont.GetDescentPoint(text, fontSize);

                // Calculate the position for centering the text within the rectangle
                float offsetX = (width - textWidth) / 2;
                float offsetY = (height - textHeight) / 2 + baseFont.GetDescentPoint(text, fontSize) - 10; // Adjust for descent

                // Draw the text
                pdfContentByte.BeginText();
                pdfContentByte.SetFontAndSize(baseFont, fontSize);
                pdfContentByte.SetTextMatrix(x + offsetX, y + offsetY);

                string finalText = String.Empty;
                string reversedText = String.Empty;

                //if (!Regex.IsMatch(text, "^[a-zA-Z0-9]*$"))
                // Check if the text contains non-ASCII characters
                if (!Regex.IsMatch(text, @"^[\u0000-\u007F]*$"))
                {
                    reversedText = ReverseTextForRTL(text);
                    finalText = '\u2007' + reversedText;
                }
                else
                {
                    finalText = text;

                }

                pdfContentByte.ShowText(finalText);
                pdfContentByte.EndText();
            }
            catch (Exception exc)
            {
                pdfContentByte.EndText();

            }
        }
        private float CalculateMaxFontSize_Original(string text, float width, float height, string fontFilePath)
        {
            float fontSize = 1.0f;
            BaseFont baseFont = BaseFont.CreateFont(fontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            while (true)
            {
                // Calculate text width and height using BaseFont
                float textWidth = baseFont.GetWidthPoint(text, fontSize);
                float textHeight = baseFont.GetAscentPoint(text, fontSize) - baseFont.GetDescentPoint(text, fontSize);

                // Check if text fits within width and height
                if (textWidth < width && textHeight < height)
                    fontSize++;
                else
                    break;
            }

            return fontSize - 1; // Return the maximum font size that fits
        }

        //new code
        private void DrawTextWithinRectangle(PdfContentByte pdfContentByte, string text, float x, float y, float width, float height, float fontSize, BaseFont baseFont)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(text) || fontSize <= 0 || width <= 0 || height <= 0)
                    return;

                // Calculate text dimensions
                float textWidth = baseFont.GetWidthPoint(text, fontSize);
                float textHeight = baseFont.GetAscentPoint(text, fontSize) - baseFont.GetDescentPoint(text, fontSize);

                // Calculate centering offsets
                float offsetX = (width - textWidth) / 2;
                float offsetY = (height - textHeight) / 2 + baseFont.GetDescentPoint(text, fontSize);

                // Clamp offsets to prevent text from going outside bounds
                offsetX = Math.Max(0, Math.Min(offsetX, width * 0.9f));
                offsetY = Math.Max(0, offsetY);

                // Begin text rendering
                pdfContentByte.BeginText();

                // CRITICAL: Set to INVISIBLE mode BEFORE setting font
                // This makes text searchable but NOT visible
                pdfContentByte.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_INVISIBLE);

                pdfContentByte.SetFontAndSize(baseFont, fontSize);

                // Set text position with calculated offsets
                pdfContentByte.SetTextMatrix(x + offsetX, y + offsetY);

                // Render the ORIGINAL text (do NOT reverse for invisible mode)
                // Invisible mode doesn't need RTL reversal - it's for search indexing only
                pdfContentByte.ShowText(text);

                pdfContentByte.EndText();
            }
            catch (Exception ex)
            {
                // Safely close text context if exception occurs
                try
                {
                    pdfContentByte.EndText();
                }
                catch { }

                // Log the error but don't fail the entire operation
            }
        }
        private float CalculateMaxFontSize(string text, float width, float height, string fontFilePath)
        {
            // Validate input dimensions
            if (width <= 0 || height <= 0 || string.IsNullOrEmpty(text))
                return 0f;

            try
            {
                BaseFont baseFont = BaseFont.CreateFont(fontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                // Binary search for optimal font size
                float low = 0.5f;
                float high = Math.Min(100f, height * 2f); // Cap at reasonable maximum
                float bestSize = 0.5f;
                int iterations = 0;
                const int maxIterations = 20; // Prevent infinite loops

                while (high - low > 0.1f && iterations < maxIterations)
                {
                    iterations++;
                    float mid = (low + high) / 2f;

                    float textWidth = baseFont.GetWidthPoint(text, mid);
                    float textHeight = baseFont.GetAscentPoint(text, mid) - baseFont.GetDescentPoint(text, mid);

                    // Check if text fits with small margin
                    const float margin = 1.05f; // 5% margin
                    if (textWidth < width / margin && textHeight < height / margin)
                    {
                        bestSize = mid;
                        low = mid;
                    }
                    else
                    {
                        high = mid;
                    }
                }

                return bestSize;
            }
            catch (Exception ex)
            {
                return 8.0f; // Safe default font size
            }
        }


        // Function to reverse text for RTL display
        private string ReverseTextForRTL(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ' || c == '-' || c == ',')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public Dictionary<string, object> ToDictionary(object model)
        {
            var serializedModel = JsonConvert.SerializeObject(model);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedModel);
        }

        public string[] GetTitlesbyId(int? categoryId, int? subCategoryId, int? countryId, int? languageId, int? bookTypeId)
        {
            string[] allTitles = new string[5];

            if (categoryId != null)
            {
                var categoryTitle = _context.ElMCategories
                      .Where(c => c.Id == categoryId)
                      .Select(c => c.Title)
                      .FirstOrDefault();
                allTitles[0] = categoryTitle.ToString();

            }

            if (subCategoryId != null)
            {
                var subCategoryTitle = _context.ElMSubCategories
                         .Where(s => s.Id == subCategoryId)
                         .Select(s => s.Title)
                         .FirstOrDefault();
                allTitles[1] = subCategoryTitle.ToString();

            }

            if (countryId != null)
            {
                var countryTitle = _context.ElMCountries
                     .Where(c => c.Id == countryId)
                     .Select(c => c.Title)
                     .FirstOrDefault();
                allTitles[2] = countryTitle.ToString();
            }

            if (languageId != null)
            {
                var languageTitle = _context.ElMLanguages
                               .Where(l => l.Id == languageId)
                               .Select(l => l.Title)
                               .FirstOrDefault();
                allTitles[3] = languageTitle.ToString();

            }

            if (bookTypeId != null)
            {
                var bookTypeTitle = _context.ElMBookTypes
                                      .Where(b => b.Id == bookTypeId)
                                      .Select(b => b.Title)
                                      .FirstOrDefault();
                allTitles[4] = bookTypeTitle.ToString();

            }
            return allTitles;

        }

        public async Task<string[]> StartBookEditProcess(IFormCollection files, BookModel bookModel)
        {
            string[] BlobUrls = new string[3];
            //IFormFile bookFile = files.Files.SingleOrDefault(item => item.Name == "bookfile");
            //IFormFile bookThumbnailFile = files.Files.SingleOrDefault(item => item.Name == "thumbnailfile");
            //IFormFile bookApproverAttachmentFile = files.Files.SingleOrDefault(item => item.Name == "approverattachmentfile");

            //Upload file to blob storage
            string folderNameForBookFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/BookFile";
            string folderNameForBookThumbnailFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/Thumbnail";
            string folderNameForApproverAttachmentFile = "/BooksOriginal/" + bookModel.UniqueFolderName + "/ApproverAttachment";

            string bookFileBlobUrl = String.Empty;
            string thumbnailFileBlobUrl = String.Empty;
            string approverAttachmentFileBlobUrl = String.Empty;
            var updatedMetadata = await UpdateOnlyMetadatainBlob(bookModel.bookfile, folderNameForBookFile, bookModel);

            if (bookModel.bookfile != null)
            {
                bookFileBlobUrl = await UpdateOnlyFileinBlob(bookModel.bookfile, folderNameForBookFile, updatedMetadata);
            }

            if (bookModel.thumbnailfile != null)
            {
                thumbnailFileBlobUrl = await UpdateOnlyFileinBlob(bookModel.thumbnailfile, folderNameForBookThumbnailFile, updatedMetadata);
            }

            if (bookModel.approverattachmentfile != null)
            {
                approverAttachmentFileBlobUrl = await UpdateOnlyFileinBlob(bookModel.approverattachmentfile, folderNameForApproverAttachmentFile, updatedMetadata);
            }

            BlobUrls[0] = bookFileBlobUrl;
            BlobUrls[1] = thumbnailFileBlobUrl;
            BlobUrls[2] = approverAttachmentFileBlobUrl;

            return BlobUrls;
        }

        public async Task<string> UpdateOnlyFileinBlob(IFormFile item, string blobFolderName, IDictionary<string, string> metadata)
        {
            Stream myBlob = new MemoryStream();
            myBlob = item.OpenReadStream();

            FileInfo fi = new FileInfo(item.FileName);
            string extn = fi.Extension;

            string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();
            string uniqueFileName = uniqueFolderName + extn;


            //new method for handling large files
            string newblobFolderName = blobFolderName.Substring(1);
            // Create a new file in the Data Lake store
            var fileClient = fileSystemClient.GetFileClient(newblobFolderName + "/" + uniqueFileName);
            // Open the source file stream
            using (var sourceStream = myBlob)
            {
                var transferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 4 * 1024 * 1024,    // Set the maximum transfer size (optional)
                    InitialTransferSize = 4 * 1024 * 1024      // Set the initial transfer size (optional)

                };
                var uploadOptions = new DataLakeFileUploadOptions
                {
                    TransferOptions = transferOptions,
                    ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes")) // Progress handler (optional)
                };
                await fileClient.UploadAsync(sourceStream, uploadOptions);
            }

            //Retrieve the uploaded file properties
            var propertiesNew = await fileClient.GetPropertiesAsync();

            //Access the file URL
            var fileUrl = fileClient.Uri.ToString();


            //DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(blobFolderName);
            //DataLakeFileClient fileClient = directoryClient.GetFileClient(item.FileName);

            //var data = await _dataLakeHandler.UploadFile(myBlob, blobFolderName, item.FileName, item.ContentType);

            if (blobFolderName.Contains("/BookFile"))
            {
                await fileClient.SetMetadataAsync(metadata);
            }
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

        public async Task<IDictionary<string, string>> UpdateOnlyMetadatainBlob(IFormFile item, string blobFolderName, BookModel bookModel)
        {
            Uri uri = new Uri(bookModel.BookUrl);
            string queryString = uri.Query;
            Uri uri2 = new Uri(queryString.Replace("?url=", ""));
            string filename = System.IO.Path.GetFileName(uri2.LocalPath);

            string newblobFolderNameForOCR = blobFolderName.Replace("BooksOriginal", "Books");
            string fileNameForOCR = "ocr_" + filename;

            //string filename = GetFileNameFromUrl(bookModel.BookUrl);
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(newblobFolderNameForOCR);
            DataLakeFileClient fileClient = directoryClient.GetFileClient(fileNameForOCR);

            //Getting existing metadata
            var existingblobMetadata = fileClient.GetProperties();

            //Converting new Metadata to Dictionary    
            string[] allTitle = GetTitlesbyId(bookModel.Category, bookModel.SubCategory, bookModel.Country, bookModel.Language, bookModel.BookType);

            Dictionary<string, string> newDictMetadata = new Dictionary<string, string>();
            PropertyInfo[] properties = typeof(BookModel).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(bookModel);
                if (value != null)
                {
                    if (property.Name == "Category")
                    {
                        string propertyValue = allTitle[0].Trim();
                        //propertyValue = RemoveSpecialCharacters(propertyValue);
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                        string base64String = System.Convert.ToBase64String(plainTextBytes);

                        newDictMetadata.Add(property.Name, base64String);

                    }
                    else if (property.Name == "SubCategory")
                    {
                        string propertyValue = allTitle[1].Trim();
                        //propertyValue = RemoveSpecialCharacters(propertyValue);
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                        string base64String = System.Convert.ToBase64String(plainTextBytes);

                        newDictMetadata.Add(property.Name, base64String);

                    }
                    else if (property.Name == "BookType")
                    {
                        string propertyValue = allTitle[4].Trim();
                        propertyValue = RemoveSpecialCharacters(propertyValue);

                        newDictMetadata.Add(property.Name, propertyValue);

                    }
                    else if (property.Name == "Language")
                    {
                        string propertyValue = allTitle[3].Trim();
                        propertyValue = RemoveSpecialCharacters(propertyValue);

                        newDictMetadata.Add(property.Name, propertyValue);

                    }
                    else if (property.Name == "Country")
                    {
                        string propertyValue = allTitle[2].Trim();
                        propertyValue = RemoveSpecialCharacters(propertyValue);

                        newDictMetadata.Add(property.Name, propertyValue);
                    }
                    else if (property.Name == "ArabicKeywords" || property.Name == "BookTitleArabic" || property.Name == "Description" || property.Name == "Author" || property.Name == "Version" || property.Name == "VolumeNumber" || property.Name == "Publication")
                    {
                        string propertyValue = value.ToString().Trim();

                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(propertyValue);
                        string base64String = System.Convert.ToBase64String(plainTextBytes);

                        newDictMetadata.Add(property.Name, base64String);
                    }
                    else
                    {
                        string propertyValue = value.ToString().Trim();
                        propertyValue = RemoveSpecialCharacters(propertyValue);

                        newDictMetadata.Add(property.Name, propertyValue);

                    }
                }
            }

            //Comparing with New Metadata and replacing

            foreach (var data in newDictMetadata)
            {
                if (existingblobMetadata.Value.Metadata.ContainsKey(data.Key))
                {
                    // Key is already present, update the value
                    existingblobMetadata.Value.Metadata[data.Key] = data.Value;
                }
                else
                {
                    // Key is not present, add it with corresponding value
                    existingblobMetadata.Value.Metadata.Add(data.Key, data.Value);
                }
            }

            await fileClient.SetMetadataAsync(existingblobMetadata.Value.Metadata);

            return existingblobMetadata.Value.Metadata;

        }

        public bool CreateItemInLinkedBooks(int bookId, string linkedBooksId)
        {
            string[] linkedBooksIdArray = linkedBooksId.Split(',');

            foreach (string referBookId in linkedBooksIdArray)
            {
                var linkedBook = new ElTLinkedBook
                {
                    BookId = bookId,
                    ReferBookId = Convert.ToInt32(referBookId)
                };

                var linkedBookReverse = new ElTLinkedBook
                {
                    BookId = Convert.ToInt32(referBookId),
                    ReferBookId = bookId
                };
                _context.ElTLinkedBooks.Add(linkedBook);
                _context.ElTLinkedBooks.Add(linkedBookReverse);

            }
            _context.SaveChanges();



            return true;
        }

        public bool DeleteItemInLinkedBooks(int bookId, string linkedBooksId)
        {
            string[] linkedBooksIdArray = linkedBooksId.Split(',');

            foreach (string referBookId in linkedBooksIdArray)
            {
                //Deleting from Linked 
                var linkedDocumentsToDelete = _context.ElTLinkedBooks.Where(x => (x.BookId == bookId && x.ReferBookId == Convert.ToInt32(referBookId)) || (x.ReferBookId == bookId && x.BookId == Convert.ToInt32(referBookId)));
                _context.ElTLinkedBooks.RemoveRange(linkedDocumentsToDelete);

            }
            _context.SaveChanges();



            return true;
        }

        /// <summary>
        /// Search Book
        /// </summary>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <param name="IsGeneralView"></param>
        /// <returns></returns>
        //       public BookSearchModel SearchBooks(string query, string filter, int top, int skip, bool? IsGeneralView = false)
        //       {
        //           string finalQuery = String.Empty;

        //           if (query != "*" && !query.StartsWith("\""))
        //           {
        //               query = TranslatedText(query);
        //           }

        //		if (filter != "all")
        //           {
        //               filter = " and " + filter;
        //			string pattern = @"(?<=\w)'(?=\w)";

        //			// Replace single quotes in the middle with two single quotes using Regex.Replace
        //               filter = Regex.Replace(filter, pattern, "''");

        //		}
        //		else
        //           {
        //               filter = String.Empty;
        //           }

        //           if (IsGeneralView == true)
        //           {
        //			finalQuery = query + "&$filter=UniqueFolderName ne null and VisibilityOfBook eq 'Public'" + filter + "&$highlight=merged_content,content&$top=" + top+"&$skip="+skip+"&$count=true";

        //		}
        //		else
        //           {
        //			finalQuery = query + "&$filter=UniqueFolderName ne null" + filter + "&$highlight=merged_content,content&$top=" + top + "&$skip=" + skip + "&$count=true";

        //		}

        //		if (finalQuery.Contains("Author"))
        //           {
        //               finalQuery = finalQuery.Replace("Author", "AuthorDecoded");
        //           }
        //           if (finalQuery.Contains("Publication"))
        //           {
        //               finalQuery = finalQuery.Replace("Publication", "PublicationDecoded");
        //           }
        //           if (finalQuery.Contains("Category"))
        //           {
        //               finalQuery = finalQuery.Replace("Category", "CategoryDecoded");
        //           }

        //           var configuration = new ConfigurationBuilder()
        //      .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //      .AddJsonFile("appsettings.json")
        //      .Build();
        //           // Read the file path from the configuration
        //           string searchServiceUrl = configuration["SearchServiceUrl"];
        //           string searchServiceKey = configuration["SearchServiceAPIKey"];
        //           string searchAPIVersion = configuration["SearchAPIVersion"];

        //           var client = new RestClient(searchServiceUrl + "/docs?api-version=" + searchAPIVersion + "&search=" + finalQuery);
        //           var request = new RestRequest("", Method.Get);
        //           request.Timeout = -1;
        //           request.AddHeader("api-key", searchServiceKey);
        //           RestResponse response = client.Execute(request);
        //		BookSearchModel searchResultsFinal = new BookSearchModel();

        //		if (response.IsSuccessStatusCode && response.Content!=null)
        //           {
        //			BookSearchModel searchResults = JsonConvert.DeserializeObject<BookSearchModel>(response.Content);
        //			//Get Data from DB Table based on Search results

        //			if (searchResults != null && searchResults.value != null && searchResults.value.Count > 0)
        //			{
        //				var folderNames = new List<string>();

        //				foreach (Value resultValues in searchResults.value)
        //				{
        //					folderNames.Add(resultValues.UniqueFolderName);
        //				}

        //				var result = (from book in _context.ElTBooks
        //							  where folderNames.Contains(book.UniqueFolderName) && book.IsDeleted != true
        //							  select new
        //							  {
        //								  book.BookTitleEnglish,
        //								  book.BookId,
        //								  book.BookUrl,
        //								  book.ThumbnailUrl,
        //								  book.UniqueFolderName,
        //								  book.UpdatedDate,
        //								  book.ApproverDateTime,
        //								  book.Description,
        //								  book.Author
        //							  }).ToList();

        //				//Rearranging again based on Search result ranking
        //				result = result
        //.OrderBy(bd => Array.IndexOf(searchResults.value.Select(b => b.UniqueFolderName).ToArray(), bd.UniqueFolderName))
        //.ToList();

        //				searchResultsFinal.value = new List<Value>();

        //				for (int index = 0; index < result.Count; index++)
        //				{
        //					string UniqueFolderName = result[index].UniqueFolderName;

        //					var searchResultIndividual = searchResults.value.Where(x => x.UniqueFolderName == UniqueFolderName).FirstOrDefault();

        //					if (searchResultIndividual != default(Value))
        //					{
        //						searchResultIndividual.BookTitleEnglish = result[index].BookTitleEnglish;
        //						searchResultIndividual.BookID = result[index].BookId;
        //						searchResultIndividual.BookUrl = result[index].BookUrl;
        //						searchResultIndividual.ThumbnailUrl = result[index].ThumbnailUrl;
        //						searchResultIndividual.UpdatedDate = result[index].UpdatedDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
        //						searchResultIndividual.ApproverDateTime = result[index].ApproverDateTime?.ToString("yyyy-MM-ddTHH:mm:ssZ");
        //						searchResultIndividual.Description = result[index].Description;
        //						searchResultIndividual.Author = result[index].Author;

        //						searchResultsFinal.value.Add(searchResultIndividual);
        //					}

        //				}

        //				searchResultsFinal.odatacount = searchResults.odatacount;
        //				return searchResultsFinal;

        //			}
        //			else
        //               {
        //                   return searchResults;
        //			}

        //		}
        //           else
        //           {
        //               searchResultsFinal.Message = response.StatusCode + response.Content;
        //               searchResultsFinal.value = new List<Value>();
        //               searchResultsFinal.value.Add(new Value());
        //			return searchResultsFinal;

        //		}

        //       }

        #region UAT code
        //    public BookSearchModel SearchBooks(string query, string filter, int top, int skip, bool? IsGeneralView = false)
        //    {
        //        // string finalQuery = String.Empty;

        //        //if (query != "*" && !query.StartsWith("\""))
        //        //{
        //        //    query = TranslatedText(query);
        //        //}

        //        //if (filter != "all")
        //        //{
        //        //    filter = " and " + filter;
        //        //    string pattern = @"(?<=\w)'(?=\w)";

        //        //    // Replace single quotes in the middle with two single quotes using Regex.Replace
        //        //    filter = Regex.Replace(filter, pattern, "''");

        //        //}
        //        //else
        //        //{
        //        //    filter = String.Empty;
        //        //}
        //        string finalQuery = "UniqueFolderName ne null";

        //        if (IsGeneralView == true)
        //            finalQuery += " and VisibilityOfBook eq 'Public'";

        //        if (!string.IsNullOrEmpty(filter) && filter != "all")
        //            finalQuery += " and " + filter;
        //        string highlightFields =
        //            "content," +
        //            "BookTitleEnglish," +
        //            "BookTitleArabic," +
        //            "BookTitleArabicInArabic," +
        //            "Author," +
        //            "AuthorDecoded," +
        //            "Publication," +
        //            "PublicationDecoded," +
        //            "Category," +
        //            "CategoryDecoded," +
        //            "SubCategory," +
        //            "SubCategoryDecoded," +
        //            "Description," +
        //            "DescriptionDecoded," +
        //            "EnglishKeywords," +
        //            "ArabicKeywords," +
        //            "ArabicKeywordsInArabic";


        //        //if (IsGeneralView == true)
        //        //{
        //        //    // finalQuery = query + "&$filter=UniqueFolderName ne null and VisibilityOfBook eq 'Public'" + filter + "&$highlight=merged_content,content&$top=300&$skip=0&$count=true";
        //        //    finalQuery = query + "&$filter=UniqueFolderName ne null and VisibilityOfBook eq 'Public'" + filter + "&$highlight=" + highlightFields + "&$top=300&$skip=0&$count=true";
        //        //}
        //        //else
        //        //{
        //        //    //finalQuery = query + "&$filter=UniqueFolderName ne null" + filter + "&$highlight=merged_content,content&$top=300&$skip=0&$count=true";
        //        //    finalQuery = query + "&$filter=UniqueFolderName ne null" + filter + "&$highlight=" + highlightFields + "&$top=300&$skip=0&$count=true";
        //        //}

        //        //if (finalQuery.Contains("Author"))
        //        //{
        //        //    finalQuery = finalQuery.Replace("Author", "AuthorDecoded");
        //        //}
        //        //if (finalQuery.Contains("Publication"))
        //        //{
        //        //    finalQuery = finalQuery.Replace("Publication", "PublicationDecoded");
        //        //}
        //        //if (finalQuery.Contains("Category"))
        //        //{
        //        //    finalQuery = finalQuery.Replace("Category", "CategoryDecoded");
        //        //}
        //        finalQuery = Regex.Replace(
        //            finalQuery,
        //            @"\bAuthor\s+eq\b",
        //            "AuthorDecoded eq",
        //            RegexOptions.IgnoreCase
        //        );

        //        finalQuery = Regex.Replace(

        //            finalQuery,
        //            @"\bPublication\s+eq\b",
        //            "PublicationDecoded eq",
        //            RegexOptions.IgnoreCase
        //        );

        //        finalQuery = Regex.Replace(
        //            finalQuery,
        //            @"\bSubCategory\s+eq\b",
        //            "SubCategoryDecoded eq",
        //            RegexOptions.IgnoreCase
        //        );



        //        var configuration = new ConfigurationBuilder()
        //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //   .AddJsonFile("appsettings.json")
        //   .Build();
        //        // Read the file path from the configuration
        //        string searchServiceUrl = configuration["SearchServiceUrl"];
        //        string searchServiceKey = configuration["SearchServiceAPIKey"];
        //        string searchAPIVersion = configuration["SearchAPIVersion"];
        //        //
        //        string url =
        //          $"{searchServiceUrl}/docs" +
        //          $"?api-version={searchAPIVersion}" +
        //          $"&search={Uri.EscapeDataString(query)}" +
        //          $"&$filter={Uri.EscapeDataString(finalQuery)}" +
        //          $"&highlight={Uri.EscapeDataString(highlightFields)}" +
        //          $"&$top=300" +
        //          $"&$skip=0" +
        //          $"&$count=true";

        //        //string url = searchServiceUrl + "/docs?api-version=" + searchAPIVersion + "&search=" + finalQuery;
        //        //var client = new RestClient(searchServiceUrl + "/docs?api-version=" + searchAPIVersion + "&search=" + finalQuery);
        //        var client = new RestClient(url);
        //        var request = new RestRequest("", Method.Get);
        //        request.Timeout = -1;
        //        request.AddHeader("api-key", searchServiceKey);
        //        RestResponse response = client.Execute(request);
        //        BookSearchModel searchResultsFinal = new BookSearchModel();

        //        if (response.IsSuccessStatusCode && response.Content != null)
        //        {
        //            BookSearchModel searchResults = JsonConvert.DeserializeObject<BookSearchModel>(response.Content);
        //            //Get Data from DB Table based on Search results

        //            if (searchResults != null && searchResults.value != null && searchResults.value.Count > 0)
        //            {
        //                var folderNames = new List<string>();

        //                foreach (Value resultValues in searchResults.value)
        //                {
        //                    folderNames.Add(resultValues.UniqueFolderName);
        //                }

        //                var result = (from book in _context.ElTBooks
        //                              where folderNames.Contains(book.UniqueFolderName) && book.IsDeleted != true
        //                              select new
        //                              {
        //                                  book.BookTitleEnglish,
        //                                  book.BookId,
        //                                  book.BookUrl,
        //                                  book.ThumbnailUrl,
        //                                  book.UniqueFolderName,
        //                                  book.UpdatedDate,
        //                                  book.ApproverDateTime,
        //                                  book.Description,
        //                                  book.Author
        //                              }).ToList();

        //                //Rearranging again based on Search result ranking
        //                result = result
        //.OrderBy(bd => Array.IndexOf(searchResults.value.Select(b => b.UniqueFolderName).ToArray(), bd.UniqueFolderName))
        //.ToList();

        //                searchResultsFinal.value = new List<Value>();

        //                for (int index = 0; index < result.Count; index++)
        //                {
        //                    string UniqueFolderName = result[index].UniqueFolderName;

        //                    var searchResultIndividual = searchResults.value.Where(x => x.UniqueFolderName == UniqueFolderName).FirstOrDefault();

        //                    Dictionary<string, string> highlightFieldMap = new()
        //                    {
        //                        { "content", "File Content" },
        //                        { "merged_content", "File Content" },

        //                        { "BookTitleEnglish", " English Title" },
        //                      //  { "BookTitleArabic", "Title (Arabic Encoded)" },
        //                        { "BookTitleArabicInArabic", "Arabic Title" },

        //                        { "Author", "Author" },
        //                        { "AuthorDecoded", "Author" },

        //                        { "Publication", "Publication" },
        //                        { "PublicationDecoded", "Publication" },

        //                        { "Category", "Category" },
        //                        { "CategoryDecoded", "Category" },

        //                        { "SubCategory", "Sub Category" },
        //                        { "SubCategoryDecoded", "Sub Category" },

        //                        { "Description", "Description" },
        //                        { "DescriptionDecoded", "Description" },

        //                        { "EnglishKeywords", "English Keywords" },
        //                        { "ArabicKeywords", "Arabic Keywords" },
        //                       // { "ArabicKeywordsInArabic", "Keywords" },

        //                        { "Version", "Book Version" },
        //                        { "VersionDecoded", "Book Version" },

        //                        { "VolumeNumber", "Volumn Number" },
        //                        { "VolumeNumberDecoded", "Volumn Number" }
        //                    };
        //                    if (searchResultIndividual != default(Value))
        //                    {
        //                        searchResultIndividual.BookTitleEnglish = result[index].BookTitleEnglish;
        //                        searchResultIndividual.BookID = result[index].BookId;
        //                        searchResultIndividual.BookUrl = result[index].BookUrl;
        //                        searchResultIndividual.ThumbnailUrl = result[index].ThumbnailUrl;
        //                        searchResultIndividual.UpdatedDate = result[index].UpdatedDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
        //                        searchResultIndividual.ApproverDateTime = result[index].ApproverDateTime?.ToString("yyyy-MM-ddTHH:mm:ssZ");
        //                        searchResultIndividual.Description = result[index].Description;
        //                        searchResultIndividual.Author = result[index].Author;

        //                        if (!string.IsNullOrEmpty(query) && query != "*")
        //                        {
        //                            // filter the match result from the response
        //                            if (searchResultIndividual.searchhighlights == null || searchResultIndividual.searchhighlights.Count == 0)
        //                                continue;

        //                            foreach (var field in searchResultIndividual.searchhighlights.Keys)
        //                            {
        //                                if (highlightFieldMap.TryGetValue(field, out var displayName))
        //                                {
        //                                    if (!searchResultIndividual.MatchSources.Contains(displayName))
        //                                    {
        //                                        searchResultIndividual.MatchSources.Add(displayName);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        searchResultsFinal.value.Add(searchResultIndividual);
        //                    }
        //                }
        //                searchResultsFinal.odatacount = searchResultsFinal.value.Count;
        //                searchResultsFinal.value = searchResultsFinal.value.Skip(skip).Take(top).ToList();
        //                return searchResultsFinal;

        //            }
        //            else
        //            {
        //                return searchResults;
        //            }

        //        }
        //        else
        //        {
        //            searchResultsFinal.Message = response.StatusCode + response.Content;
        //            searchResultsFinal.value = new List<Value>();
        //            searchResultsFinal.value.Add(new Value());
        //            return searchResultsFinal;

        //        }

        //    }
        #endregion

        #region     RBAC implemetation code
        public BookSearchModel SearchBooks(string query, string filter, int top, int skip, bool? IsGeneralView = false)
        {
            string finalQuery = "UniqueFolderName ne null";

            if (IsGeneralView == true)
                finalQuery += " and VisibilityOfBook eq 'Public'";

            if (!string.IsNullOrEmpty(filter) && filter != "all")
            {
                // Escape single quotes properly
                filter = Regex.Replace(filter, @"(?<=\w)'(?=\w)", "''");
                string pattern = @"(?<=\w)'(?=\w)";
                finalQuery += " and " + filter;
             }

            finalQuery = Regex.Replace(
                 finalQuery,
                 @"\bAuthor\s+eq\b",
                 "AuthorDecoded eq",
                 RegexOptions.IgnoreCase
             );

            finalQuery = Regex.Replace(

                finalQuery,
                @"\bPublication\s+eq\b",
                "PublicationDecoded eq",
                RegexOptions.IgnoreCase
            );

            finalQuery = Regex.Replace(
                finalQuery,
                @"\bCategory\s+eq\b",
                "CategoryDecoded eq",
                RegexOptions.IgnoreCase
            );

            finalQuery = Regex.Replace(
                finalQuery,
                @"\bSubCategory\s+eq\b",
                "SubCategoryDecoded eq",
                RegexOptions.IgnoreCase
            );


            string highlightFields =
                "content," +
                "BookTitleEnglish," +
                "BookTitleArabic," +
                "BookTitleArabicInArabic," +
                "Author," +
                "AuthorDecoded," +
                "Publication," +
                "PublicationDecoded," +
                "Category," +
                "CategoryDecoded," +
                "SubCategory," +
                "SubCategoryDecoded," +
                "Description," +
                "DescriptionDecoded," +
                "EnglishKeywords," +
                "ArabicKeywords," +
                "ArabicKeywordsInArabic";

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string searchServiceUrl = configuration["SearchServiceUrl"];
            string indexName = configuration["searchIndexName"];
            //string searchServiceKey = configuration["SearchServiceAPIKey"];
            //string searchAPIVersion = configuration["SearchAPIVersion"];

            Uri endpoint = new Uri(searchServiceUrl);

            // RBAC Authentication
            //var credentials = new DefaultAzureCredential();

            // enable below code test in local environment
            var credentials = new ChainedTokenCredential(
               new VisualStudioCredential(),
               new AzureCliCredential()
               );

            SearchClient searchCliet = new SearchClient(
                endpoint,
                indexName,
                credentials
                );

            SearchOptions options = new SearchOptions()
            {
                Filter = finalQuery,
                Size = 300,
                Skip = 0,
                IncludeTotalCount = true
            };

            foreach(var field in highlightFields.Split(','))
            {
                options.HighlightFields.Add(field.Trim());
            }

            string searchText = string.IsNullOrWhiteSpace(query) ? "*" : query;
            BookSearchModel searchResultsFinal = new BookSearchModel();
            SearchResults<SearchDocument> response;
            try
            {
                response = searchCliet.Search<SearchDocument>(
                    searchText,
                    options
                    );
            }
            catch(RequestFailedException ex)
            {
                _logger.LogError(ex, "Azure Ai Search failed. Filter: {Filter}",
                    options.Filter);
                searchResultsFinal.Message = "Invalid search filter.";
                searchResultsFinal.value = new List<Value>();
                searchResultsFinal.odatacount = 0;
                return searchResultsFinal;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while searching.",
                  options.Filter);
                searchResultsFinal.Message = "An unexpected error occured while searching.";
                searchResultsFinal.value = new List<Value>();
                searchResultsFinal.odatacount = 0;
                return searchResultsFinal;
            }

            BookSearchModel searchResults = new BookSearchModel();
            searchResults.value = new List<Value>();

            foreach (SearchResult<SearchDocument> result in response.GetResults())
            {
                var doc = result.Document;
                Value item = new Value();
                item.searchscore = Convert.ToInt32(result.Score);
                item.UniqueFolderName =
                    doc.ContainsKey("UniqueFolderName")
                    ? doc["UniqueFolderName"]?.ToString()
                    : null;

                item.BookTitleEnglish =
                    doc.ContainsKey("BookTitleEnglish")
                    ? doc["BookTitleEnglish"]?.ToString()
                    : null;

                item.BookTitleArabic =
                   doc.ContainsKey("BookTitleArabicinArabic")
                   ? doc["BookTitleArabicinArabic"]?.ToString()
                   : null;

                item.Author =
                   doc.ContainsKey("AuthorDecoded")
                   ? doc["AuthorDecoded"]?.ToString()
                   : null;

                item.Publication =
                   doc.ContainsKey("PublicationDecoded")
                   ? doc["PublicationDecoded"]?.ToString()
                   : null;

                item.Category =
                   doc.ContainsKey("CategoryDecoded")
                   ? doc["CategoryDecoded"]?.ToString()
                   : null;

                item.SubCategory =
                   doc.ContainsKey("SubCategoryDecoded")
                   ? doc["SubCategoryDecoded"]?.ToString()
                   : null;

                item.Description =
                   doc.ContainsKey("Description")
                   ? doc["Description"]?.ToString()
                   : null;

                item.Version =
                   doc.ContainsKey("VersionDecoded")
                   ? doc["VersionDecoded"]?.ToString()
                   : null;

                item.VolumeNumber =
                   doc.ContainsKey("VolumeNumberDecoded")
                   ? doc["VolumeNumberDecoded"]?.ToString()
                   : null;

                if (result.Highlights != null && result.Highlights.Count > 0)
                {
                    item.searchhighlights = new Dictionary<string, string[]>();
                    foreach(var highlight in result.Highlights)
                    {
                        item.searchhighlights.Add(
                            highlight.Key,
                            highlight.Value.ToArray()
                        );
                    }
                }
                searchResults.value.Add(item);
            }

            searchResults.odatacount = searchResults.value.Count;

            if(searchResults != null && searchResults.value !=null && searchResults.value.Count > 0)
            {
                var folderNames = new List<string>();
                foreach (Value resultValues in searchResults.value)
                {
                    folderNames.Add(resultValues.UniqueFolderName);
                }
                var result = (from book in _context.ElTBooks
                              where folderNames.Contains(book.UniqueFolderName) && book.IsDeleted != true
                              select new
                              {
                                  book.BookTitleEnglish,
                                  book.BookId,
                                  book.BookUrl,
                                  book.ThumbnailUrl,
                                  book.UniqueFolderName,
                                  book.UpdatedDate,
                                  book.ApproverDateTime,
                                  book.Description,
                                  book.Author
                              }).ToList();

                //Rearranging again based on Search result ranking
                result = result
                    .OrderBy(bd => Array.IndexOf(searchResults.value.Select(b => b.UniqueFolderName).ToArray(), bd.UniqueFolderName))
                    .ToList();

                searchResultsFinal.value = new List<Value>();

                for (int index = 0; index < result.Count; index++)
                {
                    string UniqueFolderName = result[index].UniqueFolderName;

                    var searchResultIndividual = searchResults.value.Where(x => x.UniqueFolderName == UniqueFolderName).FirstOrDefault();

                    if(!string.IsNullOrWhiteSpace(query) && query != "*")
                    {
                         if(searchResultIndividual.searchhighlights == null ||
                            searchResultIndividual.searchhighlights.Count == 0)
                        {
                            continue; // skip non-mathing records
                        }
                    }

                    Dictionary<string, string> highlightFieldMap = new()
                            {
                                { "content", "File Content" },
                                { "merged_content", "File Content" },

                                { "BookTitleEnglish", " English Title" },
                                { "BookTitleArabicInArabic", "Arabic Title" },

                                { "Author", "Author" },
                                { "AuthorDecoded", "Author" },

                                { "Publication", "Publication" },
                                { "PublicationDecoded", "Publication" },

                                { "Category", "Category" },
                                { "CategoryDecoded", "Category" },

                                { "SubCategory", "Sub Category" },
                                { "SubCategoryDecoded", "Sub Category" },

                                { "Description", "Description" },
                                { "DescriptionDecoded", "Description" },

                                { "EnglishKeywords", "English Keywords" },
                                { "ArabicKeywords", "Arabic Keywords" },

                                { "Version", "Book Version" },
                                { "VersionDecoded", "Book Version" },

                                { "VolumeNumber", "Volumn Number" },
                                { "VolumeNumberDecoded", "Volumn Number" }
                            };
                    if (searchResultIndividual != null)
                    {
                        searchResultIndividual.BookTitleEnglish = result[index].BookTitleEnglish;
                        searchResultIndividual.BookID = result[index].BookId;
                        searchResultIndividual.BookUrl = result[index].BookUrl;
                        searchResultIndividual.ThumbnailUrl = result[index].ThumbnailUrl;
                        searchResultIndividual.UpdatedDate = result[index].UpdatedDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
                        searchResultIndividual.ApproverDateTime = result[index].ApproverDateTime?.ToString("yyyy-MM-ddTHH:mm:ssZ");
                        searchResultIndividual.Description = result[index].Description;
                        searchResultIndividual.Author = result[index].Author;

                        if (!string.IsNullOrEmpty(query) && query != "*")
                        {
                            // filter the match result from the response
                            if (searchResultIndividual.searchhighlights != null && searchResultIndividual.searchhighlights.Count > 0)
                            {
                                foreach (var field in searchResultIndividual.searchhighlights.Keys)
                                {
                                    if (highlightFieldMap.TryGetValue(field, out var displayName))
                                    {
                                        if (!searchResultIndividual.MatchSources.Contains(displayName))
                                        {
                                            searchResultIndividual.MatchSources.Add(displayName);
                                        }
                                    }
                                }
                            }  

                            
                        }
                        searchResultsFinal.value.Add(searchResultIndividual);
                    }
                }
                searchResultsFinal.odatacount = searchResultsFinal.value.Count;
                searchResultsFinal.value = searchResultsFinal.value.Skip(skip).Take(top).ToList();
                return searchResultsFinal;
            }
            else
            {
                return searchResults;
            }
        }

        #endregion
        public bool DeleteBookfromAzureBlobAndSearchIndex(string uniqueFolderName)
        {
            string blobFolderName = "/BooksOriginal/" + uniqueFolderName;

            //Deleting from Blob
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(blobFolderName);
            directoryClient.DeleteIfExists();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string searchServiceUrl = configuration["SearchServiceUrl"];
            string searchServiceKey = configuration["SearchServiceAPIKey"];
            string searchAPIVersion = configuration["SearchAPIVersion"];


            //Deleting from Search index
            var client = new RestClient(searchServiceUrl + "/docs?api-version=" + searchAPIVersion + "&search=*&$filter=UniqueFolderName eq '" + uniqueFolderName + "'");

            var request = new RestRequest("", Method.Get);
            request.Timeout = Timeout.InfiniteTimeSpan;
            request.AddHeader("api-key", searchServiceKey);
            RestResponse response = client.Execute(request);
            if (response.Content != null)
            {
                List<BookSearchModel> searchResults = JsonConvert.DeserializeObject<List<BookSearchModel>>("[" + response.Content + "]");

                if (searchResults[0].value.Count > 0)
                {
                    string searchIndexKey = searchResults[0].value[0].metadata_storage_path;
                    //string searchIndexKey = searchResults[0].value[0].id;

                    var clientNew = new RestClient(searchServiceUrl + "/docs/index?api-version=2023-11-01");
                    var requestNew = new RestRequest("", Method.Post);
                    requestNew.Timeout = Timeout.InfiniteTimeSpan;
                    requestNew.AddHeader("api-key", searchServiceKey);
                    requestNew.AddHeader("Content-Type", "application/json");
                    var body = @"{  
            " + "\n" +
                    @"  ""value"": [  
            " + "\n" +
                    @"    {  
            " + "\n" +
                    @"      ""@search.action"": ""delete"",  
            " + "\n" +
                    @"      ""metadata_storage_path"": ""metadata_storage_path_value""  
            " + "\n" +
                    @"    }  
            " + "\n" +
                    @"  ]  
            " + "\n" +
                    @"}";
                    body = body.Replace("metadata_storage_path_value", searchIndexKey);
                    requestNew.AddParameter("application/json", body, ParameterType.RequestBody);
                    RestResponse responseNew = clientNew.Execute(requestNew);
                    Console.WriteLine(responseNew.Content);
                }
            }

            return true;
        }





        public DataLakeFileClient DownloadFile(string url)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string containerName = configuration["ContainerName"];

            Uri uri = new Uri(url);
            string filepath = uri.AbsolutePath.Replace("/" + containerName + "/", "");

            DataLakeFileClient fileClient = fileSystemClient.GetFileClient(filepath);

            return fileClient;
        }

        public string DownloadFile2(string url)
        {
            Uri uri = new Uri(url);
            string filepath = uri.AbsolutePath.Replace("/elibrary/", "");

            //DataLakeFileClient fileClient = fileSystemClient.GetFileClient(filepath);

            return filepath;
        }
        public byte[] StreamToByteArray(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        //public string TranslateToEnglish(string arabicText)
        //{
        //    //var client = new RestClient("https://almasdar-dev-translator.cognitiveservices.azure.com/translator/text/v3.0/translate?api-version=3.0&to=en");
        //    var client = new RestClient("https://almasdar-dev-cs.cognitiveservices.azure.com/translator/text/v3.0/translate?to=en");

        //    var request = new RestRequest("", Method.Post);
        //    request.Timeout = -1; // Set the timeout for the request
        //    request.AddHeader("Ocp-Apim-Subscription-Key", "a7c475ec1b8148f9b729b4188ca8f2f5");
        //    request.AddHeader("Ocp-Apim-Subscription-Region", "uaenorth");
        //    request.AddHeader("Content-Type", "application/json");

        //    var body = @"[" + "\n" + @" {" + "\n" + @" ""Text"":""" + arabicText + @"""" + "\n" + @" }" + "\n" + @"]";
        //    request.AddParameter("application/json", body, ParameterType.RequestBody);

        //    RestResponse response = client.Execute(request);

        //    List<Class1> class1s = new List<Class1>();

        //    class1s = JsonConvert.DeserializeObject<List<Class1>>(response.Content);

        //    string translatedText = class1s[0].translations[0].text;

        //    return translatedText;

        //}

        public bool DeleteElibContainerData()
        {
            foreach (var fileSystemEntry in fileSystemClient.GetPaths())
            {
                if ((bool)fileSystemEntry.IsDirectory)
                {
                    // Delete Book directories recursively
                    if (fileSystemEntry.Name == "Books")
                    {
                        var directoryClient = fileSystemClient.GetDirectoryClient(fileSystemEntry.Name);
                        directoryClient.DeleteIfExists(true);
                    }
                }


                //else
                //{
                //    // Delete individual files
                //    var fileClient = fileSystemClient.GetFileClient(fileSystemEntry.Name);
                //    fileClient.DeleteIfExists();
                //}
            }

            return true;

        }

        public bool DeleteBooksFromSearchIndex()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();
            // Read the file path from the configuration
            string searchServiceUrl = configuration["SearchServiceUrl"];
            string searchServiceKey = configuration["SearchServiceAPIKey"];
            string searchAPIVersion = configuration["SearchAPIVersion"];

            var client = new RestClient(searchServiceUrl + "/docs?api-version=" + searchAPIVersion + "&search=*&$filter=UniqueFolderName ne null&$top=999");
            var request = new RestRequest("", Method.Get);
            request.Timeout = Timeout.InfiniteTimeSpan;
            request.AddHeader("api-key", searchServiceKey);
            RestResponse response = client.Execute(request);
            List<BookSearchModel> searchResults = JsonConvert.DeserializeObject<List<BookSearchModel>>("[" + response.Content + "]");

            if (searchResults[0].value.Count > 0)
            {
                foreach (var values in searchResults[0].value)
                {
                    string searchIndexKey = values.metadata_storage_path;
                    //string searchIndexKey = values.id;


                    var clientNew = new RestClient(searchServiceUrl + "/docs/index?api-version=2023-11-01");
                    var requestNew = new RestRequest("", Method.Post);
                    requestNew.Timeout = Timeout.InfiniteTimeSpan;
                    requestNew.AddHeader("api-key", searchServiceKey);
                    requestNew.AddHeader("Content-Type", "application/json");
                    var body = @"{  
" + "\n" +
                    @"  ""value"": [  
" + "\n" +
                    @"    {  
" + "\n" +
                    @"      ""@search.action"": ""delete"",  
" + "\n" +
                    @"      ""metadata_storage_path"": ""metadata_storage_path_value""  
" + "\n" +
                    @"    }  
" + "\n" +
                    @"  ]  
" + "\n" +
                    @"}";
                    body = body.Replace("metadata_storage_path_value", searchIndexKey);
                    requestNew.AddParameter("application/json", body, ParameterType.RequestBody);
                    RestResponse responseNew = clientNew.Execute(requestNew);
                    Console.WriteLine(responseNew.Content);
                }

            }
            return true;
        }

        public async Task<string> StartDeletionAttachementUploadProcess(IFormCollection files)
        {
            IFormFile deletionApprovalFile = files.Files.SingleOrDefault(item => item.Name == "deletionApprovalFile");

            //Upload file to blob storage
            string folderNameForBookFile = "/BooksDeletion/DeletionApprovalFile";

            string bookFileBlobUrl = String.Empty;
            bookFileBlobUrl = UploadDeletedApprovalFiletoBlob(deletionApprovalFile, folderNameForBookFile).Result;

            return bookFileBlobUrl;
        }


        public async Task<string> UploadDeletedApprovalFiletoBlob(IFormFile item, string blobFolderName)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();

            FileInfo fi = new FileInfo(item.FileName);
            string extn = fi.Extension;

            string uniqueFolderName = DateTime.UtcNow.Ticks.ToString();
            string uniqueFileName = uniqueFolderName + extn;

            Stream myBlob = new MemoryStream();
            myBlob = item.OpenReadStream();

            //new method for handling large files
            string newblobFolderName = blobFolderName.Substring(1);
            // Create a new file in the Data Lake store
            var fileClient = fileSystemClient.GetFileClient(newblobFolderName + "/" + uniqueFileName);
            // Open the source file stream
            using (var sourceStream = myBlob)
            {
                var transferOptions = new StorageTransferOptions
                {
                    MaximumTransferSize = 4 * 1024 * 1024,    // Set the maximum transfer size (optional)
                    InitialTransferSize = 4 * 1024 * 1024     // Set the initial transfer size (optional)

                };
                var uploadOptions = new DataLakeFileUploadOptions
                {
                    TransferOptions = transferOptions,
                    ProgressHandler = new Progress<long>(progress => Console.WriteLine($"Uploaded {progress} bytes")) // Progress handler (optional)
                };
                await fileClient.UploadAsync(sourceStream, uploadOptions);
            }

            //Retrieve the uploaded file properties

            string appServiceUrl = configuration["AppServiceUrl"];
            string url = appServiceUrl + "/api/Books/GetBlobData?url=" + fileClient.Uri.OriginalString;
            return url;

        }

        public string TranslatedText(string text)
        {
            try
            {
                string englishText = String.Empty;
                string arabicText = String.Empty;
                string final_search_text = String.Empty;

                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                    .Build();
                // Read the file path from the configuration
                string YourFormRecognizerEndpoint = configuration["YourFormRecognizerEndpoint"];
                string YourFormRecognizerApiKey = configuration["YourFormRecognizerApiKey"];

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, YourFormRecognizerEndpoint + "translator/text/v3.0/translate?to=ar");
                request.Headers.Add("Ocp-Apim-Subscription-Key", YourFormRecognizerApiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", "uaenorth");

                var body = @"[" + "\n" + @" {" + "\n" + @" ""Text"":""" + text + @"""" + "\n" + @" }" + "\n" + @"]";

                var content = new StringContent(body, null, "application/json");
                request.Content = content;
                var response = client.Send(request);
                var responseContent = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var translations = JArray.Parse(responseContent.Result);
                    if (translations.Count > 0)
                    {
                        arabicText = translations[0]["translations"]?.FirstOrDefault()?["text"]?.ToString();

                    }
                }


                client = new HttpClient();
                request = new HttpRequestMessage(HttpMethod.Post, YourFormRecognizerEndpoint + "translator/text/v3.0/translate?to=en");
                request.Headers.Add("Ocp-Apim-Subscription-Key", YourFormRecognizerApiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", "uaenorth");

                body = @"[" + "\n" + @" {" + "\n" + @" ""Text"":""" + text + @"""" + "\n" + @" }" + "\n" + @"]";

                content = new StringContent(body, null, "application/json");
                request.Content = content;
                response = client.Send(request);
                responseContent = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var translations = JArray.Parse(responseContent.Result);
                    if (translations.Count > 0)
                    {
                        englishText = translations[0]["translations"]?.FirstOrDefault()?["text"]?.ToString();

                    }
                }

                final_search_text = arabicText + " " + englishText;

                return final_search_text;
            }
            catch (Exception ex)
            {
                //Log Error in DB
                ErrorLogModel errorLogModel = new ErrorLogModel();
                errorLogModel.Apiurl = "Elibrary searched keyword translation";
                errorLogModel.StackTrace = Convert.ToString(ex.StackTrace);
                errorLogModel.Source = Convert.ToString(ex.Source);
                errorLogModel.ExceptionMessage = Convert.ToString(ex.Message);
                errorLogModel.CreatedOn = DateTime.UtcNow;
                if (ex.InnerException != null)
                {
                    errorLogModel.InnerException = ex.InnerException.Message + ex.InnerException.ToString();
                }
                DataClass1 dataClass1 = new DataClass1();
                dataClass1.InsertErrorLog(errorLogModel, _context);
                return text;
            }
        }
    }


    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public Detectedlanguage detectedLanguage { get; set; }
        public Translation[] translations { get; set; }
    }

    public class Detectedlanguage
    {
        public string language { get; set; }
        public float score { get; set; }
    }

    public class Translation
    {
        public string text { get; set; }
        public string to { get; set; }
    }


}

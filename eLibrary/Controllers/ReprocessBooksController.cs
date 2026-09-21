using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure;
using Azure.Storage.Files.DataLake;
using CommonLib.Data;
using eLibrary.Services.Interface;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static iTextSharp.text.pdf.AcroFields;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Web;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReprocessBooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBooksService _booksService;

        public ReprocessBooksController(ApplicationDbContext context, IBooksService booksService)
        {
            _context = context;
            _booksService = booksService;
        }

        [HttpGet]
        [Route("StartBookReprocessbyID")]
        public async Task<IActionResult> StartReprocessbyID(int bookId)
        {
            var book = (from b in _context.ElTBooks
                        where b.BookId == bookId
                        select new { Book = b })
              .FirstOrDefault();

            if (book != null)
            {
                string originalUrl = book.Book.BookUrl;

                Uri uri = new Uri(originalUrl);
                string query = uri.Query;
                string value = HttpUtility.ParseQueryString(query).Get("url");

                originalUrl= value;
                // Find the position of the last '/' character
                int lastSlashIndex = originalUrl.LastIndexOf('/');

                // Extract the filename
                string filename = originalUrl.Substring(lastSlashIndex + 1);

                // Insert "ocr_" just before the filename
                string modifiedFilename = "ocr_" + filename;

                // Replace the original filename with the modified one in the URL
                string modifiedUrl = originalUrl.Substring(0, lastSlashIndex + 1) + modifiedFilename;

                DataLakeFileClient fileClient = _booksService.DownloadFile(modifiedUrl);
                var downloadResponse = fileClient.OpenRead();
                byte[] byteData = _booksService.StreamToByteArray(downloadResponse);

                bool status = await StartReProcessBook(byteData);

            }

            return Ok();
        }

        [HttpGet]
        [Route("StartReProcessBook")]
        public async Task<Boolean> StartReProcessBook(byte[] byteData)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                  ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .Build();

            MemoryStream stream = new MemoryStream(byteData);

            iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(stream);

            // Create a PDF stamper to write content to the output PDF
            MemoryStream outputStream = new MemoryStream();

            // Create a PdfStamper that writes to the 'outputStream'
            PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream);

            string YourFormRecognizerApiKey = configuration["YourFormRecognizerApiKey"];
            string YourFormRecognizerEndpoint = configuration["YourFormRecognizerEndpoint"];

            AzureKeyCredential credential = new AzureKeyCredential(YourFormRecognizerApiKey);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(YourFormRecognizerEndpoint), credential);

            MemoryStream formRecogStream = new MemoryStream(byteData);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-read", formRecogStream);
            AnalyzeResult result = operation.Value;

            if (operation.HasCompleted)
            {
                var recognizedForms = result.Pages;

            }

            stream.Close();
            return true;
        }

    }
}

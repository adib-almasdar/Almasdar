using Azure.Storage.Files.DataLake;
using eLibrary.Models;

namespace eLibrary.Services.Interface
{
    public interface IBooksService
    {
        Task<string[]> StartBookUploadProcess(IFormCollection files, BookModel bookModel);
        Task<string[]> StartBookEditProcess(IFormCollection files, BookModel bookModel);
        bool CreateItemInLinkedBooks(int bookId, string linkedBooksId);
        bool DeleteItemInLinkedBooks(int bookId, string linkedBooksId);
        BookSearchModel SearchBooks(string query, string filter, int top, int skip, bool? IsGeneralView = false);
        bool DeleteBookfromAzureBlobAndSearchIndex(string uniqueFolderName);
        DataLakeFileClient DownloadFile(string url);
        string DownloadFile2(string url);

        byte[] StreamToByteArray(Stream stream);
        //string TranslateToEnglish(string arabicText);
        bool DeleteElibContainerData();
        bool DeleteBooksFromSearchIndex();
        Task<string> StartDeletionAttachementUploadProcess(IFormCollection files);

    }
}

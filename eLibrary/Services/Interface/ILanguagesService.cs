using eLibrary.Models;

namespace eLibrary.Services.Interface
{
    public interface ILanguagesService
    {
        Task<string> StartDocumentUploadProcess(IFormCollection filesCollection, LanguageModel languageModel);
    }
}

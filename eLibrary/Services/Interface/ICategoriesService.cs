using eLibrary.Models;

namespace eLibrary.Services.Interface
{
    public interface ICategoriesService
    {
        Task<string> StartDocumentUploadProcess(IFormCollection filesCollection, CategoryModel categoryModel);

    }
}

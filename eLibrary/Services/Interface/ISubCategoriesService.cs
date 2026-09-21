using eLibrary.Models;

namespace eLibrary.Services.Interface
{
    public interface ISubCategoriesService
    {
        Task<string> StartDocumentUploadProcess(IFormCollection filesCollection, SubCategoryModel subCategoryModel);
    }
}

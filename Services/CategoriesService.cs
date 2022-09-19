using TvTidCLI.Models;

namespace TvTidCLI.Services;

public class CategoriesService
{
    private ITvTidApi api;

    public CategoriesService(ITvTidApi api)
    {
        this.api = api;
    }

    public async Task<List<TvTidCategory>> GetCategories()
    {
         var categories = await api.GetCategoriesAsync();

        return categories.Categories;
    }
}
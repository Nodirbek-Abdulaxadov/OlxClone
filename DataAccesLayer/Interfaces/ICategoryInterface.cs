using DataAccesLayer.Models;

namespace DataAccesLayer.Interfaces;

public interface ICategoryInterface 
    : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAllWithSubcategoriesAsync();

    // 56s
    Task TestTransaction();

    // 6s
    Task TestAdoNet();

    // 2s
    Task TestTSQL();

    Task<IEnumerable<Category>> GetCategoriesByAdoNetAsync();
    Task<IEnumerable<Category>> GetCategoriesByTSQLPaginationAsync(int pageSize, int pageNumber);
}
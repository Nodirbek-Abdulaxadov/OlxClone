using DataAccesLayer.Models;

namespace DataAccesLayer.Interfaces;

public interface ICategoryInterface 
    : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAllWithSubcategoriesAsync();
}
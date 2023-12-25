

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories;

public class CategoryRepository 
    : Repository<Category>, ICategoryInterface
{
    public CategoryRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllWithSubcategoriesAsync()
    {
        var list = await _dbContext.Categories
                                   .Include(c => c.SubCategories)
                                   .ToListAsync();
        return list;
    }
}

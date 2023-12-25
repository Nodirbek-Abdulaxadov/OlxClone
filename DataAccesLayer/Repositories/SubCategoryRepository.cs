

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryInterface
{
    public SubCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

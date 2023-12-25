

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class SubRegionRepository : Repository<SubRegion>, ISubRegionInterface
{
    public SubRegionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

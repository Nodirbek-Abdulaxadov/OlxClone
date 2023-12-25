

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class RegionRepository : Repository<Region>, IRegionInterface
{
    public RegionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}



using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class AdsElonRepository : Repository<AdsElon>, IAdsElonInterface
{
    public AdsElonRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

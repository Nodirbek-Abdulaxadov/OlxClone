

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class ImageRepository : Repository<Image>, IImageInterface
{
    public ImageRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    
}

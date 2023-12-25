

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class UserRepository : Repository<User>, IUserInterface
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

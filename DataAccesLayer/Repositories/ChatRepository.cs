

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class ChatRepository : Repository<Chat>, IChatInterface
{
    public ChatRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

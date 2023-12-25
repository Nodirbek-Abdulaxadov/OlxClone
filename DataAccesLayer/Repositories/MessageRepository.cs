

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;

namespace DataAccesLayer.Repositories;

public class MessageRepository : Repository<Message>, IMessageInterface
{
    public MessageRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

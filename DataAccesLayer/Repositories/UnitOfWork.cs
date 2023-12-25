

using DataAccesLayer.Datas;
using DataAccesLayer.Interfaces;

namespace DataAccesLayer.Repositories;

public class UnitOfWork(AppDbContext dbContext,
                        IAdsElonInterface adsElonInterface,
                        ICategoryInterface categoryInterface,
                        IChatInterface chatInterface,
                        IImageInterface imageInterface,
                        IMessageInterface messageInterface,
                        IRegionInterface regionInterface,
                        ISubCategoryInterface subCategoryInterface,
                        ISubRegionInterface subRegionInterface,
                        IUserInterface userInterface                    ) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public IAdsElonInterface AdsElonInterface { get; } = adsElonInterface;

    public ICategoryInterface CategoryInterface { get; } = categoryInterface;

    public IChatInterface ChatInterface { get; } = chatInterface;

    public IImageInterface ImageInterface { get; } = imageInterface;

    public IMessageInterface MessageInterface { get; } = messageInterface;

    public IRegionInterface RegionInterface { get; } = regionInterface;

    public ISubCategoryInterface SubCategoryInterface { get; } = subCategoryInterface;

    public ISubRegionInterface SubRegionInterface { get; } = subRegionInterface;

    public IUserInterface UserInterface { get; } = userInterface;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

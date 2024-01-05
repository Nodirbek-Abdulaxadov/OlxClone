

namespace DataAccesLayer.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAdsElonInterface AdsElonInterface { get; }
    ICategoryInterface CategoryInterface { get; }

    IChatInterface ChatInterface { get; }
    IImageInterface ImageInterface { get; }

    IMessageInterface MessageInterface { get; }
    IRegionInterface RegionInterface { get; }

    ISubCategoryInterface SubCategoryInterface { get; }
    ISubRegionInterface SubRegionInterface { get; }



    Task SaveAsync();
}

using DataAccesLayer.Models;

namespace BusinessLogicLayer.Extended;
public static class Validator
{
    public static bool IsValid(this Category category)
        => category != null
        && !string.IsNullOrEmpty(category.Name);

    public static bool IsExist(this Category category, 
                              IEnumerable<Category> categories)
        => categories.Any(c => c.Name == category.Name 
                               && c.Id != category.Id);

    public static bool IsValid(this SubCategory subcategory)
        => subcategory != null
            && !string.IsNullOrEmpty(subcategory.Name)
            && subcategory.CategoryId > 0;

    public static bool IsExist(this SubCategory subcategory,
                              IEnumerable<SubCategory> subcategories)
        => subcategories.Any(c => c.Name == subcategory.Name
                               && c.Id != subcategory.Id);
}
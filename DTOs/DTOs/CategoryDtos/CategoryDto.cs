using DTO.DTOs.SubCategoryDtos;

namespace DTO.DTOs.CategoryDtos;

public class CategoryDto : BaseDto
{
    public string? Name { get; set; }

    public virtual ICollection<SubCategoryDto> SubCategories { get; set; } 
        = new List<SubCategoryDto>();
}
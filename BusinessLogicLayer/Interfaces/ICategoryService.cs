using BusinessLogicLayer.Extended;
using DTO.DTOs.CategoryDtos;

namespace BusinessLogicLayer.Interfaces;
public interface ICategoryService
{
    Task<List<CategoryDto>> GetAll();
    Task<PagedList<CategoryDto>> GetAllPaged(int pageSize, 
                                             int pageNumber);
    Task<CategoryDto> GetById(int id);
    Task Add(AddCategoryDto categoryDto);
    Task Update(UpdateCategoryDto categoryDto);
    Task Delete(int id);
}
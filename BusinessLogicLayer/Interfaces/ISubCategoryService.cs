using BusinessLogicLayer.Extended;
using DTO.DTOs.SubCategoryDtos;

namespace BusinessLogicLayer.Interfaces;
public interface ISubCategoryService
{
    Task<List<SubCategoryDto>> GetAll();
    Task<PagedList<SubCategoryDto>> GetAllPaged(int pageSize, 
                                             int pageNumber);
    Task<SubCategoryDto> GetById(int id);
    Task Add(AddSubCategoryDto subcategoryDto);
    Task Update(UpdateSubCategoryDto subcategoryDto);
    Task Delete(int id);
}
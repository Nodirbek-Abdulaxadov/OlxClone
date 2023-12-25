using AutoMapper;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using DTO.DTOs.SubCategoryDtos;

namespace BusinessLogicLayer.Services;
public class SubCategoryService (IUnitOfWork unitOfWork,
                                 IMapper mapper)
    : ISubCategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Add(AddSubCategoryDto categoryDto)
    {
        if (categoryDto is null)
        {
            throw new ArgumentNullException("SubCategory null bo'p qoldi!");
        }

        var category = _mapper.Map<SubCategory>(categoryDto);
        if (!category.IsValid())
        {
            throw new CustomException("Invalid SubCategory!");
        }

        var subcategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        if (category.IsExist(subcategories))
        {
            throw new CustomException($"{category.Name} uje bor!");
        }

        var list = await _unitOfWork.CategoryInterface.GetAllAsync();
        var categoryIdIsValid = list.Any(c => c.Id == categoryDto.CategoryId);
        if (!categoryIdIsValid)
        {
            throw new CustomException("CategoryId not found");
        }

        await _unitOfWork.SubCategoryInterface.AddAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var category = await _unitOfWork.SubCategoryInterface.GetByIdAsync(id);
        if (category is null)
        {
            throw new ArgumentNullException("Bunaqa SubCategory yo'q!");
        }

        await _unitOfWork.SubCategoryInterface.DeleteAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SubCategoryDto>> GetAll()
    {
        var subcategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        return subcategories.Select(c => _mapper.Map<SubCategoryDto>(c))
                         .ToList();
    }

    public async Task<PagedList<SubCategoryDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var subcategories = await GetAll();
        PagedList<SubCategoryDto> pagedList = new(subcategories, subcategories.Count, 
                                                pageNumber, pageSize);
        return pagedList.ToPagedList(subcategories, 
                                     pageSize, 
                                     pageNumber);
    }

    public async Task<SubCategoryDto> GetById(int id)
    {
        var category = await _unitOfWork.SubCategoryInterface.GetByIdAsync(id);
        if (category is null)
        {
            throw new ArgumentNullException("SubCategory topilmadi!");
        }
        return _mapper.Map<SubCategoryDto>(category);
    }

    public async Task Update(UpdateSubCategoryDto categoryDto)
    {
        if (categoryDto is null)
        {
            throw new ArgumentNullException("SubCategory null bo'p qoldi!");
        }

        var subcategories = await _unitOfWork.SubCategoryInterface.GetAllAsync();
        var category = subcategories.FirstOrDefault(c => c.Id == categoryDto.Id);
        if (category is null)
        {
            throw new ArgumentNullException("SubCategory topilmadi!");
        }
        
        var updateSubCategory = _mapper.Map<SubCategory>(categoryDto);
        if (!updateSubCategory.IsValid())
        {
            throw new CustomException("SubCategory Invalid!");
        }

        if (updateSubCategory.IsExist(subcategories))
        {
            throw new CustomException("SubCategory uje bor");
        }

        var list = await _unitOfWork.CategoryInterface.GetAllAsync();
        var categoryIdIsValid = list.Any(c => c.Id == categoryDto.CategoryId);
        if (!categoryIdIsValid)
        {
            throw new CustomException("CategoryId not found");
        }

        await _unitOfWork.SubCategoryInterface.UpdateAsync(updateSubCategory);
        await _unitOfWork.SaveAsync();
    }
}
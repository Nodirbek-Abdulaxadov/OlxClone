using AutoMapper;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Models;
using DTO.DTOs.CategoryDtos;

namespace BusinessLogicLayer.Services;
public class CategoryService (IUnitOfWork unitOfWork,
                              IMapper mapper)
    : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task Add(AddCategoryDto categoryDto)
    {
        if (categoryDto is null)
        {
            throw new ArgumentNullException("Category null bo'p qoldi!");
        }

        var category = _mapper.Map<Category>(categoryDto);
        if (!category.IsValid())
        {
            throw new CustomException("Invalid Category!");
        }

        var categories = await _unitOfWork.CategoryInterface.GetAllAsync();
        if (category.IsExist(categories))
        {
            throw new CustomException($"{category.Name} uje bor!");
        }

        await _unitOfWork.CategoryInterface.AddAsync(category);
        await _unitOfWork.SaveAsync();

        //await _unitOfWork.CategoryInterface.TestTransaction();

        //await _unitOfWork.CategoryInterface.TestAdoNet();

        //await _unitOfWork.CategoryInterface.TestTSQL();
    }

    public async Task Delete(int id)
    {
        var category = await _unitOfWork.CategoryInterface.GetByIdAsync(id);
        if (category is null)
        {
            throw new ArgumentNullException("Bunaqa Category yo'q!");
        }

        await _unitOfWork.CategoryInterface.DeleteAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<CategoryDto>> Filter(bool ordered, Func<string, bool, bool> func)
    {
        var list = await _unitOfWork.CategoryInterface.GetAllAsync();
        list = list.Where(c => func(c.Name, ordered))
                   .ToList();




        return (List<CategoryDto>)list.Select(c => _mapper.Map<CategoryDto>(c));
    }

    public async Task<List<CategoryDto>> GetAll()
    {
        var categories = await _unitOfWork.CategoryInterface
                                          .GetAllWithSubcategoriesAsync();
        return categories.Select(c => _mapper.Map<CategoryDto>(c))
                         .ToList();
    }

    public async Task<PagedList<CategoryDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var categories = await GetAll();
        PagedList<CategoryDto> pagedList = new(categories, categories.Count, 
                                                pageNumber, pageSize);
        return pagedList.ToPagedList(categories, 
                                     pageSize, 
                                     pageNumber);
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _unitOfWork.CategoryInterface.GetByIdAsync(id);
        if (category is null)
        {
            throw new ArgumentNullException("Category topilmadi!");
        }
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetPagedWithTSQL(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.CategoryInterface.GetCategoriesByTSQLPaginationAsync(pageSize, pageNumber);
        return list.Select(c => _mapper.Map<CategoryDto>(c))
                   .ToList();
    }

    public async Task Update(UpdateCategoryDto categoryDto)
    {
        if (categoryDto is null)
        {
            throw new ArgumentNullException("Category null bo'p qoldi!");
        }

        var categories = await _unitOfWork.CategoryInterface.GetAllAsync();
        var category = categories.FirstOrDefault(c => c.Id == categoryDto.Id);
        if (category is null)
        {
            throw new ArgumentNullException("Category topilmadi!");
        }
        
        var updateCategory = _mapper.Map<Category>(categoryDto);
        if (!updateCategory.IsValid())
        {
            throw new CustomException("Category Invalid!");
        }

        if (updateCategory.IsExist(categories))
        {
            throw new CustomException("Category uje bor");
        }

        await _unitOfWork.CategoryInterface.UpdateAsync(updateCategory);
        await _unitOfWork.SaveAsync();
    }
}
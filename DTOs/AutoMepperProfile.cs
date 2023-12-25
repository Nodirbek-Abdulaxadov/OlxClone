

using AutoMapper;
using DataAccesLayer.Models;
using DTO.DTOs.AdsElonDtos;
using DTO.DTOs.CategoryDtos;
using DTO.DTOs.SubCategoryDtos;

namespace DTO;

public class AutoMepperProfile : Profile
{
    public AutoMepperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<SubCategory, SubCategoryDto>();
        CreateMap<AddSubCategoryDto, SubCategory>();
        CreateMap<UpdateSubCategoryDto, SubCategory>();
    }
}

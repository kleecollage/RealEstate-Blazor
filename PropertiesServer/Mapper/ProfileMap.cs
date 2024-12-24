using AutoMapper;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;

namespace PropertiesServer.Mapper;

public class ProfileMap: Profile
{
    public ProfileMap()
    {
        /* THE OTHER WAY
        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>(); */
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Estate, EstateDto>().ReverseMap();
        CreateMap<Category, DropDownCategoryDto>().ReverseMap();
        CreateMap<EstateImage, EstateImageDto>().ReverseMap();
    }
}
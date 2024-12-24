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
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Estate, EstateDto>().ReverseMap();
    }
}
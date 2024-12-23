using AutoMapper;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;

namespace PropertiesServer.Mapper;

public class ProfileMap: Profile
{
    public ProfileMap()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        /* THE OTHER WAY
        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();
        */
    }
}
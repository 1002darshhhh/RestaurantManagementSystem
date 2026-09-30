using Restaurant.API.Models;
using Restaurant.API.DTOs;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MenuItem,MenuItemDto>();
        CreateMap<MenuItemDto, MenuItem>();
    }
}
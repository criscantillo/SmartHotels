using AutoMapper;
using SmartHotels.DTOs;
using SmartHotels.Infrastructure.Models;

namespace SmartHotels.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<HotelDto, Hotel>().ReverseMap();
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}

using AutoMapper;
using SmartHotels.Data.Models;
using SmartHotels.DTOs;

namespace SmartHotels.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<HotelDto, Hotel>().ReverseMap();
            CreateMap<RoomDto, Room>().ReverseMap();
            CreateMap<GuestDto, Guest>().ReverseMap();
            CreateMap<ReservationDto, Reservation>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}

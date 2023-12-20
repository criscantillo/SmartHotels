using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHotels.Data.Models;
using SmartHotels.Data.SeedWork;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName(nameof(GetHotels))]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            IEnumerable<Hotel> lstHotel = await _unitOfWork.Hotels.GetAll();
            return Ok(lstHotel);
        }

        [HttpGet("{hotelId}")]
        [ActionName(nameof(GetHotel))]
        public async Task<ActionResult<Hotel>> GetHotel(int hotelId)
        {
            Hotel hotel = await _unitOfWork.Hotels.Get(hotelId);
            return Ok(hotel);
        }

        [HttpPost]
        [ActionName(nameof(CreateHotel))]
        public async Task<ActionResult<Hotel>> CreateHotel(HotelDto hotelDto)
        {
            Hotel hotel = _mapper.Map<Hotel>(hotelDto);
            await _unitOfWork.Hotels.Add(hotel);
            await _unitOfWork.Save();

            return Ok(hotel);
        }

        [HttpPut("{hotelId}")]
        [ActionName(nameof(UpdateHotel))]
        public async Task<ActionResult<Hotel>> UpdateHotel(int hotelId, HotelDto hotelDto)
        {
            Hotel hotel = _mapper.Map<Hotel>(hotelDto);
            hotel.HotelId = hotelId;

            _unitOfWork.Hotels.Update(hotel);
            await _unitOfWork.Save();

            return Ok(hotel);
        }

        [HttpPatch("active/{hotelId}")]
        [ActionName(nameof(SetActiveHotel))]
        public async Task<ActionResult<Hotel>> SetActiveHotel(int hotelId, bool active)
        {
            Hotel hotel = await _unitOfWork.Hotels.Get(hotelId);
            hotel.Active = active;

            _unitOfWork.Hotels.Update(hotel);
            await _unitOfWork.Save();

            return Ok(hotel);
        }

        [HttpGet("{hotelId}/Room")]
        [ActionName(nameof(GetRooms))]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int hotelId)
        {
            IEnumerable<Room> lstRooms =
                await _unitOfWork.Rooms.GetAllWhitFilter(h => h.HotelId == hotelId);

            return Ok(lstRooms);
        }

        [HttpGet("Room/{roomId}")]
        [ActionName(nameof(GetRoom))]
        public async Task<ActionResult<Room>> GetRoom(int roomId)
        {
            Room room = await _unitOfWork.Rooms.Get(roomId);
            return Ok(room);
        }

        [HttpPost("{hotelId}/Room")]
        [ActionName(nameof(CreateRoom))]
        public async Task<ActionResult<Room>> CreateRoom(int hotelId, RoomDto roomDto)
        {
            Room room = _mapper.Map<Room>(roomDto);
            room.HotelId = hotelId;

            await _unitOfWork.Rooms.Add(room);
            await _unitOfWork.Save();

            return Ok(room);
        }

        [HttpPut("{hotelId}/Room/{roomId}")]
        [ActionName(nameof(UpdateRoom))]
        public async Task<ActionResult<Room>> UpdateRoom(int hotelId, int roomId, HotelDto roomDto)
        {
            Room room = _mapper.Map<Room>(roomDto);
            room.HotelId = hotelId;
            room.RoomId = roomId;

            _unitOfWork.Rooms.Update(room);
            await _unitOfWork.Save();

            return Ok(room);
        }

        [HttpPatch("Room/Active/{roomId}")]
        [ActionName(nameof(SetActiveRoom))]
        public async Task<ActionResult<Room>> SetActiveRoom(int roomId, bool active)
        {
            Room room = await _unitOfWork.Rooms.Get(roomId);
            room.Active = active;

            _unitOfWork.Rooms.Update(room);
            await _unitOfWork.Save();

            return Ok(room);
        }
    }
}

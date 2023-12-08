using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHotels.Data.Models;
using SmartHotels.Data.SeedWork;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISearchRoomRepository _searchRoomRepository;
        private readonly IReservationRepository _reservationRoomRepository;

        public ReservationController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            ISearchRoomRepository searchRoomRepository,
            IReservationRepository reservationRoomRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _searchRoomRepository = searchRoomRepository;
            _reservationRoomRepository = reservationRoomRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetReservations))]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            IEnumerable<Reservation> lstReservation =
                await _unitOfWork.Reservations.GetAll();

            return Ok(lstReservation);
        }

        [HttpGet("userId")]
        [ActionName(nameof(GetReservationsByAdmin))]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByAdmin(string userId)
        {
            IEnumerable<Reservation> lstReservation =
                await _reservationRoomRepository.GetReservationFromAdmin(userId);

            return Ok(lstReservation);
        }

        [Route("Search")]
        [HttpGet]
        [ActionName(nameof(SearchRoom))]
        public async Task<ActionResult<IEnumerable<Room>>> SearchRoom(DateTime from, 
            DateTime to, int guests, string city)
        {
            FilterRoomDto filterRoomDto = new FilterRoomDto 
            {
                FromDate = from,
                ToDate = to,
                Guests = guests,
                City = city
            };

            IEnumerable<Room> lstRoomSearch =
                await _searchRoomRepository.GetRoomsFromFilter(filterRoomDto);

            return Ok(lstRoomSearch);
        }

        [HttpPost]
        [ActionName(nameof(CreateReservation))]
        public async Task<ActionResult<Reservation>> CreateReservation(ReservationDto reservationDto)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationDto);
            reservation.ReserveAt = DateTime.UtcNow;
            reservation.GuestIds = string.Join(",", reservationDto.GuestIds);

            TimeSpan difference = reservation.ToDate - reservation.FromDate;
            int numberOfNigths = difference.Days;

            Room room = await _unitOfWork.Rooms.Get(reservation.RoomId);
            reservation.TotalPrice = (numberOfNigths * room.BasePrice) + room.Taxes;

            await _unitOfWork.Reservations.Add(reservation);
            await _unitOfWork.Save();

            return Ok(reservation);
        }
    }
}

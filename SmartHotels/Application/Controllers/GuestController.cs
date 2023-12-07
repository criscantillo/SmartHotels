using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHotels.Data.Models;
using SmartHotels.Data.SeedWork;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        [ActionName(nameof(GetGuests))]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests(string userId)
        {
            IEnumerable<Guest> lstGuests = 
                await _unitOfWork.Guests.GetAllWhitFilter(g => g.UserId == userId);

            return Ok(lstGuests);
        }

        [HttpPost]
        [ActionName(nameof(CreateGuest))]
        public async Task<ActionResult<Guest>> CreateGuest(GuestDto guestDto)
        {
            Guest guest = _mapper.Map<Guest>(guestDto);
            await _unitOfWork.Guests.Add(guest);
            await _unitOfWork.Save();

            return Ok(guest);
        }
    }
}

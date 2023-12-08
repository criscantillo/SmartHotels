using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHotels.Data.Models;
using SmartHotels.Data.SeedWork;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        [ActionName(nameof(GetUser))]
        public async Task<ActionResult<UserApp>> GetUser(string userId)
        {
            IEnumerable<UserApp> users = 
                await _unitOfWork.Users.GetAllWhitFilter(u => u.UserId == userId);

            if(users is not null)
            {
                UserApp? user = users.FirstOrDefault();
                return Ok(user);
            }
            
            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(CreateUser))]
        public async Task<ActionResult<UserApp>> CreateUser(UserAppDto userDto)
        {
            UserApp user = _mapper.Map<UserApp>(userDto);
            await _unitOfWork.Users.Add(user);
            await _unitOfWork.Save();

            return Ok(user);
        }
    }
}

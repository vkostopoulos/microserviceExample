using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BOL;
using DAL.Repository;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserDto> GetByIdAsync(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<UserDto, User>(userDto);
                await _userRepository.InsertAsync(user);
                return StatusCode(StatusCodes.Status201Created, userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

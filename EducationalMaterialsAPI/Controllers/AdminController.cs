using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.UserDtos;
using EducationalMaterialsAPI.Data.Repository.Users;
using EducationalMaterialsAPI.Model.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IUsersRepo _usersRepo;
        public AdminController(ILogger<AuthController> logger, IUsersRepo usersRepo, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _usersRepo = usersRepo;
        }

        [HttpGet("users")]
        public async Task<ActionResult<UserReadDto>> GetAllUsers()
        {
            var userModels = await _usersRepo.GetAll();
            if (userModels == null)
            {
                return NotFound();
            }
            var usersReadDto = _mapper.Map<ICollection<UserReadDto>>(userModels);
            return Ok(usersReadDto);
        }

        [HttpGet("users/{id}", Name = "GetUser")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var userModel = await _usersRepo.Get(id);
            if(userModel == null)
            {
                return NotFound();
            }
            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return Ok(userReadDto);
        }

        [HttpPost("users")]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            await _usersRepo.Add(userModel);

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUser), new { id = userModel.Id }, userReadDto);
        }
    }
}

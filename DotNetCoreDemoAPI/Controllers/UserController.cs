using InfucareRx.PatientHealthApp.DTO;
using InfucareRx.PatientHealthApp.Serivces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfucareRx.PatientHealthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ResponseModel<List<UserDTO>>> GetAll()
        {
            return (await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel<UserDTO>> GetById(Guid id)
        {
            return (await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        public ResponseModel<UserDTO> Create(UserDTO model)
        {
            return (_userService.AddUser(model));
        }
    }
}

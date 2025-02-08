using server.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Interface.Repository;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<ResponseDto>> GetAll()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Data = await this.userRepository.GetAllUsers();
            return Ok(responseDto);
        }
    }
}

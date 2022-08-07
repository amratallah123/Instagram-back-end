using Microsoft.AspNetCore.Mvc;
using server.Services;
using AutoMapper;
using server.Entites;
using server.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IInstagramRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IInstagramRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<UserController>

        // GET api/<UserController>/5

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDto user)
        {
            var existUser = await _repository.GetUserAsync(user.UserName);
            if (existUser != null)
            {
                return BadRequest("user is exist");
            }
            var finalUser = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Bio = user.Bio,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
            };

            _repository.CreateUser(finalUser);
            await _repository.SaveChangesAsync();
            return Ok(finalUser);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult>  GetUser(string username)
        {
            try
            {
                var user = await _repository.GetUserAsync(username);
                if(user == null)
                {
                    return NotFound("User not found");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "OOPS! there is a problem in the server");
            }
        }

        // POST api/<UserController>
  

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{username}")]
        public async Task<ActionResult> Delete(string username)
        {
            var user = await _repository.GetUserAsync(username);
            if(user == null)
            {
                return NotFound("User not found");
            }
            await _repository.DeleteUserAsync(user);
            await _repository.SaveChangesAsync();
            return Ok("user is deleted");
        }
    }
}

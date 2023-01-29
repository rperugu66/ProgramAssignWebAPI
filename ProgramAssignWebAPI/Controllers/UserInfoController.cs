using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramAssignWebAPI.Models.DTO;
using ProgramAssignWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgramAssignWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepo _userInfoRepo;
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoRepo userInfoRepo, IMapper mapper)
        {
            _userInfoRepo = userInfoRepo;
            _mapper = mapper;
        }
        // GET: api/<UserInfoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserInfoController>/5
        [HttpGet("{VAMId}")]
        public async Task<IActionResult> Get(int VAMId)
        {
            //call the repository to get item 
            var response= await _userInfoRepo.GetUserInfoAsync(VAMId);
            if(response== null)
            {
                return NotFound();  
            }
            //convert domain class object to DTO class
            var responseDto = _mapper.Map<UserInfoDto>(response); 
            return Ok(responseDto);
        }

        // POST api/<UserInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

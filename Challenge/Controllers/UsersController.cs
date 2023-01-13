using AutoMapper;
using Challenge.DTOs;
using Challenge.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/users/{id:int}")]
    public class UsersController : ControllerBase
    {

        private readonly ChallengeContext context;
        private readonly IMapper mapper;

        public UsersController(ChallengeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                    
            if (user == null)
            {
                return NotFound();
            }

            var existsAdvisor = await context.Users.FirstOrDefaultAsync(x => x.Advisorid == id);
            var userDTO = mapper.Map<UserDTO>(user);
            
            if (existsAdvisor != null)
            {
               userDTO.NameAdvisor = userDTO.Firstname +' '+ userDTO.Surname;
            }

            return Ok(userDTO); ;
        }
    }
}

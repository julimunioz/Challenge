using AutoMapper;
using Challenge.DTOs;
using Challenge.Entities;
using Challenge.Services;
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
        private readonly UserService userService;

        public UsersController(ChallengeContext context, IMapper mapper, UserService userService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                    
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<UserDTO>(user);
            var existsAdvisor = await context.Users.FirstOrDefaultAsync(x => x.Advisorid == id);
                
            if (existsAdvisor != null)
            {
               userDTO.NameAdvisor = userDTO.Firstname +' '+ userDTO.Surname;
            }

            return Ok(userDTO); ;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<UserSummaryDTO>> GetResumen(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("User no encontrado");
            }

            UserSummaryDTO objUserResponse = new UserSummaryDTO();
            objUserResponse = await userService.UserSummary(id);
         
            return Ok(objUserResponse); 
        }
    }
}

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
        private readonly GoalService goalService;

        public UsersController(ChallengeContext context, IMapper mapper, UserService userService, GoalService goalService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
            this.goalService = goalService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
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
               userDTO.FullNameAdvisor = userDTO.Firstname +' '+ userDTO.Surname;
            }

            return Ok(userDTO); ;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<UserSummaryDTO>> GetSummary(int id)
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


        [HttpGet("goals")]
        public async Task<ActionResult<GoalsDTO>> GetGoals(int id)
        {
            var goal = await context.Goals.FirstOrDefaultAsync(x => x.Userid == id);

            if (goal == null)
            {
                return BadRequest("Error con el User");
            }
         
            PortfolioDTO objPortfolioResponse = new PortfolioDTO();
            objPortfolioResponse = await goalService.Portfolio(id);
            
            GoalsDTO objGoalsResponse = new GoalsDTO();
            objGoalsResponse = await goalService.Goals(id);

            objGoalsResponse.Portfolios = objPortfolioResponse;

            return Ok(objGoalsResponse);
        }

        [HttpGet("goals/{goalId:int}")]
        public async Task<ActionResult<GoalDetailDTO>> GetGoalsDetails(int goalId, int id)
        {
            var existsGoal = await context.Goals.AnyAsync(x => x.Id == goalId);

            if (!existsGoal)
            {
                return BadRequest("This goal doesn't exist");
            }

            var existsUser = await context.Goals.AnyAsync(x => x.Userid == id);
        
            if (!existsUser)
            {
                return BadRequest("Error with user/goal");
            }

            GoalDetailDTO goalDetailDTOResponse = new GoalDetailDTO();
            goalDetailDTOResponse = await goalService.GoalsDetails(goalId, id);

            return Ok(goalDetailDTOResponse);
        }
    }
}

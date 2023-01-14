using AutoMapper;
using Challenge.DTOs;
using Challenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Services
{
    public class GoalService
    {
        private readonly ChallengeContext context;
        private readonly IMapper mapper;

        public GoalService(ChallengeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GoalsDTO> Goals(int id)
        {
            GoalsDTO goalsDTO = new GoalsDTO();
          
            var goals = await context.Goals
                .FirstOrDefaultAsync(x => x.Userid == id);

            var financialentityId = await context.Goals
                .Where(x => x.Userid == id)
                .Select(x => x.Financialentityid).FirstOrDefaultAsync();
           
            var financialentity = await context.Financialentities
                .Where(x => x.Id == financialentityId)
                .Select(x => x.Title).FirstOrDefaultAsync();

            goalsDTO = mapper.Map<GoalsDTO>(goals);
            goalsDTO.Financialentity = financialentity;
 
            return goalsDTO;
        }

        public async Task<PortfolioDTO> Portfolio(int id)
        {
            PortfolioDTO portfolioDTO = new PortfolioDTO();
       
            var portfolioId = await context.Goals
                .Where(x => x.Userid == id)
                .Select(x => x.Portfolioid).FirstOrDefaultAsync();

            var portfolio = await context.Portfolios
                .FirstOrDefaultAsync(x => x.Id == portfolioId);
            
            portfolioDTO = mapper.Map<PortfolioDTO>(portfolio);

            return portfolioDTO;
        }
    }
}

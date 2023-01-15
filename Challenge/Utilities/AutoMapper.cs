using AutoMapper;
using Challenge.DTOs;
using Challenge.Entities;

namespace Challenge.Utilities
{
    public class AutoMapper: Profile
    {
        public AutoMapper() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<Goal, GoalsDTO>();
            CreateMap<Goal, GoalDetailDTO>();
            CreateMap<Portfolio, PortfolioDTO>();
        }
    }
}

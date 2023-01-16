using AutoMapper;
using Challenge.DTOs;
using Challenge.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Services
{
    public class UserService
    {
        private readonly ChallengeContext context;
        private readonly IMapper mapper;

        public UserService(ChallengeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    
        public async Task<UserSummaryDTO> UserSummary(int id)
        {
            UserSummaryDTO userSummaryDTO = new UserSummaryDTO();

            var goalTransactionquotas = await context.Goaltransactionfundings
                .Where(x => x.Ownerid == id).Select(x => x.Quotas).FirstOrDefaultAsync();
           
            var goalTransactionAmount = await context.Goaltransactions
                .Where(x => x.Ownerid == id).Select(x => x.Amount).ToListAsync();
            
            var fundingId = await context.Goaltransactionfundings
                .Where(x => x.Ownerid == id).Select(x => x.Fundingid).FirstOrDefaultAsync();

            var fundingvalue = await context.Fundingsharevalues
                .Where(x => x.Fundingid == fundingId).Select(x => x.Value).FirstOrDefaultAsync();

            var currencyId = await context.Users
                .Where(x => x.Id == id).Select(x => x.Currencyid).FirstOrDefaultAsync();
           
            var currencyValue = await context.Currencyindicators
                .Where(x => x.Destinationcurrencyid == currencyId).Select(x => x.Value).FirstOrDefaultAsync();

            
            var balance = goalTransactionquotas * fundingvalue * currencyValue;
            var contributions = goalTransactionAmount.Sum();

            userSummaryDTO.Balance = balance;
            userSummaryDTO.Contributions = contributions;
            
            return userSummaryDTO;
        }
    }
}


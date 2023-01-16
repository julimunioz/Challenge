namespace Challenge.DTOs
{
    public class GoalsDTO
    {
        public string? Title { get; set; }
       
        public int? Years { get; set; }
        
        public int? Initialinvestment { get; set; }
      
        public int? Monthlycontribution { get; set; }
      
        public int? Targetamount { get; set; }
      
        public DateTime? Created { get; set; }
      
        public string? Financialentity { get; set; }
      
        public PortfolioDTO Portfolios { get; set; }
    }
}

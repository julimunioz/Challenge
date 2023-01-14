using Challenge.Entities;

namespace Challenge.DTOs
{
    public class PortfolioDTO
    {
        public int Id { get; set; }

        public double? Maxrangeyear { get; set; }

        public double? Minrangeyear { get; set; }

        public string? Uuid { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? Financialentityid { get; set; }

        public int? Risklevelid { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool? Isdefault { get; set; }

        public string? Profitability { get; set; }

        public int? Investmentstrategyid { get; set; }

        public string? Version { get; set; }

        public string? Extraprofitabilitycurrencycode { get; set; }

        public double? Estimatedprofitability { get; set; }

        public double? Bpcomission { get; set; }

    }
}

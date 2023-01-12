using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Goaltransactionfunding
{
    public int Id { get; set; }

    public double? Percentage { get; set; }

    public double? Amount { get; set; }

    public double? Quotas { get; set; }

    public DateOnly? Date { get; set; }

    public int? Fundingid { get; set; }

    public DateTimeOffset[]? Created { get; set; }

    public DateTimeOffset? Modified { get; set; }

    public int? Transactionid { get; set; }

    public string? State { get; set; }

    public string? Type { get; set; }

    public int? Goalid { get; set; }

    public int? Ownerid { get; set; }

    public double? Cost { get; set; }

    public virtual Funding? Funding { get; set; }

    public virtual Goal? Goal { get; set; }

    public virtual User? Owner { get; set; }

    public virtual Goaltransaction? Transaction { get; set; }
}

using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Fundingsharevalue
{
    public int Id { get; set; }

    public double? Value { get; set; }

    public DateOnly? Date { get; set; }

    public int? Fundingid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Funding? Funding { get; set; }
}

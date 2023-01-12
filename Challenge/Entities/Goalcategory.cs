using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Goalcategory
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Uuid { get; set; }

    public string? Title { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();
}

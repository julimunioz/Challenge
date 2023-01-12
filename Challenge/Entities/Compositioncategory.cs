using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Compositioncategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Uuid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<Compositionsubcategory> Compositionsubcategories { get; } = new List<Compositionsubcategory>();
}

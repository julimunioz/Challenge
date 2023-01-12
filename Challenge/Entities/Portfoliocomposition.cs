using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Portfoliocomposition
{
    public int Id { get; set; }

    public double? Percentage { get; set; }

    public int? Subcategoryid { get; set; }

    public int? Portfolioid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Portfolio? Portfolio { get; set; }

    public virtual Compositionsubcategory? Subcategory { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Fundingcomposition
{
    public int Id { get; set; }

    public double? Percentage { get; set; }

    public int? Subcategoryid { get; set; }

    public int? Fundingid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Funding? Funding { get; set; }

    public virtual Compositionsubcategory? Subcategory { get; set; }
}

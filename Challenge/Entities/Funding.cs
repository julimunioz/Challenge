using System;
using System.Collections.Generic;

namespace Challenge.Entities;

public partial class Funding
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Uuid { get; set; }

    public int? Financialentityid { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? Mnemonic { get; set; }

    public bool? Isbox { get; set; }

    public string? Yahoomnemonic { get; set; }

    public string? Cmfurl { get; set; }

    public int? Currencyid { get; set; }

    public bool? Hassharevalue { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual Financialentity? Financialentity { get; set; }

    public virtual ICollection<Fundingcomposition> Fundingcompositions { get; } = new List<Fundingcomposition>();

    public virtual ICollection<Fundingsharevalue> Fundingsharevalues { get; } = new List<Fundingsharevalue>();

    public virtual ICollection<Goaltransactionfunding> Goaltransactionfundings { get; } = new List<Goaltransactionfunding>();

    public virtual ICollection<Goaltransaction> Goaltransactions { get; } = new List<Goaltransaction>();

    public virtual ICollection<Portfoliofunding> Portfoliofundings { get; } = new List<Portfoliofunding>();
}

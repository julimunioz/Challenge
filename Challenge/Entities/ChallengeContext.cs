using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Entities;

public partial class ChallengeContext : DbContext
{
    public ChallengeContext()
    {
    }

    public ChallengeContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Compositioncategory> Compositioncategories { get; set; }

    public virtual DbSet<Compositionsubcategory> Compositionsubcategories { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Currencyindicator> Currencyindicators { get; set; }

    public virtual DbSet<Financialentity> Financialentities { get; set; }

    public virtual DbSet<Funding> Fundings { get; set; }

    public virtual DbSet<Fundingcomposition> Fundingcompositions { get; set; }

    public virtual DbSet<Fundingsharevalue> Fundingsharevalues { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Goalcategory> Goalcategories { get; set; }

    public virtual DbSet<Goaltransaction> Goaltransactions { get; set; }

    public virtual DbSet<Goaltransactionfunding> Goaltransactionfundings { get; set; }

    public virtual DbSet<Investmentstrategy> Investmentstrategies { get; set; }

    public virtual DbSet<Investmentstrategytype> Investmentstrategytypes { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Portfoliocomposition> Portfoliocompositions { get; set; }

    public virtual DbSet<Portfoliofunding> Portfoliofundings { get; set; }

    public virtual DbSet<Risklevel> Risklevels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compositioncategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compositioncategory_pkey");

            entity.ToTable("compositioncategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<Compositionsubcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compositionsubcategory_pkey");

            entity.ToTable("compositionsubcategory");

            entity.HasIndex(e => e.Categoryid, "fki_categoryid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Uuid).HasColumnName("uuid");

            entity.HasOne(d => d.Category).WithMany(p => p.Compositionsubcategories)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("categoryid:id");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("currency_pkey");

            entity.ToTable("currency");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Currencycode).HasColumnName("currencycode");
            entity.Property(e => e.Digitsinfo).HasColumnName("digitsinfo");
            entity.Property(e => e.Display).HasColumnName("display");
            entity.Property(e => e.Locale).HasColumnName("locale");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Serverformatnumber).HasColumnName("serverformatnumber");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
            entity.Property(e => e.Yahoomnemonic).HasColumnName("yahoomnemonic");
        });

        modelBuilder.Entity<Currencyindicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("currencyindicator_pkey");

            entity.ToTable("currencyindicator");

            entity.HasIndex(e => e.Destinationcurrencyid, "fki_destinationcurrencyid:id");

            entity.HasIndex(e => e.Sourcecurrencyid, "fki_sourcecurrencyid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ask).HasColumnName("ask");
            entity.Property(e => e.Bid).HasColumnName("bid");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Destinationcurrencyid).HasColumnName("destinationcurrencyid");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Requestdate)
                .HasPrecision(6)
                .HasColumnName("requestdate");
            entity.Property(e => e.Sourcecurrencyid).HasColumnName("sourcecurrencyid");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Destinationcurrency).WithMany(p => p.CurrencyindicatorDestinationcurrencies)
                .HasForeignKey(d => d.Destinationcurrencyid)
                .HasConstraintName("destinationcurrencyid:id");

            entity.HasOne(d => d.Sourcecurrency).WithMany(p => p.CurrencyindicatorSourcecurrencies)
                .HasForeignKey(d => d.Sourcecurrencyid)
                .HasConstraintName("sourcecurrencyid:id");
        });

        modelBuilder.Entity<Financialentity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("financialentity_pkey");

            entity.ToTable("financialentity");

            entity.HasIndex(e => e.Defaultcurrencyid, "fki_defaultcurrencyid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Defaultcurrencyid).HasColumnName("defaultcurrencyid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Uuid).HasColumnName("uuid");

            entity.HasOne(d => d.Defaultcurrency).WithMany(p => p.Financialentities)
                .HasForeignKey(d => d.Defaultcurrencyid)
                .HasConstraintName("defaultcurrencyid:id");
        });

        modelBuilder.Entity<Funding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funding_pkey");

            entity.ToTable("funding");

            entity.HasIndex(e => e.Currencyid, "fki_currencyid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cmfurl).HasColumnName("cmfurl");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Hassharevalue).HasColumnName("hassharevalue");
            entity.Property(e => e.Isbox).HasColumnName("isbox");
            entity.Property(e => e.Mnemonic).HasColumnName("mnemonic");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
            entity.Property(e => e.Yahoomnemonic).HasColumnName("yahoomnemonic");

            entity.HasOne(d => d.Currency).WithMany(p => p.Fundings)
                .HasForeignKey(d => d.Currencyid)
                .HasConstraintName("currencyid:id");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Fundings)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");
        });

        modelBuilder.Entity<Fundingcomposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fundingcomposition_pkey");

            entity.ToTable("fundingcomposition");

            entity.HasIndex(e => e.Subcategoryid, "fki_subcategoryid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Fundingid).HasColumnName("fundingid");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

            entity.HasOne(d => d.Funding).WithMany(p => p.Fundingcompositions)
                .HasForeignKey(d => d.Fundingid)
                .HasConstraintName("fundingid:id");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Fundingcompositions)
                .HasForeignKey(d => d.Subcategoryid)
                .HasConstraintName("subcategoryid:id");
        });

        modelBuilder.Entity<Fundingsharevalue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fundingsharevalue_pkey");

            entity.ToTable("fundingsharevalue");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Fundingid).HasColumnName("fundingid");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Funding).WithMany(p => p.Fundingsharevalues)
                .HasForeignKey(d => d.Fundingid)
                .HasConstraintName("fundingid:id");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goal_pkey");

            entity.ToTable("goal");

            entity.HasIndex(e => e.Displaycurrencyid, "fki_displaycurrencyid:id");

            entity.HasIndex(e => e.Goalcategoryid, "fki_goalcategoryid:id");

            entity.HasIndex(e => e.Userid, "fki_userid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Displaycurrencyid).HasColumnName("displaycurrencyid");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Goalcategoryid).HasColumnName("goalcategoryid");
            entity.Property(e => e.Initialinvestment).HasColumnName("initialinvestment");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Monthlycontribution).HasColumnName("monthlycontribution");
            entity.Property(e => e.Portfolioid).HasColumnName("portfolioid");
            entity.Property(e => e.Risklevelid).HasColumnName("risklevelid");
            entity.Property(e => e.Targetamount).HasColumnName("targetamount");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Years).HasColumnName("years");

            entity.HasOne(d => d.Currency).WithMany(p => p.GoalCurrencies)
                .HasForeignKey(d => d.Currencyid)
                .HasConstraintName("currencyid:id");

            entity.HasOne(d => d.Displaycurrency).WithMany(p => p.GoalDisplaycurrencies)
                .HasForeignKey(d => d.Displaycurrencyid)
                .HasConstraintName("displaycurrencyid:id");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");

            entity.HasOne(d => d.Goalcategory).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Goalcategoryid)
                .HasConstraintName("goalcategoryid:id");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Portfolioid)
                .HasConstraintName("portfolioid:id");

            entity.HasOne(d => d.Risklevel).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Risklevelid)
                .HasConstraintName("risklevelid:id");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userid:id");
        });

        modelBuilder.Entity<Goalcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goalcategory_pkey");

            entity.ToTable("goalcategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<Goaltransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goaltransaction_pkey");

            entity.ToTable("goaltransaction");

            entity.HasIndex(e => e.Currencyid, "fki_d");

            entity.HasIndex(e => e.Financialentityid, "fki_financialentityid:id");

            entity.HasIndex(e => e.Fundingid, "fki_fundingid:id");

            entity.HasIndex(e => e.Goalid, "fki_goalid:id");

            entity.HasIndex(e => e.Ownerid, "fki_ownerid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.All).HasColumnName("all");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Fundingid).HasColumnName("fundingid");
            entity.Property(e => e.Goalid).HasColumnName("goalid");
            entity.Property(e => e.Isprocessed).HasColumnName("isprocessed");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Currency).WithMany(p => p.Goaltransactions)
                .HasForeignKey(d => d.Currencyid)
                .HasConstraintName("currencyid:id");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Goaltransactions)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");

            entity.HasOne(d => d.Funding).WithMany(p => p.Goaltransactions)
                .HasForeignKey(d => d.Fundingid)
                .HasConstraintName("fundingid:id");

            entity.HasOne(d => d.Goal).WithMany(p => p.Goaltransactions)
                .HasForeignKey(d => d.Goalid)
                .HasConstraintName("goalid:id");

            entity.HasOne(d => d.Owner).WithMany(p => p.Goaltransactions)
                .HasForeignKey(d => d.Ownerid)
                .HasConstraintName("ownerid:id");
        });

        modelBuilder.Entity<Goaltransactionfunding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goaltransactionfunding_pkey");

            entity.ToTable("goaltransactionfunding");

            entity.HasIndex(e => e.Transactionid, "fki_transactionid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Created)
                .HasColumnType("time(6) with time zone[]")
                .HasColumnName("created");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Fundingid).HasColumnName("fundingid");
            entity.Property(e => e.Goalid).HasColumnName("goalid");
            entity.Property(e => e.Modified)
                .HasColumnType("time(6) with time zone")
                .HasColumnName("modified");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Quotas).HasColumnName("quotas");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Funding).WithMany(p => p.Goaltransactionfundings)
                .HasForeignKey(d => d.Fundingid)
                .HasConstraintName("fundingid:id");

            entity.HasOne(d => d.Goal).WithMany(p => p.Goaltransactionfundings)
                .HasForeignKey(d => d.Goalid)
                .HasConstraintName("goalid:id");

            entity.HasOne(d => d.Owner).WithMany(p => p.Goaltransactionfundings)
                .HasForeignKey(d => d.Ownerid)
                .HasConstraintName("ownerid:id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Goaltransactionfundings)
                .HasForeignKey(d => d.Transactionid)
                .HasConstraintName("transactionid:id");
        });

        modelBuilder.Entity<Investmentstrategy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("investmentstrategy_pkey");

            entity.ToTable("investmentstrategy");

            entity.HasIndex(e => e.Investmentstrategytypeid, "fki_investmentstrategytypeid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Displayorder).HasColumnName("displayorder");
            entity.Property(e => e.Features).HasColumnName("features");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Iconurl).HasColumnName("iconurl");
            entity.Property(e => e.Investmentstrategytypeid).HasColumnName("investmentstrategytypeid");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.Isrecommended).HasColumnName("isrecommended");
            entity.Property(e => e.Isvisible).HasColumnName("isvisible");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Recommendedfor).HasColumnName("recommendedfor");
            entity.Property(e => e.Shorttitle).HasColumnName("shorttitle");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Investmentstrategies)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");

            entity.HasOne(d => d.Investmentstrategytype).WithMany(p => p.Investmentstrategies)
                .HasForeignKey(d => d.Investmentstrategytypeid)
                .HasConstraintName("investmentstrategytypeid:id");
        });

        modelBuilder.Entity<Investmentstrategytype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("investmentstrategytype_pkey");

            entity.ToTable("investmentstrategytype");

            entity.HasIndex(e => e.Financialentityid, "fki_i");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Displayorder).HasColumnName("displayorder");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Iconurl).HasColumnName("iconurl");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.Isvisibe).HasColumnName("isvisibe");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Recommendedfor).HasColumnName("recommendedfor");
            entity.Property(e => e.Shottitle).HasColumnName("shottitle");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Investmentstrategytypes)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portfolio_pkey");

            entity.ToTable("portfolio");

            entity.HasIndex(e => e.Investmentstrategyid, "fki_investmentstrategyid:id");

            entity.HasIndex(e => e.Risklevelid, "fki_risklevelid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Bpcomission).HasColumnName("bpcomission");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Estimatedprofitability).HasColumnName("estimatedprofitability");
            entity.Property(e => e.Extraprofitabilitycurrencycode).HasColumnName("extraprofitabilitycurrencycode");
            entity.Property(e => e.Financialentityid).HasColumnName("financialentityid");
            entity.Property(e => e.Investmentstrategyid).HasColumnName("investmentstrategyid");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.Maxrangeyear).HasColumnName("maxrangeyear");
            entity.Property(e => e.Minrangeyear).HasColumnName("minrangeyear");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Profitability)
                .HasColumnType("json")
                .HasColumnName("profitability");
            entity.Property(e => e.Risklevelid).HasColumnName("risklevelid");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
            entity.Property(e => e.Version).HasColumnName("version");

            entity.HasOne(d => d.Financialentity).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.Financialentityid)
                .HasConstraintName("financialentityid:id");

            entity.HasOne(d => d.Investmentstrategy).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.Investmentstrategyid)
                .HasConstraintName("investmentstrategyid:id");

            entity.HasOne(d => d.Risklevel).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.Risklevelid)
                .HasConstraintName("risklevelid:id");
        });

        modelBuilder.Entity<Portfoliocomposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portfoliocomposition_pkey");

            entity.ToTable("portfoliocomposition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Portfolioid).HasColumnName("portfolioid");
            entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Portfoliocompositions)
                .HasForeignKey(d => d.Portfolioid)
                .HasConstraintName("portfolioid:id");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Portfoliocompositions)
                .HasForeignKey(d => d.Subcategoryid)
                .HasConstraintName("subcategoryid:id");
        });

        modelBuilder.Entity<Portfoliofunding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portfoliofunding_pkey");

            entity.ToTable("portfoliofunding");

            entity.HasIndex(e => e.Portfolioid, "fki_portfolioid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Fundingid).HasColumnName("fundingid");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.Portfolioid).HasColumnName("portfolioid");

            entity.HasOne(d => d.Funding).WithMany(p => p.Portfoliofundings)
                .HasForeignKey(d => d.Fundingid)
                .HasConstraintName("fundingid:id");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Portfoliofundings)
                .HasForeignKey(d => d.Portfolioid)
                .HasConstraintName("portfolioid:id");
        });

        modelBuilder.Entity<Risklevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("risklevel_pkey");

            entity.ToTable("risklevel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Advisorid, "fki_advisorid:id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Advisorid).HasColumnName("advisorid");
            entity.Property(e => e.Created)
                .HasPrecision(6)
                .HasColumnName("created");
            entity.Property(e => e.Currencyid).HasColumnName("currencyid");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Modified)
                .HasPrecision(6)
                .HasColumnName("modified");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.Advisor).WithMany(p => p.InverseAdvisor)
                .HasForeignKey(d => d.Advisorid)
                .HasConstraintName("advisorid:id");

            entity.HasOne(d => d.Currency).WithMany(p => p.Users)
                .HasForeignKey(d => d.Currencyid)
                .HasConstraintName("currencyid:id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

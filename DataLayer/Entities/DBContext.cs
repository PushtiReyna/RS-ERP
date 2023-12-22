using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentMst> DepartmentMsts { get; set; }

    public virtual DbSet<DesignationMst> DesignationMsts { get; set; }

    public virtual DbSet<EmployeeTypeMst> EmployeeTypeMsts { get; set; }

    public virtual DbSet<RoleMst> RoleMsts { get; set; }

    public virtual DbSet<TokenMst> TokenMsts { get; set; }

    public virtual DbSet<UserMst> UserMsts { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=RS_ERP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentMst>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED58E9C880");

            entity.ToTable("DepartmentMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DesignationMst>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD60DE3A687638");

            entity.ToTable("DesignationMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DesignationName).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeTypeMst>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__Employee__1F1B6A94371EAF71");

            entity.ToTable("EmployeeTypeMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeType).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RoleMst>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleMst__8AFACE1AE10DC566");

            entity.ToTable("RoleMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleType).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TokenMst>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__TokenMst__658FEEEA671CFA77");

            entity.ToTable("TokenMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.TokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserMst__3214EC2734BDFDD5");

            entity.ToTable("UserMst");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AadharNo).HasMaxLength(50);
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankIfsc).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.ComapanyAddress).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentAddress).HasMaxLength(100);
            entity.Property(e => e.CurrentAddressPostalCode).HasMaxLength(10);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactName).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactNo).HasMaxLength(30);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EsiApplicable).HasColumnName("ESI_Applicable");
            entity.Property(e => e.Esiamount)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("ESIAmount");
            entity.Property(e => e.ExitDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MartialStatus).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.MonthlySalary).HasColumnType("decimal(13, 2)");
            entity.Property(e => e.NameOnTheAccount).HasMaxLength(50);
            entity.Property(e => e.OfferDate).HasColumnType("datetime");
            entity.Property(e => e.Panno)
                .HasMaxLength(50)
                .HasColumnName("PANNO");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PermanentAddress).HasMaxLength(100);
            entity.Property(e => e.PermanentAddressPostalCode).HasMaxLength(10);
            entity.Property(e => e.PfApplicable).HasColumnName("PF_Applicable");
            entity.Property(e => e.PfaccountNo)
                .HasMaxLength(50)
                .HasColumnName("PFAccountNo");
            entity.Property(e => e.Pfamount)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("PFAmount");
            entity.Property(e => e.PtApplicable).HasColumnName("PT_Applicable");
            entity.Property(e => e.Ptamount)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("PTAmount");
            entity.Property(e => e.ReportingManager).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

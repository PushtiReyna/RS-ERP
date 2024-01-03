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

    public virtual DbSet<AttendanceMst> AttendanceMsts { get; set; }

    public virtual DbSet<AttendanceTypeMst> AttendanceTypeMsts { get; set; }

    public virtual DbSet<AttritionTypeMst> AttritionTypeMsts { get; set; }

    public virtual DbSet<DepartmentMst> DepartmentMsts { get; set; }

    public virtual DbSet<DesignationMst> DesignationMsts { get; set; }

    public virtual DbSet<EmployeeMst> EmployeeMsts { get; set; }

    public virtual DbSet<EmployeeTypeMst> EmployeeTypeMsts { get; set; }

    public virtual DbSet<HolidaysMst> HolidaysMsts { get; set; }

    public virtual DbSet<LeaveMst> LeaveMsts { get; set; }

    public virtual DbSet<LeaveStatusMst> LeaveStatusMsts { get; set; }

    public virtual DbSet<ReportingManagerMst> ReportingManagerMsts { get; set; }

    public virtual DbSet<ResignMst> ResignMsts { get; set; }

    public virtual DbSet<RoleMst> RoleMsts { get; set; }

    public virtual DbSet<TokenMst> TokenMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ARCHE-ITD440\\SQLEXPRESS;Database=RS_ERP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendanceMst>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C672814E0");

            entity.ToTable("AttendanceMst");

            entity.Property(e => e.AttendanceTypeName).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DayNoOfMonth).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AttendanceTypeMst>(entity =>
        {
            entity.HasKey(e => e.AttendanceTypeId).HasName("PK__Attendan__F843372C72E9E7AB");

            entity.ToTable("AttendanceTypeMst");

            entity.Property(e => e.AttendanceTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<AttritionTypeMst>(entity =>
        {
            entity.HasKey(e => e.AttritionTypeId).HasName("PK__Attritio__696BE7ECBB7F1E79");

            entity.ToTable("AttritionTypeMst");

            entity.Property(e => e.AttritionTypeName).HasMaxLength(30);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepartmentMst>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED4F8A184D");

            entity.ToTable("DepartmentMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DesignationMst>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD60DEFC095B29");

            entity.ToTable("DesignationMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DesignationName).HasMaxLength(30);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserMst__3214EC27024423BE");

            entity.ToTable("EmployeeMst");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AadharNo).HasMaxLength(50);
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankIfsc).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.ComapanyAddress).HasMaxLength(100);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
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
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MartialStatus).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.MonthlySalary).HasColumnType("decimal(13, 2)");
            entity.Property(e => e.NameOnTheAccount).HasMaxLength(50);
            entity.Property(e => e.OfferDate).HasColumnType("datetime");
            entity.Property(e => e.Panno)
                .HasMaxLength(50)
                .HasColumnName("PANNO");
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
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeTypeMst>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__Employee__1F1B6A94D79A4BA3");

            entity.ToTable("EmployeeTypeMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeType).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HolidaysMst>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK__Holidays__2D35D57A2C0CA534");

            entity.ToTable("HolidaysMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Day).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeaveMst>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__LeaveMst__796DB95992568AC0");

            entity.ToTable("LeaveMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LeaveFrom).HasColumnType("datetime");
            entity.Property(e => e.LeaveReason).HasMaxLength(100);
            entity.Property(e => e.LeaveStatus).HasMaxLength(50);
            entity.Property(e => e.LeaveTo).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeaveStatusMst>(entity =>
        {
            entity.HasKey(e => e.LeaveStatusId).HasName("PK__LeaveSta__75EE81FA547CF1E8");

            entity.ToTable("LeaveStatusMst");

            entity.Property(e => e.LeaveStatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<ReportingManagerMst>(entity =>
        {
            entity.HasKey(e => e.ReportingManagerId).HasName("PK__Reportin__0C57AC941D90F91B");

            entity.ToTable("ReportingManagerMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ReportingManagerName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ResignMst>(entity =>
        {
            entity.HasKey(e => e.ResignId).HasName("PK__ResignMs__4696AE4F33EB93E0");

            entity.ToTable("ResignMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfResignation).HasColumnType("datetime");
            entity.Property(e => e.FinalDate).HasColumnType("datetime");
            entity.Property(e => e.FinalStatus).HasMaxLength(50);
            entity.Property(e => e.Reason).HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleMst>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleMst__8AFACE1AF2C0FB42");

            entity.ToTable("RoleMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoleType).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TokenMst>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__TokenMst__658FEEEAF03357E4");

            entity.ToTable("TokenMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.TokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

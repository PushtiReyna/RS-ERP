using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserMst
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string? Image { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string EmergencyContactName { get; set; } = null!;

    public string EmergencyContactNo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string MartialStatus { get; set; } = null!;

    public string PermanentAddress { get; set; } = null!;

    public string? PermanentAddressPostalCode { get; set; }

    public string CurrentAddress { get; set; } = null!;

    public string? CurrentAddressPostalCode { get; set; }

    public int? EmployeeTypeId { get; set; }

    public string? CompanyName { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public DateTime? OfferDate { get; set; }

    public DateTime? ExitDate { get; set; }

    public string? ComapanyAddress { get; set; }

    public int? ProbationPeriod { get; set; }

    public int? NoticePeriod { get; set; }

    public int? RoleId { get; set; }

    public int? ReportingManagerId { get; set; }

    public string? BankName { get; set; }

    public string? NameOnTheAccount { get; set; }

    public string? AccountNo { get; set; }

    public string? BankBranch { get; set; }

    public string? BankIfsc { get; set; }

    public string? PfaccountNo { get; set; }

    public string? AadharNo { get; set; }

    public string? Panno { get; set; }

    public decimal? MonthlySalary { get; set; }

    public decimal? Pfamount { get; set; }

    public decimal? Esiamount { get; set; }

    public decimal? Ptamount { get; set; }

    public bool? PfApplicable { get; set; }

    public bool? PtApplicable { get; set; }

    public bool? EsiApplicable { get; set; }

    public DateTime? JoiningDate { get; set; }

    public bool? EmployeeStatus { get; set; }

    public string? ContactNumber { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

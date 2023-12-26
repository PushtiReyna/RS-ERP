using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ResignMst
{
    public int ResignId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfResignation { get; set; }

    public int AttritionId { get; set; }

    public string? Reason { get; set; }

    public string? Region { get; set; }

    public DateTime? FinalDate { get; set; }

    public string? FinalStatus { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}

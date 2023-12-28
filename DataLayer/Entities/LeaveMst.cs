using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class LeaveMst
{
    public int LeaveId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime LeaveFrom { get; set; }

    public DateTime LeaveTo { get; set; }

    public int NumberOfDays { get; set; }

    public int RemainingLeaves { get; set; }

    public string LeaveReason { get; set; } = null!;

    public string? LeaveStatus { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class AttendanceMst
{
    public int AttendanceId { get; set; }

    public int EmployeeId { get; set; }

    public string AttendanceTypeName { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public string DayNoOfMonth { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class AttendanceTypeMst
{
    public int AttendanceTypeId { get; set; }

    public string AttendanceTypeName { get; set; } = null!;
}

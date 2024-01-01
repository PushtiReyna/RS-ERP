using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class LeaveStatusMst
{
    public int LeaveStatusId { get; set; }

    public string LeaveStatusName { get; set; } = null!;
}

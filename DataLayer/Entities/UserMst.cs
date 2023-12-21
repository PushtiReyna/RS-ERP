using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserMst
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

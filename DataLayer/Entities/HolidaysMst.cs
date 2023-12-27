using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class HolidaysMst
{
    public int HolidayId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Day { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

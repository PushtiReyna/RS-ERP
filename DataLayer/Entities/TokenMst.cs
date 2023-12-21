using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class TokenMst
{
    public int TokenId { get; set; }

    public int EmployeeId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime TokenExpiryTime { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenExpiryTime { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

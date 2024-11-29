using System;
using System.Collections.Generic;

namespace dev_hospital1.Models;

public partial class Register
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}

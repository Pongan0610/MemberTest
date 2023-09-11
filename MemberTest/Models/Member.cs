using System;
using System.Collections.Generic;

namespace MemberTest.Models;

public partial class Member
{
    public int Sn { get; set; }

    public string? Name { get; set; }

    public bool? Sex { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Phone { get; set; }

    public string? Mail { get; set; }

    public string? Address { get; set; }
}

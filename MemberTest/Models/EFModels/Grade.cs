using System;
using System.Collections.Generic;

namespace MemberTest.Models.EFModels;

public partial class Grade
{
    public int Sn { get; set; }

    public string? Classid { get; set; }

    public string? Category { get; set; }

    public string? Studentid { get; set; }

    public int? Grade1 { get; set; }
}

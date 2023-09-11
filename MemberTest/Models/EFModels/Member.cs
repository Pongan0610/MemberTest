using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MemberTest.Models.EFModels;

public partial class Member
{
    public int Sn { get; set; }

    [DisplayName("姓名")]
    public string? Name { get; set; }

    [DisplayName("性別")]
    public bool? Sex { get; set; }

    [DisplayName("生日")]
    public DateTime? Birthday { get; set; }

    [DisplayName("手機")]
    public string? Phone { get; set; }

    [DisplayName("信箱")]
    public string? Mail { get; set; }

    [DisplayName("地址")]
    public string? Address { get; set; }
}

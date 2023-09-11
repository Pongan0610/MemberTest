using MemberTest.Models.EFModels;

namespace MemberTest.Models.ViewModels.Home
{
    public class MemberViewModel : Member
    {
        public bool IsVaild { get; set; } = true;
        public string Msg { get; set; }
    }
}

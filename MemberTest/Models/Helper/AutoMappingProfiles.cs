using AutoMapper;
using MemberTest.Models.EFModels;
using MemberTest.Models.ViewModels.Home;

namespace MemberTest.Models.Helper
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Member, MemberViewModel>().ReverseMap();
        }
    }
}

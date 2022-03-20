using API.DTOs;
using API.Extensions;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest=> dest.PhotoUrl, opt=>opt.MapFrom(src=>
                src.Photos.FirstOrDefault(X=>X.IsMain).Url))
               .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<Photos, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}

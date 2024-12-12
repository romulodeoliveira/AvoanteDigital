using AutoMapper;
using AvoanteDigital.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using AvoanteDigital.Domain.ValueObjects;

namespace AvoanteDigital.Api.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
        CreateMap<CreateUserModel, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => 
                new Password(src.Password)))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (UserRole)src.UserRole));
        CreateMap<LoginUserModel, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src =>
                new Password(src.Password)));
        CreateMap<User, GetUserModel>()
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => (int)src.Role));
        CreateMap<UpdateProfileModel, User>();
        CreateMap<UserActivityModel, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (UserRole)src.UserRole));
    }
}
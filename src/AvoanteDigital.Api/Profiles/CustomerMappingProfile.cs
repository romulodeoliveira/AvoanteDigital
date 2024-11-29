using AutoMapper;
using AvoanteDigital.Api.Models.Customer;
using AvoanteDigital.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Enums;
using AvoanteDigital.Domain.ValueObjects;

namespace AvoanteDigital.Api.Profiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        // Customer
        CreateMap<Customer, CustomerModel>();
        CreateMap<CustomerModel, Customer>();
        CreateMap<CreateCustomerModel, Customer>();
        CreateMap<Customer, GetCustomerModel>();
        
        // User
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
        CreateMap<CreateUserModel, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => 
                new Password(src.Password)))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (UserRole)src.UserRole));
        CreateMap<LoginUserModel, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src =>
                new Password(src.Password)));
        CreateMap<User, GetUserModel>();
    }
}
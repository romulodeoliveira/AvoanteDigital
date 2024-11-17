using AutoMapper;
using AvoanteDigital.Domain.Api.Models.Customer;
using AvoanteDigital.Domain.Api.Models.User;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.ValueObjects;

namespace AvoanteDigital.Domain.Api.Profiles;

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
                new Password { PasswordLiteral = src.Password }));

    }
}
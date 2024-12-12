using AutoMapper;
using AvoanteDigital.Api.Models.Campaign;
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
        CreateMap<Customer, CustomerModel>();
        CreateMap<CustomerModel, Customer>();
        CreateMap<CreateCustomerModel, Customer>();
        CreateMap<Customer, GetCustomerModel>();
    }
}
using AutoMapper;
using AvoanteDigital.Domain.Api.Models.Customer;
using AvoanteDigital.Domain.Entities;

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
    }
}
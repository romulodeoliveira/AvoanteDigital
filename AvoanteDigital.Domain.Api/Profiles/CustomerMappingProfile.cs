using AutoMapper;
using AvoanteDigital.Domain.Api.Models;
using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Api.Profiles;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerModel>();
        CreateMap<CustomerModel, Customer>();
        CreateMap<CreateCustomerModel, Customer>();
    }
}
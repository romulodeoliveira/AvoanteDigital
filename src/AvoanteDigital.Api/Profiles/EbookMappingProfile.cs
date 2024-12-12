using AutoMapper;
using AvoanteDigital.Api.Models.Campaign;
using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Api.Profiles;

public class EbookMappingProfile : Profile
{
    public EbookMappingProfile()
    {
        CreateMap<CreateEbookModel, Ebook>();
    }
}
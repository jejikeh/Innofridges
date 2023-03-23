using AutoMapper;
using InnoFridges.Application.Common.Mappings;
using InnoFridges.Domain;

namespace InnoFridges.Application.Queries.ProductQueries.GetProductsList;

public class ProductIdNameDto : IMapWith<Product>
{
    public required Guid ProductId  { get; set; }
    public required string ProductName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductIdNameDto>()
            .ForMember(
                productDetailsViewModel => productDetailsViewModel.ProductId,
                member => member.MapFrom(product => product.ProductId))
            .ForMember(
                productDetailsViewModel => productDetailsViewModel.ProductName,
                member => member.MapFrom(product => product.ProductName));
    }
}
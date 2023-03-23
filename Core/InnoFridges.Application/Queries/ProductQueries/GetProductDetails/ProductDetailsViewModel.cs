using AutoMapper;
using InnoFridges.Application.Common.Mappings;
using InnoFridges.Domain;

namespace InnoFridges.Application.Queries.ProductQueries.GetProductDetails;

public class ProductDetailsViewModel : IMapWith<Product>
{
    public required string ProductName { get; set; }
    public required string Manufacturer { get; set; }
    public int Price { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDetailsViewModel>()
            .ForMember(
                productDetailsViewModel => productDetailsViewModel.Manufacturer, 
                member => member.MapFrom(product => product.Manufacturer))
            .ForMember(
                productDetailsViewModel => productDetailsViewModel.ProductName, 
                member => member.MapFrom(product => product.ProductName))
            .ForMember(
                productDetailsViewModel => productDetailsViewModel.Price, 
                member => member.MapFrom(product => product.Price));
    }
}
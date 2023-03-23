using AutoMapper;
using InnoFridges.Application.Commands.ProductCommands.CreateProduct;
using InnoFridges.Application.Commands.ProductCommands.DeleteProduct;
using InnoFridges.Application.Queries.ProductQueries.GetProductDetails;
using InnoFridges.Application.Queries.ProductQueries.GetProductsList;
using InnoFridges.Domain;
using InnoFridges.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoFridges.WebApi.Controllers;

[Authorize]
public class ProductsController : ApiController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ProductsListViewModel>> Get()
    {
        var query = new GetProductsListQuery();
        var mediator = Mediator();
        if (mediator is null)
            return BadRequest("Internal Server Error");
        
        var productListViewModel = await mediator.Send(query);
        return Ok(productListViewModel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsViewModel>> Get(Guid id)
    {
        var query = new GetProductDetailsQuery()
        {
            ProductId = id
        };
        
        var mediator = Mediator();
        if (mediator is null)
            return BadRequest("Internal Server Error");

        var productDetailsViewModel = await mediator.Send(query);
        return Ok(productDetailsViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(CreateProductCommand createProductCommand)
    {
        var mediator = Mediator();
        if (mediator is null)
            return BadRequest("Internal Server Error");

        return Ok(await mediator.Send(createProductCommand));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(DeleteProductCommand deleteProductCommand)
    {
        var mediator = Mediator();
        if (mediator is null)
            return BadRequest("Internal Server Error");

        await mediator.Send(deleteProductCommand);
        return Ok();
    }
}
using Application.Common.Dto;
using Domain;
using MediatR;

namespace Application.Requests.Manufactures.Queries.GetManufactureModels;

public record GetManufactureModelsCommands(Guid Id, int Page) : IRequest<List<ManufactureFridgeModelDto>>;
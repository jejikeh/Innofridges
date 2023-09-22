using Domain;

namespace Application.Common.Dto;

public record ManufactureFridgeModelDto(
    Guid Id,
    string Name,
    DateOnly ManufactureDate,
    Guid ManufactureId)
{
    public static ManufactureFridgeModelDto FromManufactureModel(FridgeModel manufacture)
    {
        return new ManufactureFridgeModelDto(
            manufacture.Id,
            manufacture.Name,
            manufacture.ManufactureDate,
            manufacture.ManufactureId
        );
    }
}
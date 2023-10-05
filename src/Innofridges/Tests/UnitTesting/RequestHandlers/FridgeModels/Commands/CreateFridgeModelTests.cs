using Application.Abstractions;
using Moq;

namespace UnitTesting.RequestHandlers.FridgeModels.Commands;

public class CreateFridgeModelTests
{
    private Mock<IFridgeModelsRepository> _fridgeModelsRepository;
    private Mock<IManufactureRepository> _manufactureRepository;

    public CreateFridgeModelTests()
    {
        _fridgeModelsRepository = new Mock<IFridgeModelsRepository>();
        _manufactureRepository = new Mock<IManufactureRepository>();
    }
    
    
}
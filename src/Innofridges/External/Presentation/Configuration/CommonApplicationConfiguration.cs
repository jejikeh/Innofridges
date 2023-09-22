using Application.Abstractions;

namespace Presentation.Configuration;

public class CommonApplicationConfiguration : ICommonApplicationConfiguration
{
    public int PageSize { get; } = 10;
}
using MathApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MathApi.Tests.Services;

public class MathServicesTests
{
    private readonly ServiceProvider _services;

    public MathServicesTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMathService, MathService>();

        _services = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public async void ShouldAddTwoNumbersCorrectly()
    {
        // Given
        var mathService = _services.GetRequiredService<IMathService>();
        var a = 1;
        var b = 2;

        // When
        var result = await mathService.AddAsync(a, b, CancellationToken.None);

        // Then
        Assert.Equal(3, result);
    }

    [Theory]
    [InlineData(long.MaxValue, 1)]
    [InlineData(long.MinValue, -1)]
    public async Task ThrowsOverflowExceptionWhenNotInRange(long a, long b)
    {
        // Given
        var mathService = _services.GetRequiredService<IMathService>();

        // When
        var task = async () => await mathService.AddAsync(a, b, CancellationToken.None);

        // Then
        await Assert.ThrowsAsync<OverflowException>(task);
    }
}
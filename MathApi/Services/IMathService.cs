namespace MathApi.Services
{
    public interface IMathService
    {
        Task<long> AddAsync(long a, long b);
    }
}
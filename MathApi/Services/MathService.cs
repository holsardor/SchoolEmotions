namespace MathApi.Services
{
    public class MathService : IMathService
    {
        public Task<long> AddAsync(long a, long b)
        {
            try
            {
                var result = checked(a + b);
                return Task.FromResult<long>(result);
            }
            catch (Exception)
            {
                throw new OverflowException($"The sum of {a} and {b} can't fit in long datatype.");
            }
        }
    }
}
using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Tests.Entities;

namespace DomainValidationCore.Tests.Specifications
{
    public class AsyncSpecification : IAsyncSpecification<User>
    {
        public async Task<bool> IsSatisfiedByAsync(User entity)
        {
            await Task.Delay(100);
            return entity.Active;
        }
    }
}

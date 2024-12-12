using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Interfaces.Validation;
using System.Threading.Tasks;

namespace DomainValidationCore.Validation
{
    public class AsyncRule<TEntity> : IAsyncRule<TEntity>
    {
        private readonly IAsyncSpecification<TEntity> _asyncSpecification;

        public string ErrorMessage { get; }

        public AsyncRule(IAsyncSpecification<TEntity> asyncSpecification, string errorMessage)
        {
            _asyncSpecification = asyncSpecification;
            ErrorMessage = errorMessage;
        }

        public async Task<bool> ValidateAsync(TEntity entity)
            => await _asyncSpecification.IsSatisfiedByAsync(entity);
    }
}

using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Interfaces.Validation;

namespace DomainValidationCore.Validation
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;

        public string ErrorMessage { get; }

        public Rule(ISpecification<TEntity> spec, string errorMessage)
        {
            _specification = spec;
            ErrorMessage = errorMessage;
        }

        public bool Validate(TEntity entity) => _specification.IsSatisfiedBy(entity);
    }
}

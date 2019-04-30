using DomainValidationCore.Validation;

namespace DomainValidationCore.Interfaces.Validation
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}

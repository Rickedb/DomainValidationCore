using DomainValidationCore.Validation;
using System.Threading.Tasks;

namespace DomainValidationCore.Interfaces.Validation
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
        Task<ValidationResult> ValidateAsync(TEntity entity);
    }
}

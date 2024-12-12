using System.Threading.Tasks;

namespace DomainValidationCore.Interfaces.Validation
{
    public interface IRule
    {
        string ErrorMessage { get; }
    }

    public interface IRule<in TEntity> : IRule
    {
        bool Validate(TEntity entity);
    }

    public interface IAsyncRule<in TEntity> : IRule
    {
        Task<bool> ValidateAsync(TEntity entity);
    }
}

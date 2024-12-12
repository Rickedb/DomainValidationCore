using System.Threading.Tasks;

namespace DomainValidationCore.Interfaces.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }

    public interface IAsyncSpecification<in T>
    {
        Task<bool> IsSatisfiedByAsync(T entity);
    }
}

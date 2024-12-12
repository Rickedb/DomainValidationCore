using DomainValidationCore.Tests.Entities;
using DomainValidationCore.Tests.Specifications;
using DomainValidationCore.Validation;

namespace DomainValidationCore.Tests.Validators
{
    public class UserValidator : Validator<User>
    {
        public UserValidator()
        {
            Add("Sync", new SyncSpecification());
            Add("Async", new AsyncSpecification());
        }
    }
}

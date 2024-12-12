using DomainValidationCore.Tests.Entities;
using DomainValidationCore.Tests.Specifications;
using DomainValidationCore.Tests.Validators;
using DomainValidationCore.Validation;
using System.Data;

namespace DomainValidationCore.Tests
{
    public class Tests
    {
        [Fact]
        public void TestSyncRule()
        {
            var entity = new User()
            {
                Id = 1,
                Name = "User",
                Active = true
            };
            var validator = new UserValidator();
            var validation = validator.Validate(entity);
            Assert.True(validation.IsValid);
        }

        [Fact]
        public async void TestAsyncRule()
        {
            var entity = new User()
            {
                Id = 1,
                Name = "User",
                Active = true
            };
            var validator = new UserValidator();
            var validation = await validator.ValidateAsync(entity);
            Assert.True(validation.IsValid);
        }
    }
}

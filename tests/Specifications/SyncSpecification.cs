using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainValidationCore.Tests.Specifications
{
    internal class SyncSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User entity)
        {
            return entity.Active;
        }
    }
}

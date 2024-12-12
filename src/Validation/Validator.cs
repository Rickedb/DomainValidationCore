using DomainValidationCore.Interfaces.Validation;
using System.Collections.Generic;

namespace DomainValidationCore.Validation
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _rules;

        public Validator() => _rules = new Dictionary<string, IRule<TEntity>>();

        public virtual ValidationResult Validate(TEntity entity)
        {
            var validation = new ValidationResult();
            foreach(var rule in _rules)
                if (!rule.Value.Validate(entity))
                    validation.Add(new ValidationError(rule.Key, rule.Value.ErrorMessage));

            return validation;
        }

        protected virtual void Add(string name, IRule<TEntity> rule) => _rules.Add(name, rule);

        protected IRule<TEntity> GetRule(string name) => _rules[name];

        protected virtual void Remove(string name) => _rules.Remove(name);
    }
}

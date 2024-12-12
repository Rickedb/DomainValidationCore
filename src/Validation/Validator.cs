using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Interfaces.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainValidationCore.Validation
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule> _rules;

        public Validator()
        {
            _rules = new Dictionary<string, IRule>();
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var validation = new ValidationResult();
            foreach (var kvp in _rules)
            {
                var rule = kvp.Value;
                if (rule is IRule<TEntity> syncRule)
                {
                    if (!syncRule.Validate(entity))
                    {
                        validation.Add(new ValidationError(kvp.Key, syncRule.ErrorMessage));
                    }
                }
                else if (rule is IAsyncRule<TEntity> asyncRule)
                {
                    if (!asyncRule.ValidateAsync(entity).GetAwaiter().GetResult())
                    {
                        validation.Add(new ValidationError(kvp.Key, asyncRule.ErrorMessage));
                    }
                }
            }

            return validation;
        }

        public virtual async Task<ValidationResult> ValidateAsync(TEntity entity)
        {
            var validation = new ValidationResult();
            foreach (var kvp in _rules)
            {
                var rule = kvp.Value;
                if (rule is IRule<TEntity> syncRule)
                {
                    if (!syncRule.Validate(entity))
                    {
                        validation.Add(new ValidationError(kvp.Key, syncRule.ErrorMessage));
                    }
                }
                else if (rule is IAsyncRule<TEntity> asyncRule)
                {
                    if (!await asyncRule.ValidateAsync(entity))
                    {
                        validation.Add(new ValidationError(kvp.Key, asyncRule.ErrorMessage));
                    }
                }
            }

            return validation;
        }

        protected virtual void Add(string name, IRule<TEntity> rule) => _rules.Add(name, rule);
        protected virtual void Add(string name, IAsyncRule<TEntity> rule) => _rules.Add(name, rule);

        protected virtual void Add(string name, ISpecification<TEntity> specification)
        {
            var rule = new Rule<TEntity>(specification, $"{name} rule failed!");
            Add(name, rule);
        }

        protected virtual void Add(string name, ISpecification<TEntity> specification, string errorMessage)
        {
            var rule = new Rule<TEntity>(specification, errorMessage);
            Add(name, rule);
        }

        protected virtual void Add(string name, IAsyncSpecification<TEntity> specification)
        {
            var rule = new AsyncRule<TEntity>(specification, $"{name} rule failed!");
            Add(name, rule);
        }

        protected virtual void Add(string name, IAsyncSpecification<TEntity> specification, string errorMessage)
        {
            var rule = new AsyncRule<TEntity>(specification, errorMessage);
            Add(name, rule);
        }

        protected virtual IRule<TEntity> GetRule(string name) => _rules[name] as IRule<TEntity>;
        protected virtual IAsyncRule<TEntity> GetAsyncRule(string name) => _rules[name] as IAsyncRule<TEntity>;

        protected virtual void Remove(string name) => _rules.Remove(name);
    }
}

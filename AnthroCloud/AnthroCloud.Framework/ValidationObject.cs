using System;
using System.Collections.Generic;

namespace AnthroCloud.Framework
{
    /// <summary>
    /// Provides validation objection abstraction using domain model
    /// </summary>
    public abstract class ValidationObject
    {
        // list of validation rules
        List<ValidationRule> rules = new List<ValidationRule>();

        // list of validation errors (following validation failure)
        readonly List<string> errors = new List<string>();

        /// <summary>
        /// Gets list of validations errors
        /// </summary>
        public List<string> Errors
        {
            get { return errors; }
        }

        /// <summary>
        /// Adds a validation rule to the object
        /// </summary>
        /// <param name="rule"></param>
        protected void AddRule(ValidationRule rule)
        {
            rules.Add(rule);
        }

        /// <summary>
        /// Creates a list of validation errors if applicable
        /// </summary>
        /// <returns>Returns true if validation rules are valid; otherwise, false.</returns>
        public bool IsValid()
        {
            bool valid = true;

            errors.Clear();

            foreach (var rule in rules)
            {
                if (!rule.Validate(this))
                {
                    valid = false;
                    errors.Add(rule.Error);
                }
            }
            return valid;
        }
    }
}

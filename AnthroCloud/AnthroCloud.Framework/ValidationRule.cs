using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Framework
{
    /// <summary>
    /// Maintains property name to which validation rule applies and validation error message.
    /// </summary>
    public abstract class ValidationRule
    {
        public string Property { get; set; }
        public string Error { get; set; }

        public ValidationRule(string property)
        {
            Property = property;
            Error = property + " is not valid";
        }

        public ValidationRule(string property, string error)
            : this(property)
        {
            Error = error;
        }

        /// <summary>
        /// Implements validation method in derived classes.
        /// </summary>
        /// <param name="validationObject">Object to be validated</param>
        /// <returns>True if rules rules satisfied, false if not.</returns>
        public abstract bool Validate(ValidationObject validationObject);

        /// <summary>
        /// Gets value for given validation object's property using reflection
        /// </summary>
        /// <param name="validationObject"></param>
        /// <returns></returns>
        protected object GetPropertyValue(ValidationObject validationObject)
        {
            // note: reflection is relatively slow
            return validationObject.GetType().GetProperty(Property).GetValue(validationObject, null);
        }
    }
}

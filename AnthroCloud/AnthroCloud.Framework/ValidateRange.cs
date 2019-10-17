using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Framework
{
    public class ValidateRange : ValidationRule
    {
        ValidationDataType DataType { get; set; }
        private ValidationOperator Operator { get; set; }

        object Min { get; set; }
        object Max { get; set; }

        public ValidateRange(string propertyName, object min, object max,
            ValidationOperator @operator, ValidationDataType dataType)
            : base(propertyName)
        {
            Min = min;
            Max = max;

            Operator = @operator;
            DataType = dataType;

            Error = propertyName + " must be between " + Min + " and " + Max;
        }

        public ValidateRange(string propertyName, string errorMessage, object min, object max,
            ValidationOperator @operator, ValidationDataType dataType)
            : this(propertyName, min, max, @operator, dataType)
        {
            Error = errorMessage;
        }

        /// <summary>
        /// Validates acceptable range of values for an object
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public override bool Validate(ValidationObject @object)
        {
            try
            {
                string value = GetPropertyValue(@object).ToString();

                switch (DataType)
                {
                    case ValidationDataType.Integer:

                        int imin = int.Parse(Min.ToString());
                        int imax = int.Parse(Max.ToString());
                        int ival = int.Parse(value);

                        return (ival >= imin && ival <= imax);

                    case ValidationDataType.Double:
                        double dmin = double.Parse(Min.ToString());
                        double dmax = double.Parse(Max.ToString());
                        double dval = double.Parse(value);

                        return (dval >= dmin && dval <= dmax);

                    case ValidationDataType.Decimal:
                        decimal cmin = decimal.Parse(Min.ToString());
                        decimal cmax = decimal.Parse(Max.ToString());
                        decimal cval = decimal.Parse(value);

                        return (cval >= cmin && cval <= cmax);

                    case ValidationDataType.Date:
                        DateTime tmin = DateTime.Parse(Min.ToString());
                        DateTime tmax = DateTime.Parse(Max.ToString());
                        DateTime tval = DateTime.Parse(value);

                        return (tval >= tmin && tval <= tmax);

                    case ValidationDataType.String:

                        string smin = Min.ToString();
                        string smax = Max.ToString();

                        int result1 = string.Compare(smin, value);
                        int result2 = string.Compare(value, smax);

                        return result1 >= 0 && result2 <= 0;
                }
                return false;
            }
            catch { return false; }
        }
    }

    /// <summary>
    /// Specifies  types to be used in validation rules
    /// </summary>
    public enum ValidationDataType
    {
        String,
        Integer,
        Double,
        Decimal,
        Date
    }

    /// <summary>
    /// Specifies operators that can be used in validation rules
    /// </summary>
    public enum ValidationOperator
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual
    }
}

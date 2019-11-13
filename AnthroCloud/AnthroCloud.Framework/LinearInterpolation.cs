using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Framework.Drawing
{
    /// <summary>
    /// Calculates new data points for a set of known data points to fit lines on a curve.
    /// </summary>
    public class LinearInterpolation
    {
        /// <summary>
        /// Known new x coordinate in a data point pair.
        /// </summary>
        private decimal X { get; set; }

        /// <summary>
        /// Coordinate x0 begins straight line to x1.
        /// </summary>
        private decimal X0 { get; set; }

        /// <summary>
        /// Coordinate x0 ends straight line from x1.
        /// </summary>
        private decimal X1 { get; set; }

        /// <summary>
        /// Coordinate y0 begins straight line to y1.
        /// </summary>
        private decimal Y0 { get; set; }

        /// <summary>
        /// Coordinate y0 ends straight line from y1.
        /// </summary>
        private decimal Y1 { get; set; }

        public LinearInterpolation() { }

        public LinearInterpolation(decimal newX, decimal newX0, decimal newX1, decimal newY0, decimal newY1)
        {
            X = newX;
            X0 = newX0;
            X1 = newX1;
            Y0 = newY0;
            Y1 = newY1;
        }

        /// <summary>
        /// Calculates Y for a known value of x.  Y occurs between Y0 and Y1.
        /// </summary>
        /// <returns>Return Y for a known value of x.  Y occurs between Y0 and Y1.</returns>
        public decimal CalculateY()
        {
            if ((X1 - X0) == 0)
            {
                return (Y0 + Y1) / 2;
            }
            return Y0 + (X - X0) * (Y1 - Y0) / (X1 - X0);
        }
    }
}

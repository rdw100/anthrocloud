using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Entities
{
    /// <summary>
    /// Provides ISO/IEC 5218 Information technology codes for the representation 
    /// of human sexes is an international standard that defines a representation 
    /// of human sexes through a language-neutral single-digit code. 
    /// </summary>
    /// <remarks>
    /// Naming Enumerations: DO use a singular type name for an enumeration unless 
    /// its values are bit fields.
    /// </remarks>
    public enum Sexes : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Unapplicable = 9
    }
}

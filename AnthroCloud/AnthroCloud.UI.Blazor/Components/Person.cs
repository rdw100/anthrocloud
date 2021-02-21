using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnthroCloud.UI.Blazor.Components
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int Age { get; set; }
    }
}

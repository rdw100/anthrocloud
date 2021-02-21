using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AnthroCloud.Business;
using AnthroCloud.Entities;

namespace AnthroCloud.UI.Blazor.Components
{
    public class FormViewModel
    {
        [Required]
        [DisplayName("Birth Date")]
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        [Required]
        [DisplayName("Visit Date")]
        public DateTime DateOfVisit { get; set; } = DateTime.Today;

        [Required]
        [DisplayName("Weight (kg)")]
        [Range(.9, 58, ErrorMessage = "Weight must be between .9 and 58.")]
        public double Weight { get; set; } = 9.00;

        [Required]
        [DisplayName("Length/height (cm)")]
        public double Height { get; set; } = 73.00;

        [Required, EnumDataType(typeof(Sexes))]
        public Sexes Sex { get; set; } = Sexes.Female;

        public Age Age { get; set; } //Todo: Move Age to Entities

        public string AgeString { get; set;}

        public double BMI { get; set; }

        //[Required]
        //[StringLength(10, ErrorMessage = "Name is too long.")]
        //public string Name { get; set; }
    }
}

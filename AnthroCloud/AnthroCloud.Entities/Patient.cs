using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnthroCloud.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required, EnumDataType(typeof(Sexes))]
        public Sexes Sex { get; set; } = Sexes.Female;

        [Required]
        [DisplayName("Birth Date")]
        [CheckPresentDateRange]
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-1);

        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}

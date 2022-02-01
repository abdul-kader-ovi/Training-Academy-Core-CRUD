using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Name can't exceed 20 characters.")]
        public String TrainingName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

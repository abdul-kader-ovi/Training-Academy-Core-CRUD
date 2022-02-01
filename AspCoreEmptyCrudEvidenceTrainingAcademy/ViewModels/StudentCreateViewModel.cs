using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.ViewModels
{
    public class StudentCreateViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Name can't exceed 20 characters")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage="Email formate not matched.")]
        public string Email { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        public int TrainingId { get; set; }

        public string TrainingName { get; set; }

        public IFormFile Photo { get; set; }
        public string Photopath { get; set; }
    }
}

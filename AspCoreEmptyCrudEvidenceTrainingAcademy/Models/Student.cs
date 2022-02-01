using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        public string Name { get; set; }
        [Required]        
        [Remote(action: "IsEmailInUse", controller: "Employee")]
        [Display(Name = "Office Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$")]
        public string Email { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        public string PhotoPath { get; set; }
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}

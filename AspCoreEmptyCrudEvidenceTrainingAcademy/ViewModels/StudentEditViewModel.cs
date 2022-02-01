using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.ViewModels
{
    public class StudentEditViewModel : StudentCreateViewModel
    {
        public string ExistingPhotoPath { get; set; }
    }
}

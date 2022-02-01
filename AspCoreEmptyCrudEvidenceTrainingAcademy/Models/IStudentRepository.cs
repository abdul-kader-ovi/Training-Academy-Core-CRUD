using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudent();
        Student GetStudentById(int id);
        Student SaveStudent(Student obj);
        Student UpdateStudent(Student upObj);
        Student DeleteStudent(int id);
        bool GetStudentByEmail(string email);
        IEnumerable<Training> GetAllTrainings();
        Training GetTrainingById(int id);
        Training SaveTraining(Training obj);
    }
}

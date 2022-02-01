using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Models
{
    public class StudentSQLRepository : IStudentRepository
    {
        private readonly MyAppDBContext _context;
        public StudentSQLRepository(MyAppDBContext context)
        {
            this._context = context;
        }
        public Student DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students;
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            return _context.Trainings;
        }

        public bool GetStudentByEmail(string email)
        {
            Student student = _context.Students.Where(e => e.Email == email).FirstOrDefault();
            if (student != null)
            {
                return true;
            }
            return false;
        }

        public Student GetStudentById(int id)
        {
            Student student = _context.Students.Find(id);
            return student;
        }

        public Training GetTrainingById(int id)
        {
            Training training = _context.Trainings.Find(id);
            return training;
        }



        public Student SaveStudent(Student obj)
        {
            _context.Students.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public Training SaveTraining(Training obj)
        {
            _context.Trainings.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public Student UpdateStudent(Student upObj)
        {
            var stu = _context.Students.Attach(upObj);
            stu.State = EntityState.Modified;
            _context.SaveChanges();
            return upObj;
        }
    }
}

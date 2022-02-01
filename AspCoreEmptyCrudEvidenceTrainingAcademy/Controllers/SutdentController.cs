using AspCoreEmptyCrudEvidenceTrainingAcademy.Models;
using AspCoreEmptyCrudEvidenceTrainingAcademy.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Controllers
{
    public class SutdentController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IStudentRepository _studentRepository;
        public SutdentController(IStudentRepository studentRepository, IWebHostEnvironment hostingEnvironment)
        {
            this._studentRepository = studentRepository;
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            List<Student> list = _studentRepository.GetAllStudent().ToList();
            return View(list);
        }
        public IActionResult Details(int id)
        {
            Student student = _studentRepository.GetStudentById(id);
            return View(student);
        }
        public IActionResult Create()
        {
            ViewBag.Trainings = _studentRepository.GetAllTrainings().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel obj)
        {
            string uniqueFileName = ProcessFileUpload(obj);

            Student student = new Student
            {
                Name = obj.Name,
                Email = obj.Email,
                AdmissionDate = obj.AdmissionDate,
                TrainingId = obj.TrainingId,
                PhotoPath = uniqueFileName
            };
            _studentRepository.SaveStudent(student);
            return RedirectToAction("Details", new { id = student.Id });
        }

        private string ProcessFileUpload(StudentCreateViewModel obj)
        {
            string uniqueFileName = null;
            if (obj.Photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    obj.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Edit(int id)
        {
            Student emp = _studentRepository.GetStudentById(id);
            StudentEditViewModel viewModel = GetEditStudent(emp);
            return View(viewModel);
        }

        private StudentEditViewModel GetEditStudent(Student stu)
        {
            StudentEditViewModel editEmployee = new StudentEditViewModel
            {
                Id = stu.Id,
                Name = stu.Name,
                Email = stu.Email,
                TrainingId = stu.TrainingId,
                AdmissionDate = stu.AdmissionDate,
                ExistingPhotoPath = stu.PhotoPath
            };
            return editEmployee;
        }

        [HttpPost]
        public IActionResult Edit(StudentEditViewModel obj)
        {
            Student empObj = _studentRepository.GetStudentById(obj.Id);
            if (ModelState.IsValid)
            {
                empObj.Name = obj.Name;
                empObj.Email = obj.Email;
                empObj.TrainingId = obj.TrainingId;
                if (obj.Photo != null)
                {
                    if (obj.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", obj.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                }
                empObj.PhotoPath = ProcessFileUpload(obj);
                Student stu = _studentRepository.UpdateStudent(empObj);
                return RedirectToAction("Index");
            }
            StudentEditViewModel viewModel = GetEditStudent(empObj);
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            Student emp = _studentRepository.GetStudentById(id);
            StudentEditViewModel viewModel = GetEditStudent(emp);
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Student studObj = _studentRepository.GetStudentById(id);
            if (studObj.PhotoPath != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", studObj.PhotoPath);
                System.IO.File.Delete(filePath);
                Student stu = _studentRepository.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            StudentEditViewModel viewModel = GetEditStudent(studObj);
            return View(viewModel);
        }

    }
}

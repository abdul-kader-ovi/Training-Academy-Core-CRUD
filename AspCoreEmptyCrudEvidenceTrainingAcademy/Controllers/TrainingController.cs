using AspCoreEmptyCrudEvidenceTrainingAcademy.Models;
using AspCoreEmptyCrudEvidenceTrainingAcademy.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEmptyCrudEvidenceTrainingAcademy.Controllers
{
    public class TrainingController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IStudentRepository _studentRepository;
        public TrainingController(IStudentRepository studentRepository, IWebHostEnvironment hostingEnvironment)
        {
            this._studentRepository = studentRepository;
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Training> list = _studentRepository.GetAllTrainings().ToList();
            return View(list);
        }
        public IActionResult CreateTraining(Training obj)
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateTraining(StudentCreateViewModel obj)
        {
            Training training = new Training
            {
                TrainingName = obj.TrainingName
            };
            _studentRepository.SaveTraining(training);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabW06StudentGrades.Models;
using LabW06StudentGrades.Services;
using LabW06StudentGrades.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LabW06StudentGrades.Controllers
{
   public class HomeController : Controller
   {
      private IStudentRepository _studentRepo;
        private StudentGradesDbContext _studentCourseGradeRepo;
      public HomeController(IStudentRepository studentRepo)
      {
         _studentRepo = studentRepo;
      }

      public IActionResult Index()
      {
         var model = new List<StudentListVM>();
         var students = _studentRepo.ReadAll();
         foreach(var student in students)
         {
            var modelItem = new StudentListVM {
               ENumber = student.ENumber,
               FullName = $"{student.LastName}, {student.FirstName}",
               CourseGrades = ""
            };
            var courseGradeList = new List<string>();
            foreach(var grade in student.Grades)
            {
               var courseGrade = $"{grade.Course.Code}{grade.Course.Number} {grade.LetterGrade}";
               courseGradeList.Add(courseGrade);
            }
            modelItem.CourseGrades = String.Join(",  ", courseGradeList);
            model.Add(modelItem);
         }
         return View(model);
      }
        public IActionResult LastName()
        {
            ViewData["Message"] = "Students ordered by last name";

            var query = _studentRepo.ReadAll();

            // Extension method syntax

            var model = query

            .OrderBy(sp => sp.LastName);

            return View("Filtering", model);


        }


        

        public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}

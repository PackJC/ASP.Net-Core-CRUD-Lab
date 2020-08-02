using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabW06StudentGrades.Models.Entities;
using LabW06StudentGrades.Models.ViewModels;
using LabW06StudentGrades.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabW06StudentGrades.Controllers
{
   public class StudentController : Controller
   {
      private IStudentRepository _studentRepo;
      private ICourseRepository _courseRepo;

      public StudentController(IStudentRepository studentRepo, ICourseRepository courseRepo)
      {
         _studentRepo = studentRepo;
         _courseRepo = courseRepo;
      }

      public IActionResult AddCourse(string id)
      {
         var model = new NotEnrolledVM
         {
            Student = _studentRepo.Read(id),
            Courses = new List<Course>()
         };
         var allCourses = _courseRepo.ReadAll();
         foreach(var course in allCourses)
         {
            if (!model.Student.HasCourseRecord(course))
            {
               model.Courses.Add(course);
            }
         }
         return View(model);
      }

      [HttpPost, ValidateAntiForgeryToken]
      public IActionResult EnrollInCourse(string studentId, string courseCode, string courseNumber)
      {
         var student = _studentRepo.Read(studentId);
         var course = _courseRepo.Read(courseCode, courseNumber);
         if (!student.HasCourseRecord(course))
         {
            _studentRepo.EnrollInCourse(student.ENumber, course.Code, course.Number);
         }
         return RedirectToAction("Index", "Home");
      }


    }
}